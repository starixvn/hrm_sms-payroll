using System;
using System.Data;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class Company : First
    {

        TSQL tSQL;
        string EditFlag;
        string whereCompanyID;
        string whereDeptID;

        #region ======= this form ========
		
        public Company()
        {
            InitializeComponent();
        }
		
        private void company_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            EditFlag = string.Empty;
            tSQL = new TSQL(base.RemoteDBAbsPath());
            CompanyToolBarOnClick("SaveAndCancel");
            DeptToolBarOnClick("SaveAndCancel");
            load_CompanyData2ListView();
        }
		
        private void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            tSQL.closeConnection();
        }
		
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		
        #endregion ==== this form ========


        #region ======= Company Tabs ========
		
        private void load_CompanyData2ListView()
        {
            DataTable tb;
            CompanyListView.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();

            foreach (DataRow row in tb.Rows)
            {
                ListViewItem exList = new ListViewItem();
                exList.Text = row["CompanyID"].ToString();
                exList.SubItems.Add(row["CompDesc"].ToString());
                CompanyListView.Items.Add(exList);
            }
        }
        private void CompanyToolBarOnClick(string act)
        {
            switch (act)
            {
                case "Add":
                    CompanyBar.Buttons[0].Enabled = false;
                    CompanyBar.Buttons[1].Enabled = false;
                    CompanyBar.Buttons[2].Enabled = false;
                    CompanyBar.Buttons[3].Enabled = true;
                    CompanyBar.Buttons[4].Enabled = true;
                    txtCompanyID.Enabled = true;
                    txtCompDesc.Enabled = true;
                    CompanyListView.Enabled = false;
                    break;
                case "Edit":
                    CompanyBar.Buttons[0].Enabled = false;
                    CompanyBar.Buttons[1].Enabled = false;
                    CompanyBar.Buttons[2].Enabled = false;
                    CompanyBar.Buttons[3].Enabled = true;
                    CompanyBar.Buttons[4].Enabled = true;
                    txtCompanyID.Enabled = true;
                    txtCompDesc.Enabled = true;
                    CompanyListView.Enabled = false;
                    break;
                case "SaveAndCancel":
                    CompanyBar.Buttons[0].Enabled = true;
                    CompanyBar.Buttons[1].Enabled = true;
                    CompanyBar.Buttons[2].Enabled = true;
                    CompanyBar.Buttons[3].Enabled = false;
                    CompanyBar.Buttons[4].Enabled = false;
                    txtCompanyID.Enabled = false;
                    txtCompDesc.Enabled = false;
                    CompanyListView.Enabled = true;
                    break;
                default:
                    CompanyBar.Buttons[0].Enabled = true;
                    CompanyBar.Buttons[1].Enabled = false;
                    CompanyBar.Buttons[2].Enabled = false;
                    CompanyBar.Buttons[3].Enabled = false;
                    CompanyBar.Buttons[4].Enabled = false;
                    txtCompanyID.Enabled = false;
                    txtCompDesc.Enabled = false;
                    CompanyListView.Enabled = true;
                    break;
            }
        }
        private void CompanyListView_Click(object sender, EventArgs e)
        {
            txtCompanyID.Text = CompanyListView.SelectedItems[0].Text.Trim();
            txtCompDesc.Text = CompanyListView.SelectedItems[0].SubItems[1].Text.Trim();
        }
        private void CompanyBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            DialogResult result;
            switch (CompanyBar.Buttons.IndexOf(e.Button))
            {
                case 0: //Add
                    EditFlag = "Add";
                    CompanyToolBarOnClick("Add");
                    txtCompanyID.Text = string.Empty;
                    txtCompDesc.Text = string.Empty;
                    txtCompanyID.Focus();
                    break;

                case 1: //Edit
                    EditFlag = "Edit";
                    whereCompanyID = string.Empty;
                    if (CompanyListView.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    CompanyToolBarOnClick("Edit");
                    whereCompanyID = txtCompanyID.Text;
                    txtCompanyID.Focus();
                    break;

                case 2: //Del
                    if (CompanyListView.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        tSQL.CompanyData_Delete(txtCompanyID.Text);
                        txtCompanyID.Text = string.Empty;
                        txtCompDesc.Text = string.Empty;
                        load_CompanyData2ListView();
                        load_DeptData2ListBox();
                        load_DeptData2ListView();
                        MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                    }
                    break;

                case 3: //Save
                    CompanyToolBarOnClick("SaveAndCancel");
                    if (EditFlag == "Add")
                    {
                        tSQL.CompanyData_Insert(txtCompanyID.Text, txtCompDesc.Text);
                        MessageBox.Show("Created.", "Add Record", MessageBoxButtons.OK);
                    }
                    else if (EditFlag == "Edit")
                    {
                        tSQL.CompanyData_Update(txtCompanyID.Text, txtCompDesc.Text, whereCompanyID);
                        MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                    }
                    load_CompanyData2ListView();
                    load_DeptData2ListBox();
                    load_DeptData2ListView();
                    EditFlag = string.Empty;
                    break;
                case 4: //Cancel
                    CompanyToolBarOnClick("SaveAndCancel");
                    if (CompanyListView.SelectedItems.Count > 0)
                    {
                        CompanyListView_Click(null, null);
                    }
                    EditFlag = string.Empty;
                    break;
            }
        }
        #endregion ==== Company Tabs ========


        #region ======= Department Tabs ========
        private void load_DeptData2ListBox()
        {
            DataTable tb;

            CompanyBox.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();
            string formatStr;
            foreach (DataRow row in tb.Rows)
            {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                CompanyBox.Items.Add(formatStr);
            }
            if (CompanyBox.Items.Count > 0) CompanyBox.SelectedIndex = 0;
        }
        private void load_DeptData2ListView()
        {
            DataTable tb;
            deptListView.Items.Clear();
            tb = tSQL.DeptData_SelectAll(this.get_CompanyIDformBox());

            foreach (DataRow row in tb.Rows)
            {
                ListViewItem exList = new ListViewItem();
                exList.Text = row.ItemArray.GetValue(0).ToString();
                deptListView.Items.Add(exList);
            }
        }
        private string get_CompanyIDformBox()
        {
            string result = string.Empty;
            if (CompanyBox.Items.Count > 0 || CompanyBox.SelectedItem != null)
            {
                result = CompanyBox.SelectedItem.ToString();
            }
            return result;
        }
        private void DeptToolBarOnClick(string act)
        {
            switch (act)
            {
                case "Add":
                    deptBar.Buttons[0].Enabled = false;
                    deptBar.Buttons[1].Enabled = false;
                    deptBar.Buttons[2].Enabled = false;
                    deptBar.Buttons[3].Enabled = true;
                    deptBar.Buttons[4].Enabled = true;
                    txtDeptName.Enabled = true;
                    deptListView.Enabled = false;
                    CompanyBox.Enabled = false;
                    break;
                case "Edit":
                    deptBar.Buttons[0].Enabled = false;
                    deptBar.Buttons[1].Enabled = false;
                    deptBar.Buttons[2].Enabled = false;
                    deptBar.Buttons[3].Enabled = true;
                    deptBar.Buttons[4].Enabled = true;
                    txtDeptName.Enabled = true;
                    deptListView.Enabled = false;
                    CompanyBox.Enabled = false;
                    break;
                case "SaveAndCancel":
                    deptBar.Buttons[0].Enabled = true;
                    deptBar.Buttons[1].Enabled = true;
                    deptBar.Buttons[2].Enabled = true;
                    deptBar.Buttons[3].Enabled = false;
                    deptBar.Buttons[4].Enabled = false;
                    txtDeptName.Enabled = false;
                    deptListView.Enabled = true;
                    CompanyBox.Enabled = true;
                    break;
                default:
                    deptBar.Buttons[0].Enabled = true;
                    deptBar.Buttons[1].Enabled = false;
                    deptBar.Buttons[2].Enabled = false;
                    deptBar.Buttons[3].Enabled = false;
                    deptBar.Buttons[4].Enabled = false;
                    txtDeptName.Enabled = false;
                    deptListView.Enabled = true;
                    CompanyBox.Enabled = true;
                    break;
            }
        }
        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_DeptData2ListView();
            txtDeptName.Text = string.Empty;
        }
        private void deptListView_Click(object sender, EventArgs e)
        {
            txtDeptName.Text = deptListView.SelectedItems[0].SubItems[0].Text.Trim();
        }
        private void deptBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            DialogResult result;
            switch (deptBar.Buttons.IndexOf(e.Button))
            {
                case 0: //Add
                    EditFlag = "Add";
                    DeptToolBarOnClick("Add");
                    txtDeptName.Text = string.Empty;
                    txtDeptName.Focus();
                    break;

                case 1: //Edit
                    EditFlag = "Edit";
                    whereDeptID = string.Empty;
                    if (deptListView.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    DeptToolBarOnClick("Edit");
                    whereDeptID = txtDeptName.Text;
                    txtDeptName.Focus();
                    break;

                case 2: //Del
                    if (deptListView.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (tSQL.DeptData_Delete(this.get_CompanyIDformBox(), txtDeptName.Text))
                        {
                            MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(tSQL.errMessage, "Delete Error", MessageBoxButtons.OK);
                        }
                        txtDeptName.Text = string.Empty;
                        load_DeptData2ListView();
                    }
                    break;

                case 3: //Save
                    DeptToolBarOnClick("SaveAndCancel");
                    if (EditFlag == "Add")
                    {
                        if (tSQL.DeptData_Insert(this.get_CompanyIDformBox(), txtDeptName.Text))
                        {
                            MessageBox.Show("Created.", "Create Record", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(tSQL.errMessage, "Create Error", MessageBoxButtons.OK);
                        }
                    }
                    else if (EditFlag == "Edit")
                    {
                        if (tSQL.DeptData_Update(this.get_CompanyIDformBox(), txtDeptName.Text, whereDeptID))
                        {
                            MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(tSQL.errMessage, "Modify Error", MessageBoxButtons.OK);
                        }
                    }
                    load_DeptData2ListView();
                    EditFlag = string.Empty;
                    break;
                case 4: //Cancel
                    DeptToolBarOnClick("SaveAndCancel");
                    if (deptListView.SelectedItems.Count > 0)
                    {
                        deptListView_Click(null, null);
                    }
                    EditFlag = string.Empty;
                    break;
            }
        }
        #endregion ==== Department Tabs ========


        //Restore status
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CompanyToolBarOnClick("SaveAndCancel");
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                DeptToolBarOnClick("SaveAndCancel");
                load_DeptData2ListBox();
                load_DeptData2ListView();
            }
        }
    }
}