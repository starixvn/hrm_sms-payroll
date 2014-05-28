using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Payroll_System {
    public partial class Report_List : First {

        TSQL tSQL;
        DataTable CurrencyDT;        
        int HeadBankCountMax;
        int HeadCount = -1;
        string thisMonthyStr;
        string Str_ALL = "======= All =======";
        Dictionary<string, Dictionary<string, string>> gName = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, string> hColumn;

        int EmpColCount = 0;
        int SalaryColCount = 0;
        int ReceivedColCount = 0;
        int BankColCount = 0;

        #region =====================  Form Load ======================
        public string addHeadCount(){
            HeadCount++;
            return HeadCount.ToString();
        }
        public Report_List() {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Report_List_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            thisMonthyStr = tSQL.LockData_openMonth();
            CurrencyDT = tSQL.Report_CurrencyData_SelectAll(thisMonthyStr);            
            HeadBankCountMax = tSQL.KeyData_getBankInCountMax(thisMonthyStr);

            load_CompanyListBox();
            load_DeptListBox(CompanyBox, DeptBox);

            initHeadEmp();
            initHeadSalary();
            initHeadReceiveCury();
            initVarianceRM();
            initHeadBank();
            initHeadRemark();

            CreateHead();

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
        private void load_DeptListBox(ComboBox Comp, ComboBox Dept) {
            DataTable tb;
            Dept.Items.Clear();
            tb = tSQL.DeptData_SelectAll(this.get_IDformBox(Comp));
            string formatStr;
            Dept.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                Dept.Items.Add(formatStr);
            }
            if (Dept.Items.Count > 0)
                Dept.SelectedIndex = 0;
            else
                Dept.Text = "";
        }
        private string get_IDformBox(ComboBox Lx) {
            string reval = "";
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null) {
                if (Lx.SelectedItem.ToString() != Str_ALL)
                    reval = Lx.SelectedItem.ToString();
            }
            return reval;
        }
        #endregion =====================  Form Load ======================

        //gen Dic Item
        private void genDicItem(string _Group, string _hHeaderText, string _hWidth, string _hSqlColumn, string _hIsCurrency) {            
            hColumn = new Dictionary<string, string>();
            hColumn.Add("HeaderText", _hHeaderText);
            hColumn.Add("SqlColumn", _hSqlColumn);
            hColumn.Add("Width", _hWidth);
            hColumn.Add("ISCurrency", _hIsCurrency);
            
            gName.Add(_Group, hColumn);
        }

        //head
        private void initHeadEmp() {
            genDicItem(addHeadCount(), "No", "40", "", "N");
            genDicItem(addHeadCount(), "Company", "70", "CompanyID", "N");
            genDicItem(addHeadCount(), "Department", "60", "DepartmentID", "N");
            genDicItem(addHeadCount(), "Name", "70", "eName", "N");
            genDicItem(addHeadCount(), "Nick", "70", "CallName", "N");
            genDicItem(addHeadCount(), "Doc", "70", "DateJoined", "N");

            EmpColCount = 6;
        }
        private void initHeadSalary() {
            genDicItem(addHeadCount(), "Salary Currency", "40", "Pcurrency", "N");
            genDicItem(addHeadCount(), "Probation Salary", "60", "Prob_Salary", "Y");
            genDicItem(addHeadCount(), "Increment Salary", "60", "Incre_Amount", "Y");
            genDicItem(addHeadCount(), "Additional Salary", "60", "Add_Amount", "Y");
            genDicItem(addHeadCount(), "Total Gross Salary", "60", "Gross_Total", "Y");
            genDicItem(addHeadCount(), "Unpaid Currency", "40", "Unpaidcury", "N");
            genDicItem(addHeadCount(), "Unpaid Leave", "60", "Unpaid_Amount", "Y");
            genDicItem(addHeadCount(), "Adv Currency", "40", "Advcury", "N");
            genDicItem(addHeadCount(), "Salary Adv", "60", "Adv_Amount", "Y");
            genDicItem(addHeadCount(), "Others Currency", "40", "Loancury", "N");
            genDicItem(addHeadCount(), "Others", "60", "Loan_Amount", "Y");
            genDicItem(addHeadCount(), "Total Net Salary", "60", "Net_Salary", "Y");            

            SalaryColCount = 12;
            
        }
        private void initHeadReceiveCury() {
            int i;
            for (i = 0; i < CurrencyDT.Rows.Count; i++) {
                genDicItem(addHeadCount(), "Rec-" + CurrencyDT.Rows[i]["Pcurrency"].ToString(), "60", CurrencyDT.Rows[i]["Pcurrency"].ToString(), "Y"); //notice [Query] Received!
            }

            ReceivedColCount = i+1;
        }
        private void initVarianceRM() {
            // add Variacne column
            genDicItem(addHeadCount(), "C/Rate Variance RM", "60", "Show_VarianceRM", "Y");
        }
        private void initHeadBank() {
            int i;
            for (i = 0; i < HeadBankCountMax; i++) {
                genDicItem(addHeadCount(), "A/c Holder", "60", "AcHolder", "N");
                genDicItem(addHeadCount(), "Bank", "40", "Bank", "N");
                genDicItem(addHeadCount(), "A/c Number", "60", "AcNumber", "N");
                genDicItem(addHeadCount(), "Amount", "60", "Amount", "Y");
                genDicItem(addHeadCount(), "Payout Location", "80", "payoutRelation", "N");
            }            
            BankColCount = i + 1; 
        }
        private void initHeadRemark() {
            genDicItem(addHeadCount(), "Remark", "60", "Remark", "N");
        }
        private void CreateHead() {
            int i;
            string idx;
            bankGrid.Columns.Clear();
            DataGridViewTextBoxColumn dvc;

            for (i = 0; i <= HeadCount; i++) {
                idx = i.ToString();
                dvc = new DataGridViewTextBoxColumn();
                dvc.Name = string.Format("cc{0}", gName[idx]["HeaderText"]);
                dvc.Width = Convert.ToInt16( gName[idx]["Width"] );
                dvc.HeaderText = string.Format("{0}", gName[idx]["HeaderText"]);
                bankGrid.Columns.Add(dvc);
            }
            
        }

        //Query
        private void button3_Click(object sender, EventArgs e) {
            int row;
            int col = 0;
            int idx;
            int r;
            string GrpID;
            string fieldName;
            string IsCurrency;
            int headColCount = bankGrid.Columns.Count;
            string _CompanyBox = get_IDformBox(CompanyBox);
            string _DeptBox = get_IDformBox(DeptBox);
            if (_CompanyBox == Str_ALL) _CompanyBox = "";
            if (_DeptBox == Str_ALL) _DeptBox = "";

            bankGrid.Rows.Clear();

            DataTable empDT = tSQL.Report_getEmpList(thisMonthyStr, _CompanyBox, _DeptBox,"");
            DataTable recDT;
            DataTable bankDT;

            bankGrid.RowCount = empDT.Rows.Count;
            for (row = 0; row < empDT.Rows.Count; row++) {
                col = 0;
                GrpID = empDT.Rows[row]["GrpID"].ToString();
                //Employee
                bankGrid.Rows[row].Cells[col].Value = Convert.ToString(row + 1);
                col++;
                for (idx = 1; idx < EmpColCount; idx++) { // 0 : number
                    fieldName = gName[col.ToString()]["SqlColumn"];
                    bankGrid.Rows[row].Cells[col].Value = empDT.Rows[row][fieldName].ToString();
                    col++;
                }         
       
                //Salary
                for (idx = 0; idx < SalaryColCount; idx++) {
                    fieldName = gName[col.ToString()]["SqlColumn"];
                    bankGrid.Rows[row].Cells[col].Value = ((empDT.Rows[row][fieldName] == null) ? "" : empDT.Rows[row][fieldName].ToString());
                    col++;
                }

                //Received
                recDT = tSQL.Report_getEmpReceivedList(thisMonthyStr, GrpID);
                for (r = 0; r < recDT.Rows.Count; r++) {
                    fieldName = "ccRec-" + recDT.Rows[r]["Pcurrency"].ToString();
                    if (bankGrid.Columns.Contains(fieldName)) {
                        bankGrid.Rows[row].Cells[fieldName].Value = ((recDT.Rows[r]["Amount"] == null) ? "" : recDT.Rows[r]["Amount"].ToString());
                    }                   
                }
                col += ReceivedColCount - 1;

                //Variance
                for (idx = 0; idx < 1; idx++) {
                    fieldName = gName[col.ToString()]["SqlColumn"];
                    bankGrid.Rows[row].Cells[col].Value = ((empDT.Rows[row][fieldName] == null) ? "" : empDT.Rows[row][fieldName].ToString());
                    col++;
                }
                
                //Bank
                string payout;
                int pos;
                bankDT = tSQL.Report_getEmpBankList(thisMonthyStr, GrpID);
                for (r = 0; r < bankDT.Rows.Count; r++) {
                    for (idx = 0; idx < bankDT.Columns.Count; idx++) {
                        fieldName = gName[col.ToString()]["SqlColumn"];
                        payout = ((bankDT.Rows[r][fieldName] == null) ? "" : bankDT.Rows[r][fieldName].ToString());
                        if (fieldName == "payoutRelation") {
                            if (payout != "") {
                                pos = payout.LastIndexOf("(");
                                if (pos != -1) {
                                    payout = payout.Substring(0, pos - 1);                                  
                                }
                            }
                        }
                        bankGrid.Rows[row].Cells[col].Value = payout;
                        col++;
                    }
                }
                                
                //remark
                col = headColCount - 1;
                bankGrid.Rows[row].Cells[col].Value = empDT.Rows[row]["Remark"].ToString();

                //Currency Format
                for (idx = 1; idx < headColCount; idx++) {
                    IsCurrency = gName[idx.ToString()]["ISCurrency"];
                    if (IsCurrency == "Y") {
                        bankGrid.Rows[row].Cells[idx].Value = base.obj2thousand(base.payKeyDecrypt(base.obj2str(bankGrid.Rows[row].Cells[idx].Value)));
                    }
                }
                
            }
        }
        
        //export
        private void button1_Click(object sender, EventArgs e) {
            saveFileDialog1.FileName = "Target.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                Employee_Excel EEX = new Employee_Excel();
                EEX.Rpt_ExcelApp = new Excel.ApplicationClass();
                EEX.Rpt_ReportExportFileName = saveFileDialog1.FileName;
                EEX.outPayrollList(bankGrid);
                EEX.SaveAndClose();                                
                MessageBox.Show("Export.", "Export Payroll List", MessageBoxButtons.OK);
            }
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_DeptListBox(CompanyBox, DeptBox);
        }

    }
}