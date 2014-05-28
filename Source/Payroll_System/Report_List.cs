using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class Report_List : First
    {
        TSQL tSQL;
        DataTable CurrencyData;
        int HeadBankCountMax;
        int HeadCount = -1;
        string thisMonthy;

        string TextAll = "======= All =======";

        Dictionary<string, Dictionary<string, string>> gName = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, string> hColumn;

        int EmpColCount = 0;
        int SalaryColCount = 0;
        int ReceivedColCount = 0;
        int BankColCount = 0;

        #region =====================  Form Load ======================

        public string addHeadCount()
        {
            HeadCount++;
            return HeadCount.ToString();
        }

        public Report_List()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_List_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.RemoteDBAbsPath());

            thisMonthy = tSQL.LockData_openMonth();
            CurrencyData = tSQL.Report_CurrencyData_SelectAll(thisMonthy);
            HeadBankCountMax = tSQL.KeyData_getBankInCountMax(thisMonthy);

            load_CompanyListBox();
            load_DeptListBox(companyBox, DeptBox);

            initHeadEmp();
            initHeadSalary();
            initHeadReceiveCury();
            initVarianceRM();
            initHeadBank();
            initHeadRemark();

            CreateHead();

        }

        private void load_CompanyListBox()
        {
            DataTable tb;
            companyBox.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();
            string format;
            companyBox.Items.Add(TextAll);
            foreach (DataRow row in tb.Rows)
            {
                format = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                companyBox.Items.Add(format);
            }
            if (companyBox.Items.Count > 0)
                companyBox.SelectedIndex = 0;
            else
                companyBox.Text = string.Empty;
        }

        private void load_DeptListBox(ComboBox combo, ComboBox deptBox)
        {
            DataTable data;
            deptBox.Items.Clear();
            data = tSQL.DeptData_SelectAll(this.get_IDformBox(combo));
            string formatStr;
            deptBox.Items.Add(TextAll);
            foreach (DataRow row in data.Rows)
            {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                deptBox.Items.Add(formatStr);
            }
            if (deptBox.Items.Count > 0)
                deptBox.SelectedIndex = 0;
            else
                deptBox.Text = string.Empty;
        }

        private string get_IDformBox(ComboBox selection)
        {
            string value = string.Empty;
            if (selection.Items.Count > 0 && selection.SelectedItem != null)
            {
                if (selection.SelectedItem.ToString() != TextAll)
                    value = selection.SelectedItem.ToString();
            }
            return value;
        }

        #endregion =====================  Form Load ======================

        private void GenerateItem(string _Group, string _hHeaderText, string _hWidth, string _hSqlColumn, string _hIsCurrency)
        {
            hColumn = new Dictionary<string, string>();
            hColumn.Add("HeaderText", _hHeaderText);
            hColumn.Add("SqlColumn", _hSqlColumn);
            hColumn.Add("Width", _hWidth);
            hColumn.Add("ISCurrency", _hIsCurrency);

            gName.Add(_Group, hColumn);
        }

        // Head
        private void initHeadEmp()
        {
            GenerateItem(addHeadCount(), "No", "40", "", "N");
            GenerateItem(addHeadCount(), "Company", "70", "CompanyID", "N");
            GenerateItem(addHeadCount(), "Department", "60", "DepartmentID", "N");
            GenerateItem(addHeadCount(), "Name", "70", "eName", "N");
            GenerateItem(addHeadCount(), "Nick", "70", "CallName", "N");
            GenerateItem(addHeadCount(), "Doc", "70", "DateJoined", "N");

            EmpColCount = 6;
        }

        private void initHeadSalary()
        {
            GenerateItem(addHeadCount(), "Salary Currency", "40", "Pcurrency", "N");
            GenerateItem(addHeadCount(), "Probation Salary", "60", "Prob_Salary", "Y");
            GenerateItem(addHeadCount(), "Increment Salary", "60", "Incre_Amount", "Y");
            GenerateItem(addHeadCount(), "Additional Salary", "60", "Add_Amount", "Y");
            GenerateItem(addHeadCount(), "Total Gross Salary", "60", "Gross_Total", "Y");
            GenerateItem(addHeadCount(), "Unpaid Currency", "40", "Unpaidcury", "N");
            GenerateItem(addHeadCount(), "Unpaid Leave", "60", "Unpaid_Amount", "Y");
            GenerateItem(addHeadCount(), "Adv Currency", "40", "Advcury", "N");
            GenerateItem(addHeadCount(), "Salary Adv", "60", "Adv_Amount", "Y");
            GenerateItem(addHeadCount(), "Others Currency", "40", "Loancury", "N");
            GenerateItem(addHeadCount(), "Others", "60", "Loan_Amount", "Y");
            GenerateItem(addHeadCount(), "Total Net Salary", "60", "Net_Salary", "Y");

            SalaryColCount = 12;

        }

        private void initHeadReceiveCury()
        {
            int i;
            for (i = 0; i < CurrencyData.Rows.Count; i++)
            {
                GenerateItem(addHeadCount(), "Rec-" + CurrencyData.Rows[i]["Pcurrency"].ToString(), "60", CurrencyData.Rows[i]["Pcurrency"].ToString(), "Y"); // notice [Query] Received!
            }

            ReceivedColCount = i + 1;
        }

        private void initVarianceRM()
        {
            // add Variacne column
            GenerateItem(addHeadCount(), "C/Rate Variance", "60", "Show_VarianceRM", "Y");
        }

        private void initHeadBank()
        {
            int i;
            for (i = 0; i < HeadBankCountMax; i++)
            {
                GenerateItem(addHeadCount(), "A/c Holder", "60", "AcHolder", "N");
                GenerateItem(addHeadCount(), "Bank", "40", "Bank", "N");
                GenerateItem(addHeadCount(), "A/c Number", "60", "AcNumber", "N");
                GenerateItem(addHeadCount(), "Amount", "60", "Amount", "Y");
                GenerateItem(addHeadCount(), "Payout Location", "80", "payoutRelation", "N");
            }
            BankColCount = i + 1;
        }

        private void initHeadRemark()
        {
            GenerateItem(addHeadCount(), "Remark", "60", "Remark", "N");
            GenerateItem(addHeadCount(), "Basic Salary Remark", "90", "Basic Salary Remark", "N");
            GenerateItem(addHeadCount(), "Increment Remark", "80", "Increment Remark", "N");
            GenerateItem(addHeadCount(), "Other Remark", "70", "Other Remark", "N");
        }

        private void CreateHead()
        {
            int i;
            string idx;
            bankGrid.Columns.Clear();
            DataGridViewTextBoxColumn dvc;

            for (i = 0; i <= HeadCount; i++)
            {
                idx = i.ToString();
                dvc = new DataGridViewTextBoxColumn();
                dvc.Name = string.Format("cc{0}", gName[idx]["HeaderText"]);
                dvc.Width = Convert.ToInt16(gName[idx]["Width"]);
                dvc.HeaderText = string.Format("{0}", gName[idx]["HeaderText"]);
                bankGrid.Columns.Add(dvc);
            }

        }

        // Query
        private void btnQuery_Click(object sender, EventArgs e)
        {
            int row;
            int col = 0;
            int idx;
            int r;
            string groupID;
            string fieldName;
            string isCurrency;
            int headColCount = bankGrid.Columns.Count;
            string _CompanyBox = get_IDformBox(companyBox);
            string _DeptBox = get_IDformBox(DeptBox);
            if (_CompanyBox == TextAll) _CompanyBox = string.Empty;
            if (_DeptBox == TextAll) _DeptBox = string.Empty;

            bankGrid.Rows.Clear();

            DataTable employeeData = tSQL.Report_getEmpList(thisMonthy, _CompanyBox, _DeptBox, "");
            DataTable rateData;
            DataTable bankData;

            bankGrid.RowCount = employeeData.Rows.Count;
            for (row = 0; row < employeeData.Rows.Count; row++)
            {
                col = 0;
                groupID = employeeData.Rows[row]["GrpID"].ToString();
                // Employee
                bankGrid.Rows[row].Cells[col].Value = Convert.ToString(row + 1);
                col++;
                for (idx = 1; idx < EmpColCount; idx++)
                { // 0 : number
                    fieldName = gName[col.ToString()]["SqlColumn"];
                    bankGrid.Rows[row].Cells[col].Value = employeeData.Rows[row][fieldName].ToString();
                    col++;
                }

                // Salary
                for (idx = 0; idx < SalaryColCount; idx++)
                {
                    fieldName = gName[col.ToString()]["SqlColumn"];
                    bankGrid.Rows[row].Cells[col].Value = ((employeeData.Rows[row][fieldName] == null) ? "" : employeeData.Rows[row][fieldName].ToString());
                    col++;
                }

                // Received
                rateData = tSQL.Report_getEmpReceivedList(thisMonthy, groupID);
                for (r = 0; r < rateData.Rows.Count; r++)
                {
                    fieldName = "ccRec-" + rateData.Rows[r]["Pcurrency"].ToString();
                    if (bankGrid.Columns.Contains(fieldName))
                    {
                        bankGrid.Rows[row].Cells[fieldName].Value = ((rateData.Rows[r]["Amount"] == null) ? "" : rateData.Rows[r]["Amount"].ToString());
                    }
                }
                col += ReceivedColCount - 1;

                // Variance
                for (idx = 0; idx < 1; idx++)
                {
                    fieldName = gName[col.ToString()]["SqlColumn"];
                    bankGrid.Rows[row].Cells[col].Value = ((employeeData.Rows[row][fieldName] == null) ? "" : employeeData.Rows[row][fieldName].ToString());
                    col++;
                }

                // Bank
                string payout;
                int pos;
                bankData = tSQL.Report_getEmpBankList(thisMonthy, groupID);
                for (r = 0; r < bankData.Rows.Count; r++)
                {
                    for (idx = 0; idx < bankData.Columns.Count; idx++)
                    {
                        fieldName = gName[col.ToString()]["SqlColumn"];
                        payout = ((bankData.Rows[r][fieldName] == null) ? "" : bankData.Rows[r][fieldName].ToString());
                        if (fieldName == "payoutRelation")
                        {
                            if (payout != string.Empty)
                            {
                                pos = payout.LastIndexOf("(");
                                if (pos != -1)
                                {
                                    payout = payout.Substring(0, pos - 1);
                                }
                            }
                        }
                        bankGrid.Rows[row].Cells[col].Value = payout;
                        col++;
                    }
                }

                // Remark
                col = headColCount - 1;

                // Format remark
                string remark = employeeData.Rows[row]["Remark"].ToString();  // P.IncreRemark, P.OtherRemark, P.BasicSalaryRemark
                string basicRemark = employeeData.Rows[row]["BasicSalaryRemark"].ToString();
                string incrRemark = employeeData.Rows[row]["IncreRemark"].ToString();
                string otherRemark = employeeData.Rows[row]["OtherRemark"].ToString();

                bankGrid.Rows[row].Cells[col - 3].Value = remark;
                bankGrid.Rows[row].Cells[col - 2].Value = basicRemark;
                bankGrid.Rows[row].Cells[col - 1].Value = incrRemark;
                bankGrid.Rows[row].Cells[col].Value = otherRemark;

                // Currency Format
                for (idx = 1; idx < headColCount; idx++)
                {
                    isCurrency = gName[idx.ToString()]["ISCurrency"];
                    if (isCurrency == "Y")
                    {
                        bankGrid.Rows[row].Cells[idx].Value = base.obj2thousand(base.payKeyDecrypt(base.obj2str(bankGrid.Rows[row].Cells[idx].Value)));
                    }
                }
            }
        }

        // Export
        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = thisMonthy + "_PayrollList.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Employee_Excel excel = new Employee_Excel();
                excel.Rpt_ExcelApp = new Excel.ApplicationClass();
                excel.Rpt_ReportExportFileName = saveFileDialog.FileName;
                excel.outPayrollList(bankGrid);
                excel.SaveAndClose();
                MessageBox.Show("Exported.", "Export Payroll List", MessageBoxButtons.OK);
            }
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_DeptListBox(companyBox, DeptBox);
        }

    }
}