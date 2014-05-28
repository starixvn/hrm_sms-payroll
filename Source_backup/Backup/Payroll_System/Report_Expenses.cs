using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Payroll_System {
    public partial class Report_Expenses : First {
        TSQL tSQL;
        string thisMonthyStr;
        string Str_ALL = "===== All =====";
        

        public Report_Expenses() { 
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            thisMonthyStr = tSQL.LockData_openMonth();

            load_CompanyListBox();
        }

        private void load_CompanyListBox() {
            DataTable tb;
            CompanyBox.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();
            string formatStr;
            CompanyBox.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                CompanyBox.Items.Add(formatStr);
            }
            if (CompanyBox.Items.Count > 0)
                CompanyBox.SelectedIndex = 0;
            else
                CompanyBox.Text = "";
        }

        private string get_IDformBox(ComboBox Lx) {
            string reval = "";
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null) {
                if (Lx.SelectedItem.ToString() != Str_ALL)
                    reval = Lx.SelectedItem.ToString();
            }
            return reval;
        }

        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e){
            Hashtable pos_Col = new Hashtable();
            DataTable DeptGroupDT;
            DataTable PeopleDT;
            DataTable amountDT;
            DataTable ExRateDT;
            DataTable RateByMonthDT;
            int tmpIdx;

            string cid = this.get_IDformBox(CompanyBox);
            string _year = thisMonthyStr.Substring(0, 4);
            string tmpMonthyStr;
            string method="";
            string location = "";
            string upmethod = "";

            int _monthCount = Convert.ToInt16(thisMonthyStr.Substring(4,2));
            double _peopleCount;
            double _TotalAmount;
            int _bankinCount = 0;
            int posX = 0;
            int posY = 0;
            int i=0;
            int margeStart = 0;
            int margeEnd = 0;
            int methodmargeStart = 0;
            int methodmargeEnd = 0;
            int copyStart = 0;
            int copyEnd = 0;
            int lastColPos = 0;
            int _ExRateGroupCount;

            string CompanyID = "";
            string DepartmentID = "";
            string Net_Amonut;
            string currencyName="";
            string RateValue = "";

            saveFileDialog1.FileName = string.Format("{0}_Expenses.xls", thisMonthyStr);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                Excel_Expenses EEX = new Excel_Expenses();
                EEX.Rpt_ExcelApp = new Excel.ApplicationClass();
                EEX.Rpt_ReportExportFileName = saveFileDialog1.FileName;
                EEX.TemplateFileSource = base.remoteDBAbsPath() + "\\ExcelTemplate\\ExpensesReport.xls";
                if (EEX.OpenExcelAndCopy_FormTemplate()) {

                    #region =======  Create Head  ===========
                    EEX.addTitle("BVI Monthly Payroll Expenses Report " + _year);
                    //first count point - X title
                    EEX.addCompDeptTitle();
                    pos_Col.Add("CompDept", new posRange(2, 3));

                    // months title
                    posX = 4;
                    posX = EEX.addMonthsTitle(_monthCount, posX);
                    pos_Col.Add("MonthGroup", new posRange(4, posX - 1));
                    tmpIdx = posX;

                    posX = EEX.addThisMonthsTitle(posX, base.YYMM2EnglishDate(thisMonthyStr));
                    
                    //steven
                    posX = EEX.addStevenTitle(posX);
                    pos_Col.Add("NowMonthAndSteven", new posRange(tmpIdx, posX - 1));
                    tmpIdx = posX;

                    //pay method & location
                    DataTable MethodLocation = tSQL.Report_getBankinGroupByYear(thisMonthyStr);
                    _bankinCount = MethodLocation.Rows.Count;
                    margeStart = posX;
                    methodmargeStart = posX;
                    
                    for (i = 0; i < _bankinCount; i++) {
                        method = base.obj2str(MethodLocation.Rows[i]["method"]);                                                
                        posX = EEX.addBankInTitle(posX, method, base.obj2str(MethodLocation.Rows[i]["location"]));
                        if (method != upmethod) {                            
                            methodmargeEnd = posX - 1 ;
                            if (methodmargeStart != methodmargeEnd) {
                                EEX.margeColumn(4, methodmargeStart, methodmargeEnd - 1);// prv col = End
                            }
                            methodmargeStart = methodmargeEnd;
                        }
                        upmethod = method;
                    }
                    margeEnd = posX - 1;

                    //Marge Method and his title
                    EEX.margeColumn(3, margeStart, margeEnd);

                    pos_Col.Add("Binkin", new posRange(margeStart, margeEnd));
                    tmpIdx = margeEnd + 1;

                    //Total
                    EEX.addTotalTitle(posX);
                    pos_Col.Add("Total", new posRange(tmpIdx, tmpIdx));
                    #endregion =======  Create Head  ===========

                    #region =======  gen new line  ===========
                    posY = 6;
                    //company to months
                    copyStart = ((posRange)(pos_Col["CompDept"])).colStart;
                    copyEnd = ((posRange)(pos_Col["MonthGroup"])).colEnd;
                    EEX.addNewSpaceline(copyStart, copyEnd, posY, copyStart, copyEnd);
                    //gen thismonth
                    copyStart = ((posRange)(pos_Col["NowMonthAndSteven"])).colStart;
                    copyEnd = ((posRange)(pos_Col["NowMonthAndSteven"])).colEnd;
                    EEX.addNewSpaceline(26, 29, posY, copyStart, copyEnd);
                    //gen bankin 
                    copyStart = ((posRange)(pos_Col["Binkin"])).colStart;
                    copyEnd = ((posRange)(pos_Col["Binkin"])).colEnd;
                    EEX.addNewSpaceline(30, 30, posY, copyStart, copyEnd);
                    //gen total
                    copyStart = ((posRange)(pos_Col["Total"])).colStart;
                    lastColPos = ((posRange)(pos_Col["Total"])).colEnd;
                    EEX.addNewSpaceline(43, 43, posY, copyStart, lastColPos);
                    #endregion =======  gen new line  ===========

                    #region =======  gen data line  ===========
                    DeptGroupDT = tSQL.Report_GroupPeopleByDept(cid, "");

                    foreach (DataRow rs in DeptGroupDT.Rows) {
                        //Copy next line
                        EEX.copyline(posY, posY + 1, 2, lastColPos);                        
                        //add company
                        EEX.addValue_company(posY, base.obj2str(rs["CompanyID"]), base.obj2str(rs["DepartmentID"]));
                        //add month
                        CompanyID = base.obj2str(rs["CompanyID"]);
                        DepartmentID = base.obj2str(rs["DepartmentID"]);
                        for (i = 0; i < _monthCount; i++) {
                            posX = i * 2 + 4;
                            tmpMonthyStr = string.Format("{0}{1:00}", _year, i + 1);                            
                            PeopleDT = tSQL.Report_getPeopleCountByMonth(tmpMonthyStr, CompanyID, DepartmentID);
                            amountDT = tSQL.Report_get_OverPayByCompAndLocationPerEmp(tmpMonthyStr, CompanyID, DepartmentID);
                            Net_Amonut = this.getAmount(ref amountDT, "MYR_Net");

                            _peopleCount = base.obj2double(PeopleDT.Rows[0]["total"]);
                            EEX.addValue_Months(posY, posX, _peopleCount.ToString(), Net_Amonut);
                        }
                        //add bank-in 
                        _TotalAmount = 0;
                        for (i = 0; i < _bankinCount; i++) {
                            method = base.obj2str(MethodLocation.Rows[i]["Mid"]);
                            location = base.obj2str(MethodLocation.Rows[i]["Lid"]);
                            posX = margeStart + i; // X-position
                            amountDT = tSQL.Report_get_BankinMYRAmountByCpDtMeLo(thisMonthyStr, CompanyID, DepartmentID, method, location);
                            Net_Amonut = this.getAmount(ref amountDT, "MYR_Amount");
                            _TotalAmount += base.txt2double(Net_Amonut);
                            EEX.addValue(posY, posX, Net_Amonut);
                        }
                        //Total amount
                        EEX.addValue(posY, posX + 1, base.double2thousand(_TotalAmount));

                        posY++;
                    }
                    #endregion =======  gen data line  ===========

                    #region =======  gen Total line  ===========
                    EEX.copyFootTotal(posY, lastColPos);
                    //set column formula
                    EEX.setFoot_D_SumFormula(posY, 6, posY-1);
                    //copy formula
                    EEX.copyFoot_D_SumFormula(posY, 5, lastColPos);
                    #endregion =======  gen data line  ===========
                    
                    #region =======  gen Rate  ===========
                    posY = posY + 2;

                    ExRateDT = tSQL.Report_get_AllRateItemByYear(_year);
                    _ExRateGroupCount = ExRateDT.Rows.Count;
                    copyEnd = ((posRange)(pos_Col["NowMonthAndSteven"])).colStart + 1;             

                    //copy Rate Title
                    EEX.addRateTitle(posY, copyEnd);
        
                    posY = posY + 1; //Currency pos-Y                    
                    for (i = 0; i < _ExRateGroupCount; i++) { 
                        currencyName = base.obj2str(ExRateDT.Rows[i]["exchangeCurrency"]);                        
                        //Rate space line
                        EEX.addRateSpaceLine(posY + i, copyEnd);      
                        //1st col
                        EEX.addValue(posY + i, 2, currencyName + " to MYR");
                        // every month!
                        RateByMonthDT = tSQL.Report_get_oneMonthRateByMonth(_year, currencyName, thisMonthyStr);

                        for (tmpIdx = 0; tmpIdx < RateByMonthDT.Rows.Count; tmpIdx ++) {
                            tmpMonthyStr = base.obj2str(RateByMonthDT.Rows[tmpIdx]["monthly"]);
                            RateValue = base.obj2str(RateByMonthDT.Rows[tmpIdx]["showRate"]);
                            EEX.addRateValue(posY + i, tmpMonthyStr, RateValue);
                        }
                    }
                    #endregion =======  gen data line  ===========
           
                    EEX.DeltmpSheetAndSaveAndClose();
                    //Application.Exit();
                    MessageBox.Show("Completed.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.None);

                    DosCommand.Open(saveFileDialog1.FileName);
                } else {
                    EEX.close();
                    MessageBox.Show(EEX.messageString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }   
            }

        }

        private string getAmount(ref DataTable dt, string amountName) {
            double _amount = 0;
            double _tmp;
            foreach (DataRow rs in dt.Rows) {
                _tmp = base.obj2double(base.payKeyDecrypt(base.obj2str(rs[amountName])));
                _amount += _tmp;             
            }
            _amount = Math.Abs(_amount);
            _amount = Math.Round(_amount, 0, MidpointRounding.AwayFromZero);
            return Convert.ToString(_amount);
        }
                

    }
}