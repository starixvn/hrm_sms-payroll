using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Payroll_System
{
    using CS;

    public partial class Payment : First
    {
        int X = 190;
        int Y = 10;
        float currentSize;
        TSQL tSQL;

        string AllText = "======= All =======";

        string FormatMonthlyWorkDaysText = "{0} work days for all employees";

        string LockMonth;
        string groupID = string.Empty;
        string MiddleName;
        string FamilyName;
        string FirstName;
        string JobTitle;
        string JoinDate;
        string Write;
        string Company;
        string Department;

        string Salary;
        string IncrementAmount;
        string AdditionalAmount;
        string Currency;

        Hashtable CurrencyRate;
        Hashtable RunCurrencyRate; // This employee's Rate
        DataTable PayoutRelation;

        bool ExistedError = false;

        private int sortedColumnId = -1;

        enum Step
        { 
            SelectInputDay,
            SelectEmployee,
            Keyin
        }

        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            tSQL = new TSQL(base.RemoteDBAbsPath());
            CurrencyRate = new Hashtable();
            RunCurrencyRate = new Hashtable();

            currentSize = btnSelectEmp.Font.Size;
            Step1.Left = Step2.Left = X;
            Step1.Top = Step2.Top = Y;

            LockMonth = tSQL.LockData_openMonth();
            SelectMonth2.Text = LockMonth;
            SelectMonth3.Text = LockMonth;

            Load_CompanyListBox();
            Load_DeptListBox(CompanyBox, DeptBox);
            Load_EmployeeData_2_empListView();

            ChangePage(Step.SelectEmployee);
        }

        private void Load_IncrementRemark()
        {
            txtIncreRemark.Items.Clear();
            txtIncreRemark.Items.Add(string.Empty);
            txtIncreRemark.Items.Add("Confirmation");
            txtIncreRemark.Items.Add("Annual");
            txtIncreRemark.Items.Add("Promotion");
        }

        private void Load_CompanyListBox()
        {
            DataTable data;
            CompanyBox.Items.Clear();
            data = tSQL.CompanyData_SelectAll();
            string formatStr;
            CompanyBox.Items.Add(AllText);
            foreach (DataRow row in data.Rows)
            {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                CompanyBox.Items.Add(formatStr);
            }
            if (CompanyBox.Items.Count > 0) CompanyBox.SelectedIndex = 0;
        }

        private void Load_DeptListBox(ComboBox Comp, ComboBox Dept)
        {
            DataTable tb;
            Dept.Items.Clear();
            tb = tSQL.DeptData_SelectAll(this.GetIDFromBox(Comp));
            string formatStr;
            if (Dept.Name == "DeptBox")
            {
                Dept.Items.Add(AllText);
            }
            foreach (DataRow row in tb.Rows)
            {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                Dept.Items.Add(formatStr);
            }
            if (Dept.Items.Count > 0)
                Dept.SelectedIndex = 0;
            else
                Dept.Text = string.Empty;
        }

        private string GetIDFromBox(ComboBox combo)
        {
            string value = string.Empty;
            if (combo.Items.Count > 0 && combo.SelectedItem != null)
            {
                if (combo.SelectedItem.ToString() != AllText)
                    value = combo.SelectedItem.ToString();
            }
            return value;
        }

        private void Load_CurrencyListBox()
        {
            DataTable data;

            Salary_DUM.Items.Clear();
            Salary_DAM.Items.Clear();
            Salary_DLM.Items.Clear();
            txtCurrency.Items.Clear();

            data = tSQL.CurrencyData_SelectAll();
            string formatStr;
            foreach (DataRow row in data.Rows)
            {
                formatStr = string.Format("{0}", row["Pcurrency"].ToString());
                Salary_DUM.Items.Add(formatStr);
                Salary_DAM.Items.Add(formatStr);
                Salary_DLM.Items.Add(formatStr);
                txtCurrency.Items.Add(formatStr);
            }
            if (Salary_DUM.Items.Count > 0)
            {
                Salary_DUM.Text = "MYR";
                Salary_DAM.Text = "MYR";
                Salary_DLM.Text = "MYR";
                txtCurrency.Text = "MYR";
            }
        }

        private void SetBankGridStyle()
        {
            int i;
            for (i = 0; i <= 4; i++)
            {
                bankGrid.Columns[i].DefaultCellStyle.BackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionBackColor = Control.DefaultBackColor;
                bankGrid.Columns[i].DefaultCellStyle.SelectionForeColor = Control.DefaultForeColor;
            }
            bankGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePage(Step step)
        {
            switch (step)
            {
                case Step.SelectEmployee:
                    btnSelectEmp.ForeColor = Color.Blue;
                    btnKeyin.ForeColor = Color.Gray;

                    Step1.Visible = true;
                    Step2.Visible = false;

                    MarkY.Top = btnSelectEmp.Location.Y - 5;

                    SetBankGridStyle();
                    Load_CurrencyListBox();
                    Load_RateHeader();
                    PayoutRelation = tSQL.PayRelationData_ShowTree();
                    Load_IncrementRemark();

                    break;
                case Step.Keyin:
                    if (groupID == string.Empty)
                    {
                        CleanAll();
                        MessageBox.Show("Please select a record to write.", "Keyin", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                    }

                    btnSelectEmp.ForeColor = Color.Gray;
                    btnKeyin.ForeColor = Color.Blue;

                    Step1.Visible = false;
                    Step2.Visible = true;

                    Load_EmpBasicProfile();
                    Calculation();

                    MarkY.Top = btnKeyin.Location.Y - 5;

                    break;
            }

            MarkY.SendToBack();
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupID = string.Empty;
            Load_DeptListBox(CompanyBox, DeptBox);
            Load_EmployeeData_2_empListView();
        }

        private void Load_EmployeeData_2_empListView()
        {
            DataTable data;
            empListView.Items.Clear();

            data = tSQL.KeyData_getEmpList(LockMonth, this.GetIDFromBox(CompanyBox), this.GetIDFromBox(DeptBox));
            string _monthly;
            foreach (DataRow row in data.Rows)
            {
                ListViewItem employeeList = new ListViewItem();

                _monthly = base.obj2str(row["monthly"]);
                string groupID = FormatGroupID(row["GrpID"]);

                if (_monthly != string.Empty)
                {
                    employeeList.ImageIndex = 23;

                    if (StorageHelper.GetPayoutError(groupID, _monthly))
                    {
                        employeeList.ImageIndex = 27;
                    }
                }
                else 
                {
                    _monthly = LockMonth;
                    employeeList.ImageIndex = 24;
                }

                employeeList.SubItems.Add(base.obj2str(row["CompanyID"]));
                employeeList.SubItems.Add(base.obj2str(row["DepartmentID"]));
                employeeList.SubItems.Add( FormatGroupID(row["GrpID"]) );
                employeeList.SubItems.Add(base.obj2str(row["FirstName"]));
                employeeList.SubItems.Add(base.obj2str(row["MiddleName"]));
                employeeList.SubItems.Add(base.obj2str(row["FamilyName"]));
                employeeList.SubItems.Add(base.obj2str(row["Sex"]));
                employeeList.SubItems.Add(base.obj2str(row["PositionName"]));
                employeeList.SubItems.Add(FormatDateOfJoined(row["DateJoined"]));
                employeeList.SubItems.Add(base.obj2str(row["Pcurrency"]));

                var currentMonth = _monthly;
                string basicSalary = StorageHelper.GetBasicSalary(groupID, _monthly);
                if(string.IsNullOrEmpty(basicSalary))
                {
                    _monthly = StorageHelper.GetLastMonth(_monthly);
                    basicSalary = StorageHelper.GetBasicSalary(groupID, _monthly);
                }

                if (!string.IsNullOrEmpty(basicSalary))
                {
                    bool isProbation = StorageHelper.GetInProbationTime(groupID, _monthly);
                    if (isProbation)
                    {
                        basicSalary = StorageHelper.GetProbationSalary(groupID, _monthly);
                    }
                    basicSalary = base.empKeyDecrypt(basicSalary);

                    string additionalAmount = StorageHelper.GetAdditionalAmount(groupID, _monthly);
                    if (string.IsNullOrEmpty(additionalAmount))
                    {
                        additionalAmount = "0";
                    }
                    else 
                    {
                        additionalAmount = base.empKeyDecrypt(additionalAmount);
                    }

                    string incrementSalary = StorageHelper.GetIncrementSalary(groupID, currentMonth);
                    if (string.IsNullOrEmpty(incrementSalary))
                    {
                        incrementSalary = "0";
                    }
                    else
                    {
                        incrementSalary = base.empKeyDecrypt(incrementSalary);
                    }

                    if (!isProbation)
                    {
                        if (StorageHelper.GetInProbationTime(groupID, StorageHelper.GetLastMonth(_monthly)))
                        {
                            string probationSalary = StorageHelper.GetProbationSalary(groupID, StorageHelper.GetLastMonth(_monthly));
                            probationSalary = base.empKeyDecrypt(probationSalary);

                            if (basicSalary == "-")
                            {
                                basicSalary = probationSalary;
                            }

                            if (basicSalary == "-")
                            {
                                basicSalary = probationSalary = "0";
                            }

                            incrementSalary = Math.Round(decimal.Parse(basicSalary) - decimal.Parse(probationSalary)).ToString();
                            basicSalary = probationSalary;
                        }
                        else
                        {
                            if (basicSalary == "-")
                            {
                                basicSalary = "0";
                            }
                            
                            if (incrementSalary == "-")
                            {
                                incrementSalary = "0";
                            }

                            basicSalary = Math.Round(decimal.Parse(basicSalary) - decimal.Parse(incrementSalary)).ToString();
                        }
                    }
                    else
                    {
                        incrementSalary = "0";
                    }

                    employeeList.SubItems.Add(basicSalary);
                    employeeList.SubItems.Add(additionalAmount);
                    employeeList.SubItems.Add(incrementSalary);
                }
                else
                {
                    employeeList.SubItems.Add(base.empKeyDecrypt(base.obj2str(row["LASalary"])));
                    employeeList.SubItems.Add(base.empKeyDecrypt(base.obj2str(row["Add_Amount"])));
                    employeeList.SubItems.Add(base.empKeyDecrypt(base.obj2str(row["Incre_Amount"])));
                }

                empListView.Items.Add(employeeList);
            }
        }

        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_EmployeeData_2_empListView();
        }

        private void CleanAll()
        {
            groupID = string.Empty;
            MiddleName = string.Empty;
            FamilyName = string.Empty;
            FirstName = string.Empty;
            JobTitle = string.Empty;
            JoinDate = string.Empty;
            Write = string.Empty;
            Company = string.Empty;
            Department = string.Empty;

            Currency = string.Empty;
            Salary = string.Empty;
            AdditionalAmount = string.Empty;
            IncrementAmount = string.Empty;
        }

        private void EmpListView_Click(object sender, EventArgs e)
        {
            if (empListView.SelectedItems[0].ImageIndex == 23 || empListView.SelectedItems[0].ImageIndex == 27)
            {
                Write = "Y";
            }
            else
            {
                Write = "N";
            }

            groupID = empListView.SelectedItems[0].SubItems[3].Text.Trim();

            MiddleName = empListView.SelectedItems[0].SubItems[5].Text.Trim();
            FamilyName = empListView.SelectedItems[0].SubItems[6].Text.Trim();
            FirstName = empListView.SelectedItems[0].SubItems[4].Text.Trim();

            JobTitle = empListView.SelectedItems[0].SubItems[8].Text.Trim();
            JoinDate = empListView.SelectedItems[0].SubItems[9].Text.Trim();
            Company = empListView.SelectedItems[0].SubItems[1].Text.Trim();
            Department = empListView.SelectedItems[0].SubItems[2].Text.Trim();
            Currency = empListView.SelectedItems[0].SubItems[10].Text.Trim();

            string basicSalary = StorageHelper.GetBasicSalary(groupID, LockMonth);
            if (!string.IsNullOrEmpty(basicSalary))
            {
                bool isProbation = StorageHelper.GetInProbationTime(groupID, LockMonth);
                if (isProbation)
                {
                    basicSalary = StorageHelper.GetProbationSalary(groupID, LockMonth);
                }
                basicSalary = base.empKeyDecrypt(basicSalary);

                string additionalAmount = StorageHelper.GetAdditionalAmount(groupID, LockMonth);
                if (string.IsNullOrEmpty(additionalAmount))
                {
                    additionalAmount = "0";
                }
                else
                {
                    additionalAmount = base.empKeyDecrypt(additionalAmount);
                }

                string incrementSalary = StorageHelper.GetIncrementSalary(groupID, LockMonth);
                if (string.IsNullOrEmpty(incrementSalary))
                {
                    incrementSalary = "0";
                }
                else
                {
                    incrementSalary = base.empKeyDecrypt(incrementSalary);
                }

                if (!isProbation)
                {
                    if (StorageHelper.GetInProbationTime(groupID, StorageHelper.GetLastMonth(LockMonth)))
                    {
                        string probationSalary = StorageHelper.GetProbationSalary(groupID, StorageHelper.GetLastMonth(LockMonth));
                        probationSalary = base.empKeyDecrypt(probationSalary);

                        if (basicSalary == "-")
                        {
                            basicSalary = probationSalary;
                        }

                        if (basicSalary == "-")
                        {
                            basicSalary = probationSalary = "0";
                        }

                        incrementSalary = Math.Round(decimal.Parse(basicSalary) - decimal.Parse(probationSalary)).ToString();

                        basicSalary = probationSalary;
                        txtIncreRemark.Text = "Confirmation";
                        Salary_Increment.Enabled = false;
                    }
                    else
                    {
                        if (basicSalary == "-")
                        {
                            basicSalary = "0";
                        }

                        if (incrementSalary == "-")
                        {
                            incrementSalary = "0";
                        }

                        basicSalary = Math.Round(decimal.Parse(basicSalary) - decimal.Parse(incrementSalary)).ToString();

                        txtIncreRemark.Text = string.Empty;
                        lblSalaryName.Text = "Basic Salary";
                        Salary_Increment.Enabled = true;
                    }
                }
                else
                {
                    Salary_Increment.Enabled = false;
                    lblSalaryName.Text = "Probation";
                    incrementSalary = "0";
                }

                Salary = basicSalary;
                AdditionalAmount = additionalAmount;
                IncrementAmount = incrementSalary;
            }
            else
            {
                Salary = empListView.SelectedItems[0].SubItems[11].Text.Trim();
                AdditionalAmount = empListView.SelectedItems[0].SubItems[12].Text.Trim();
                IncrementAmount = empListView.SelectedItems[0].SubItems[13].Text.Trim();
            }
        }

        private void Load_RateHeader()
        {
            int i = 0;
            string currency;
            rateGrid.Rows.Clear();
            rateGrid.Columns.Clear();
            receivedGrid.Rows.Clear();
            receivedGrid.Columns.Clear();
            varianceGrid.Rows.Clear();
            varianceGrid.Columns.Clear();

            DataTable currencyData = tSQL.CurrencyData_SelectAll();
            DataGridViewTextBoxColumn viewColumn;
            DataGridViewTextBoxColumn viewColumn2;

            foreach (DataRow row in currencyData.Rows)
            {
                viewColumn = new DataGridViewTextBoxColumn();
                viewColumn.Name = string.Format("{0}", base.obj2str(row["Pcurrency"]));
                viewColumn.Width = 55;
                viewColumn.DataPropertyName = string.Format("{0}", base.obj2str(row["Pcurrency"]));
                viewColumn.HeaderText = base.obj2str(row["Pcurrency"]);
                viewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                rateGrid.Columns.Add(viewColumn);
                rateGrid.Columns[i].Tag = row["strFormat"].ToString(); //save strFormat
                i++;
            }

            // Tip column
            viewColumn2 = new DataGridViewTextBoxColumn();
            viewColumn2.Name = "descColumn";
            viewColumn2.Width = 70;
            viewColumn2.HeaderText = string.Empty;
            viewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            viewColumn2.Frozen = true;
            receivedGrid.Columns.Add(viewColumn2);

            currencyData = tSQL.CurrencyData_SelectAll();
            foreach (DataRow row in currencyData.Rows)
            {
                viewColumn2 = new DataGridViewTextBoxColumn();
                viewColumn2.Name = string.Format("{0}", row["Pcurrency"].ToString());
                viewColumn2.Width = 55;
                viewColumn2.DataPropertyName = string.Format("{0}", row["Pcurrency"].ToString());
                viewColumn2.HeaderText = row["Pcurrency"].ToString();
                viewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
                receivedGrid.Columns.Add(viewColumn2);
            }

            rateGrid.RowCount = 1;
            receivedGrid.RowCount = 2;

            // Load ExRate
            DataTable dt = tSQL.ExRateData_getAllbyDate(LockMonth);
            CurrencyRate.Clear();
            CurrencyRate.Add("MYR", "1");
            rateGrid.Rows[0].Cells["MYR"].Value = "1";
            for (i = 0; i < dt.Rows.Count; i++)
            {
                currency = dt.Rows[i]["exchangeCurrency"].ToString();
                if (rateGrid.Columns.Contains(currency))
                {
                    rateGrid.Rows[0].Cells[currency].Value = dt.Rows[i]["showRate"].ToString();
                    if (!CurrencyRate.ContainsKey(currency))
                    {
                        CurrencyRate.Add(currency, dt.Rows[i]["showRate"].ToString());
                    }
                }
            }
        }

        private void MarkGridCell(ref DataGridView grid, int rows, int cells, bool read_only, string txt)
        {
            grid.Rows[rows].Cells[cells].Value = txt;
            grid.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            grid.Rows[rows].Cells[cells].Style.SelectionBackColor = Control.DefaultBackColor;
            grid.Rows[rows].Cells[cells].Style.SelectionForeColor = Control.DefaultForeColor;
            grid.Rows[rows].Cells[cells].ReadOnly = !read_only;
        }

        private void ShowStatusPix()
        {
            if (Write == "Y")
            {
                statusPixY.Visible = true;
                statusPixN.Visible = false;

                if (StorageHelper.GetPayoutError(groupID, LockMonth))
                {
                    statusPixY.Visible = false;
                    statusPixE.Visible = true;
                }
                else
                {
                    statusPixY.Visible = true;
                    statusPixE.Visible = false;
                }
            }
            else if (Write == "N")
            {
                statusPixE.Visible = false;
                statusPixY.Visible = false;
                statusPixN.Visible = true;
            }
            else
            {
                statusPixY.Visible = false;
                statusPixN.Visible = false;
            }
        }

        private void Load_EmpBasicProfile()
        {
            string fieldName;
            string currencyName;
            int i;

            ShowStatusPix();

            labGroupID.Text = FormatGroupID(groupID);
            labCompany.Text = Company;
            labDept.Text = Department;
            labFName.Text = FirstName;
            labMName.Text = MiddleName;
            labFaName.Text = FamilyName;
            labDOC.Text = FormatDateOfJoined(JoinDate);

            labCurrency.Text = Currency;

            DataTable data;

            // Load salary , deduction and remark

            Salary_Basic.Text = base.Cash_cryt2txt(Salary);
            Salary_Increment.Text = base.Cash_cryt2txt(IncrementAmount);
            Salary_Addition.Text = base.Cash_cryt2txt(AdditionalAmount);

            Salary_DU.Text = string.Empty;
            Salary_DA.Text = string.Empty;
            Salary_DL.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtOther.Text = string.Empty;
            txtBasicRemark.Text = string.Empty;
            
            if (Write == "Y")
            {
                // Load keyin value!
                data = tSQL.KeyData_getDeduction(SelectMonth3.Text, groupID);
                if (data.Rows.Count > 0)
                {
                    Salary_Basic.Text = base.payKeyDecrypt(base.obj2str(data.Rows[0]["Prob_Salary"]));
                    Salary_Increment.Text = base.payKeyDecrypt(base.obj2str(data.Rows[0]["Incre_Amount"]));
                    Salary_Addition.Text = base.payKeyDecrypt(base.obj2str(data.Rows[0]["Add_Amount"]));
                    Salary_DUM.Text = base.obj2str(data.Rows[0]["Unpaidcury"]);
                    Salary_DU.Text = base.payKeyDecrypt(base.obj2str(data.Rows[0]["Unpaid_Amount"]));
                    Salary_DAM.Text = base.obj2str(data.Rows[0]["Advcury"]);
                    Salary_DA.Text = base.payKeyDecrypt(base.obj2str(data.Rows[0]["Adv_Amount"]));
                    Salary_DLM.Text = base.obj2str(data.Rows[0]["Loancury"]);
                    Salary_DL.Text = base.payKeyDecrypt(base.obj2str(data.Rows[0]["Loan_Amount"]));
                    txtRemark.Text = base.obj2str(data.Rows[0]["Remark"]);
                    txtOther.Text = base.obj2str(data.Rows[0]["OtherRemark"]);
                    txtBasicRemark.Text = base.obj2str(data.Rows[0]["BasicSalaryRemark"]);
                    txtIncreRemark.Text = base.obj2str(data.Rows[0]["IncreRemark"]);

                    bool isProbation = false;
                    string basicSalary = StorageHelper.GetBasicSalary(groupID, LockMonth);
                    if (!string.IsNullOrEmpty(basicSalary))
                    {
                        txtUnpaidDays.Value = StorageHelper.GetUnpaidDays(groupID, LockMonth);

                        isProbation = StorageHelper.GetInProbationTime(groupID, LockMonth);
                        if (isProbation)
                        {
                            basicSalary = StorageHelper.GetProbationSalary(groupID, LockMonth);
                        }
                        basicSalary = base.empKeyDecrypt(basicSalary);

                        string additionalAmount = StorageHelper.GetAdditionalAmount(groupID, LockMonth);
                        if (string.IsNullOrEmpty(additionalAmount))
                        {
                            additionalAmount = "0";
                        }
                        else
                        {
                            additionalAmount = base.empKeyDecrypt(additionalAmount);
                        }

                        string incrementSalary = StorageHelper.GetIncrementSalary(groupID, LockMonth);
                        incrementSalary = base.empKeyDecrypt(incrementSalary);

                        if (!isProbation)
                        {
                            if (StorageHelper.GetInProbationTime(groupID, StorageHelper.GetLastMonth(LockMonth)))
                            {
                                string probationSalary = StorageHelper.GetProbationSalary(groupID, StorageHelper.GetLastMonth(LockMonth));
                                probationSalary = base.empKeyDecrypt(probationSalary);

                                if (basicSalary == "-")
                                {
                                    basicSalary = probationSalary;
                                }

                                if (basicSalary == "-")
                                {
                                    basicSalary = probationSalary = "0";
                                }

                                incrementSalary = Math.Round(decimal.Parse(basicSalary) - decimal.Parse(probationSalary)).ToString();

                                basicSalary = probationSalary;
                                txtIncreRemark.Text = "Confirmation";
                                Salary_Increment.Enabled = false;
                            }
                            else
                            {
                                if (basicSalary == "-")
                                {
                                    basicSalary = "0";
                                }

                                if (incrementSalary == "-")
                                {
                                    incrementSalary = "0";
                                }

                                basicSalary = Math.Round(decimal.Parse(basicSalary) - decimal.Parse(incrementSalary)).ToString();
                                txtIncreRemark.Text = string.Empty;
                                lblSalaryName.Text = "Basic Salary";
                                Salary_Increment.Enabled = true;
                            }

                            Salary_Basic.Text = basicSalary;
                            Salary_Increment.Text = incrementSalary;
                        }
                        else 
                        {
                            lblSalaryName.Text = "Probation";
                            Salary_Basic.Text = basicSalary;
                            Salary_Increment.Text = "0";
                        }

                        Salary_Addition.Text = additionalAmount;
                    }
                }
            }
            else
            {
                Salary_DUM.Text = Currency;
                Salary_DAM.Text = Currency;
                Salary_DLM.Text = Currency;
            }

            txtMonthlyWorkDays.Value = StorageHelper.GetKeyinWorkDays(groupID, LockMonth);
            btnSaveWorkDays.Text = string.Format(btnSaveWorkDays.Text, txtMonthlyWorkDays.Value);

            // Load personal Rate
            txtCurrency.Text = Currency;  // Call rate-event
            RunCurrencyRate.Clear();
            for (i = 0; i < rateGrid.Columns.Count; i++)
            {
                currencyName = rateGrid.Columns[i].Name;
                RunCurrencyRate.Add(currencyName, obj2str(rateGrid.Rows[0].Cells[currencyName].Value));
            }

            // Load Received Reference
            receivedGrid.Rows.Clear();
            receivedGrid.RowCount = 2;

            MarkGridCell(ref receivedGrid, 0, 0, false, "Received");
            MarkGridCell(ref receivedGrid, 1, 0, false, "Balance");

            // Load received 2st row Style
            for (i = 1; i < receivedGrid.Columns.Count; i++)
            {
                MarkGridCell(ref receivedGrid, 1, i, false, "");
            }

            if (Write != "Y")
            {
                data = tSQL.ReceivedData_getOne(groupID);
            }
            else
            {
                //Load keyin value!
                data = tSQL.KeyData_ReceivedList(groupID, SelectMonth3.Text);
            }

            for (i = 0; i < data.Rows.Count; i++)
            {
                fieldName = data.Rows[i]["Pcurrency"].ToString();
                if (receivedGrid.Columns.Contains(fieldName))
                {
                    if (Write != "Y")
                    {
                        receivedGrid.Rows[0].Cells[fieldName].Value = base.empKeyDecrypt(base.obj2str(data.Rows[i]["Amount"]));
                    }
                    else
                    {
                        // Load keyin value!
                        receivedGrid.Rows[0].Cells[fieldName].Value = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Amount"]));
                    }
                }
            }

            // Load bank grid
            bankGrid.Rows.Clear();
            object[] Ary;
            if (Write != "Y")
            {
                data = tSQL.BankData_getBankInList(groupID);
                for (i = 0; i < data.Rows.Count; i++)
                {
                    Ary = new object[] { 
                            data.Rows[i]["payoutRelation"].ToString(), 
                            data.Rows[i]["AcHolder"].ToString(), 
                            data.Rows[i]["Bank"].ToString(), 
                            data.Rows[i]["AcNumber"].ToString() ,
                            data.Rows[i]["Cury"].ToString() ,
                            "0"
                          };
                    bankGrid.Rows.Add(Ary);
                    SetAmountVariance2ReceivedGrid(data.Rows[i]["Cury"].ToString(), 0);
                }
            }
            else
            {
                // Load keyin value!
                data = tSQL.KeyData_getBankInList(groupID, SelectMonth3.Text);
                for (i = 0; i < data.Rows.Count; i++)
                {
                    Ary = new object[] { 
                            data.Rows[i]["payoutRelation"].ToString(), 
                            data.Rows[i]["AcHolder"].ToString(), 
                            data.Rows[i]["Bank"].ToString(), 
                            data.Rows[i]["AcNumber"].ToString() ,
                            data.Rows[i]["Cury"].ToString() ,
                            base.payKeyDecrypt(base.obj2str(data.Rows[i]["Amount"]))
                          };
                    bankGrid.Rows.Add(Ary);
                    SetAmountVariance2ReceivedGrid(data.Rows[i]["Cury"].ToString(), base.payKeyDecrypt(base.obj2str(data.Rows[i]["Amount"])));
                }
            }

            ExistedError = CheckVariance_receivedGrid();
            ModifyGrid();
        }

        private bool CheckVariance_receivedGrid()
        {
            int i;
            double _base;
            double _compare;
            string _coldName;
            float fontSize = receivedGrid.DefaultCellStyle.Font.Size;
            string fontName = receivedGrid.DefaultCellStyle.Font.Name;

            bool existedError = false;

            for (i = 1; i < receivedGrid.Columns.Count; i++)
            {
                _coldName = receivedGrid.Columns[i].Name;
                _base = base.txt2double(base.obj2str(receivedGrid.Rows[0].Cells[_coldName].Value));
                _compare = base.txt2double(base.obj2str(receivedGrid.Rows[1].Cells[_coldName].Value));

                if (_base != _compare)
                {
                    receivedGrid.Rows[1].Cells[_coldName].Style.ForeColor = Color.Red;
                    receivedGrid.Rows[1].Cells[_coldName].Style.SelectionForeColor = Color.Red;
                    receivedGrid.Rows[1].Cells[_coldName].Style.Font = new Font(fontName, fontSize, System.Drawing.FontStyle.Bold);

                    existedError = true;
                }
                else
                {
                    receivedGrid.Rows[1].Cells[_coldName].Style.ForeColor = Control.DefaultForeColor;
                    receivedGrid.Rows[1].Cells[_coldName].Style.SelectionForeColor = Control.DefaultForeColor;
                    receivedGrid.Rows[1].Cells[_coldName].Style.Font = new Font(fontName, fontSize, System.Drawing.FontStyle.Regular);
                }
            }

            return existedError;
        }

        private void SetAmountVariance2ReceivedGrid(string currencyHeadName, object addAmount)
        {
            if (receivedGrid.Columns.Contains(currencyHeadName))
            {
                double _addAmount = base.txt2double(base.obj2str(addAmount));
                double _secondRow = base.txt2double(base.obj2str(receivedGrid.Rows[1].Cells[currencyHeadName].Value));
                double _total = Math.Round((_addAmount + _secondRow), 0, MidpointRounding.AwayFromZero);
                receivedGrid.Rows[1].Cells[currencyHeadName].Value = _total.ToString();
            }
        }

        private void Salary_DL_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void Salary_DU_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private double ExchangeRateValue(object currency)
        {
            double value = 1;
            if (currency != null)
            {
                value = txt2double(base.obj2str(RunCurrencyRate[currency]));
            }
            return value;
        }

        private void Calculation()
        {
            double _Gross = 0;
            double _Deduction = 0;

            // Salary
            _Gross += base.txt2double(Salary_Basic.Text);
            _Gross += base.txt2double(Salary_Increment.Text);
            _Gross += base.txt2double(Salary_Addition.Text);

            double _unpaid = base.txt2double(Salary_DU.Text) * ExchangeRateValue(Salary_DUM.SelectedItem);
            double _adv = base.txt2double(Salary_DA.Text) * ExchangeRateValue(Salary_DAM.SelectedItem);
            double _loan = base.txt2double(Salary_DL.Text) * ExchangeRateValue(Salary_DLM.SelectedItem);

            double _unpaid_leave = (double)txtDeductiveAmt.Value;

            _Deduction = _unpaid + _adv + _loan + _unpaid_leave;

            txtTotalDeduction.Text = RoundDouble2Txt(_Deduction);
            txtTotalAddition.Text = RoundDouble2Txt(base.txt2double(Salary_Increment.Text) + base.txt2double(Salary_Addition.Text));

            _Deduction = base.txt2double(txtTotalDeduction.Text);

            txtNetAmount.Text = RoundDouble2Txt(_Gross - _Deduction);

            // Received
            int i;
            string columnName;
            object money;
            string xRate;
            double subAmount;
            double _varianceBase = 0;

            for (i = 1; i < receivedGrid.ColumnCount; i++)
            {
                columnName = receivedGrid.Columns[i].Name;
                money = receivedGrid.Rows[0].Cells[columnName].Value;
                if (RunCurrencyRate.Contains(columnName))
                {
                    xRate = RunCurrencyRate[columnName].ToString();
                }
                else
                {
                    xRate = "0";
                }
                subAmount = base.txt2double(base.obj2str(money));
                if (subAmount != 0 && xRate != "0")
                {
                    _varianceBase += subAmount * txt2double(xRate);
                }
            }

            txtVarianceBase.Text = RoundDouble2Txt(base.txt2double(txtNetAmount.Text) - _varianceBase);

            // Clean
            for (i = 1; i < receivedGrid.ColumnCount; i++)
            {
                receivedGrid.Rows[1].Cells[i].Value = string.Empty;
            }
            // Variance base currency
            for (i = 0; i < bankGrid.Rows.Count; i++)
            {
                columnName = base.obj2str(bankGrid.Rows[i].Cells["ccPCurrency"].Value);
                SetAmountVariance2ReceivedGrid(columnName, bankGrid.Rows[i].Cells["ccAmount"].Value);
            }

            // Variance color
            ExistedError = CheckVariance_receivedGrid();
            UpdateVarianceGrid();
        }

        private string RoundDouble2Txt(double d)
        {
            d = Math.Round(d, 0, MidpointRounding.AwayFromZero);
            return d.ToString();
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            __groupID = groupID;
            PaymentRecord record = new PaymentRecord();
            try
            {
                record.ShowDialog();
            }
            catch { }
        }

        private void ReceivedGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Calculation();
        }
        private void ReceivedGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculation();
        }
        private void ReceivedGrid_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            Calculation();
        }
        private void bankGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Calculation();
        }
        private void bankGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculation();
        }
        private void bankGrid_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            Calculation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save
            bool flag;
            int i;
            string columnName;

            string action;
            string __monthly = SelectMonth3.Text;
            string __GroupID = groupID;
            string __Currency = labCurrency.Text;
            string __Salary = Salary_Basic.Text;
            string __Increment_Amount = Salary_Increment.Text;
            string __Add_Amount = Salary_Addition.Text;

            // Save additional amount
            StorageHelper.SetAdditionalAmount(groupID, LockMonth, base.empKeyEncryt(__Add_Amount));

            // Save increment this month
            StorageHelper.SetIncrementSalary(groupID, LockMonth, base.empKeyEncryt(__Increment_Amount));

            // Save unpaid leave this month
            StorageHelper.SetUnpaidDays(groupID, LockMonth, (int)txtUnpaidDays.Value);

            // Save total deduction
            StorageHelper.SetTotalDeduction(groupID, LockMonth, int.Parse(txtTotalDeduction.Text));

            // Save keyin works day
            StorageHelper.SetKeyinWorkDays(groupID, LockMonth, (int)txtMonthlyWorkDays.Value);

            if (txtVarianceBase.ForeColor == Color.Red || txtVarianceBase.Text != "0" || CheckVariance_receivedGrid())
            {
                // Save payment status
                StorageHelper.SetPayoutError(groupID, LockMonth, true);
            }
            else
            {
                // Save payment status
                StorageHelper.SetPayoutError(groupID, LockMonth, false);
            }

            if (string.IsNullOrEmpty(StorageHelper.GetProbationSalary(groupID, LockMonth)))
            {
                if (__Increment_Amount == "-")
                {
                    __Increment_Amount = "0";
                }

                if (__Salary == "-")
                {
                    __Salary = "0";
                }

                // Save basic salary (with increment already) for next month
                StorageHelper.SetBasicSalary(groupID, StorageHelper.GetNextMonth(LockMonth), base.empKeyEncryt(
                    Math.Round(decimal.Parse(__Increment_Amount) + decimal.Parse(__Salary)).ToString()
                    ));
                // Set increment next month to zero
                StorageHelper.SetIncrementSalary(groupID, StorageHelper.GetNextMonth(LockMonth), base.empKeyEncryt("0"));
                // Copy probation salary to next month
                string probationSalaryThisMonth = StorageHelper.GetProbationSalary(groupID, LockMonth);
                StorageHelper.SetProbationSalary(groupID, StorageHelper.GetNextMonth(LockMonth), probationSalaryThisMonth);
                // Copy probation time
                bool probationTimeThisMonth = StorageHelper.GetInProbationTime(groupID, LockMonth);
                StorageHelper.SetInProbationTime(groupID, StorageHelper.GetNextMonth(LockMonth), probationTimeThisMonth);
            }

            string __Gross_Total = "0";
            string __Unpaidcury = ((Salary_DUM.SelectedItem == null) ? "0" : Salary_DUM.SelectedItem.ToString());
            string __Unpaid_Amount = Salary_DU.Text.Trim();
            string __Advcury = ((Salary_DAM.SelectedItem == null) ? "0" : Salary_DAM.SelectedItem.ToString());
            string __Adv_Amount = Salary_DA.Text.Trim();
            string __Loancury = ((Salary_DLM.SelectedItem == null) ? "0" : Salary_DLM.SelectedItem.ToString());
            string __Loan_Amount = Salary_DL.Text.Trim();
            string __Deduction_Total = txtTotalDeduction.Text;
            string __Net_Salary = txtNetAmount.Text;
            string __Show_VarianceRM = txtVarianceBase.Text;
            string __Remark = txtRemark.Text.Trim();
            string __OtherRemark = txtOther.Text.Trim();
            string __BasicRemark = txtBasicRemark.Text.Trim();
            string __IncreRemark = this.GetIDFromBox(txtIncreRemark);

            string MYR_Gross;
            string MYR_Deduction;
            string MYR_Net;
            double _RateToMYR = 1;

            string __Bank_MYRAmount;


            __Gross_Total = Convert.ToString(txt2double(__Salary) + txt2double(__Increment_Amount) + txt2double(__Add_Amount));

            if (__Currency == "MYR")
            {
                MYR_Gross = __Gross_Total;
                MYR_Deduction = __Deduction_Total;
                MYR_Net = __Net_Salary;
            }
            else
            {
                // need MYR
                _RateToMYR = base.obj2double(CurrencyRate[__Currency]);
                if (_RateToMYR == 0) _RateToMYR = 1;
                MYR_Gross = Convert.ToString(Math.Round(base.txt2double(__Gross_Total) * _RateToMYR, 0, MidpointRounding.AwayFromZero));
                MYR_Deduction = Convert.ToString(Math.Round(base.txt2double(__Deduction_Total) * _RateToMYR, 0, MidpointRounding.AwayFromZero));
                MYR_Net = Convert.ToString(base.txt2double(MYR_Gross) - base.txt2double(MYR_Deduction));
            }

            if (Write != "Y")
            {
                action = "Insert";
            }
            else
            {
                action = "Update";
            }

            // Main
            __Salary = base.payKeyEncryt(__Salary);
            __Increment_Amount = base.payKeyEncryt(__Increment_Amount);
            __Add_Amount = base.payKeyEncryt(__Add_Amount);
            __Gross_Total = base.payKeyEncryt(__Gross_Total);
            __Unpaid_Amount = base.payKeyEncryt(__Unpaid_Amount);
            __Adv_Amount = base.payKeyEncryt(__Adv_Amount);
            __Loan_Amount = base.payKeyEncryt(__Loan_Amount);
            __Deduction_Total = base.payKeyEncryt(__Deduction_Total);
            __Net_Salary = base.payKeyEncryt(__Net_Salary);
            __Show_VarianceRM = base.payKeyEncryt(__Show_VarianceRM);
            MYR_Gross = base.payKeyEncryt(MYR_Gross);
            MYR_Deduction = base.payKeyEncryt(MYR_Deduction);
            MYR_Net = base.payKeyEncryt(MYR_Net);

            flag = tSQL.KeyData_InsertUpdate(action, __monthly, __GroupID, __Currency, __Salary, __Increment_Amount, __Add_Amount,
                                   __Gross_Total, __Unpaidcury, __Unpaid_Amount, __Advcury, __Adv_Amount, __Loancury,
                                   __Loan_Amount, __Deduction_Total, __Net_Salary, __Show_VarianceRM, __Remark, MYR_Gross, MYR_Deduction, MYR_Net, Company, Department, __OtherRemark, __IncreRemark, __BasicRemark);
            // Received
            tSQL.KeyData_ReceivedInsert("Delete", __monthly, __GroupID, string.Empty, string.Empty, string.Empty, "");
            for (i = 1; i < receivedGrid.ColumnCount; i++)
            {
                columnName = receivedGrid.Columns[i].Name;
                if (receivedGrid.Rows[0].Cells[columnName].Value != null)
                {
                    __Bank_MYRAmount = base.payKeyEncryt(base.obj2str(receivedGrid.Rows[0].Cells[i].Value));
                    flag = flag && tSQL.KeyData_ReceivedInsert("Insert", __monthly, __GroupID, columnName, __Bank_MYRAmount, Company, Department);
                }
            }

            // Bank      
            object __Amount;
            object __AcHolder;
            object __Bank;
            object __AcNumber;
            object __PayoutRelation;
            tSQL.KeyData_BankInInsert("Delete", __monthly, __GroupID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            for (i = 0; i < bankGrid.Rows.Count; i++)
            {
                //string __monthly
                //string __GroupID
                __Currency = string.Empty;
                __PayoutRelation = bankGrid.Rows[i].Cells["ccpayoutRelation"].Value;
                __AcHolder = bankGrid.Rows[i].Cells["ccAcHolder"].Value;
                __Bank = bankGrid.Rows[i].Cells["ccBank"].Value;
                __AcNumber = bankGrid.Rows[i].Cells["ccAcNumber"].Value;
                __Amount = bankGrid.Rows[i].Cells["ccAmount"].Value;

                __PayoutRelation = ((__PayoutRelation == null) ? string.Empty : __PayoutRelation.ToString());
                __AcHolder = ((__AcHolder == null) ? string.Empty : __AcHolder.ToString());
                __Bank = ((__Bank == null) ? string.Empty : __Bank.ToString());
                __AcNumber = ((__AcNumber == null) ? string.Empty : __AcNumber.ToString());
                __Amount = ((__Amount == null) ? "0" : __Amount.ToString());

                __Bank_MYRAmount = base.calculate_Amount_byDiffCurrency(this.GetRateByHSBypRelation(__PayoutRelation.ToString()), "1", __Amount.ToString()); //MYR rate = 1;

                flag = flag && tSQL.KeyData_BankInInsert("Insert", __monthly, __GroupID, __Currency, base.payKeyEncryt(base.obj2str(__Amount)), __AcHolder.ToString(),
                                                        __Bank.ToString(), __AcNumber.ToString(), __PayoutRelation.ToString(), Company, Department, base.payKeyEncryt(base.obj2str(__Bank_MYRAmount)));
            }


            if (flag)
            {
                MessageBox.Show("Saved.", "Save Payout", MessageBoxButtons.OK);
                // Refresh
                Load_EmployeeData_2_empListView();
                Write = "Y";
                ShowStatusPix();
            }
            else
            {
                MessageBox.Show(tSQL.errMessage, "Save Payout", MessageBoxButtons.OK);
            }
        }

        private string GetRateByHSBypRelation(string relation)
        {
            string currency = string.Empty;
            string payout = string.Empty;
            string rate = "0";
            int pos = -1;

            if (relation.Trim() != string.Empty)
            {
                pos = relation.LastIndexOf("(");
                if (pos != -1)
                {
                    payout = relation.Substring(pos + 1);
                    currency = payout.Split('|')[2];
                    if (CurrencyRate.ContainsKey(currency))
                    {
                        rate = base.obj2str(CurrencyRate[currency]);
                    }
                }
            }

            return rate;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string __monthly = SelectMonth3.Text;
            string __GroupID = groupID;

            result = MessageBox.Show("This action cannot be undone. \r\nAre you sure want to reset this record ?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Write = "N";

                // Main
                tSQL.KeyData_Delete(__monthly, __GroupID);

                // Received
                tSQL.KeyData_ReceivedInsert("Delete", __monthly, __GroupID, string.Empty, string.Empty, string.Empty, string.Empty);

                // Bank
                tSQL.KeyData_BankInInsert("Delete", __monthly, __GroupID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                MessageBox.Show("Done.", "Reset", MessageBoxButtons.OK);
                Load_EmployeeData_2_empListView();

                ChangePage(Step.Keyin);
            }
        }

        // Change Rate!
        private void txtCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string currency;
            string currencyName;
            string _format;
            double _base;
            double _rate;
            double _newRate;

            if (txtCurrency.SelectedItem != null)
            {
                currency = txtCurrency.SelectedItem.ToString();
                if (currency == "MYR")
                {
                    for (i = 0; i < rateGrid.Columns.Count; i++)
                    {
                        currencyName = rateGrid.Columns[i].Name;
                        rateGrid.Rows[0].Cells[currencyName].Value = CurrencyRate[currencyName];
                    }
                }
                else
                {
                    // Change!
                    _base = txt2double(base.obj2str(CurrencyRate[currency]));
                    for (i = 0; i < rateGrid.Columns.Count; i++)
                    {
                        currencyName = rateGrid.Columns[i].Name;
                        _rate = txt2double(base.obj2str(CurrencyRate[currencyName]));
                        _format = base.obj2str(rateGrid.Columns[i].Tag);

                        if (_base != 0)
                        {
                            _newRate = (1 / _base * _rate);
                        }
                        else
                        {
                            _newRate = 0;
                        }

                        rateGrid.Rows[0].Cells[currencyName].Value = string.Format(_format, _newRate);
                    }
                }
            }
            else
            {
                txtCurrency.Text = string.Empty;
            }
        }

        // Employee list refresh
        private void btnReload_Click(object sender, EventArgs e)
        {
            Load_EmployeeData_2_empListView();
            ChangePage(Step.Keyin);
        }

        private void Salary_NET_TextChanged(object sender, EventArgs e)
        {
            if (txtNetAmount.Text.IndexOf("-") != -1)
            {
                txtNetAmount.ForeColor = Color.Red;
            }
            else
            {
                txtNetAmount.ForeColor = Color.Blue;
            }
        }

        private void VarianceRM_TextChanged(object sender, EventArgs e)
        {
            if (txtVarianceBase.Text.IndexOf("-") != -1)
            {
                txtVarianceBase.ForeColor = Color.Red;
            }
            else
            {
                txtVarianceBase.ForeColor = Color.Blue;
            }
        }

        private void Salary_DUM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void Salary_DAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void Salary_DLM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void EmpListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Go to key-in form
            ChangePage(Step.Keyin);
        }

        private void EmpListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (empListView.SelectedItems.Count > 0)
                {
                    EmpListView_Click(null, null);
                    ChangePage(Step.Keyin);
                }
            }
        }

        private void txtUnpaidDays_ValueChanged(object sender, EventArgs e)
        {
            if (txtUnpaidDays.Value >= txtMonthlyWorkDays.Value)
            {
                txtUnpaidDays.Value = txtMonthlyWorkDays.Value;
            }

            decimal deductiveAmount = 0;
            decimal salary = int.Parse(Salary_Basic.Text) + int.Parse(Salary_Increment.Text);
            int workDays = (int)txtMonthlyWorkDays.Value;
            int unpaidLeave = (int)txtUnpaidDays.Value;

            deductiveAmount = (salary / workDays) * unpaidLeave;
            txtDeductiveAmt.Value = Math.Round(deductiveAmount);

            Calculation();
        }

        private void btnSaveWorkDays_Click(object sender, EventArgs e)
        {
            int oldValue = StorageHelper.GetMonthlyWorkDays(LockMonth);

            if (oldValue != (int)txtMonthlyWorkDays.Value)
            {
                DialogResult result = MessageBox.Show(
                    string.Format("This action may affect new payslips on {0}.\r\nAre you sure want to continue ?",
                    base.YYMM2EnglishDate(LockMonth)),
                    "Save work days warning", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);

                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    txtMonthlyWorkDays.Value = oldValue;
                    return;
                }
            }

            StorageHelper.SetMonthlyWorkDays((int)txtMonthlyWorkDays.Value, LockMonth);
            Calculation();
            MessageBox.Show(txtMonthlyWorkDays.Value + string.Format(" work days has been applied for all employees on {0}.", base.YYMM2EnglishDate(LockMonth)), "Monthly work days", MessageBoxButtons.OK);
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            ChangePage(Step.SelectEmployee);
        }

        private void btnKeyin_Click(object sender, EventArgs e)
        {
            ChangePage(Step.Keyin);
        }

        private void Salary_Increment_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void Salary_Addition_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void txtMonthlyWorkDays_ValueChanged(object sender, EventArgs e)
        {
            btnSaveWorkDays.Text = string.Format(FormatMonthlyWorkDaysText, txtMonthlyWorkDays.Value);
            Calculation();
        }

        /// <summary>
        /// Make grid available currencies only.
        /// </summary>
        private void ModifyGrid()
        { 
            // receivedGrid
            // varianceGrid

            varianceGrid.Columns.Clear();
            varianceGrid.Rows.Clear();

            List<string> availableCurrencies = new List<string>();
            foreach (DataGridViewRow row in bankGrid.Rows)
            {
                string currency = row.Cells[4].Value.ToString();
                availableCurrencies.Add(currency);
            }

            List<string> removedColumns = new List<string>();
            foreach (DataGridViewColumn column in receivedGrid.Columns)
            {
                if (!availableCurrencies.Contains(column.HeaderText))
                {
                    removedColumns.Add(column.Name);
                }
                else
                {
                    DataGridViewColumn newColumn = (DataGridViewColumn) column.Clone();
                    varianceGrid.Columns.Add(newColumn);
                }
            }

            // Hide unvailable currencies
            foreach (string name in removedColumns)
            {
                receivedGrid.Columns[name].Visible = false;
            }

        }

        /// <summary>
        /// Update variance grid base on txtVarianceBase value
        /// </summary>
        private void UpdateVarianceGrid()
        {
            if (varianceGrid.Columns.Count == 0)
            {
                return;
            }

            double varianceBase = double.Parse(txtVarianceBase.Text);
            if (varianceGrid.Rows.Count == 0)
            { 
                varianceGrid.Rows.Add();
            }

            DataGridViewRow row = varianceGrid.Rows[0];
            int count = row.Cells.Count;

            for (int i = 0; i < count; i++)
            {
                string currency = varianceGrid.Columns[i].Name;
                string format = rateGrid.Columns[currency].Tag + string.Empty;
                string variance = string.Format(
                    format, 
                    ((Currency == currency) 
                    ? 
                    1 
                    :
                   (1 / double.Parse("0" + CurrencyRate[currency]) * double.Parse("0" + CurrencyRate[Currency])))
                        * varianceBase);
                row.Cells[i].Value = variance;
            }
        }

        private void empListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortedColumnId)
            {
                sortedColumnId = e.Column;
                empListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                empListView.Sorting = empListView.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }

            empListView.Sort();
            empListView.ListViewItemSorter = new ListViewItemComparer(e.Column, empListView.Sorting);
        }
    }
}