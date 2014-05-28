using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Payroll_System {
    public partial class PayRelationShip : First {

        TSQL tSQL;
        string EditFlag = null;
        int whereMethodID;
        int whereLocationID;
        ArrayList pCury;
        DataTable CurrencyDT;

        #region ==============  this form ===============
        public PayRelationShip() {
            InitializeComponent();
        }
        private void PayRelationShip_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            
            tSQL = new TSQL(base.remoteDBAbsPath());
            loadCurrencyData();

            //-----new --
            load_CurrencyHead2Grid();
            load_RelationDate2Grid();


            MethodToolBarOnClick("SaveAndCancel");
            LocationToolBarOnClick("SaveAndCancel");
            RelationToolBarOnClick("SaveAndCancel");
            load_MethodData2ListView();
            load_LocationData2ListView();

            load_MethodDDL();
            load_locationDDL();

            bankGrid_Click(null, null);
          
        }
        private void loadCurrencyData() {
            DataTable tb = tSQL.CurrencyData_SelectAll();
            pCury = new ArrayList();
            foreach (DataRow row in tb.Rows) {
                pCury.Add(row["Pcurrency"].ToString());
            }
        }       
        private void load_CurrencyHead2Grid() {
            CurrencyDT = tSQL.CurrencyData_SelectAll();
            DataGridViewCheckBoxColumn dvb;
            int insertPos = 5;
            foreach (DataRow row in CurrencyDT.Rows) {
                dvb = new DataGridViewCheckBoxColumn();
                dvb.FlatStyle = FlatStyle.Flat;
                dvb.SortMode = DataGridViewColumnSortMode.NotSortable;
                dvb.HeaderText = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                dvb.Name = dvb.HeaderText;
                dvb.Width = 55;
                bankGrid.Columns.Insert(insertPos, dvb);
                insertPos++;
            }                        
        }
        private void load_RelationDate2Grid() {
            
            bankGrid.Rows.Clear();
            DataTable tb = tSQL.PayRelationData_SelectAll();

            string prv_mid = "";
            string prv_lid = "";
            string mid = "";
            string lid = "";
            string mStr = "";
            string lStr = "";
            string _Pcurrency = "";
            bool newline;
            int i;
            int RowCount = bankGrid.Columns.Count;
            int linecount = -1;

            foreach (DataRow row in tb.Rows) {
                mid = row["methodID"].ToString();
                lid = row["locationID"].ToString();
                mStr = "";
                lStr = "";

                newline = false;
                //check
                if (mid != prv_mid) {
                    mStr = row["methodStr"].ToString();
                    newline = true;
                }
                if ( (mid == prv_mid && lid != prv_lid) || (mid != prv_mid) ) {
                    lStr = row["locationStr"].ToString();
                    newline = true;
                }

                if (newline) {
                    linecount++;

                    bankGrid.Rows.Add();
                    //hidden -- ¡õ
                    bankGrid.Rows[linecount].Cells[0].Value = mid;
                    bankGrid.Rows[linecount].Cells[1].Value = lid;
                    bankGrid.Rows[linecount].Cells[2].Value = row["methodStr"].ToString();
                    //hidden --¡ô
                    bankGrid.Rows[linecount].Cells[3].Value = mStr;
                    bankGrid.Rows[linecount].Cells[4].Value = lStr;
                    
                    for (i = 0; i < RowCount; i++) {                       
                        markGridCell(linecount, i);
                    }                    
                }

                // check box
                _Pcurrency = row["Pcurrency"].ToString();                
                bankGrid.Rows[linecount].Cells[_Pcurrency].Value = true;

                prv_mid = mid;
                prv_lid = lid;
            }
        }
        private void markGridCell(int rows, int cells) {
            bankGrid.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            bankGrid.Rows[rows].Cells[cells].Style.SelectionForeColor = Color.Wheat;
            bankGrid.Rows[rows].Cells[cells].ReadOnly = true;
        }
        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion ==================  this form ===============


        #region ==============  method ===============
        private void MethodToolBarOnClick(string act) {
            switch (act) {
                case "Add":
                    MethodBar.Buttons[0].Enabled = false;
                    MethodBar.Buttons[1].Enabled = false;
                    MethodBar.Buttons[2].Enabled = false;
                    MethodBar.Buttons[3].Enabled = true;
                    MethodBar.Buttons[4].Enabled = true;
                    MethodBox.Enabled = true;
                    MethodListView.Enabled = false;
                    break;
                case "Edit":
                    MethodBar.Buttons[0].Enabled = false;
                    MethodBar.Buttons[1].Enabled = false;
                    MethodBar.Buttons[2].Enabled = false;
                    MethodBar.Buttons[3].Enabled = true;
                    MethodBar.Buttons[4].Enabled = true;
                    MethodBox.Enabled = true;
                    MethodListView.Enabled = false;
                    break;
                case "SaveAndCancel":
                    MethodBar.Buttons[0].Enabled = true;
                    MethodBar.Buttons[1].Enabled = true;
                    MethodBar.Buttons[2].Enabled = true;
                    MethodBar.Buttons[3].Enabled = false;
                    MethodBar.Buttons[4].Enabled = false;
                    MethodBox.Enabled = false;
                    MethodListView.Enabled = true;
                    break;
                default:                   
                    break;
            }
        }
        private void load_MethodData2ListView() {
            DataTable tb;
            MethodListView.Items.Clear();
            tb = tSQL.PayMethodData_SelectAll();

            foreach (DataRow row in tb.Rows) {
                ListViewItem exList = new ListViewItem();
                exList.Text = row["methodID"].ToString();
                exList.SubItems.Add(row["methodStr"].ToString()); 
                MethodListView.Items.Add(exList);
            }
        }     
        private void MethodListView_Click(object sender, EventArgs e) {
            MethodBox.Text = MethodListView.SelectedItems[0].SubItems[1].Text.ToString();
        }
        private void MethodBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            DialogResult result;
            switch (MethodBar.Buttons.IndexOf(e.Button)) {
                case 0: //Add   
                    EditFlag = "Add";
                    MethodToolBarOnClick("Add");
                    MethodBox.Text = "";
                    MethodBox.Focus();
                    break;

                case 1: //Edit   
                    EditFlag = "Edit";
                    whereMethodID = 0;
                    if (MethodListView.SelectedItems.Count < 1) {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    MethodToolBarOnClick("Edit");
                    whereMethodID = Convert.ToInt16(MethodListView.SelectedItems[0].Text.ToString());
                    MethodBox.Focus();
                    break;

                case 2: //Del              
                    if (MethodListView.SelectedItems.Count < 1) {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        whereMethodID = Convert.ToInt16( MethodListView.SelectedItems[0].Text.ToString());
                        tSQL.PayMethodData_Delete(whereMethodID);
                        MethodBox.Text = "";
                        load_RelationDate2Grid();
                        load_MethodData2ListView();
                        load_MethodDDL();
                        MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                    }
                    break;

                case 3: //Save                
                    MethodToolBarOnClick("SaveAndCancel");
                    if (EditFlag == "Add") {
                        tSQL.PayMethodData_Insert(MethodBox.Text);
                        MessageBox.Show("Created.", "Add Record", MessageBoxButtons.OK);
                    } else if (EditFlag == "Edit") {
                        tSQL.PayMethodData_Update(MethodBox.Text, whereMethodID);
                        MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                    }
                    load_RelationDate2Grid();
                    load_MethodData2ListView();
                    load_MethodDDL();
                    EditFlag = "";
                    break;
                case 4: //Cancel                
                    MethodToolBarOnClick("SaveAndCancel");
                    if (MethodListView.SelectedItems.Count > 0) {
                        MethodListView_Click(null, null);
                    }
                    EditFlag = "";
                    break;
            }
        }
        #endregion ==================  method ===============


        #region ==============  Location ===============
        private void LocationToolBarOnClick(string act) {
            switch (act) {
                case "Add":
                    LocationBar.Buttons[0].Enabled = false;
                    LocationBar.Buttons[1].Enabled = false;
                    LocationBar.Buttons[2].Enabled = false;
                    LocationBar.Buttons[3].Enabled = true;
                    LocationBar.Buttons[4].Enabled = true;
                    LocationBox.Enabled = true;
                    LocationListView.Enabled = false;
                    break;
                case "Edit":
                    LocationBar.Buttons[0].Enabled = false;
                    LocationBar.Buttons[1].Enabled = false;
                    LocationBar.Buttons[2].Enabled = false;
                    LocationBar.Buttons[3].Enabled = true;
                    LocationBar.Buttons[4].Enabled = true;
                    LocationBox.Enabled = true;
                    LocationListView.Enabled = false;
                    break;
                case "SaveAndCancel":
                    LocationBar.Buttons[0].Enabled = true;
                    LocationBar.Buttons[1].Enabled = true;
                    LocationBar.Buttons[2].Enabled = true;
                    LocationBar.Buttons[3].Enabled = false;
                    LocationBar.Buttons[4].Enabled = false;
                    LocationBox.Enabled = false;
                    LocationListView.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        private void load_LocationData2ListView() {
            DataTable tb;
            LocationListView.Items.Clear();
            tb = tSQL.PayLocationData_SelectAll();

            foreach (DataRow row in tb.Rows) {
                ListViewItem exList = new ListViewItem();
                exList.Text = row["locationID"].ToString();
                exList.SubItems.Add(row["locationStr"].ToString());
                LocationListView.Items.Add(exList);
            }
        } 
        private void LocationListView_Click(object sender, EventArgs e) {
            LocationBox.Text = LocationListView.SelectedItems[0].SubItems[1].Text.ToString();
        }   
        private void LocationBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            DialogResult result;
            switch (LocationBar.Buttons.IndexOf(e.Button)) {
                case 0: //Add   
                    EditFlag = "Add";
                    LocationToolBarOnClick("Add");
                    LocationBox.Text = "";
                    LocationBox.Focus();
                    break;

                case 1: //Edit   
                    EditFlag = "Edit";
                    whereLocationID = 0;
                    if (LocationListView.SelectedItems.Count < 1) {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    LocationToolBarOnClick("Edit");
                    whereLocationID = Convert.ToInt16(LocationListView.SelectedItems[0].Text.ToString());
                    LocationBox.Focus();
                    break;

                case 2: //Del              
                    if (LocationListView.SelectedItems.Count < 1) {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        whereLocationID = Convert.ToInt16(LocationListView.SelectedItems[0].Text.ToString());
                        tSQL.PayLocationData_Delete(whereLocationID);
                        LocationBox.Text = "";
                        load_RelationDate2Grid();
                        load_LocationData2ListView();
                        load_locationDDL();
                        MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                    }
                    break;

                case 3: //Save                
                    LocationToolBarOnClick("SaveAndCancel");
                    if (EditFlag == "Add") {
                        tSQL.PayLocationData_Insert(LocationBox.Text);
                        MessageBox.Show("Created.", "Add Record", MessageBoxButtons.OK);
                    } else if (EditFlag == "Edit") {
                        tSQL.PayLocationData_Update(LocationBox.Text, whereLocationID);
                        MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                    }
                    load_RelationDate2Grid();
                    load_LocationData2ListView();
                    load_locationDDL();
                    EditFlag = "";
                    break;
                case 4: //Cancel                
                    LocationToolBarOnClick("SaveAndCancel");
                    if (LocationListView.SelectedItems.Count > 0) {
                        LocationListView_Click(null, null);
                    }
                    EditFlag = "";
                    break;
            }
        }
        #endregion ==================  Location ===============


        #region ==============  Relation ===============
        private void load_MethodDDL() {
            MethodDDL.Items.Clear();
            int count = MethodListView.Items.Count;
            for (int i = 0; i < count; i++) {
                MethodDDL.Items.Add(MethodListView.Items[i].SubItems[1].Text);
            }
        }
        private void load_locationDDL() {
            locationDDL.Items.Clear();
            int count = LocationListView.Items.Count;
            for (int i = 0; i < count; i++) {
                locationDDL.Items.Add(LocationListView.Items[i].SubItems[1].Text);
            }
        }        
        private void RelationToolBarOnClick(string act) {
            switch (act) {
                case "Add":
                    RelationBar.Buttons[0].Enabled = false;
                    RelationBar.Buttons[1].Enabled = false;
                    RelationBar.Buttons[2].Enabled = false;
                    RelationBar.Buttons[3].Enabled = true;
                    RelationBar.Buttons[4].Enabled = true;
                    MethodDDL.Enabled = true;
                    locationDDL.Enabled = true;
                    bankGrid.Enabled = false;
                    setPCury.Enabled = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    unsetPCury.Visible = true;
                    break;
                case "Edit":
                    RelationBar.Buttons[0].Enabled = false;
                    RelationBar.Buttons[1].Enabled = false;
                    RelationBar.Buttons[2].Enabled = false;
                    RelationBar.Buttons[3].Enabled = true;
                    RelationBar.Buttons[4].Enabled = true;
                    MethodDDL.Enabled = false;
                    locationDDL.Enabled = false;
                    bankGrid.Enabled = false;
                    setPCury.Enabled = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    unsetPCury.Visible = true;
                    break;
                case "SaveAndCancel":
                    RelationBar.Buttons[0].Enabled = true;
                    RelationBar.Buttons[1].Enabled = true;
                    RelationBar.Buttons[2].Enabled = true;
                    RelationBar.Buttons[3].Enabled = false;
                    RelationBar.Buttons[4].Enabled = false;
                    MethodDDL.Enabled = false;
                    locationDDL.Enabled = false;
                    bankGrid.Enabled = true;
                    setPCury.Enabled = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    unsetPCury.Visible = false;
                    break;
                default:
                    break;
            }
        }
        private void RelationBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            DialogResult result;
            switch (RelationBar.Buttons.IndexOf(e.Button)) {
                case 0: //Add   
                    EditFlag = "Add";
                    RelationToolBarOnClick("Add");
                    setPCury.Items.Clear();
                    unsetPCury.Items.Clear();
                    for (int i = 0; i < pCury.Count; i++) {                        
                        unsetPCury.Items.Add(pCury[i].ToString());                  
                    }
                    break;
                case 1: //Edit   
                    EditFlag = "Edit";
                    if (bankGrid.SelectedRows.Count < 1) {
                        MessageBox.Show("Please select a record to modify.", "Modify Record", MessageBoxButtons.OK);
                        break;
                    }
                    RelationToolBarOnClick("Edit");
                    break;
                case 2: //Del              
                    if (bankGrid.SelectedRows.Count < 1) {
                        MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK);
                        break;
                    }
                    result = MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        string __mid = findMid(MethodDDL.SelectedItem.ToString());
                        string __lid = findLid(locationDDL.SelectedItem.ToString());
                        tSQL.PayRelationData_Delete(__mid, __lid);              

                        load_RelationDate2Grid();
                        MessageBox.Show("Deleted.", "Delete Record", MessageBoxButtons.OK);
                    }
                    break;

                case 3: //Save                
                    RelationToolBarOnClick("SaveAndCancel");
                    if (EditFlag == "Add") {
                        this.insertRelation();
                        MessageBox.Show("Created.", "Add Record", MessageBoxButtons.OK);
                    } else if (EditFlag == "Edit") {
                        this.insertRelation();
                        MessageBox.Show("Modified.", "Modify Record", MessageBoxButtons.OK);
                    }
                    load_RelationDate2Grid();
                    EditFlag = "";
                    break;
                case 4: //Cancel                
                    RelationToolBarOnClick("SaveAndCancel");
                    if (bankGrid.SelectedRows.Count > 0) {
                        bankGrid_Click(null, null);
                    }
                    EditFlag = "";
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            if (unsetPCury.SelectedItem != null) {
                setPCury.Items.Add(unsetPCury.SelectedItem.ToString());
                unsetPCury.Items.RemoveAt(unsetPCury.SelectedIndex);
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            if (setPCury.SelectedItem != null) {
                unsetPCury.Items.Add(setPCury.SelectedItem.ToString());
                setPCury.Items.RemoveAt(setPCury.SelectedIndex);
            }
        }
        private bool insertRelation() {
            bool flag = true;
            string mid = findMid(MethodDDL.SelectedItem.ToString());
            string lid = findLid(locationDDL.SelectedItem.ToString());

            tSQL.PayRelationData_Delete(mid, lid);
            if (MethodDDL.SelectedItem != null && locationDDL.SelectedItem != null) {
                for (int i = 0; i < setPCury.Items.Count; i++) {
                    flag = flag && tSQL.PayRelationData_Insert(mid, lid, setPCury.Items[i].ToString());
                }   
            }             
            return flag;
        }
        private string findMid(string MethodStr) {
            string mid = "";
            for (int i = 0; i < MethodListView.Items.Count; i++) {
                if (MethodStr == MethodListView.Items[i].SubItems[1].Text) {
                    mid = MethodListView.Items[i].SubItems[0].Text;
                    break;
                }
            }
            return mid;
        }
        private string findLid(string locationStr) {
            string lid = "";
            for (int i = 0; i < LocationListView.Items.Count; i++) {
                if (locationStr == LocationListView.Items[i].SubItems[1].Text) {
                    lid = LocationListView.Items[i].SubItems[0].Text;
                    break;
                }
            }
            return lid;
        }        
        private void bankGrid_Click(object sender, EventArgs e) {
            string mid = bankGrid.SelectedRows[0].Cells[0].Value.ToString();
            string lid = bankGrid.SelectedRows[0].Cells[1].Value.ToString();
            string mstr = bankGrid.SelectedRows[0].Cells[2].Value.ToString();
            string lstr = bankGrid.SelectedRows[0].Cells[4].Value.ToString();
            ArrayList setC = new ArrayList();

            MethodDDL.Text = mstr;
            locationDDL.Text = lstr;

            //show currency
            int i;
            string _pcurrency;
            object value;
            setPCury.Items.Clear();
            unsetPCury.Items.Clear();
            for (i = 0; i < CurrencyDT.Rows.Count; i++) {
                _pcurrency = CurrencyDT.Rows[i][0].ToString();
                value = bankGrid.SelectedRows[0].Cells[_pcurrency].Value;
                if (Convert.ToBoolean(value)) {
                    setPCury.Items.Add(_pcurrency);
                    setC.Add(_pcurrency);
                }
            }
            for (i = 0; i < pCury.Count; i++) {
                if (setC.IndexOf(pCury[i].ToString()) < 0) {
                    unsetPCury.Items.Add(pCury[i].ToString());
                }
            }
        }
        #endregion ==================  Relation ===============

    }
}