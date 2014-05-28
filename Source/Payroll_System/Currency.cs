using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class Currency : First
    {
        TSQL tSQL;
        string EditFlag = string.Empty;
        string whereID = string.Empty;

        #region =======  this form ========
        public Currency()
        {
            InitializeComponent();
        }
        private void Currency_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.RemoteDBAbsPath());

            ToolBarOnClick("SaveAndCancel");
            loadCurrencyData();
        }
        private void Currency_FormClosed(object sender, FormClosedEventArgs e)
        {
            tSQL.closeConnection();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadCurrencyData()
        {
            DataTable tb = tSQL.CurrencyData_SelectAllandEnable();
            CurrencyListView.Items.Clear();
            foreach (DataRow row in tb.Rows)
            {
                ListViewItem exList = new ListViewItem();

                if (row["enable"].ToString() == "Y")
                {
                    exList.ImageIndex = 22;
                }
                else
                {
                    exList.ImageIndex = 23;
                }
                exList.Text = row["Pcurrency"].ToString();
                exList.SubItems.Add(row["showDecimal"].ToString());
                CurrencyListView.Items.Add(exList);
            }
            txtCurrency.Text = string.Empty;
            txtDecimal.Value = 0;
        }
        #endregion ====  this form ========

        private void ToolBarOnClick(string act)
        {
            switch (act)
            {
                case "Add":
                    toolBar.Buttons[0].Enabled = false;
                    toolBar.Buttons[1].Enabled = false;
                    toolBar.Buttons[2].Enabled = false;
                    toolBar.Buttons[3].Enabled = true;
                    toolBar.Buttons[4].Enabled = true;
                    txtCurrency.Enabled = true;
                    txtDecimal.Enabled = true;
                    txtY.Enabled = true;
                    txtN.Enabled = true;
                    CurrencyListView.Enabled = false;

                    break;
                case "Edit":
                    toolBar.Buttons[0].Enabled = false;
                    toolBar.Buttons[1].Enabled = false;
                    toolBar.Buttons[2].Enabled = false;
                    toolBar.Buttons[3].Enabled = true;
                    toolBar.Buttons[4].Enabled = true;
                    txtCurrency.Enabled = false;
                    txtDecimal.Enabled = true;
                    txtY.Enabled = true;
                    txtN.Enabled = true;
                    CurrencyListView.Enabled = false;

                    break;
                case "SaveAndCancel":
                    toolBar.Buttons[0].Enabled = true;
                    toolBar.Buttons[1].Enabled = true;
                    toolBar.Buttons[2].Enabled = true;
                    toolBar.Buttons[3].Enabled = false;
                    toolBar.Buttons[4].Enabled = false;
                    txtCurrency.Enabled = false;
                    txtDecimal.Enabled = false;
                    txtY.Enabled = false;
                    txtN.Enabled = false;
                    CurrencyListView.Enabled = true;

                    break;
                default:
                    break;
            }
        }

        private void CurrencyListView_Click(object sender, EventArgs e)
        {
            txtCurrency.Text = CurrencyListView.SelectedItems[0].SubItems[0].Text.ToString();
            txtDecimal.Text = CurrencyListView.SelectedItems[0].SubItems[1].Text.ToString();
            if (CurrencyListView.SelectedItems[0].ImageIndex == 22)
            {
                txtY.Checked = true;
            }
            else
            {
                txtN.Checked = true;
            }
        }

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            DialogResult result;
            string _YN;
            switch (toolBar.Buttons.IndexOf(e.Button))
            {
                case 0: //Add   
                    EditFlag = "Add";
                    ToolBarOnClick("Add");
                    txtCurrency.Text = string.Empty;
                    txtDecimal.Value = 4;
                    txtY.Checked = true;
                    txtCurrency.Focus();
                    break;

                case 1: //Edit   
                    EditFlag = "Edit";
                    whereID = string.Empty;
                    if (CurrencyListView.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    ToolBarOnClick("Edit");
                    whereID = CurrencyListView.SelectedItems[0].Text.ToString();
                    txtDecimal.Focus();
                    break;

                case 2: //Del              
                    if (CurrencyListView.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        whereID = CurrencyListView.SelectedItems[0].Text.ToString();
                        if (whereID == "MYR")
                        {
                            MessageBox.Show("Cannot delete [MYR] record.", "Delete Record", MessageBoxButtons.OK);
                            break;
                        }
                        tSQL.CurrencyData_Delete(whereID);
                        txtCurrency.Text = string.Empty;
                        loadCurrencyData();
                        MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                    }
                    break;

                case 3: //Save    
                    if (txtY.Checked)
                        _YN = "Y";
                    else
                        _YN = "N";

                    if (EditFlag == "Add")
                    {
                        if (tSQL.CurrencyData_Insert(txtCurrency.Text.Trim(), txtDecimal.Value, _YN))
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
                        if (tSQL.CurrencyData_Update(whereID, txtDecimal.Value, _YN))
                        {
                            MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(tSQL.errMessage, "Modify Error", MessageBoxButtons.OK);
                        }
                    }

                    loadCurrencyData();
                    ToolBarOnClick("SaveAndCancel");
                    EditFlag = string.Empty;
                    break;

                case 4: //Cancel                
                    ToolBarOnClick("SaveAndCancel");
                    if (CurrencyListView.SelectedItems.Count > 0)
                    {
                        CurrencyListView_Click(null, null);
                    }
                    EditFlag = string.Empty;
                    break;
            }
        }

        private void txtY_CheckedChanged(object sender, EventArgs e)
        {
            txtN.Checked = !txtY.Checked;
        }

        private void txtN_CheckedChanged(object sender, EventArgs e)
        {
            txtY.Checked = !txtN.Checked;
        }


    }
}