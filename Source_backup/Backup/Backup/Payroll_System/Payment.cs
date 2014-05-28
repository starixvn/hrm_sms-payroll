using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Payroll_System {    
    public partial class Payment : First {

        int X = 194;
        int Y = 2;
        float currentSize;
        TSQL tSQL;
        string Str_ALL = "======= All =======";
        string LockMonth;
        string GrpID = "";
        string MiddleName;
        string FamilyName;
        string FirstName;
        string JobTitle;
        string JoinDate;
        string Write;
        string Company;
        string Department;

        string LASalary;
        string Incre_Amount;
        string Add_Amount;
        string Pcurrency;
        
        Hashtable CuryRate;
        Hashtable RunCuryRate; // this employee's Rate
        DataTable PayoutRelationDT;

        public Payment() {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());
            CuryRate = new Hashtable();
            RunCuryRate = new Hashtable();

            currentSize = button1.Font.Size;
            Step1.Left = Step2.Left = X;
            Step1.Top = Step2.Top = Y;
            setBankGridStyle();            
            load_CompanyListBox();
            load_DeptListBox(CompanyBox, DeptBox);
            load_CurrencyListBox();            
            
            LockMonth = tSQL.LockData_openMonth();
            SelectMonth2.Text = LockMonth;
            SelectMonth3.Text = LockMonth;
            changPage("1");
            load_EmployeeData2EmpListView();
            load_RateHead();

            PayoutRelationDT = tSQL.PayRelationData_ShowTree();

            load_txtIncreRemark();
        }

        private void load_txtIncreRemark() {
            txtIncreRemark.Items.Add("");
            txtIncreRemark.Items.Add("Confirmation");
            txtIncreRemark.Items.Add("Annual");
            txtIncreRemark.Items.Add("Promotion");
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
            if (CompanyBox.Items.Count > 0) CompanyBox.SelectedIndex = 0;
        }
        private void load_DeptListBox(ComboBox Comp, ComboBox Dept) {
            DataTable tb;
            Dept.Items.Clear();
            tb = tSQL.DeptData_SelectAll(this.get_IDformBox(Comp));
            string formatStr;
            if (Dept.Name == "DeptBox") {
                Dept.Items.Add(Str_ALL);
            }
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
        private void load_CurrencyListBox() {
            DataTable tb;
            Salary_DUM.Items.Clear();
            Salary_DAM.Items.Clear();
            Salary_DLM.Items.Clear();
            txtCurry.Items.Clear();

            tb = tSQL.CurrencyData_SelectAll();
            string formatStr;
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row["Pcurrency"].ToString());
                Salary_DUM.Items.Add(formatStr);
                Salary_DAM.Items.Add(formatStr);
                Salary_DLM.Items.Add(formatStr);
                txtCurry.Items.Add(formatStr);
            }
            if (Salary_DUM.Items.Count > 0) {
                Salary_DUM.Text = "MYR";
                Salary_DAM.Text = "MYR";
                Salary_DLM.Text = "MYR";
                txtCurry.Text = "MYR";
            }
        }

        private void setBankGridStyle() {
            int i;
            for (i = 0; i <= 4; i++) {
                bankGrid.Columns[i].DefaultCellStyle.BackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionBackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionForeColor = Control.DefaultForeColor;
            }
            bankGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void changPage(string page) {
            switch (page) { 
                case "1":
                    button1.ForeColor = Color.Blue;
                    button2.ForeColor = Color.Gray;

                    button1.Font = new Font(button1.Font.Name, currentSize, System.Drawing.FontStyle.Bold);
                    button2.Font = new Font(button1.Font.Name, currentSize - 2, System.Drawing.FontStyle.Regular);

                    Step1.Visible = true;
                    Step2.Visible = false;

                    MarkY.Top = button1.Location.Y - 5;

                    break;
                case "2":
                    if (GrpID == "") {
                        set_txt_clean();
                        MessageBox.Show("Please select a record to write.", "Keyin", MessageBoxButtons.OK);
                        break;
                    }
                    button1.ForeColor = Color.Gray;
                    button2.ForeColor = Color.Blue;

                    button1.Font = new Font(button1.Font.Name, currentSize - 2, System.Drawing.FontStyle.Regular);
                    button2.Font = new Font(button1.Font.Name, currentSize, System.Drawing.FontStyle.Bold);

                    Step1.Visible = false;
                    Step2.Visible = true;
                    
                    load_EmpBasicInfo();
                    calculation();

                    MarkY.Top = button2.Location.Y - 5;                    

                    break;
           }
            MarkY.SendToBack();
        }

        private void buttonMenu_Click(object sender, EventArgs e) {
            changPage(((Button)sender).Tag.ToString());            
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e) {
            GrpID = "";
            load_DeptListBox(CompanyBox, DeptBox);
            load_EmployeeData2EmpListView();
        }

        private void load_EmployeeData2EmpListView() {
            DataTable tb;
            EmpListView.Items.Clear();            

            tb = tSQL.KeyData_getEmpList(LockMonth, this.get_IDformBox(CompanyBox), this.get_IDformBox(DeptBox));
            string _monthly;
            foreach (DataRow row in tb.Rows) {
                ListViewItem exList = new ListViewItem();

                _monthly = base.obj2str(row["monthly"]);
                 
                if(_monthly != "") exList.ImageIndex = 23;
                exList.SubItems.Add(base.obj2str(row["CompanyID"]));
                exList.SubItems.Add(base.obj2str(row["DepartmentID"]));
                exList.SubItems.Add(base.obj2str(row["GrpID"]));
                exList.SubItems.Add(base.obj2str(row["FirstName"]));
                exList.SubItems.Add(base.obj2str(row["MiddleName"]));
                exList.SubItems.Add(base.obj2str(row["FamilyName"]));
                exList.SubItems.Add(base.obj2str(row["Sex"]));
                exList.SubItems.Add(base.obj2str(row["PositionName"]));
                exList.SubItems.Add(base.obj2str(row["DateJoined"]));

                exList.SubItems.Add(base.obj2str(row["Pcurrency"]));
                exList.SubItems.Add(base.empKeyDecrypt(base.obj2str(row["LASalary"])));
                exList.SubItems.Add(base.empKeyDecrypt(base.obj2str(row["Add_Amount"]))); 
                exList.SubItems.Add(base.empKeyDecrypt(base.obj2str(row["Incre_Amount"]))); 

                EmpListView.Items.Add(exList);
            }
        }

        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_EmployeeData2EmpListView();
        }

        private void set_txt_clean() {
            GrpID = "";
            MiddleName = "";
            FamilyName = "";
            FirstName = "";
            JobTitle = "";
            JoinDate = "";
            Write = "";
            Company = "";
            Department = "";

            Pcurrency = "";
            LASalary = "";
            Add_Amount = "";
            Incre_Amount = "";
        }

        private void EmpListView_Click(object sender, EventArgs e) {
            if (EmpListView.SelectedItems[0].ImageIndex == 23) {
                Write = "Y";
            }else{
                Write = "N";
            }

            GrpID = EmpListView.SelectedItems[0].SubItems[3].Text.Trim();
            MiddleName = EmpListView.SelectedItems[0].SubItems[5].Text.Trim();
            FamilyName = EmpListView.SelectedItems[0].SubItems[6].Text.Trim();
            FirstName = EmpListView.SelectedItems[0].SubItems[4].Text.Trim();
            JobTitle = EmpListView.SelectedItems[0].SubItems[8].Text.Trim();
            JoinDate = EmpListView.SelectedItems[0].SubItems[9].Text.Trim();
            Company = EmpListView.SelectedItems[0].SubItems[1].Text.Trim();
            Department = EmpListView.SelectedItems[0].SubItems[2].Text.Trim();

            Pcurrency = EmpListView.SelectedItems[0].SubItems[10].Text.Trim();
            LASalary = EmpListView.SelectedItems[0].SubItems[11].Text.Trim();
            Add_Amount = EmpListView.SelectedItems[0].SubItems[12].Text.Trim();
            Incre_Amount = EmpListView.SelectedItems[0].SubItems[13].Text.Trim();
        }

        private void load_RateHead() {
            int i = 0;
            string cury;
            RecGrid.Rows.Clear();
            RecGrid.Columns.Clear();
            ReceivedGrid.Rows.Clear();
            ReceivedGrid.Columns.Clear();

            DataTable CurrencyDT = tSQL.CurrencyData_SelectAll();
            DataGridViewTextBoxColumn dvc;
            DataGridViewTextBoxColumn dvc2;
            foreach (DataRow row in CurrencyDT.Rows) {
                dvc = new DataGridViewTextBoxColumn();
                dvc.Name = string.Format("{0}", base.obj2str(row["Pcurrency"]));
                dvc.Width = 55;
                dvc.DataPropertyName = string.Format("{0}", base.obj2str(row["Pcurrency"]));
                dvc.HeaderText = base.obj2str(row["Pcurrency"]);
                dvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                RecGrid.Columns.Add(dvc);
                RecGrid.Columns[i].Tag = row["strFormat"].ToString(); //save strFormat
                i++;
            }

            //tip column
            dvc2 = new DataGridViewTextBoxColumn();
            dvc2.Name = "descColumn";
            dvc2.Width = 70;           
            dvc2.HeaderText = "";
            dvc2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dvc2.Frozen = true;
            ReceivedGrid.Columns.Add(dvc2);

            CurrencyDT = tSQL.CurrencyData_SelectAll();
            foreach (DataRow row in CurrencyDT.Rows) {
                dvc2 = new DataGridViewTextBoxColumn();
                dvc2.Name = string.Format("{0}", row["Pcurrency"].ToString());
                dvc2.Width = 55;
                dvc2.DataPropertyName = string.Format("{0}", row["Pcurrency"].ToString());
                dvc2.HeaderText = row["Pcurrency"].ToString();
                dvc2.SortMode = DataGridViewColumnSortMode.NotSortable;
                ReceivedGrid.Columns.Add(dvc2);
            }

            RecGrid.RowCount = 1;
            ReceivedGrid.RowCount = 2;          

            // load ExRate
            DataTable dt = tSQL.ExRateData_getAllbyDate(LockMonth);
            CuryRate.Clear();
            CuryRate.Add("MYR", "1");
            RecGrid.Rows[0].Cells["MYR"].Value = "1";
            for (i = 0; i < dt.Rows.Count; i++) {
                cury = dt.Rows[i]["exchangeCurrency"].ToString();
                if (RecGrid.Columns.Contains(cury)) {
                    RecGrid.Rows[0].Cells[cury].Value = dt.Rows[i]["showRate"].ToString();
                    CuryRate.Add(cury, dt.Rows[i]["showRate"].ToString());
                }
            }            
        }

        private void markGridCell(ref DataGridView DG, int rows, int cells, bool read_only, string txt) {
            DG.Rows[rows].Cells[cells].Value = txt;
            DG.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            DG.Rows[rows].Cells[cells].Style.SelectionBackColor = Control.DefaultBackColor;
            DG.Rows[rows].Cells[cells].Style.SelectionForeColor = Control.DefaultForeColor;
            DG.Rows[rows].Cells[cells].ReadOnly = !read_only;
        }

        private void showStatusPic() {
            if (Write == "Y") {
                StatusPicY.Visible = true;
                StatusPicN.Visible = false;
            } else if (Write == "N") {
                StatusPicY.Visible = false;
                StatusPicN.Visible = true;
            } else {
                StatusPicY.Visible = false;
                StatusPicN.Visible = false;
            }
        }

        private void load_EmpBasicInfo() {
            string fieldname;
            string CryName;            
            int i;

            showStatusPic();
            
            labGrpID.Text = GrpID;
            labCompany.Text = Company;
            labDept.Text = Department;
            labFname.Text = FirstName;
            labMname.Text = MiddleName;
            labFaName.Text = FamilyName;
            labDOC.Text = JoinDate;

            labCurrency.Text = Pcurrency;
            
            DataTable dt;
            // load salary , deduction and remark
            Salary_P.Text = base.Cash_cryt2txt(LASalary);
            Salary_I.Text = base.Cash_cryt2txt(Incre_Amount);
            Salary_A.Text = base.Cash_cryt2txt(Add_Amount);
            Salary_DU.Text = "";
            Salary_DA.Text = "";
            Salary_DL.Text = "";
            txtReMark.Text = "";
            txtOther.Text = "";
            txtBasicRemark.Text = "";
            txtIncreRemark.Text = "";
            if (Write == "Y") {
                //Load keyin value!
                dt = tSQL.KeyData_getDeduction(SelectMonth3.Text, GrpID);
                if (dt.Rows.Count > 0) {
                    Salary_P.Text = base.payKeyDecrypt(base.obj2str(dt.Rows[0]["Prob_Salary"]));
                    Salary_I.Text = base.payKeyDecrypt(base.obj2str(dt.Rows[0]["Incre_Amount"]));
                    Salary_A.Text = base.payKeyDecrypt(base.obj2str(dt.Rows[0]["Add_Amount"]));
                    Salary_DUM.Text = base.obj2str(dt.Rows[0]["Unpaidcury"]);
                    Salary_DU.Text = base.payKeyDecrypt(base.obj2str(dt.Rows[0]["Unpaid_Amount"]));
                    Salary_DAM.Text = base.obj2str(dt.Rows[0]["Advcury"]);
                    Salary_DA.Text = base.payKeyDecrypt(base.obj2str(dt.Rows[0]["Adv_Amount"]));
                    Salary_DLM.Text = base.obj2str(dt.Rows[0]["Loancury"]);
                    Salary_DL.Text = base.payKeyDecrypt(base.obj2str(dt.Rows[0]["Loan_Amount"]));
                    txtReMark.Text = base.obj2str(dt.Rows[0]["Remark"]);
                    txtOther.Text = base.obj2str(dt.Rows[0]["OtherRemark"]);
                    txtBasicRemark.Text = base.obj2str(dt.Rows[0]["BasicSalaryRemark"]);
                    txtIncreRemark.Text = base.obj2str(dt.Rows[0]["IncreRemark"]);
                }
            } else {
                Salary_DUM.Text = Pcurrency;
                Salary_DAM.Text = Pcurrency;
                Salary_DLM.Text = Pcurrency;
            }

            // load personal Rate
            txtCurry.Text = Pcurrency;  //call rate-evnet            
            RunCuryRate.Clear();
            for (i = 0; i < RecGrid.Columns.Count; i++) {
                CryName = RecGrid.Columns[i].Name;
                RunCuryRate.Add(CryName, obj2str(RecGrid.Rows[0].Cells[CryName].Value));
            }

            // load Received Reference
            ReceivedGrid.Rows.Clear();
            ReceivedGrid.RowCount = 2;
            markGridCell(ref ReceivedGrid, 0, 0, false, "Received");
            markGridCell(ref ReceivedGrid, 1, 0, false, "Balance");
            //load received 2st row Style
            for (i = 1; i < ReceivedGrid.Columns.Count; i++) {
                markGridCell(ref ReceivedGrid, 1, i, false, "");
            }

            if (Write != "Y") {
                dt = tSQL.ReceivedData_getOne(GrpID);                
            } else { 
                //Load keyin value!
                dt = tSQL.KeyData_ReceivedList(GrpID, SelectMonth3.Text);
            }

            for (i = 0; i < dt.Rows.Count; i++) {
                fieldname = dt.Rows[i]["Pcurrency"].ToString();
                if (ReceivedGrid.Columns.Contains(fieldname)) {
                    if (Write != "Y") {
                        ReceivedGrid.Rows[0].Cells[fieldname].Value = base.empKeyDecrypt(base.obj2str(dt.Rows[i]["Amount"]));
                    } else {
                        //Load keyin value!
                        ReceivedGrid.Rows[0].Cells[fieldname].Value = base.payKeyDecrypt(base.obj2str(dt.Rows[i]["Amount"]));
                    }                    
                }
            }
            
            // load BankIN 
            bankGrid.Rows.Clear();
            object[] Ary;
            if (Write != "Y") {
                dt = tSQL.BankData_getBankInList(GrpID);               
                for (i = 0; i < dt.Rows.Count; i++) {
                    Ary = new object[] { 
                            dt.Rows[i]["payoutRelation"].ToString(), 
                            dt.Rows[i]["AcHolder"].ToString(), 
                            dt.Rows[i]["Bank"].ToString(), 
                            dt.Rows[i]["AcNumber"].ToString() ,
                            dt.Rows[i]["Cury"].ToString() ,
                            "0"
                          };                    
                    bankGrid.Rows.Add(Ary);
                    setAmountVariance2ReceivedGrid(dt.Rows[i]["Cury"].ToString(), 0);
                } 
            } else {
                //Load keyin value!
                dt = tSQL.KeyData_getBankInList(GrpID, SelectMonth3.Text);
                for (i = 0; i < dt.Rows.Count; i++) {
                    Ary = new object[] { 
                            dt.Rows[i]["payoutRelation"].ToString(), 
                            dt.Rows[i]["AcHolder"].ToString(), 
                            dt.Rows[i]["Bank"].ToString(), 
                            dt.Rows[i]["AcNumber"].ToString() ,
                            dt.Rows[i]["Cury"].ToString() ,
                            base.payKeyDecrypt(base.obj2str(dt.Rows[i]["Amount"]))
                          };
                    bankGrid.Rows.Add(Ary);
                    setAmountVariance2ReceivedGrid(dt.Rows[i]["Cury"].ToString(), base.payKeyDecrypt(base.obj2str(dt.Rows[i]["Amount"])));
                } 
            }

            checkVariance_ReceivedGrid();
        }

        private void checkVariance_ReceivedGrid() {
            int i;
            double _base;
            double _compare;
            string _coldName;
            float fSize = ReceivedGrid.DefaultCellStyle.Font.Size;
            string fName = ReceivedGrid.DefaultCellStyle.Font.Name;
            
            for (i = 1; i < ReceivedGrid.Columns.Count; i++) {
                _coldName = ReceivedGrid.Columns[i].Name;
                _base = base.txt2double(base.obj2str(ReceivedGrid.Rows[0].Cells[_coldName].Value));
                _compare = base.txt2double(base.obj2str(ReceivedGrid.Rows[1].Cells[_coldName].Value));
                if (_base != _compare) {
                    ReceivedGrid.Rows[1].Cells[_coldName].Style.ForeColor = Color.Red;
                    ReceivedGrid.Rows[1].Cells[_coldName].Style.SelectionForeColor = Color.Red;
                    ReceivedGrid.Rows[1].Cells[_coldName].Style.Font = new Font(fName, fSize, System.Drawing.FontStyle.Bold);
                } else {
                    ReceivedGrid.Rows[1].Cells[_coldName].Style.ForeColor = Control.DefaultForeColor;
                    ReceivedGrid.Rows[1].Cells[_coldName].Style.SelectionForeColor = Control.DefaultForeColor;
                    ReceivedGrid.Rows[1].Cells[_coldName].Style.Font = new Font(fName, fSize, System.Drawing.FontStyle.Regular);
                }
            }
        }

        private void setAmountVariance2ReceivedGrid(string currencyHeadName, object addAmount) {
            if (ReceivedGrid.Columns.Contains(currencyHeadName)) {
                double _addAmount = base.txt2double(base.obj2str(addAmount));
                double _secondRow = base.txt2double(base.obj2str(ReceivedGrid.Rows[1].Cells[currencyHeadName].Value));
                double _total = Math.Round((_addAmount + _secondRow), 0, MidpointRounding.AwayFromZero);
                ReceivedGrid.Rows[1].Cells[currencyHeadName].Value = _total.ToString();
            }
        }

        private void Salary_DL_Click(object sender, EventArgs e) {
            ((TextBox)sender).SelectAll();
        }

        private void Salary_DU_TextChanged(object sender, EventArgs e) {
            calculation(); 
        }

        private double exRateVal(object _cury) {
            double reval = 1;
            if(_cury != null){
                reval = txt2double(base.obj2str(RunCuryRate[_cury]));  
            }
            return reval;
        }

        private void calculation() {
            double _Gross = 0;
            double _Deductaion = 0;
            //Salary
            _Gross += base.txt2double(Salary_P.Text);
            _Gross += base.txt2double(Salary_I.Text);
            _Gross += base.txt2double(Salary_A.Text);

            double _unpaid = base.txt2double(Salary_DU.Text) * exRateVal(Salary_DUM.SelectedItem);
            double _adv = base.txt2double(Salary_DA.Text) * exRateVal(Salary_DAM.SelectedItem);
            double _loan = base.txt2double(Salary_DL.Text) * exRateVal(Salary_DLM.SelectedItem);

            _Deductaion = _unpaid + _adv + _loan;

            Salary_Deduction.Text = RoundDouble2Txt(_Deductaion);
            _Deductaion = base.txt2double(Salary_Deduction.Text);

            Salary_NET.Text = RoundDouble2Txt(_Gross - _Deductaion);

            //received
            int i;
            string colName;
            object money;
            string xRate;
            double subAmount;
            double _VRM = 0;
            for (i = 1; i < ReceivedGrid.ColumnCount; i++) {
                colName = ReceivedGrid.Columns[i].Name;
                money = ReceivedGrid.Rows[0].Cells[colName].Value;
                if (RunCuryRate.Contains(colName)) {
                    xRate = RunCuryRate[colName].ToString();
                } else {
                    xRate = "0";
                }
                subAmount = base.txt2double(base.obj2str(money));
                if (subAmount != 0 && xRate != "0") {
                    _VRM += subAmount * txt2double(xRate);
                }
            }
            VarianceRM.Text = RoundDouble2Txt(base.txt2double(Salary_NET.Text) - _VRM);
            
            //clean
            for (i = 1; i < ReceivedGrid.ColumnCount; i++) {
                ReceivedGrid.Rows[1].Cells[i].Value = "";
            }
            //variance RM
            for (i = 0; i < bankGrid.Rows.Count; i++) {
                colName = base.obj2str(bankGrid.Rows[i].Cells["ccPCurrency"].Value);
                setAmountVariance2ReceivedGrid(colName, bankGrid.Rows[i].Cells["ccAmount"].Value);
            }
            //variance color
            checkVariance_ReceivedGrid();
        }

        private string RoundDouble2Txt(double d) {
            d = Math.Round(d, 0, MidpointRounding.AwayFromZero);
            return d.ToString();
        }

        private void button3_Click(object sender, EventArgs e) {
            ___queryHisticalPaymentGrpID = GrpID;
            PaymentRecord cf = new PaymentRecord();
            cf.Show();           
        }

        private void ReceivedGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            calculation();
        }
        private void ReceivedGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            calculation();
        }
        private void ReceivedGrid_CancelRowEdit(object sender, QuestionEventArgs e) {
            calculation();
        }       
        private void bankGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            calculation();
        }
        private void bankGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            calculation();
        }
        private void bankGrid_CancelRowEdit(object sender, QuestionEventArgs e) {
            calculation();
        }

        private void button5_Click(object sender, EventArgs e) {
            //Save
            bool flag;
            int i;
            string colName;
          
            string act;
            string __monthly = SelectMonth3.Text;
            string __GrpID = GrpID;
            string __Pcurrency = labCurrency.Text;
            string __Prob_Salary = Salary_P.Text;
            string __Incre_Amount = Salary_I.Text; ;
            string __Add_Amount = Salary_A.Text;
            string __Gross_Total = "0";
            string __Unpaidcury = ((Salary_DUM.SelectedItem == null) ? "0" : Salary_DUM.SelectedItem.ToString());
            string __Unpaid_Amount = Salary_DU.Text.Trim();
            string __Advcury = ((Salary_DAM.SelectedItem == null) ? "0" : Salary_DAM.SelectedItem.ToString());
            string __Adv_Amount = Salary_DA.Text.Trim();
            string __Loancury = ((Salary_DLM.SelectedItem == null) ? "0" : Salary_DLM.SelectedItem.ToString());
            string __Loan_Amount = Salary_DL.Text.Trim();
            string __Dedu_Total = Salary_Deduction.Text;
            string __Net_Salary = Salary_NET.Text;
            string __Show_VarianceRM = VarianceRM.Text;
            string __Remark = txtReMark.Text.Trim();
            string __OtherRemark = txtOther.Text.Trim();
            string __BasicRemark = txtBasicRemark.Text.Trim();
            string __IncreRemark = this.get_IDformBox(txtIncreRemark);

            string MYR_Gross;
            string MYR_Dedu;
            string MYR_Net;
            double RatetoMYR = 1;

            string __Bank_MYRAmount;


            __Gross_Total = Convert.ToString(txt2double(__Prob_Salary) + txt2double(__Incre_Amount) + txt2double(__Add_Amount));

            if (__Pcurrency == "MYR") {
                MYR_Gross = __Gross_Total;
                MYR_Dedu = __Dedu_Total;
                MYR_Net = __Net_Salary;
            } else {
                // need MYR
                RatetoMYR = base.obj2double(CuryRate[__Pcurrency]);
                if(RatetoMYR == 0 ) RatetoMYR = 1;
                MYR_Gross = Convert.ToString(Math.Round(base.txt2double(__Gross_Total) * RatetoMYR, 0, MidpointRounding.AwayFromZero));
                MYR_Dedu = Convert.ToString(Math.Round(base.txt2double(__Dedu_Total) * RatetoMYR, 0, MidpointRounding.AwayFromZero));
                MYR_Net = Convert.ToString(base.txt2double(MYR_Gross) - base.txt2double(MYR_Dedu));
            }

            if (Write != "Y") {
                act = "Insert";
            } else {
                act = "Update";
            }
            
            // Main
            __Prob_Salary = base.payKeyEncryt(__Prob_Salary);
            __Incre_Amount = base.payKeyEncryt(__Incre_Amount);
            __Add_Amount = base.payKeyEncryt(__Add_Amount);
            __Gross_Total = base.payKeyEncryt(__Gross_Total);
            __Unpaid_Amount = base.payKeyEncryt(__Unpaid_Amount);
            __Adv_Amount = base.payKeyEncryt(__Adv_Amount);
            __Loan_Amount = base.payKeyEncryt(__Loan_Amount);
            __Dedu_Total = base.payKeyEncryt(__Dedu_Total);
            __Net_Salary = base.payKeyEncryt(__Net_Salary);
            __Show_VarianceRM = base.payKeyEncryt(__Show_VarianceRM);
            MYR_Gross = base.payKeyEncryt(MYR_Gross);
            MYR_Dedu = base.payKeyEncryt(MYR_Dedu);
            MYR_Net = base.payKeyEncryt(MYR_Net);

            flag = tSQL.KeyData_InsertUpdate(act, __monthly, __GrpID, __Pcurrency, __Prob_Salary, __Incre_Amount, __Add_Amount,
                                   __Gross_Total, __Unpaidcury, __Unpaid_Amount, __Advcury, __Adv_Amount, __Loancury,
                                   __Loan_Amount, __Dedu_Total, __Net_Salary, __Show_VarianceRM, __Remark, MYR_Gross, MYR_Dedu, MYR_Net, Company, Department, __OtherRemark, __IncreRemark, __BasicRemark);
            // Received
            tSQL.KeyData_ReceivedInsert("Delete", __monthly, __GrpID, "", "", "", "");
            for (i = 1; i < ReceivedGrid.ColumnCount; i++) {
                colName = ReceivedGrid.Columns[i].Name;
                if (ReceivedGrid.Rows[0].Cells[colName].Value != null) {
                    __Bank_MYRAmount = base.payKeyEncryt(base.obj2str(ReceivedGrid.Rows[0].Cells[i].Value));
                    flag = flag && tSQL.KeyData_ReceivedInsert("Insert", __monthly, __GrpID, colName, __Bank_MYRAmount, Company, Department);
                }
            }

            // Bank      
            object __Amount;
            object __AcHolder;
            object __Bank;
            object __AcNumber;
            object __payoutRelation;
            tSQL.KeyData_BankInInsert("Delete", __monthly, __GrpID, "", "", "","","","","","","");
            for (i = 0; i < bankGrid.Rows.Count; i++) {
                //string __monthly
                //string __GrpID
                __Pcurrency = "";
                __payoutRelation = bankGrid.Rows[i].Cells["ccpayoutRelation"].Value;
                __AcHolder = bankGrid.Rows[i].Cells["ccAcHolder"].Value;
                __Bank = bankGrid.Rows[i].Cells["ccBank"].Value;
                __AcNumber = bankGrid.Rows[i].Cells["ccAcNumber"].Value;
                __Amount = bankGrid.Rows[i].Cells["ccAmount"].Value;

                __payoutRelation = ((__payoutRelation == null) ? "" : __payoutRelation.ToString());
                __AcHolder = ((__AcHolder == null) ? "" : __AcHolder.ToString());
                __Bank = ((__Bank == null) ? "" : __Bank.ToString());
                __AcNumber = ((__AcNumber == null) ? "" : __AcNumber.ToString());
                __Amount = ((__Amount == null) ? "0" : __Amount.ToString());

                __Bank_MYRAmount = base.calculate_Amount_byDiffCurrency(this.getRateByHSBypRelation(__payoutRelation.ToString()), "1", __Amount.ToString()); //MYR rate = 1;

                flag = flag && tSQL.KeyData_BankInInsert("Insert", __monthly, __GrpID, __Pcurrency, base.payKeyEncryt(base.obj2str(__Amount)), __AcHolder.ToString(),
                                                        __Bank.ToString(), __AcNumber.ToString(), __payoutRelation.ToString(), Company, Department, base.payKeyEncryt(base.obj2str(__Bank_MYRAmount)));
            }


            if (flag) {
                MessageBox.Show("Saved.", "Save Payout", MessageBoxButtons.OK);
                //refrash
                load_EmployeeData2EmpListView();
                Write = "Y";
                showStatusPic();
            } else {
                MessageBox.Show(tSQL.errMessage, "Save Payout", MessageBoxButtons.OK);
            }
        }

        private string getRateByHSBypRelation(string _payoutRelation) { 
            string cuy = "";
            string payout = "";
            string rate = "0";
            int pos = -1;

            if (_payoutRelation.Trim() != "") {
                pos = _payoutRelation.LastIndexOf("(");
                if (pos != -1) {
                    payout = _payoutRelation.Substring(pos + 1);                 
                    cuy = payout.Split('|')[2];
                    if(CuryRate.ContainsKey(cuy)){
                        rate = base.obj2str(CuryRate[cuy]);
                    }
                }
            }

            return rate;
        }

        //reset
        private void button6_Click(object sender, EventArgs e) {
            DialogResult result;            
            string __monthly = SelectMonth3.Text;
            string __GrpID = GrpID;

            result = MessageBox.Show("Are you reset this record?", "Reset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                Write = "N";
                //main
                tSQL.KeyData_Delete(__monthly, __GrpID);
                // Received
                tSQL.KeyData_ReceivedInsert("Delete", __monthly, __GrpID, "", "", "", "");
                // Bank  
                tSQL.KeyData_BankInInsert("Delete", __monthly, __GrpID, "", "", "", "", "", "","","","");
                MessageBox.Show("Reset.", "Reset", MessageBoxButtons.OK);
                load_EmployeeData2EmpListView();
                changPage("2");
            }
        }

        //change Rate!
        private void txtCurry_SelectedIndexChanged(object sender, EventArgs e) {
            int i;
            string pcurrcy;
            string CryName;
            string _format;
            double _base;
            double _rate;
            double _newrate;
            if (txtCurry.SelectedItem != null) {
                pcurrcy = txtCurry.SelectedItem.ToString();
                if (pcurrcy == "MYR") {
                    for (i = 0; i < RecGrid.Columns.Count; i++) {
                        CryName = RecGrid.Columns[i].Name;
                        RecGrid.Rows[0].Cells[CryName].Value = CuryRate[CryName];
                    }
                } else {
                    // change!
                    _base = txt2double(base.obj2str(CuryRate[pcurrcy]));
                    for (i = 0; i < RecGrid.Columns.Count; i++) {
                        CryName = RecGrid.Columns[i].Name;
                        _rate = txt2double(base.obj2str(CuryRate[CryName]));
                        _format = base.obj2str(RecGrid.Columns[i].Tag);
                        
                        if(_base!=0) 
                            _newrate = ( 1 / _base * _rate );
                        else
                            _newrate = 0;

                        RecGrid.Rows[0].Cells[CryName].Value = string.Format(_format, _newrate);
                    }
                }                
            } else {
                txtCurry.Text = "";
            }

           
        }

        // employee list reflash
        private void button7_Click(object sender, EventArgs e) {
            load_EmployeeData2EmpListView();
            changPage("2");
        }

        private void Salary_NET_TextChanged(object sender, EventArgs e) {
            if (Salary_NET.Text.IndexOf("-") != -1) {
                Salary_NET.ForeColor = Color.Red;
            } else {
                Salary_NET.ForeColor = Color.Blue;
            }
        }

        private void VarianceRM_TextChanged(object sender, EventArgs e) {
            if (VarianceRM.Text.IndexOf("-") != -1) {
                VarianceRM.ForeColor = Color.Red;
            } else {
                VarianceRM.ForeColor = Color.Blue;
            }
        }

        private void Salary_DUM_SelectedIndexChanged(object sender, EventArgs e) {
            calculation();
        }

        private void Salary_DAM_SelectedIndexChanged(object sender, EventArgs e) {
            calculation();
        }

        private void Salary_DLM_SelectedIndexChanged(object sender, EventArgs e) {
            calculation();
        }

    }
}