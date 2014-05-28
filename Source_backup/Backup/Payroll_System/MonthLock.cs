using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System {
    public partial class MonthLock : First {
        
        TSQL tSQL;
        string newMonthlyStr;
        
        public MonthLock() {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void MonthLock_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            load_OpenMonthTxt();                        
            set_Addbutton();
            load_yearBox();
            load_LockMonth();            
        }

        private void load_OpenMonthTxt() {
            NowOpenMonth.Text = tSQL.LockData_openMonth(); 
        }

        private void load_LockMonth() {
            MonthLockList.Items.Clear();
            bool flag;
            string thisYearStr = this.get_valueformBox(YearBox);

            if (thisYearStr.Length != 4) return;
            
            DataTable dt = tSQL.LockData_getAllbyYear(thisYearStr);
            for (int i = 0; i < dt.Rows.Count; i++) {
                if (dt.Rows[i]["opening"].ToString() == "N")
                    flag = false;
                else
                    flag = true;
                MonthLockList.Items.Add(dt.Rows[i]["monthly"].ToString(), flag);
            }

        }

        private void load_yearBox() {
            YearBox.Items.Clear();
            DataTable tb = tSQL.LockData_selectbyYear();
            foreach (DataRow row in tb.Rows) {
                YearBox.Items.Add(row[0].ToString());
            }
            if(NowOpenMonth.Text !="")
                YearBox.Text = NowOpenMonth.Text.Substring(0,4);
            else
                YearBox.Text = DateTime.Now.ToString("yyyy");
        }

        private string get_valueformBox(ComboBox bx) {
            string reval = "";
            if (bx.Items.Count > 0 || bx.SelectedItem != null) {
                reval = bx.SelectedItem.ToString();
            }
            return reval;
        }

        private void set_Addbutton() {
            string str;
            string _year;
            string _month;
            DataTable tb = tSQL.LockData_getLastYear();
            _year = tb.Rows[0][0].ToString().Substring(0, 4);
            _month = tb.Rows[0][0].ToString().Substring(4, 2);
            DateTime d = new DateTime(Convert.ToInt16(_year), Convert.ToInt16(_month), 1);
            d = d.AddMonths(1);
            _year = d.ToString("yyyy");
            _month = d.ToString("MM");
            str = string.Format("add [{0}-{1}] record", _year, _month);
            newMonthlyStr = _year + _month;
            button1.Text = str;
            if(_month != "01") YearBox.Text = _year;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (tSQL.LockData_NewMonth(newMonthlyStr)) {
                tSQL.ExRateData_NewMonth(newMonthlyStr); //Ex Rate
                MessageBox.Show("Created.", "New Month", MessageBoxButtons.OK);                
                load_yearBox();                
                set_Addbutton();
                load_LockMonth();
            } else {
                MessageBox.Show(tSQL.errMessage, "Create Error", MessageBoxButtons.OK);
            }
        }

        private void MonthLockList_Click(object sender, EventArgs e) {
            for(int i=0;i< MonthLockList.Items.Count;i++){
                MonthLockList.SetItemChecked(i, false);
            }
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_LockMonth();
        }

        private void button2_Click(object sender, EventArgs e) {
            bool flag;
            int idx;
            if (MonthLockList.CheckedIndices.Count > 0) {
                idx = MonthLockList.CheckedIndices[0];
                NowOpenMonth.Text = MonthLockList.Items[idx].ToString();
                flag = tSQL.LockData_Update(MonthLockList.Items[idx].ToString());

                if (flag) {
                    MessageBox.Show("Saved.", "Save Record", MessageBoxButtons.OK);
                    ___MonthlyPwdKey = "";
                } else {
                    MessageBox.Show(tSQL.errMessage, "Save Record", MessageBoxButtons.OK);
                }
            } else {
                MessageBox.Show("Please tick off a item.", "Save Record", MessageBoxButtons.OK);
            }
           
        }


    }
}