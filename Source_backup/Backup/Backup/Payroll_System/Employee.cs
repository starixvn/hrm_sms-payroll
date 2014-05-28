using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace Payroll_System {
    public partial class Employee : First {     
   
        TSQL tSQL;
        DataTable CurrencyDT;
        DataTable PayoutRelationDT;
        string Str_ALL = "======= All =======";
        string EditStatus=null;
        string EditFlag = null;

        #region =====================  Form Load ======================
        public Employee() {
            InitializeComponent();
        }
        private void Employee_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            EditFlag = "";
            tSQL = new TSQL(base.remoteDBAbsPath());
            load_InServiceListBox();
            load_CompanyListBox();
            load_DeptListBox(CompanyBox, DeptBox);            
            load_Currency2DT();
            load_Currency2ListBox();
            load_CurrencyHead2Grid();
            load_Currency2DataGridCombo();
            load_EmployeeData2EmpListView("GrpID");

            EmpToolBarOnClick("SaveAndCancel");
        }
        private void Employee_FormClosed(object sender, FormClosedEventArgs e) {
            tSQL.closeConnection();
        }
        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_DeptListBox(CompanyBox,DeptBox);
            load_EmployeeData2EmpListView("GrpID");
        }
        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e){
            load_EmployeeData2EmpListView("GrpID");
        }
        private void InOfficeBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_EmployeeData2EmpListView("GrpID");
        }
        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }
        private string get_IDformBox(ComboBox Lx) {
            string reval = "";
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null) {
                if (Lx.SelectedItem.ToString() != Str_ALL)
                    reval = Lx.SelectedItem.ToString();                               
            }
            return reval;
        }
        private void load_Currency2DT() {
            CurrencyDT = tSQL.CurrencyData_SelectAll();
            PayoutRelationDT = tSQL.PayRelationData_ShowTree();
        }
        private void load_InServiceListBox() {
            InOfficeBox.Items.Clear();
            InOfficeBox.Items.Add(Str_ALL);
            InOfficeBox.Items.Add("Active");
            InOfficeBox.Items.Add("Inactive");
            InOfficeBox.SelectedIndex = 0;
        }
        private void load_CompanyListBox() {
            DataTable tb;
            CompanyBox.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();
            string formatStr;
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                CompanyBox.Items.Add(formatStr);
                txtCompanyID.Items.Add(formatStr);
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
        private void load_EmployeeData2EmpListView(string SortByColumn) {
            DataTable tb;
            EmpListView.Items.Clear();
            string _InOffice = this.get_IDformBox(InOfficeBox);
            if (_InOffice == "Active")
                _InOffice = "Y";
            else if (_InOffice == "Inactive")
                _InOffice = "N";
            else
                _InOffice = "";

            tb = tSQL.EmployeeData_SelectAll(this.get_IDformBox(CompanyBox), this.get_IDformBox(DeptBox), _InOffice, SortByColumn);
                        
            foreach (DataRow row in tb.Rows)
            {
                ListViewItem exList = new ListViewItem();
                if (row["InOffice"].ToString() == "Y") {
                    exList.ImageIndex = 22;
                } else {
                    exList.ImageIndex = 23;
                }   
                exList.Text = row["CompanyID"].ToString();
                exList.SubItems.Add(row["DepartmentID"].ToString());
                exList.SubItems.Add(row["GrpID"].ToString());
                exList.SubItems.Add(row["FamilyName"].ToString());
                exList.SubItems.Add(row["FirstName"].ToString());
                exList.SubItems.Add(row["MiddleName"].ToString());                
                exList.SubItems.Add(row["Sex"].ToString());
                exList.SubItems.Add(row["PositionName"].ToString());
                exList.SubItems.Add(row["DateJoined"].ToString());
                exList.SubItems.Add(row["DateResigned"].ToString());  
                EmpListView.Items.Add(exList);
            }  
        }        
        private void load_CurrencyHead2Grid() {
            RecGrid.Columns.Clear();         
            DataGridViewTextBoxColumn dvc;
            foreach (DataRow row in CurrencyDT.Rows) {
                dvc = new DataGridViewTextBoxColumn();
                dvc.Name = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                dvc.Width = 60;
                dvc.DataPropertyName = string.Format("{0}", row["Pcurrency"].ToString());
                dvc.HeaderText = row["Pcurrency"].ToString();               
                RecGrid.Columns.Add(dvc);
            }            
            RecGrid.RowCount = 1;
            //RecGrid.Rows[0].Height = 18;
        }
        private void load_Currency2DataGridCombo() {
            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();

            //combo.DataSource = CurrencyDT;
            //combo.DataPropertyName = "Currency";
            //combo.DisplayMember = "Currency";
            //combo.ValueMember = "Currency";
            //bankGrid.Columns.Insert(3, combo);
        }
        private void load_Currency2ListBox() {
            txtCurry.Items.Clear();
            string formatStr;
            foreach (DataRow row in CurrencyDT.Rows) {
                formatStr = string.Format("{0}", row["Pcurrency"].ToString());
                txtCurry.Items.Add(formatStr);
            }
            if (txtCurry.Items.Count > 0) {
                txtCurry.Text = "MYR";
            }
        }
        private void EmpListView_Click(object sender, EventArgs e) {
            set_txt_value(EmpListView.SelectedItems[0].SubItems[2].Text.Trim());
        }
        private void txtInOfficeY_CheckedChanged(object sender, EventArgs e) {
            txtInOfficeN.Checked = !txtInOfficeY.Checked;
        }
        private void txtInOfficeN_CheckedChanged(object sender, EventArgs e) {
            txtInOfficeY.Checked = !txtInOfficeN.Checked;
        }
        #endregion =====================  Form Load ======================


        #region =====================  Edit Employee ======================
        private void txtCompanyID_SelectedIndexChanged(object sender, EventArgs e) {
            load_DeptListBox(txtCompanyID, txtDeptID);
        }
        private void EmpToolBarOnClick(string act) {
            switch (act) {
                case "Add":
                    EmpBar.Buttons[0].Enabled = false;
                    EmpBar.Buttons[1].Enabled = false;
                    EmpBar.Buttons[2].Enabled = false;
                    EmpBar.Buttons[3].Enabled = true;
                    EmpBar.Buttons[4].Enabled = true;
                    txtAdditional.Enabled = true;
                    txtAddress.Enabled = true;
                    txtBirth.Enabled = true;
                    txtCallName.Enabled = true;
                    txtCity.Enabled = true;
                    txtCompanyID.Enabled = true;
                    txtcountry.Enabled = true;
                    txtDateJoin.Enabled = true;
                    txtDeptID.Enabled = true;
                    txtFamilyName.Enabled = true;
                    txtFirstName.Enabled = true;
                    txtGrpID.Enabled = true;
                    txtIdentityID.Enabled = true;
                    txtIncrement.Enabled = true;
                    txtJobTitle.Enabled = true;
                    txtCurry.Enabled = true;
                    txtLA.Enabled = true;
                    txtBasicSalary.Enabled = true;
                    txtMiddleName.Enabled = true;
                    txtNationality.Enabled = true;
                    txtPEmail.Enabled = true;
                    txtPostalCode.Enabled = true;
                    txtResigned.Enabled = true;
                    txtSex.Enabled = true;
                    txtWEmail.Enabled = true;
                    txtInOfficeY.Enabled = true;
                    txtInOfficeN.Enabled = true;
                    
                    RecGrid.Enabled = true;
                    bankGrid.Enabled = true;
                    EmpListView.Enabled = false;
                    CompanyBox.Enabled = false;
                    DeptBox.Enabled = false;

                    ExcelImport.Enabled = false;
                    ExcelOutput.Enabled = false;

                    break;
                case "Edit":
                    EmpBar.Buttons[0].Enabled = false;
                    EmpBar.Buttons[1].Enabled = false;
                    EmpBar.Buttons[2].Enabled = false;
                    EmpBar.Buttons[3].Enabled = true;
                    EmpBar.Buttons[4].Enabled = true;
                    txtAdditional.Enabled = true;
                    txtAddress.Enabled = true;
                    txtBirth.Enabled = true;
                    txtCallName.Enabled = true;
                    txtCity.Enabled = true;
                    txtCompanyID.Enabled = true;
                    txtcountry.Enabled = true;
                    txtDateJoin.Enabled = true;
                    txtDeptID.Enabled = true;
                    txtFamilyName.Enabled = true;
                    txtFirstName.Enabled = true;
                    txtGrpID.Enabled = false;
                    txtIdentityID.Enabled = true;
                    txtIncrement.Enabled = true;
                    txtJobTitle.Enabled = true;
                    txtCurry.Enabled = true;
                    txtLA.Enabled = true;
                    txtBasicSalary.Enabled = true;
                    txtMiddleName.Enabled = true;
                    txtNationality.Enabled = true;
                    txtPEmail.Enabled = true;
                    txtPostalCode.Enabled = true;
                    txtResigned.Enabled = true;
                    txtSex.Enabled = true;
                    txtWEmail.Enabled = true;
                    txtInOfficeY.Enabled = true;
                    txtInOfficeN.Enabled = true;

                    RecGrid.Enabled = true;
                    bankGrid.Enabled = true;
                    EmpListView.Enabled = false;
                    CompanyBox.Enabled = false;
                    DeptBox.Enabled = false;

                    ExcelImport.Enabled = false;
                    ExcelOutput.Enabled = false;

                    break;
                case "SaveAndCancel":
                    EmpBar.Buttons[0].Enabled = true;
                    EmpBar.Buttons[1].Enabled = true;
                    EmpBar.Buttons[2].Enabled = true;
                    EmpBar.Buttons[3].Enabled = false;
                    EmpBar.Buttons[4].Enabled = false;
                    txtAdditional.Enabled = false;
                    txtAddress.Enabled = false;
                    txtBirth.Enabled = false;
                    txtCallName.Enabled = false;
                    txtCity.Enabled = false;
                    txtCompanyID.Enabled = false;
                    txtcountry.Enabled = false;
                    txtDateJoin.Enabled = false;
                    txtDeptID.Enabled = false;
                    txtFamilyName.Enabled = false;
                    txtFirstName.Enabled = false;
                    txtGrpID.Enabled = false;
                    txtIdentityID.Enabled = false;
                    txtIncrement.Enabled = false;
                    txtJobTitle.Enabled = false;
                    txtCurry.Enabled = false;
                    txtLA.Enabled = false;
                    txtBasicSalary.Enabled = false;
                    txtMiddleName.Enabled = false;
                    txtNationality.Enabled = false;
                    txtPEmail.Enabled = false;
                    txtPostalCode.Enabled = false;
                    txtResigned.Enabled = false;
                    txtSex.Enabled = false;
                    txtWEmail.Enabled = false;
                    txtInOfficeY.Enabled = false;
                    txtInOfficeN.Enabled = false;

                    RecGrid.Enabled = false;
                    bankGrid.Enabled = false;
                    EmpListView.Enabled = true;
                    CompanyBox.Enabled = true;
                    DeptBox.Enabled =true;

                    ExcelImport.Enabled = true;
                    ExcelOutput.Enabled = true;

                    break;
                default:
                    EmpBar.Buttons[0].Enabled = false;
                    EmpBar.Buttons[1].Enabled = false;
                    EmpBar.Buttons[2].Enabled = false;
                    EmpBar.Buttons[3].Enabled = false;
                    EmpBar.Buttons[4].Enabled = false;
                    break;
            }
        }
        private void set_txt_clean() {
            txtAdditional.Text = "";
            txtAddress.Text = "";
            txtBirth.Text = "";
            txtCallName.Text = "";
            txtCity.Text = "";
            txtCompanyID.Text  = "";
            txtcountry.Text = "";
            txtDateJoin.Text = "";
            txtDeptID.Text = "";
            txtFamilyName.Text = "";
            txtFirstName.Text = "";
            txtGrpID.Text = "";
            txtIdentityID.Text = "";
            txtIncrement.Text = ""; 
            txtJobTitle.Text = "";
            txtCurry.Text = "MYR";
            txtLA.Text = "";
            txtBasicSalary.Text = "";
            txtMiddleName.Text = "";
            txtNationality.Text = "";
            txtPEmail.Text = "";
            txtPostalCode.Text = "";
            txtResigned.Text = "";
            txtSex.Text = "";
            txtWEmail.Text = "";
            txtInOfficeY.Checked = false;
            txtInOfficeN.Checked = false;

            RecGrid.Rows.Clear();
            RecGrid.RowCount = 1;

      
            bankGrid.Rows.Clear();            
        }
        private void set_txt_value(string GrpID) {
            string fieldname;
            string Amount;
            int i;
            
            DataTable dt = tSQL.EmployeeData_getOne(GrpID);
            if (dt.Rows.Count > 0) {                
                txtAddress.Text = dt.Rows[0]["AddressM"].ToString();
                txtBirth.Text = dt.Rows[0]["DateofBirth"].ToString();
                txtCallName.Text = dt.Rows[0]["CallName"].ToString();
                txtCity.Text = dt.Rows[0]["CityName"].ToString();
                txtCompanyID.Text = dt.Rows[0]["CompanyID"].ToString();
                txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                txtDateJoin.Text = dt.Rows[0]["DateJoined"].ToString();
                txtDeptID.Text = dt.Rows[0]["DepartmentID"].ToString();
                txtFamilyName.Text = dt.Rows[0]["FamilyName"].ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtGrpID.Text = GrpID;
                txtIdentityID.Text = dt.Rows[0]["IdentityID"].ToString();
                txtJobTitle.Text = dt.Rows[0]["PositionName"].ToString();
                txtCurry.Text = dt.Rows[0]["Pcurrency"].ToString();
                txtLA.Text = base.empKeyDecrypt(base.obj2str(dt.Rows[0]["LASalary"]));
                txtBasicSalary.Text = base.empKeyDecrypt(base.obj2str(dt.Rows[0]["BasicSalary"]));
                txtIncrement.Text = base.empKeyDecrypt(base.obj2str(dt.Rows[0]["Incre_Amount"]));
                txtAdditional.Text = base.empKeyDecrypt(base.obj2str(dt.Rows[0]["Add_Amount"])); 
                txtMiddleName.Text = dt.Rows[0]["MiddleName"].ToString();
                txtNationality.Text = dt.Rows[0]["IdentityCountryName"].ToString();
                txtPEmail.Text = dt.Rows[0]["EmailPersonal"].ToString();
                txtPostalCode.Text = dt.Rows[0]["PostalCodeM"].ToString();
                txtResigned.Text = dt.Rows[0]["DateResigned"].ToString();
                txtSex.Text = dt.Rows[0]["Sex"].ToString();
                txtWEmail.Text = dt.Rows[0]["EmailWork"].ToString();
                if (dt.Rows[0]["InOffice"].ToString()=="Y") {
                    txtInOfficeY.Checked = true;
                    txtInOfficeN.Checked = false;
                }else{
                    txtInOfficeY.Checked = false;
                    txtInOfficeN.Checked = true;
                }
                dt = tSQL.ReceivedData_getOne(GrpID);
                RecGrid.Rows.Clear();
                RecGrid.RowCount = 1;
                for (i = 0; i < dt.Rows.Count; i++) {
                    fieldname = dt.Rows[i]["Pcurrency"].ToString();
                    if (RecGrid.Columns.Contains(fieldname)) {
                        Amount = base.obj2str(dt.Rows[i]["Amount"]);
                        Amount = base.empKeyDecrypt(Amount);
                        RecGrid.Rows[0].Cells[fieldname].Value = Amount;
                    }
                }

                dt = tSQL.BankData_getAll(GrpID);
                bankGrid.Rows.Clear(); 
                object[] Ary;
                DataGridViewComboBoxCell CbBox;
                for (i = 0; i < dt.Rows.Count; i++) {
                    Ary = new object[] { 
                            dt.Rows[i]["AcHolder"].ToString(), 
                            dt.Rows[i]["Bank"].ToString(), 
                            dt.Rows[i]["AcNumber"].ToString() 
                          };
                    bankGrid.Rows.Add(Ary);
                    CbBox = (DataGridViewComboBoxCell)bankGrid.Rows[i].Cells[3];
                    CbBox.DataSource = PayoutRelationDT;
                    CbBox.DisplayMember = "tree";
                    CbBox.Value = dt.Rows[i]["payoutRelation"].ToString();
                } 
            } else {
                set_txt_clean(); 
            }            
        }
        private bool saveEmp2SQL(string act) {
            string LASalary;
            string Incre_Amount;
            string Add_Amount;
            string BasicSalary;

            bool flag=true;
            EditStatus = "";

            if (txtCompanyID.SelectedItem == null) {
                txtCompanyID.Text = "";
            }
            if (txtDeptID.SelectedItem == null) {
                txtDeptID.Text = "";
            }
            if (txtDeptID.SelectedItem == null) {
                txtDeptID.Text = "";
            }
            if (txtSex.SelectedItem == null) {
                txtSex.SelectedIndex = 0;
            }

            if (txtGrpID.Text.Trim() == "") {
                MessageBox.Show("Please input [Group ID]", "Need Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tabControl1.SelectedIndex = 0;
                txtGrpID.Focus();
                EditStatus = "Wait";
                return false;
            }

            string txtInOfficeYN = "Y";

            if (!txtInOfficeY.Checked) {
                txtInOfficeYN = "N";
            }

            if (txtCurry.SelectedItem == null) {
                txtCurry.Text = "MYR";
            }

            txtLA.Text = ((txtLA.Text.Trim() == "") ? "0" : txtLA.Text.Trim());
            txtBasicSalary.Text = ((txtBasicSalary.Text.Trim() == "") ? "0" : txtBasicSalary.Text.Trim());
            txtIncrement.Text = ((txtIncrement.Text.Trim() == "") ? "0" : txtIncrement.Text.Trim());
            txtAdditional.Text = ((txtAdditional.Text.Trim() == "") ? "0" : txtAdditional.Text.Trim());

            LASalary = base.empKeyEncryt(txtLA.Text);
            Incre_Amount = base.empKeyEncryt(txtIncrement.Text);
            Add_Amount = base.empKeyEncryt(txtAdditional.Text);
            BasicSalary = base.empKeyEncryt(txtBasicSalary.Text);

            flag = tSQL.EmployeeData_InsertUpdate(act, txtGrpID.Text,
                                                txtFirstName.Text,
                                                txtMiddleName.Text,
                                                txtFamilyName.Text,
                                                txtCallName.Text,
                                                txtIdentityID.Text,
                                                txtNationality.Text,
                                                txtBirth.Text,
                                                txtSex.Text,
                                                txtAddress.Text,
                                                txtCity.Text,
                                                txtPostalCode.Text,
                                                txtcountry.Text,
                                                txtPEmail.Text,
                                                txtCompanyID.Text,
                                                txtDeptID.Text,
                                                txtJobTitle.Text,
                                                txtDateJoin.Text,
                                                txtResigned.Text,
                                                txtWEmail.Text,
                                                txtCurry.Text,
                                                LASalary,
                                                Incre_Amount,
                                                Add_Amount,
                                                txtInOfficeYN,
                                                BasicSalary);
            //insert received
            if (flag) {                 
                string Head_currency;
                string amount;
                int cellCount = RecGrid.Rows[0].Cells.Count;
                tSQL.ReceivedData_Delete(txtGrpID.Text);
                for (int i = 0; i < cellCount; i++) {
                    Head_currency = RecGrid.Columns[i].HeaderText;
                    if (RecGrid.Rows[0].Cells[i].Value != null){
                        amount = RecGrid.Rows[0].Cells[i].Value.ToString();
                        amount = base.empKeyEncryt(amount);
                        //has value, insert to DB
                        tSQL.ReceivedData_Insert(txtGrpID.Text, Head_currency, amount);
                    }
                }
            }

            //insert 
            if (flag) {               
                string AcNumber;
                string AcHolder;
                string Bank;
                string payoutRelation;
                DataGridViewComboBoxCell CbBox;
                int cellCount = bankGrid.Rows.Count;
                tSQL.BankData_Delete(txtGrpID.Text);
                for (int i = 0; i < cellCount; i++) {
                    AcHolder = base.obj2str(bankGrid.Rows[i].Cells[0].Value);                    
                    Bank = base.obj2str(bankGrid.Rows[i].Cells[1].Value);
                    AcNumber = base.obj2str(bankGrid.Rows[i].Cells[2].Value);
                    CbBox = (DataGridViewComboBoxCell)bankGrid.Rows[i].Cells[3];
                    payoutRelation = base.obj2str(CbBox.Value);
                    tSQL.BankData_Insert(txtGrpID.Text, AcNumber, AcHolder, Bank, payoutRelation);                    
                }
            }
            return flag;
        }
        private bool delEmp2SQL() {
            bool flag;
            flag = tSQL.EmployeeDate_Delete(txtGrpID.Text);
            flag = flag && tSQL.ReceivedData_Delete(txtGrpID.Text);
            flag = flag && tSQL.BankData_Delete(txtGrpID.Text);
            return flag;
        }
        private void EmpBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            DialogResult result;
            switch (EmpBar.Buttons.IndexOf(e.Button)) {
                case 0: //Add   
                    EditFlag = "Add";
                    EditStatus = "";
                    EmpToolBarOnClick("Add");
                    set_txt_clean();
                    txtGrpID.Focus();
                    break;

                case 1: //Edit   
                    EditFlag = "Edit";
                    if (EmpListView.SelectedItems.Count < 1 && txtGrpID.Text == "") {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    EmpToolBarOnClick("Edit");                  
                    break;

                case 2: //Del              
                    if (EmpListView.SelectedItems.Count < 1 && txtGrpID.Text == "") {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        if (this.delEmp2SQL()) {
                            MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                        } else {
                            MessageBox.Show(tSQL.errMessage, "Delete Error", MessageBoxButtons.OK);
                        }
                        set_txt_clean();
                        load_EmployeeData2EmpListView("GrpID");
                    }
                    break;

                case 3: //Save        
                    if (EditFlag == "Add") {
                        if (this.saveEmp2SQL("Insert") && EditStatus == "") {
                            MessageBox.Show("Created.", "Create Record", MessageBoxButtons.OK);
                        } else if(EditStatus == "") {
                            MessageBox.Show(tSQL.errMessage, "Create Error", MessageBoxButtons.OK);
                        }
                    } else if (EditFlag == "Edit" ) {
                        if (this.saveEmp2SQL("Update") && EditStatus == "") {
                            MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                        } else if (EditStatus == "") {
                            MessageBox.Show(tSQL.errMessage, "Modify Error", MessageBoxButtons.OK);
                        }                      
                    }

                    load_EmployeeData2EmpListView("GrpID");
                    if (EditStatus == "") { //when no alarm
                        EmpToolBarOnClick("SaveAndCancel");
                        EditFlag = "";
                    }
                    break;
                case 4: //Cancel                
                    EmpToolBarOnClick("SaveAndCancel");                    
                    EditFlag = "";
                    break;
            }
        }

        #endregion =====================  Edit Employee ======================


        #region =====================  monitor Grid ======================
        private void RecGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (EditFlag == "Add") {
                EmpToolBarOnClick("Add");
            } else if (EditFlag == "Edit") {
                EmpToolBarOnClick("Edit");           
            }
        }
        private void RecGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            EmpToolBarOnClick("");
        }
        private void RecGrid_CancelRowEdit(object sender, QuestionEventArgs e) {
            if (EditFlag == "Add") {
                EmpToolBarOnClick("Add");
            } else if (EditFlag == "Edit") {
                EmpToolBarOnClick("Edit");           
            }
        }
        private void bankGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            EmpToolBarOnClick("");
        }
        private void bankGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (EditFlag == "Add") {
                EmpToolBarOnClick("Add");
            } else if (EditFlag == "Edit") {
                EmpToolBarOnClick("Edit");
            }
        }
        private void bankGrid_CancelRowEdit(object sender, QuestionEventArgs e) {
            if (EditFlag == "Add") {
                EmpToolBarOnClick("Add");
            } else if (EditFlag == "Edit") {
                EmpToolBarOnClick("Edit");
            }
        }
        private void bankGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            DataGridViewComboBoxCell CbBox;
            CbBox = (DataGridViewComboBoxCell)bankGrid.Rows[e.RowIndex].Cells[3];
            CbBox.DataSource = PayoutRelationDT;
            CbBox.DisplayMember = "tree";
        }
        private void bankGrid_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            int row;
            int col = e.ColumnIndex;
            if (col == 3) {
                row = e.RowIndex;
                DataGridViewComboBoxCell CbBox = (DataGridViewComboBoxCell)bankGrid.Rows[row].Cells[col];
                CbBox.Value = "";
            }
        }
        #endregion =====================  monitor Grid ======================    

        
        #region =====================  Excel IO ======================
        private void ExcelImport_Click(object sender, EventArgs e) {
            bool flag;

            string msgRebuild = "Keep records and update it?";

            DialogResult result = MessageBox.Show(msgRebuild, "Import Records", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) { 
                Employee_Excel EEX;
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {                
                    EEX = new Employee_Excel();
                    EEX.Rpt_ExcelApp = new Excel.ApplicationClass();
                    EEX.Rpt_ReportExportFileName = openFileDialog1.FileName;
                    flag = EEX.OpenExcelFile_II();

                    if(flag){                        
                        EEX.readData(tSQL);
                        MessageBox.Show("Created.", "Import Records", MessageBoxButtons.OK);
                    }
                    EEX.close();
                    load_EmployeeData2EmpListView("GrpID");
                }
            }
        }
        private void ExcelOutput_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                Employee_Excel EEX = new Employee_Excel();
                EEX.Rpt_ExcelApp = new Excel.ApplicationClass();
                EEX.Rpt_ReportExportFileName = saveFileDialog1.FileName;
                EEX.outData(tSQL);
                EEX.SaveAndClose();
                MessageBox.Show("Saved.", "Output Records", MessageBoxButtons.OK);
            }
        }        
        #endregion =====================  Excel IO ======================

        private void label29_Click(object sender, EventArgs e) {
 
            tip_delbankaccount cf = new tip_delbankaccount();
            cf.Show();
        }

        private void EmpListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            string sortcolumn = EmpListView.Columns[e.Column].Tag.ToString();
            load_EmployeeData2EmpListView(sortcolumn);
        }

         

    }

    
}