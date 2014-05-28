using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System {
    public partial class LoginAccount : First {
        
        TSQL tSQL;
        string EditFlag = "";
        string EditStatus = "";
        string whereID = "";

        #region ==============  this form ===============
        public LoginAccount() {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void LoginAccount_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            ToolBarOnClick("SaveAndCancel");
            loadAccountData();
        }
        private void loadAccountData() {
            DataTable tb = tSQL.AccountData_SelectAll();
            AccListView.Items.Clear();
            foreach (DataRow row in tb.Rows) {
                ListViewItem exList = new ListViewItem();
                exList.Text = row["accountID"].ToString();
                exList.SubItems.Add(row["fullname"].ToString());
                exList.SubItems.Add(row["passwords"].ToString());
                AccListView.Items.Add(exList);
            }
            accountBox.Text = "";
            fullnameBox.Text = "";
            passwordBox.Text = "";
            confirmBox.Text = "";
        }
        #endregion ==================  this form ===============

        private void ToolBarOnClick(string act) {
            switch (act) {
                case "Add":
                    toolBar.Buttons[0].Enabled = false;
                    toolBar.Buttons[1].Enabled = false;
                    toolBar.Buttons[2].Enabled = false;
                    toolBar.Buttons[3].Enabled = true;
                    toolBar.Buttons[4].Enabled = true;
                    accountBox.Enabled = true;
                    fullnameBox.Enabled = true;
                    passwordBox.Visible = true;
                    confirmBox.Visible = true;
                    AccListView.Enabled = false;

                    label3.Visible = true;
                    label4.Visible = true;

                    break;
                case "Edit":
                    toolBar.Buttons[0].Enabled = false;
                    toolBar.Buttons[1].Enabled = false;
                    toolBar.Buttons[2].Enabled = false;
                    toolBar.Buttons[3].Enabled = true;
                    toolBar.Buttons[4].Enabled = true;
                    accountBox.Enabled = false;
                    fullnameBox.Enabled = true;
                    passwordBox.Visible = true;
                    confirmBox.Visible = true;
                    AccListView.Enabled = false;

                    label3.Visible = true;
                    label4.Visible = true;

                    break;
                case "SaveAndCancel":
                    toolBar.Buttons[0].Enabled = true;
                    toolBar.Buttons[1].Enabled = true;
                    toolBar.Buttons[2].Enabled = true;
                    toolBar.Buttons[3].Enabled = false;
                    toolBar.Buttons[4].Enabled = false;
                    accountBox.Enabled = false;
                    fullnameBox.Enabled = false;
                    passwordBox.Visible = false;
                    confirmBox.Visible = false;
                    AccListView.Enabled = true;

                    label3.Visible = false;
                    label4.Visible = false;

                    break;
                default:
                    break;
            }
        }

        private void AccListView_Click(object sender, EventArgs e) {
            accountBox.Text = AccListView.SelectedItems[0].SubItems[0].Text.ToString();
            fullnameBox.Text = AccListView.SelectedItems[0].SubItems[1].Text.ToString();
            passwordBox.Text = base.sysDecrypt( AccListView.SelectedItems[0].SubItems[2].Text.ToString());
            confirmBox.Text = passwordBox.Text;
        }

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            DialogResult result;
            switch (toolBar.Buttons.IndexOf(e.Button)) {
                case 0: //Add   
                    EditFlag = "Add";
                    EditStatus = "";
                    ToolBarOnClick("Add");
                    accountBox.Text = "";
                    fullnameBox.Text = "";
                    passwordBox.Text = "";
                    confirmBox.Text = "";
                    accountBox.Focus();
                    break;

                case 1: //Edit   
                    EditFlag = "Edit";
                    whereID = "";
                    if (AccListView.SelectedItems.Count < 1) {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    ToolBarOnClick("Edit");
                    whereID = AccListView.SelectedItems[0].Text.ToString();
                    fullnameBox.Focus();
                    break;

                case 2: //Del              
                    if (AccListView.SelectedItems.Count < 1) {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        whereID = AccListView.SelectedItems[0].Text.ToString();
                        tSQL.AccountData_Delete(whereID);
                        accountBox.Text = "";
                        loadAccountData();
                        MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                    }
                    break;

                case 3: //Save    
                    if (EditFlag == "Add") {
                        if (this.saveAcc2SQL("Insert") && EditStatus == "") {
                            MessageBox.Show("Created.", "Create Record", MessageBoxButtons.OK);
                        } else if (EditStatus == "") {
                            MessageBox.Show(tSQL.errMessage, "Create Error", MessageBoxButtons.OK);
                        }
                    } else if (EditFlag == "Edit") {
                        if (this.saveAcc2SQL("Update") && EditStatus == "") {
                            MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                        } else if (EditStatus == "") {
                            MessageBox.Show(tSQL.errMessage, "Modify Error", MessageBoxButtons.OK);
                        }
                    }

                    loadAccountData();
                    if (EditStatus == "") { //when no alarm
                        ToolBarOnClick("SaveAndCancel");
                        EditFlag = "";
                    }
                    break;
                case 4: //Cancel                
                    ToolBarOnClick("SaveAndCancel");
                    if (AccListView.SelectedItems.Count > 0) {
                        AccListView_Click(null, null);
                    }
                    EditFlag = "";
                    break;
            }
        }

        private bool saveAcc2SQL(string act) {
            bool flag = true;
            EditStatus = "";

            if (accountBox.Text.Trim() == "") {
                MessageBox.Show("Please input [Account ID]", "Need Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                accountBox.Focus();
                EditStatus = "Wait";
                return false;
            }

            if (passwordBox.Text != confirmBox.Text) {
                MessageBox.Show("Please check [Password] and [ConfirmPassword]", "Check Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                confirmBox.Focus();
                EditStatus = "Wait";
                return false;
            }
            if (act == "Insert")
                flag = tSQL.AccountData_Insert(accountBox.Text.Trim(), fullnameBox.Text.Trim(), base.sysEncryt(passwordBox.Text.Trim()));
            else
                flag = tSQL.AccountData_Update(accountBox.Text.Trim(), fullnameBox.Text.Trim(), base.sysEncryt(passwordBox.Text.Trim()));
            return flag;
        }

    }
}