using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Payroll_System
{
    public partial class PaymentRecord : First
    {
        TSQL tSQL;
        string LasterMonth;
        string _monthKey = string.Empty;
        bool exiting = false;

        public PaymentRecord()
        {
            InitializeComponent();
        }

        private void PaymentRecord_Load(object sender, EventArgs e)
        {
            tSQL = new TSQL(base.RemoteDBAbsPath());

            GetLastMonth();
            Load_YearBox();
            Load_MonthBox();

            Load_EmpBasicProfile();

            SetGridStyle();

            Load_PayMain();

            if (!exiting)
            {
                this.Opacity = 1;
            }
        }

        private bool SetMonthKey()
        {
            if (monthBox.Text != string.Empty)
            {
                InputBoxResult result = InputBox.Show("Please input this month decrypt key.", SelectMonth3.Text, string.Empty);
                if (result.ReturnCode == DialogResult.OK)
                {
                    _monthKey = result.Text;
                    return true;
                }
                else
                {
                    this.Close();
                    exiting = true;
                    _monthKey = string.Empty;
                    return false;
                }
            }

            return false;
        }

        private void GetLastMonth()
        {
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

        private void Load_YearBox()
        {
            DataTable data = tSQL.LockData_selectbyYear();
            YearBox.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                YearBox.Items.Add(row[0].ToString());
            }
            YearBox.Text = LasterMonth.Substring(0, 4);
        }

        private void Load_MonthBox()
        {
            string _year = this.GetIDFromBox(YearBox);
            DataTable data;

            monthBox.Items.Clear();
            if (_year != string.Empty)
            {
                data = tSQL.LockData_selectMonthbyYear(_year);
                foreach (DataRow row in data.Rows)
                {
                    monthBox.Items.Add(row[0].ToString());
                }
                if (monthBox.Items.Contains(LasterMonth))
                {
                    monthBox.Text = LasterMonth;
                    SelectMonth3.Text = LasterMonth;
                }
            }
        }

        private string GetIDFromBox(ComboBox Lx)
        {
            string result = string.Empty;
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null)
            {
                result = Lx.SelectedItem.ToString();
            }
            return result;
        }

        private void SetGridStyle()
        {
            if (exiting)
            {
                return;
            }

            int i;

            for (i = 0; i <= 5; i++)
            {
                bankGrid.Columns[i].DefaultCellStyle.BackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionBackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionForeColor = Control.DefaultForeColor;
            }

            bankGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void MarkGridCell(ref DataGridView DG, int rows, int cells, bool read_only, string txt)
        {
            DG.Rows[rows].Cells[cells].Value = txt;
            DG.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            DG.Rows[rows].Cells[cells].Style.SelectionBackColor = Control.DefaultBackColor;
            DG.Rows[rows].Cells[cells].Style.SelectionForeColor = Control.DefaultForeColor;
            DG.Rows[rows].Cells[cells].ReadOnly = !read_only;
        }

        private void Load_EmpBasicProfile()
        {
            DataTable dt = tSQL.EmployeeData_getOne(__groupID);
            lblGroupID.Text = FormatGroupID(__groupID);
            labCompany.Text = base.obj2str(dt.Rows[0]["CompanyID"]);
            labDept.Text = base.obj2str(dt.Rows[0]["DepartmentID"]);
            labFname.Text = base.obj2str(dt.Rows[0]["FirstName"]);
            labMname.Text = base.obj2str(dt.Rows[0]["MiddleName"]);
            labFaName.Text = base.obj2str(dt.Rows[0]["FamilyName"]);
            labDOC.Text = FormatDateOfJoined(dt.Rows[0]["DateJoined"]);
        }

        private void CleanText()
        {
            Salary_Basic.Text = string.Empty;
            Salary_Increment.Text = string.Empty;
            Salary_Addition.Text = string.Empty;
            Salary_DU.Text = string.Empty;
            Salary_DA.Text = string.Empty;
            Salary_DL.Text = string.Empty;
            txtRemark.Text = string.Empty;

            rateGrid.Rows.Clear();
            rateGrid.Columns.Clear();
            receivedAmtGrid.Rows.Clear();
            receivedAmtGrid.Columns.Clear();
            bankGrid.Rows.Clear();
        }

        private void Load_PayMain()
        {
            if (exiting)
            {
                return;
            }

            string fieldName;
            int i;

            CleanText();

            string _month = this.GetIDFromBox(monthBox);
            if (_month == string.Empty)
            {
                return;
            }

            bool status = false;
            if (_monthKey == string.Empty)
            {
                status = SetMonthKey();
            }

            DataTable dtKey = tSQL.getMonthlyPwdKey(_month);
            Random ran = new Random();
            int attempt = ran.Next(1, 4);

            while (status && base.SaveKeyEncrypt(_monthKey, false) != base.obj2str(dtKey.Rows[0][0]) && attempt > 0)
            {
                attempt--;
                DialogResult result = MessageBox.Show("Error Key!", "Check Key", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Close();
                    exiting = true;
                    return;
                }
                else if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    SetMonthKey();
                }
            }

            if (_monthKey == string.Empty)
            {
                this.Close();
                exiting = true;
                return;
            }

            // Rate
            DataTable currencyData = tSQL.ExRateData_getAllbyDate(_month);
            DataGridViewTextBoxColumn currencyColumn;
            foreach (DataRow row in currencyData.Rows)
            {
                currencyColumn = new DataGridViewTextBoxColumn();
                currencyColumn.Name = string.Format("{0}", row["exchangeCurrency"].ToString());
                currencyColumn.Width = 55;
                currencyColumn.HeaderText = row["exchangeCurrency"].ToString();
                currencyColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                rateGrid.Columns.Add(currencyColumn);

            }
            rateGrid.RowCount = 1;
            foreach (DataRow row in currencyData.Rows)
            {
                fieldName = base.obj2str(row["exchangeCurrency"]);
                rateGrid.Rows[0].Cells[fieldName].Value = base.obj2str(row["showRate"]);
            }

            // Load all salary
            DataTable data = tSQL.Report_getEmpMainByGrpID(_month, __groupID);
            if (data.Rows.Count > 0)
            {
                txtCurrency.Text = base.obj2str(data.Rows[0]["Pcurrency"]);
                lblCurrency.Text = base.obj2str(data.Rows[0]["Pcurrency"]);
                Salary_Basic.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Prob_Salary"]), _monthKey);
                Salary_Increment.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Incre_Amount"]), _monthKey);
                Salary_Addition.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Add_Amount"]), _monthKey);
                Salary_DU.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Unpaid_Amount"]), _monthKey);
                Salary_DA.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Adv_Amount"]), _monthKey);
                Salary_DL.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Loan_Amount"]), _monthKey);
                Salary_DUM.Text = base.obj2str(data.Rows[0]["Unpaidcury"]);
                Salary_DAM.Text = base.obj2str(data.Rows[0]["Advcury"]);
                Salary_DLM.Text = base.obj2str(data.Rows[0]["Loancury"]);
                Salary_NET.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Net_Salary"]), _monthKey);
                VarianceRM.Text = base.emp_pay_KeyDecrypt(base.obj2str(data.Rows[0]["Show_VarianceRM"]), _monthKey);
                txtRemark.Text = base.obj2str(data.Rows[0]["Remark"]);

                string basicSalary = StorageHelper.GetBasicSalary(__groupID, _month);
                if (!string.IsNullOrEmpty(basicSalary))
                {
                    txtMonthlyWorkDays.Value = StorageHelper.GetKeyinWorkDays(__groupID, _month);
                    txtUnpaidDays.Value = StorageHelper.GetUnpaidDays(__groupID, _month);

                    txtTotalAddition.Text = (int.Parse("0" + Salary_Addition.Text) + int.Parse("0" + Salary_Increment.Text)).ToString();
                    txtTotalDeduction.Text = StorageHelper.GetTotalDeduction(__groupID, _month).ToString();

                    int workDays = (int)txtMonthlyWorkDays.Value;

                    decimal deductiveAmount = 0;
                    decimal salary = int.Parse(Salary_Basic.Text);
                    int unpaidLeave = (int)txtUnpaidDays.Value;

                    deductiveAmount = (salary / workDays) * unpaidLeave;
                    txtDeductiveAmt.Value = Math.Round(deductiveAmount);
                }
            }

            // Load Received 
            // Tip column
            DataGridViewTextBoxColumn column;
            column = new DataGridViewTextBoxColumn();
            column.Name = "descColumn";
            column.Width = 70;
            column.HeaderText = string.Empty;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.Frozen = true;
            receivedAmtGrid.Columns.Add(column);

            foreach (DataRow row in currencyData.Rows)
            {
                column = new DataGridViewTextBoxColumn();
                column.Name = string.Format("{0}", row["exchangeCurrency"].ToString());
                column.Width = 55;
                column.HeaderText = row["exchangeCurrency"].ToString();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                receivedAmtGrid.Columns.Add(column);
            }

            receivedAmtGrid.RowCount = 2;
            MarkGridCell(ref receivedAmtGrid, 0, 0, false, "Received");
            MarkGridCell(ref receivedAmtGrid, 1, 0, false, "Balance");

            // Load received 2st row Style
            DataTable receivedData = tSQL.Report_getEmpReceivedList(_month, __groupID);
            for (i = 1; i < receivedAmtGrid.Columns.Count; i++)
            {
                MarkGridCell(ref receivedAmtGrid, 0, i, false, "");
                MarkGridCell(ref receivedAmtGrid, 1, i, false, "");
            }
            // Set value
            foreach (DataRow row in receivedData.Rows)
            {
                fieldName = base.obj2str(row["Pcurrency"]);
                if (receivedAmtGrid.Columns.Contains(fieldName))
                {
                    receivedAmtGrid.Rows[0].Cells[fieldName].Value = base.emp_pay_KeyDecrypt(base.obj2str(row["Amount"]), _monthKey);
                }
            }

            // Load BankIN 
            object[] array;

            // Load keyin value!
            DataTable bankData = tSQL.KeyData_getBankInList(__groupID, _month);
            for (i = 0; i < bankData.Rows.Count; i++)
            {
                array = new object[] { 
                        bankData.Rows[i]["payoutRelation"].ToString(), 
                        bankData.Rows[i]["AcHolder"].ToString(), 
                        bankData.Rows[i]["Bank"].ToString(), 
                        bankData.Rows[i]["AcNumber"].ToString() ,
                        bankData.Rows[i]["Cury"].ToString() ,
                        base.emp_pay_KeyDecrypt(base.obj2str(bankData.Rows[i]["Amount"]), _monthKey)
                      };

                bankGrid.Rows.Add(array);
                SetAmountVariance2ReceivedGrid(bankData.Rows[i]["Cury"].ToString(), base.emp_pay_KeyDecrypt(base.obj2str(bankData.Rows[i]["Amount"]), _monthKey));
            }

            CheckVariance_receivedAmtGrid();
            ModifyGrid();
        }

        private void CheckVariance_receivedAmtGrid()
        {
            int i;
            double _base;
            double _compare;
            string _columnName;
            float fSize = receivedAmtGrid.DefaultCellStyle.Font.Size;
            string fName = receivedAmtGrid.DefaultCellStyle.Font.Name;

            for (i = 1; i < receivedAmtGrid.Columns.Count; i++)
            {
                _columnName = receivedAmtGrid.Columns[i].Name;
                _base = base.txt2double(base.obj2str(receivedAmtGrid.Rows[0].Cells[_columnName].Value));
                _compare = base.txt2double(base.obj2str(receivedAmtGrid.Rows[1].Cells[_columnName].Value));
                if (_base != _compare)
                {
                    receivedAmtGrid.Rows[1].Cells[_columnName].Style.ForeColor = Color.Red;
                    receivedAmtGrid.Rows[1].Cells[_columnName].Style.SelectionForeColor = Color.Red;
                    receivedAmtGrid.Rows[1].Cells[_columnName].Style.Font = new Font(fName, fSize, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    receivedAmtGrid.Rows[1].Cells[_columnName].Style.ForeColor = Control.DefaultForeColor;
                    receivedAmtGrid.Rows[1].Cells[_columnName].Style.SelectionForeColor = Control.DefaultForeColor;
                    receivedAmtGrid.Rows[1].Cells[_columnName].Style.Font = new Font(fName, fSize, System.Drawing.FontStyle.Regular);
                }
            }
        }

        private void SetAmountVariance2ReceivedGrid(string currencyHeadName, object addAmount)
        {
            if (receivedAmtGrid.Columns.Contains(currencyHeadName))
            {
                double _addAmount = base.txt2double(base.obj2str(addAmount));
                double _2ndRow = base.txt2double(base.obj2str(receivedAmtGrid.Rows[1].Cells[currencyHeadName].Value));
                double _total = Math.Round((_addAmount + _2ndRow), 0, MidpointRounding.AwayFromZero);
                receivedAmtGrid.Rows[1].Cells[currencyHeadName].Value = _total.ToString();
            }
        }

        private void monthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exiting)
            {
                return;
            }

            Load_PayMain();
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exiting)
            {
                return;
            }

            Load_MonthBox();
            Load_PayMain();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (exiting)
            {
                return;
            }

            SetMonthKey();
            Load_PayMain();
        }

        /// <summary>
        /// Make grid available currencies only.
        /// </summary>
        private void ModifyGrid()
        {
            // receivedAmtGrid

            List<string> availableCurrencies = new List<string>();
            foreach (DataGridViewRow row in bankGrid.Rows)
            {
                string currency = row.Cells[4].Value.ToString();
                availableCurrencies.Add(currency);
            }

            List<string> removedColumns = new List<string>();
            foreach (DataGridViewColumn column in receivedAmtGrid.Columns)
            {
                if (!availableCurrencies.Contains(column.HeaderText))
                {
                    removedColumns.Add(column.Name);
                }
            }

            // Hide unvailable currencies
            foreach (string name in removedColumns)
            {
                receivedAmtGrid.Columns[name].Visible = false;
            }

        }
    }
}