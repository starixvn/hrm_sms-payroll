using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Payroll_System {    
    public partial class PaymentRecord : First {
        TSQL tSQL;
        string LasterMonth;
        string _monthKey;

        public PaymentRecord() {
            InitializeComponent();
        }

        private void PaymentRecord_Load(object sender, EventArgs e) {
            tSQL = new TSQL(base.remoteDBAbsPath());

            
            getLasterMonth();
            load_yearBox();
            load_monthBox();

            load_EmpBasicInfo();

            setGridStyle();            
            load_PayMain();
        }

        private void setMonthKey() {
            if (monthBox.Text != "") {

                InputBoxResult test = InputBox.Show("Please input this month decrypt key", SelectMonth3.Text, "", 100, 0);

                if (test.ReturnCode == DialogResult.OK)
                    _monthKey = test.Text;
                else
                    _monthKey = "";
            }

        }

        private void getLasterMonth() {
            string _year;
            string _month;
            LasterMonth = tSQL.LockData_openMonth();
            _year = LasterMonth.Substring(0, 4);
            _month = LasterMonth.Substring(4, 2);
            DateTime d = new DateTime(Convert.ToInt16(_year), Convert.ToInt16(_month), 1);
            d = d.AddMonths(-1);
            _year = d.ToString("yyyy");
            _month = d.ToString("MM");
            LasterMonth = string.Format("{0}{1}", _year, _month);
        }

        private void load_yearBox() {
            DataTable tb = tSQL.LockData_selectbyYear();
            YearBox.Items.Clear();            
            foreach (DataRow row in tb.Rows) {
                YearBox.Items.Add(row[0].ToString());
            }
            YearBox.Text = LasterMonth.Substring(0, 4);
        }

        private void load_monthBox() {
            string _year = this.get_IDformBox(YearBox);
            DataTable tb;

            monthBox.Items.Clear();
            if (_year != "") {
                tb = tSQL.LockData_selectMonthbyYear(_year);            
                foreach (DataRow row in tb.Rows) {
                    monthBox.Items.Add(row[0].ToString());
                }
                if (monthBox.Items.Contains(LasterMonth)) {
                    monthBox.Text = LasterMonth;
                    SelectMonth3.Text = LasterMonth;
                }
            }            
        }

        private string get_IDformBox(ComboBox Lx) {
            string reval = "";
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null) {
                reval = Lx.SelectedItem.ToString();
            }
            return reval;
        }
        
        private void setGridStyle() {
            int i;

            for (i = 0; i <= 5; i++) {
                bankGrid.Columns[i].DefaultCellStyle.BackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionBackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionForeColor = Control.DefaultForeColor;                
            }
            bankGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
      
        private void markGridCell(ref DataGridView DG, int rows, int cells, bool read_only, string txt) {
            DG.Rows[rows].Cells[cells].Value = txt;
            DG.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            DG.Rows[rows].Cells[cells].Style.SelectionBackColor = Control.DefaultBackColor;
            DG.Rows[rows].Cells[cells].Style.SelectionForeColor = Control.DefaultForeColor;
            DG.Rows[rows].Cells[cells].ReadOnly = !read_only;
        }
      
        private void load_EmpBasicInfo() {            
            DataTable dt = tSQL.EmployeeData_getOne(___queryHisticalPaymentGrpID);
            labGrpID.Text = ___queryHisticalPaymentGrpID;
            labCompany.Text = base.obj2str(dt.Rows[0]["CompanyID"]);
            labDept.Text = base.obj2str(dt.Rows[0]["DepartmentID"]);
            labFname.Text = base.obj2str(dt.Rows[0]["FirstName"]);
            labMname.Text = base.obj2str(dt.Rows[0]["MiddleName"]);
            labFaName.Text = base.obj2str(dt.Rows[0]["FamilyName"]);
            labDOC.Text = base.obj2str(dt.Rows[0]["DateJoined"]);
        }

        private void cleanField() {
            Salary_P.Text = "";
            Salary_I.Text = "";
            Salary_A.Text = "";
            Salary_DU.Text = "";
            Salary_DA.Text = "";
            Salary_DL.Text = "";
            txtReMark.Text = "";

            RecGrid.Rows.Clear();
            RecGrid.Columns.Clear();
            ReceivedGrid.Rows.Clear();
            ReceivedGrid.Columns.Clear();
            bankGrid.Rows.Clear();
        }

        private void load_PayMain(){
            string fieldname;
            int i;

            cleanField();

            string _month = this.get_IDformBox(monthBox);
            if (_month == "")  return;           

            //Rate
            DataTable CurrencyDT = tSQL.ExRateData_getAllbyDate(_month);
            DataGridViewTextBoxColumn dvc;            
            foreach (DataRow row in CurrencyDT.Rows) {
                dvc = new DataGridViewTextBoxColumn();
                dvc.Name = string.Format("{0}", row["exchangeCurrency"].ToString());
                dvc.Width = 55;
                dvc.HeaderText = row["exchangeCurrency"].ToString();
                dvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                RecGrid.Columns.Add(dvc);
                
            }
            RecGrid.RowCount = 1;
            foreach (DataRow row in CurrencyDT.Rows) {
                fieldname = base.obj2str(row["exchangeCurrency"]);
                RecGrid.Rows[0].Cells[fieldname].Value = base.obj2str(row["showRate"]);
            }

            //load all salary
            DataTable MainDT = tSQL.Report_getEmpMainByGrpID(_month, ___queryHisticalPaymentGrpID);
            if (MainDT.Rows.Count > 0) {
                txtCurry.Text = base.obj2str(MainDT.Rows[0]["Pcurrency"]);
                labCurrency.Text = base.obj2str(MainDT.Rows[0]["Pcurrency"]);
                Salary_P.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Prob_Salary"]), _monthKey);
                Salary_I.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Incre_Amount"]), _monthKey);
                Salary_A.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Add_Amount"]), _monthKey);
                Salary_DU.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Unpaid_Amount"]), _monthKey);
                Salary_DA.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Adv_Amount"]), _monthKey);
                Salary_DL.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Loan_Amount"]), _monthKey);
                Salary_DUM.Text = base.obj2str(MainDT.Rows[0]["Unpaidcury"]);
                Salary_DAM.Text = base.obj2str(MainDT.Rows[0]["Advcury"]);
                Salary_DLM.Text = base.obj2str(MainDT.Rows[0]["Loancury"]);
                Salary_NET.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Net_Salary"]), _monthKey);
                VarianceRM.Text = base.emp_pay_KeyDecrypt(base.obj2str(MainDT.Rows[0]["Show_VarianceRM"]), _monthKey);
                txtReMark.Text = base.obj2str(MainDT.Rows[0]["Remark"]);
            }

            // load Received 
            //tip column
            DataGridViewTextBoxColumn dvc2; 
            dvc2 = new DataGridViewTextBoxColumn();
            dvc2.Name = "descColumn";
            dvc2.Width = 70;
            dvc2.HeaderText = "";
            dvc2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dvc2.Frozen = true;
            ReceivedGrid.Columns.Add(dvc2);
            
            foreach (DataRow row in CurrencyDT.Rows) {
                dvc2 = new DataGridViewTextBoxColumn();
                dvc2.Name = string.Format("{0}", row["exchangeCurrency"].ToString());
                dvc2.Width = 55;
                dvc2.HeaderText = row["exchangeCurrency"].ToString();
                dvc2.SortMode = DataGridViewColumnSortMode.NotSortable;
                ReceivedGrid.Columns.Add(dvc2);
            }

            ReceivedGrid.RowCount = 2;
            markGridCell(ref ReceivedGrid, 0, 0, false, "Received");
            markGridCell(ref ReceivedGrid, 1, 0, false, "Balance");
            //load received 2st row Style
            DataTable receivedDT = tSQL.Report_getEmpReceivedList(_month, ___queryHisticalPaymentGrpID);
            for (i = 1; i < ReceivedGrid.Columns.Count; i++) {
                markGridCell(ref ReceivedGrid, 0, i, false, "");
                markGridCell(ref ReceivedGrid, 1, i, false, "");
            }
            //set value
            foreach (DataRow row in receivedDT.Rows) {
                fieldname = base.obj2str(row["Pcurrency"]);
                if (ReceivedGrid.Columns.Contains(fieldname)) {
                    ReceivedGrid.Rows[0].Cells[fieldname].Value = base.emp_pay_KeyDecrypt(base.obj2str(row["Amount"]), _monthKey);
                }
            }

            // load BankIN 
            object[] Ary;
           
            //Load keyin value!
            DataTable dt = tSQL.KeyData_getBankInList(___queryHisticalPaymentGrpID, _month);
            for (i = 0; i < dt.Rows.Count; i++) {
                Ary = new object[] { 
                        dt.Rows[i]["payoutRelation"].ToString(), 
                        dt.Rows[i]["AcHolder"].ToString(), 
                        dt.Rows[i]["Bank"].ToString(), 
                        dt.Rows[i]["AcNumber"].ToString() ,
                        dt.Rows[i]["Cury"].ToString() ,
                        base.emp_pay_KeyDecrypt(base.obj2str(dt.Rows[i]["Amount"]), _monthKey)
                      };
                bankGrid.Rows.Add(Ary);
                setAmountVariance2ReceivedGrid(dt.Rows[i]["Cury"].ToString(), base.emp_pay_KeyDecrypt(base.obj2str(dt.Rows[i]["Amount"]), _monthKey));
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

        private void monthBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_PayMain();
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_monthBox();
            load_PayMain();
        }

        private void button1_Click(object sender, EventArgs e) {
            setMonthKey();
            load_PayMain();
        }

        
    }
}