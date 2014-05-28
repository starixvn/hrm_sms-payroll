using System;
using System.Data;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class Employee : First
    {
        TSQL tSQL;
        DataTable CurrencyData;
        DataTable PayoutRelationData;
        string TextAll = "======= All =======";
        string EditStatus = null;
        string EditFlag = null;
        string LockMonth = null;

        #region ===================== Form Load ======================

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            EditFlag = string.Empty;

            tSQL = new TSQL(base.RemoteDBAbsPath());

            LockMonth = tSQL.LockData_openMonth();

            Load_InServiceListBox();
            Load_CompanyListBox();
            Load_DeptListBox(companyBox, deptBox);
            Load_Currency2();
            Load_Currency2ListBox();
            Load_CurrencyHead2Grid();
            Load_Currency2DataGridCombo();
            Load_EmployeeData_2_empListView("GrpID");

            PerformAction("SaveAndCancel");
            EndMultipleEdit();
            companyBox.Focus();
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            tSQL.closeConnection();
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DeptListBox(companyBox, deptBox);
            Load_EmployeeData_2_empListView("GrpID");
        }

        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_EmployeeData_2_empListView("GrpID");
        }

        private void InOfficeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_EmployeeData_2_empListView("GrpID");
        }

        private string GetIDComboBox(ComboBox combo)
        {
            string value = string.Empty;
            if (combo.Items.Count > 0 && combo.SelectedItem != null)
            {
                if (combo.SelectedItem.ToString() != TextAll)
                {
                    value = combo.SelectedItem.ToString();
                }
            }
            return value;
        }

        private void Load_Currency2()
        {
            CurrencyData = tSQL.CurrencyData_SelectAll();
            PayoutRelationData = tSQL.PayRelationData_ShowTree();
        }

        private void Load_InServiceListBox()
        {
            inServiceBox.Items.Clear();
            inServiceBox.Items.Add(TextAll);
            inServiceBox.Items.Add("Active");
            inServiceBox.Items.Add("Inactive");
            inServiceBox.SelectedIndex = 0;
        }

        private void Load_CompanyListBox()
        {
            DataTable data;
            companyBox.Items.Clear();
            companyBox.Items.Add(TextAll);
            data = tSQL.CompanyData_SelectAll();
            string format;
            foreach (DataRow row in data.Rows)
            {
                format = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                companyBox.Items.Add(format);
                txtCompanyID.Items.Add(format);
            }
            if (companyBox.Items.Count > 0) companyBox.SelectedIndex = 0;
        }

        private void Load_DeptListBox(ComboBox Comp, ComboBox departmentCombo)
        {
            DataTable data;
            departmentCombo.Items.Clear();
            departmentCombo.Items.Add(TextAll);
            data = tSQL.DeptData_SelectAll(this.GetIDComboBox(Comp));
            string formatStr;
            if (departmentCombo.Name == "DeptBox")
            {
                departmentCombo.Items.Add(TextAll);
            }
            foreach (DataRow row in data.Rows)
            {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                departmentCombo.Items.Add(formatStr);
            }
            if (departmentCombo.Items.Count > 0)
                departmentCombo.SelectedIndex = 0;
            else
                departmentCombo.Text = string.Empty;
        }

        private void Load_EmployeeData_2_empListView(string sortByColumn)
        {
            if (string.IsNullOrEmpty(sortByColumn))
            {
                sortByColumn = "GrpID";
            }

            DataTable data;
            empListView.Items.Clear();

            string _InOffice = this.GetIDComboBox(inServiceBox);

            if (_InOffice == "Active")
                _InOffice = "Y";
            else if (_InOffice == "Inactive")
                _InOffice = "N";
            else
                _InOffice = string.Empty;

            data = tSQL.EmployeeData_SelectAll(this.GetIDComboBox(companyBox), this.GetIDComboBox(deptBox), _InOffice, sortByColumn);

            foreach (DataRow row in data.Rows)
            {
                ListViewItem listViewItem = new ListViewItem();

                if (row["InOffice"].ToString() == "Y")
                {
                    listViewItem.ImageIndex = 22;
                }
                else
                {
                    listViewItem.ImageIndex = 23;
                }

                string groupID = FormatGroupID(row["GrpID"]);
                listViewItem.SubItems.Add(groupID);
                listViewItem.SubItems.Add(row["CallName"].ToString());
                listViewItem.SubItems.Add(row["Sex"].ToString());
                listViewItem.SubItems.Add(row["PositionName"].ToString());

                DateTime dateJoined = DateTime.MinValue;
                DateTime.TryParse(row["DateJoined"] + string.Empty, out dateJoined);

                listViewItem.SubItems.Add(dateJoined.ToShortDateString());

                string laSalary = row["LASalary"].ToString();
                if (!string.IsNullOrEmpty(laSalary))
                {
                    laSalary = base.empKeyDecrypt(laSalary);
                }
                else
                {
                    laSalary = "-";
                }

                var lockMonth = LockMonth;
                bool switchedDB = !string.IsNullOrEmpty(StorageHelper.GetBasicSalary(groupID, lockMonth));
                if (!switchedDB)
                {
                    switchedDB = !string.IsNullOrEmpty(StorageHelper.GetBasicSalary(groupID, StorageHelper.GetLastMonth(lockMonth)));
                    lockMonth = StorageHelper.GetLastMonth(lockMonth);
                }

                string inProbation = "-";

                if (switchedDB)
                {
                    bool isProbationLastTime = StorageHelper.GetInProbationTime(groupID, lockMonth);

                    string lastSalary = StorageHelper.GetBasicSalary(groupID, lockMonth);
                    lastSalary = string.IsNullOrEmpty(lastSalary) ? "-" : base.empKeyDecrypt(lastSalary);

                    string lastProbationSalary = StorageHelper.GetProbationSalary(groupID, lockMonth);
                    lastProbationSalary = string.IsNullOrEmpty(lastProbationSalary) ? "-" : base.empKeyDecrypt(lastProbationSalary);

                    string currentSalary = StorageHelper.GetBasicSalary(groupID, LockMonth);
                    currentSalary = string.IsNullOrEmpty(currentSalary) ? "-" : base.empKeyDecrypt(currentSalary);

                    string currentProbationSalary = StorageHelper.GetProbationSalary(groupID, LockMonth);
                    currentProbationSalary = string.IsNullOrEmpty(currentProbationSalary) ? "-" : base.empKeyDecrypt(currentProbationSalary);

                    bool isProbation = StorageHelper.GetInProbationTime(groupID, LockMonth);
                    inProbation = isProbation ? "Yes" : "No";

                    if (lastProbationSalary != "-" || lastSalary != "-" || currentSalary != "-")
                    {
                        lastSalary = isProbationLastTime ? lastProbationSalary : lastSalary;
                        listViewItem.SubItems.Add(lastSalary);

                        decimal percent = 0;
                        if (currentSalary == "-")
                        {
                            currentSalary = lastSalary;
                        }

                        if (lastSalary != "-")
                        {
                            try
                            {
                                percent = ((decimal.Parse(currentSalary) - decimal.Parse(lastSalary)) * 100) / decimal.Parse(lastSalary);
                            }
                            catch
                            {
                                MessageBox.Show(string.Format("Data is wrong (figure 1 - {0}, figure 2 - {1}).", currentSalary, lastSalary), "Error.", MessageBoxButtons.OK);
                            }
                        }

                        string lastIncrement = (isProbationLastTime || isProbation) ? "-" : (Math.Round(percent).ToString() + "%");
                        listViewItem.SubItems.Add(lastIncrement);
                        listViewItem.SubItems.Add(isProbation ? currentProbationSalary : currentSalary);
                    }
                    else
                    {
                        listViewItem.SubItems.Add(isProbation ? currentProbationSalary : currentSalary);
                        listViewItem.SubItems.Add("-");
                        listViewItem.SubItems.Add(isProbation ? currentProbationSalary : currentSalary);
                    }
                }
                else
                {
                    listViewItem.SubItems.Add(laSalary);
                    listViewItem.SubItems.Add("-");
                    listViewItem.SubItems.Add(laSalary);
                }

                listViewItem.SubItems.Add(inProbation);
                listViewItem.SubItems.Add(row["CompanyID"].ToString());
                listViewItem.SubItems.Add(row["DepartmentID"].ToString());

                if (!string.IsNullOrEmpty(sortByColumn))
                { 
                    
                }

                empListView.Items.Add(listViewItem);
            }
        }

        private void Load_CurrencyHead2Grid()
        {
            receivedRefGrid.Columns.Clear();
            DataGridViewTextBoxColumn dvc;

            foreach (DataRow row in CurrencyData.Rows)
            {
                dvc = new DataGridViewTextBoxColumn();
                dvc.Name = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                dvc.Width = 60;
                dvc.DataPropertyName = string.Format("{0}", row["Pcurrency"].ToString());
                dvc.HeaderText = row["Pcurrency"].ToString();
                receivedRefGrid.Columns.Add(dvc);
            }

            receivedRefGrid.RowCount = 1;
            // receivedRefGrid.Rows[0].Height = 18;
        }

        private void Load_Currency2DataGridCombo()
        {
            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();

            //combo.DataSource = CurrencyDT;
            //combo.DataPropertyName = "Currency";
            //combo.DisplayMember = "Currency";
            //combo.ValueMember = "Currency";
            //bankGrid.Columns.Insert(3, combo);
        }

        private void Load_Currency2ListBox()
        {
            txtCurrency.Items.Clear();
            string format;
            foreach (DataRow row in CurrencyData.Rows)
            {
                format = string.Format("{0}", row["Pcurrency"].ToString());
                txtCurrency.Items.Add(format);
            }
            if (txtCurrency.Items.Count > 0)
            {
                txtCurrency.Text = "MYR";
            }
        }

        private void txtInOfficeY_CheckedChanged(object sender, EventArgs e)
        {
            txtInOfficeN.Checked = !txtInOfficeY.Checked;
            txtResigned.Enabled = false;
        }

        private void txtInOfficeN_CheckedChanged(object sender, EventArgs e)
        {
            txtInOfficeY.Checked = !txtInOfficeN.Checked;
            txtResigned.Enabled = true;
        }

        #endregion ===================== Form Load ======================

        #region ===================== Edit Employee ======================

        private void txtCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DeptListBox(txtCompanyID, txtDeptID);
        }

        private void StartMultipleEdit()
        {
            multipleEditSalaryGroupBox.Visible = true;
            multipleEditSalaryGroupBox.Top = tabControl.Top;
            multipleEditSalaryGroupBox.Left = tabBank.Left + 5;
            tabControl.Visible = false;
        }

        private void EndMultipleEdit()
        {
            multipleEditSalaryGroupBox.Visible = false;
            tabControl.Visible = true;
        }

        private bool IsMultipleEdit
        {
            get 
            {
                return tabControl.Visible == false;
            }
        }

        private void PerformAction(string action)
        {
            switch (action)
            {
                case "Add":

                    actionBar.Buttons[0].Enabled = false;
                    actionBar.Buttons[1].Enabled = false;
                    actionBar.Buttons[2].Enabled = false;
                    actionBar.Buttons[3].Enabled = true;
                    actionBar.Buttons[4].Enabled = true;
                    txtAddress.Enabled = true;
                    txtBirthday.Enabled = true;
                    txtCallName.Enabled = true;
                    txtCity.Enabled = true;
                    txtCompanyID.Enabled = true;
                    txtCountry.Enabled = true;
                    txtDateJoin.Enabled = true;
                    txtDeptID.Enabled = true;
                    txtFamilyName.Enabled = true;
                    txtFirstName.Enabled = true;
                    txtGroupID.Enabled = true;
                    txtIdentityID.Enabled = true;

                    txtJobTitle.Enabled = true;
                    txtCurrency.Enabled = true;
                    txtProbationSalary.Enabled = true;
                    txtBasicSalary.Enabled = true;
                    txtMiddleName.Enabled = true;
                    txtNationality.Enabled = true;
                    txtPersonalEmail.Enabled = true;
                    txtPostalCode.Enabled = true;
                    // txtResigned.Enabled = true;
                    txtSex.Enabled = true;
                    txtWorkEmail.Enabled = true;
                    txtInOfficeY.Enabled = true;
                    txtInOfficeN.Enabled = true;

                    receivedRefGrid.Enabled = true;
                    bankGrid.Enabled = true;
                    empListView.Enabled = false;
                    companyBox.Enabled = false;
                    deptBox.Enabled = false;

                    probationCheckbox.Enabled = true;

                    ExcelImport.Enabled = false;
                    ExcelOutput.Enabled = false;

                    tabPage.Focus();

                    EndMultipleEdit();

                    break;
                case "Edit":
                    actionBar.Buttons[0].Enabled = false;
                    actionBar.Buttons[1].Enabled = false;
                    actionBar.Buttons[2].Enabled = false;
                    actionBar.Buttons[3].Enabled = true;
                    actionBar.Buttons[4].Enabled = true;
                    txtAddress.Enabled = true;
                    txtBirthday.Enabled = true;
                    txtCallName.Enabled = true;
                    txtCity.Enabled = true;
                    txtCompanyID.Enabled = true;
                    txtCountry.Enabled = true;
                    txtDateJoin.Enabled = true;
                    txtDeptID.Enabled = true;
                    txtFamilyName.Enabled = true;
                    txtFirstName.Enabled = true;
                    txtGroupID.Enabled = false;
                    txtIdentityID.Enabled = true;

                    txtJobTitle.Enabled = true;
                    txtCurrency.Enabled = true;
                    txtProbationSalary.Enabled = false;
                    txtBasicSalary.Enabled = true;
                    txtMiddleName.Enabled = true;
                    txtNationality.Enabled = true;
                    txtPersonalEmail.Enabled = true;
                    txtPostalCode.Enabled = true;
                    // txtResigned.Enabled = true;
                    txtSex.Enabled = true;
                    txtWorkEmail.Enabled = true;
                    txtInOfficeY.Enabled = true;
                    txtInOfficeN.Enabled = true;

                    receivedRefGrid.Enabled = true;
                    bankGrid.Enabled = true;

                    empListView.Enabled = false;

                    companyBox.Enabled = false;
                    deptBox.Enabled = false;

                    ExcelImport.Enabled = false;
                    ExcelOutput.Enabled = false;

                    probationCheckbox_CheckedChanged(null, null);
                    probationCheckbox.Enabled = true;

                    tabPage.Focus();

                    if (empListView.SelectedItems.Count > 1)
                    {
                        StartMultipleEdit();
                    }

                    break;

                case "SaveAndCancel":
                    actionBar.Buttons[0].Enabled = true;
                    actionBar.Buttons[1].Enabled = true;
                    actionBar.Buttons[2].Enabled = true;
                    actionBar.Buttons[3].Enabled = false;
                    actionBar.Buttons[4].Enabled = false;
                    txtAddress.Enabled = false;
                    txtBirthday.Enabled = false;
                    txtCallName.Enabled = false;
                    txtCity.Enabled = false;
                    txtCompanyID.Enabled = false;
                    txtCountry.Enabled = false;
                    txtDateJoin.Enabled = false;
                    txtDeptID.Enabled = false;
                    txtFamilyName.Enabled = false;
                    txtFirstName.Enabled = false;
                    txtGroupID.Enabled = false;
                    txtIdentityID.Enabled = false;
                    txtJobTitle.Enabled = false;
                    txtCurrency.Enabled = false;
                    txtProbationSalary.Enabled = false;
                    txtBasicSalary.Enabled = false;
                    txtMiddleName.Enabled = false;
                    txtNationality.Enabled = false;
                    txtPersonalEmail.Enabled = false;
                    txtPostalCode.Enabled = false;
                    // txtResigned.Enabled = false;
                    txtSex.Enabled = false;
                    txtWorkEmail.Enabled = false;
                    txtInOfficeY.Enabled = false;
                    txtInOfficeN.Enabled = false;

                    receivedRefGrid.Enabled = false;
                    bankGrid.Enabled = false;
                    empListView.Enabled = true;
                    companyBox.Enabled = true;
                    deptBox.Enabled = true;

                    ExcelImport.Enabled = true;
                    ExcelOutput.Enabled = true;

                    probationCheckbox.Enabled = false;

                    empListView.Focus();

                    EndMultipleEdit();

                    break;
                default:
                    actionBar.Buttons[0].Enabled = false;
                    actionBar.Buttons[1].Enabled = false;
                    actionBar.Buttons[2].Enabled = false;
                    actionBar.Buttons[3].Enabled = false;
                    actionBar.Buttons[4].Enabled = false;
                    EndMultipleEdit();
                    break;
            }
        }

        private void ClearText()
        {
            txtAddress.Text = string.Empty;
            txtBirthday.Text = string.Empty;
            txtCallName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCompanyID.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtDateJoin.Text = string.Empty;
            txtDeptID.Text = string.Empty;
            txtFamilyName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtGroupID.Text = string.Empty;
            txtIdentityID.Text = string.Empty;

            txtJobTitle.Text = string.Empty;
            txtCurrency.Text = "MYR";
            txtProbationSalary.Text = string.Empty;
            txtBasicSalary.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtNationality.Text = string.Empty;
            txtPersonalEmail.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtResigned.Text = string.Empty;
            txtSex.Text = string.Empty;
            txtWorkEmail.Text = string.Empty;
            txtInOfficeY.Checked = false;
            txtInOfficeN.Checked = false;

            receivedRefGrid.Rows.Clear();
            receivedRefGrid.RowCount = 1;


            bankGrid.Rows.Clear();
        }

        private void SetTextValues(string groupID)
        {
            string fieldName;
            string amount;
            int i;

            DataTable dt = tSQL.EmployeeData_getOne(groupID);

            if (dt.Rows.Count > 0)
            {
                txtAddress.Text = dt.Rows[0]["AddressM"].ToString();
                
                txtCallName.Text = dt.Rows[0]["CallName"].ToString();
                txtCity.Text = dt.Rows[0]["CityName"].ToString();
                txtCompanyID.Text = dt.Rows[0]["CompanyID"].ToString();
                txtCountry.Text = dt.Rows[0]["CountryName"].ToString();
                
                txtDeptID.Text = dt.Rows[0]["DepartmentID"].ToString();
                txtFamilyName.Text = dt.Rows[0]["FamilyName"].ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtGroupID.Text = groupID;
                txtIdentityID.Text = dt.Rows[0]["IdentityID"].ToString();
                txtJobTitle.Text = dt.Rows[0]["PositionName"].ToString();
                txtCurrency.Text = dt.Rows[0]["Pcurrency"].ToString();

                string laSalary = dt.Rows[0]["LASalary"].ToString();
                if (!string.IsNullOrEmpty(laSalary))
                {
                    laSalary = base.empKeyDecrypt(laSalary);
                }
                else
                {
                    laSalary = "0";
                }

                string basicSalary = dt.Rows[0]["BasicSalary"].ToString();
                if (!string.IsNullOrEmpty(basicSalary))
                {
                    basicSalary = base.empKeyDecrypt(basicSalary);
                }
                else
                {
                    basicSalary = "0";
                }

                txtProbationSalary.Text = laSalary;
                txtBasicSalary.Text = basicSalary;

                txtMiddleName.Text = dt.Rows[0]["MiddleName"].ToString();
                txtNationality.Text = dt.Rows[0]["IdentityCountryName"].ToString();
                txtPersonalEmail.Text = dt.Rows[0]["EmailPersonal"].ToString();
                txtPostalCode.Text = dt.Rows[0]["PostalCodeM"].ToString();

                try
                {
                    txtResigned.Value = DateTime.Parse(dt.Rows[0]["DateResigned"].ToString());
                }
                catch
                {
                    txtResigned.Value = txtResigned.MaxDate;
                }

                try
                {
                    txtBirthday.Value = DateTime.Parse(dt.Rows[0]["DateofBirth"].ToString());
                }
                catch
                {
                    txtBirthday.Value = txtBirthday.MaxDate;
                }

                try
                {
                    txtDateJoin.Value = DateTime.Parse(dt.Rows[0]["DateJoined"].ToString());
                }
                catch
                {
                    txtDateJoin.Value = txtDateJoin.MinDate;
                }

                txtSex.Text = dt.Rows[0]["Sex"].ToString();
                txtWorkEmail.Text = dt.Rows[0]["EmailWork"].ToString();

                bool inProbation = false;
                bool switchedDB = !string.IsNullOrEmpty(StorageHelper.GetBasicSalary(groupID, LockMonth));
                if (switchedDB)
                {
                    inProbation = StorageHelper.GetInProbationTime(groupID, LockMonth);
                    txtProbationSalary.Text = base.empKeyDecrypt(StorageHelper.GetProbationSalary(groupID, LockMonth));
                    txtBasicSalary.Text = base.empKeyDecrypt(StorageHelper.GetBasicSalary(groupID, LockMonth));
                }

                probationCheckbox.Checked = inProbation;

                if (dt.Rows[0]["InOffice"].ToString() == "Y")
                {
                    txtInOfficeY.Checked = true;
                    txtInOfficeN.Checked = false;
                }
                else
                {
                    txtInOfficeY.Checked = false;
                    txtInOfficeN.Checked = true;
                }

                dt = tSQL.ReceivedData_getOne(groupID);

                receivedRefGrid.Rows.Clear();
                receivedRefGrid.RowCount = 1;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    fieldName = dt.Rows[i]["Pcurrency"].ToString();
                    if (receivedRefGrid.Columns.Contains(fieldName))
                    {
                        amount = base.obj2str(dt.Rows[i]["Amount"]);
                        amount = base.empKeyDecrypt(amount);
                        receivedRefGrid.Rows[0].Cells[fieldName].Value = amount;
                    }
                }

                dt = tSQL.BankData_getAll(groupID);
                bankGrid.Rows.Clear();
                object[] array;
                DataGridViewComboBoxCell bankSelection;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    array = new object[] {
                        dt.Rows[i]["AcHolder"].ToString(),
                        dt.Rows[i]["Bank"].ToString(),
                        dt.Rows[i]["AcNumber"].ToString()
                    };
                    bankGrid.Rows.Add(array);
                    bankSelection = (DataGridViewComboBoxCell)bankGrid.Rows[i].Cells[3];
                    bankSelection.DataSource = PayoutRelationData;
                    bankSelection.DisplayMember = "tree";
                    bankSelection.Value = dt.Rows[i]["payoutRelation"].ToString();
                }
            }
            else
            {
                ClearText();
            }
        }

        private bool SaveEmp2SQL(string action)
        {
            string probationSalary;
            string basicSalary;

            bool flag = true;
            EditStatus = string.Empty;

            if (txtCompanyID.SelectedItem == null)
            {
                txtCompanyID.Text = string.Empty;
            }
            if (txtDeptID.SelectedItem == null)
            {
                txtDeptID.Text = string.Empty;
            }
            if (txtDeptID.SelectedItem == null)
            {
                txtDeptID.Text = string.Empty;
            }
            if (txtSex.SelectedItem == null)
            {
                txtSex.SelectedIndex = 0;
            }

            if (txtGroupID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please input [Group ID]", "Need Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tabControl.SelectedIndex = 0;
                txtGroupID.Focus();
                EditStatus = "Wait";
                return false;
            }

            string txtInOfficeYN = "Y";

            if (!txtInOfficeY.Checked)
            {
                txtInOfficeYN = "N";
            }

            if (txtCurrency.SelectedItem == null)
            {
                txtCurrency.Text = "MYR";
            }

            txtProbationSalary.Text = ((txtProbationSalary.Text.Trim() == string.Empty) ? "0" : txtProbationSalary.Text.Trim());
            txtBasicSalary.Text = ((txtBasicSalary.Text.Trim() == string.Empty) ? "0" : txtBasicSalary.Text.Trim());

            probationSalary = base.empKeyEncryt(txtProbationSalary.Text);
            basicSalary = base.empKeyEncryt(txtBasicSalary.Text);

            // Get increment from last month
            string incrementSalary = "0";
            string lastMonth = tSQL.LockData_lastMonth(LockMonth);

            string lastMonthSalary = StorageHelper.GetInProbationTime(txtGroupID.Text, lastMonth) ?
            StorageHelper.GetProbationSalary(txtGroupID.Text, lastMonth) : StorageHelper.GetBasicSalary(txtGroupID.Text, lastMonth);

            if (!string.IsNullOrEmpty(lastMonthSalary))
            {
                lastMonthSalary = base.empKeyDecrypt(lastMonthSalary);
                if (IsMultipleEdit)
                {
                    incrementSalary = Math.Round(decimal.Parse(lastMonthSalary) * (txtIncrementSalary.Value / 100)).ToString();
                    txtBasicSalary.Text = Math.Round(decimal.Parse(lastMonthSalary) + decimal.Parse(incrementSalary)).ToString();
                    basicSalary = base.empKeyEncryt(txtBasicSalary.Text);
                }
                else
                {
                    incrementSalary = Math.Round(decimal.Parse(txtBasicSalary.Text) - decimal.Parse(lastMonthSalary)).ToString();
                }
            }

            if (probationCheckbox.Checked)
            {
                incrementSalary = "0";
            }

            // Save employee salary info of current month
            StorageHelper.SetInProbationTime(txtGroupID.Text, LockMonth, probationCheckbox.Checked);
            StorageHelper.SetProbationSalary(txtGroupID.Text, LockMonth, probationSalary);
            StorageHelper.SetBasicSalary(txtGroupID.Text, LockMonth, basicSalary);
            StorageHelper.SetIncrementSalary(txtGroupID.Text, LockMonth, base.empKeyEncryt(incrementSalary));

            flag = tSQL.EmployeeData_InsertUpdate(
                action, 
                txtGroupID.Text,
                txtFirstName.Text,
                txtMiddleName.Text,
                txtFamilyName.Text,
                txtCallName.Text,
                txtIdentityID.Text,
                txtNationality.Text,
                txtBirthday.Text,
                txtSex.Text,
                txtAddress.Text,
                txtCity.Text,
                txtPostalCode.Text,
                txtCountry.Text,
                txtPersonalEmail.Text,
                txtCompanyID.Text,
                txtDeptID.Text,
                txtJobTitle.Text,
                txtDateJoin.Text,
                txtResigned.Enabled ? txtResigned.Text : string.Empty,
                txtWorkEmail.Text,
                txtCurrency.Text,
                probationSalary,
                base.empKeyEncryt(incrementSalary),
                base.empKeyEncryt("0"),
                txtInOfficeYN,
                basicSalary
                );

            // Insert received
            if (flag)
            {
                string Head_currency;
                string amount;
                int cellCount = receivedRefGrid.Rows[0].Cells.Count;
                tSQL.ReceivedData_Delete(txtGroupID.Text);
                for (int i = 0; i < cellCount; i++)
                {
                    Head_currency = receivedRefGrid.Columns[i].HeaderText;
                    if (receivedRefGrid.Rows[0].Cells[i].Value != null)
                    {
                        amount = receivedRefGrid.Rows[0].Cells[i].Value.ToString();
                        amount = base.empKeyEncryt(amount);
                        // Has value, insert to DB
                        tSQL.ReceivedData_Insert(txtGroupID.Text, Head_currency, amount);
                    }
                }
            }

            // Insert
            if (flag)
            {
                string AcNumber;
                string AcHolder;
                string Bank;
                string payoutRelation;
                DataGridViewComboBoxCell combo;
                int cellCount = bankGrid.Rows.Count;
                tSQL.BankData_Delete(txtGroupID.Text);
                for (int i = 0; i < cellCount; i++)
                {
                    AcHolder = base.obj2str(bankGrid.Rows[i].Cells[0].Value);
                    Bank = base.obj2str(bankGrid.Rows[i].Cells[1].Value);
                    AcNumber = base.obj2str(bankGrid.Rows[i].Cells[2].Value);
                    combo = (DataGridViewComboBoxCell)bankGrid.Rows[i].Cells[3];
                    payoutRelation = base.obj2str(combo.Value);
                    tSQL.BankData_Insert(txtGroupID.Text, AcNumber, AcHolder, Bank, payoutRelation);
                }
            }
            return flag;
        }

        private bool DeleteEmp2SQL()
        {
            bool flag;
            flag = tSQL.EmployeeDate_Delete(txtGroupID.Text);
            flag = flag && tSQL.ReceivedData_Delete(txtGroupID.Text);
            flag = flag && tSQL.BankData_Delete(txtGroupID.Text);
            return flag;
        }

        private void actionBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            DialogResult result;
            switch (actionBar.Buttons.IndexOf(e.Button))
            {
                case 0: // Add
                    EditFlag = "Add";
                    EditStatus = string.Empty;
                    PerformAction("Add");
                    ClearText();
                    txtGroupID.Focus();
                    break;

                case 1: // Edit
                    EditFlag = "Edit";
                    if (empListView.SelectedItems.Count < 1 && txtGroupID.Text == string.Empty)
                    {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    PerformAction("Edit");
                    break;

                case 2: // Del
                    if (empListView.SelectedItems.Count < 1 && txtGroupID.Text == string.Empty)
                    {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("This action cannot be undone. Are you sure want to continue ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (this.DeleteEmp2SQL())
                        {
                            MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(tSQL.errMessage, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ClearText();
                        Load_EmployeeData_2_empListView("GrpID");
                    }
                    break;

                case 3: // Save
                    if (EditFlag == "Add")
                    {
                        if (this.SaveEmp2SQL("Insert") && EditStatus == string.Empty)
                        {
                            MessageBox.Show("Created.", "Create Record", MessageBoxButtons.OK);
                        }
                        else if (EditStatus == string.Empty)
                        {
                            MessageBox.Show(tSQL.errMessage, "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (EditFlag == "Edit")
                    {
                        if (IsMultipleEdit)
                        {
                            foreach (ListViewItem item in empListView.SelectedItems)
                            {
                                SetTextValues(item.SubItems[1].Text.Trim());
                                SaveEmp2SQL("Update");
                            }

                            MessageBox.Show("Done.", "Multile salary increment", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (this.SaveEmp2SQL("Update") && EditStatus == string.Empty)
                            {
                                MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                            }
                            else if (EditStatus == string.Empty)
                            {
                                MessageBox.Show(tSQL.errMessage, "Modify Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    Load_EmployeeData_2_empListView("GrpID");

                    if (EditStatus == string.Empty)
                    { 
                        // When no alarm
                        PerformAction("SaveAndCancel");
                        EditFlag = string.Empty;
                    }
                    break;
                case 4: // Cancel
                    PerformAction("SaveAndCancel");
                    EditFlag = string.Empty;
                    break;
            }
        }

        #endregion ===================== Edit Employee ======================

        #region ===================== monitor Grid ======================

        private void receivedRefGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (EditFlag == "Add")
            {
                PerformAction("Add");
            }
            else if (EditFlag == "Edit")
            {
                PerformAction("Edit");
            }
        }

        private void receivedRefGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            PerformAction("");
        }

        private void receivedRefGrid_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            if (EditFlag == "Add")
            {
                PerformAction("Add");
            }
            else if (EditFlag == "Edit")
            {
                PerformAction("Edit");
            }
        }

        private void bankGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            PerformAction("");
        }

        private void bankGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (EditFlag == "Add")
            {
                PerformAction("Add");
            }
            else if (EditFlag == "Edit")
            {
                PerformAction("Edit");
            }
        }

        private void bankGrid_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            if (EditFlag == "Add")
            {
                PerformAction("Add");
            }
            else if (EditFlag == "Edit")
            {
                PerformAction("Edit");
            }
        }

        private void bankGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewComboBoxCell cellBox;
            cellBox = (DataGridViewComboBoxCell)bankGrid.Rows[e.RowIndex].Cells[3];
            cellBox.DataSource = PayoutRelationData;
            cellBox.DisplayMember = "tree";
        }

        private void bankGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int row;
            int col = e.ColumnIndex;
            if (col == 3)
            {
                row = e.RowIndex;
                DataGridViewComboBoxCell CbBox = (DataGridViewComboBoxCell)bankGrid.Rows[row].Cells[col];
                CbBox.Value = string.Empty;
            }
        }

        #endregion ===================== monitor Grid ======================

        #region ===================== Excel IO ======================

        private void ExcelImport_Click(object sender, EventArgs e)
        {
            bool flag;

            string msgRebuild = "Keep records and update it ?";

            DialogResult result = MessageBox.Show(msgRebuild, "Import Records", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Employee_Excel excel;
                if (openFileDialogExport.ShowDialog() == DialogResult.OK)
                {
                    excel = new Employee_Excel();
                    excel.Rpt_ExcelApp = new Excel.ApplicationClass();
                    excel.Rpt_ReportExportFileName = openFileDialogExport.FileName;
                    flag = excel.OpenExcelFile_II();

                    if (flag)
                    {
                        excel.readData(tSQL);
                        MessageBox.Show("Imported.", "Import Records", MessageBoxButtons.OK);
                    }
                    excel.close();

                    Load_CompanyListBox();
                    Load_DeptListBox(companyBox, deptBox);
                    Load_EmployeeData_2_empListView("GrpID");
                }
            }
        }

        private void ExcelOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialogExport.ShowDialog() == DialogResult.OK)
            {
                Employee_Excel EEX = new Employee_Excel();
                EEX.Rpt_ExcelApp = new Excel.ApplicationClass();
                EEX.Rpt_ReportExportFileName = saveFileDialogExport.FileName;
                EEX.outData(tSQL);
                EEX.SaveAndClose();
                MessageBox.Show("Exported.", "Output Records", MessageBoxButtons.OK);
            }
        }

        #endregion ===================== Excel IO ======================

        private void labelHelpDeleteBankAcc_Click(object sender, EventArgs e)
        {
            Tip_DelBankAccount tip = new Tip_DelBankAccount();
            tip.Show();
        }

        private void empListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string sortColumn = empListView.Columns[e.Column].Tag + string.Empty;
            Load_EmployeeData_2_empListView(sortColumn);
        }

        private void probationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!txtCurrency.Enabled)
            {
                return;
            }

            if (probationCheckbox.Checked)
            {
                txtProbationSalary.Enabled = true;
                txtBasicSalary.Enabled = false;
            }
            else
            {
                txtProbationSalary.Enabled = false;
                txtBasicSalary.Enabled = true;
            }
        }

        private void empListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCount = empListView.SelectedItems.Count;
            if (selectedCount == 1)
            {
                SetTextValues(empListView.SelectedItems[0].SubItems[1].Text.Trim());
            }
            else if (selectedCount > 1)
            {
                ClearText();
            }
        }

        private void empListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (empListView.SelectedItems.Count > 0)
            {
                EditFlag = "Edit";
                PerformAction("Edit");
            }
        }

        private void empListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter && empListView.SelectedItems.Count > 0)
            {
                EditFlag = "Edit";
                PerformAction("Edit");
            }
        }

        private void tabControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Escape)
            {
                EditFlag = string.Empty;
                PerformAction("SaveAndCancel");
            }
        }
    }
}