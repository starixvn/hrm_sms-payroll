using System;
using System.Data;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class MonthLock : First
    {
        TSQL tSQL;
        string newMonthlyStr;

        public MonthLock()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonthLock_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.RemoteDBAbsPath());

            load_OpenMonthTxt();
            Set_AddButton();
            load_YearBox();
            load_LockMonth();

            MonthLockList.Sorted = true;
        }

        private void load_OpenMonthTxt()
        {
            NowOpenMonth.Text = tSQL.LockData_openMonth();
        }

        private void load_LockMonth()
        {
            MonthLockList.Items.Clear();
            bool flag;
            string thisYearStr = this.Get_ValueFromBox(YearBox);

            if (thisYearStr.Length != 4) return;

            DataTable dt = tSQL.LockData_getAllbyYear(thisYearStr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["opening"].ToString() == "N")
                    flag = false;
                else
                    flag = true;
                MonthLockList.Items.Add(dt.Rows[i]["monthly"].ToString(), flag);
            }

        }

        private void load_YearBox()
        {
            YearBox.Items.Clear();
            DataTable tb = tSQL.LockData_selectbyYear();
            foreach (DataRow row in tb.Rows)
            {
                YearBox.Items.Add(row[0].ToString());
            }
            if (NowOpenMonth.Text != string.Empty)
                YearBox.Text = NowOpenMonth.Text.Substring(0, 4);
            else
                YearBox.Text = DateTime.Now.ToString("yyyy");
        }

        private string Get_ValueFromBox(ComboBox bx)
        {
            string result = string.Empty;
            if (bx.Items.Count > 0 || bx.SelectedItem != null)
            {
                result = bx.SelectedItem.ToString();
            }
            return result;
        }

        private void Set_AddButton()
        {
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
            btnAdd.Text = str;
            if (_month != "01") YearBox.Text = _year;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tSQL.LockData_NewMonth(newMonthlyStr))
            {
                tSQL.ExRateData_NewMonth(newMonthlyStr); //Ex Rate
                MessageBox.Show("Created.", "New Month", MessageBoxButtons.OK);
                load_YearBox();
                Set_AddButton();
                load_LockMonth();


            }
            else
            {
                MessageBox.Show(tSQL.errMessage, "Create Error", MessageBoxButtons.OK);
            }
        }

        private void MonthLockList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MonthLockList.Items.Count; i++)
            {
                MonthLockList.SetItemChecked(i, false);
            }
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_LockMonth();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;
            int idx;

            if (MonthLockList.CheckedIndices.Count > 0)
            {
                idx = MonthLockList.CheckedIndices[0];

                NowOpenMonth.Text = MonthLockList.Items[idx].ToString();
                flag = tSQL.LockData_Update(MonthLockList.Items[idx].ToString());

                if (flag)
                {
                    DataTable dtKey = tSQL.getMonthlyPwdKey(NowOpenMonth.Text);
                    Random ran = new Random();
                    int attempt = ran.Next(3, 5);
                    string newMonthKey = string.Empty;

                    if (dtKey.Rows.Count > 0)
                    {
                        while (base.SaveKeyEncrypt(newMonthKey, false) != base.obj2str(dtKey.Rows[0][0]) && attempt > 0)
                        {
                            attempt--;

                            InputBoxResult inputResult = InputBox.Show("Please input this month decrypt key.", NowOpenMonth.Text, string.Empty);
                            if (inputResult.ReturnCode == DialogResult.OK)
                            {
                                newMonthKey = inputResult.Text;
                            }
                            else
                            {
                                this.Close();
                                newMonthKey = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        ___MonthlyPwdKey = string.Empty;
                        this.Close();
                    }

                    if (attempt == 0)
                    {
                        MessageBox.Show("Error Key!", "Check Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        ___MonthlyPwdKey = newMonthKey;
                        MessageBox.Show("Saved.", "Save Record", MessageBoxButtons.OK);
                    }

                    MonthLockList.Sorted = true;
                }
                else
                {
                    MessageBox.Show(tSQL.errMessage, "Save Record", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please tick off a item.", "Save Record", MessageBoxButtons.OK);
            }
        }
    }
}