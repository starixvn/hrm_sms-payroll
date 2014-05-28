using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class KeyEmp : First
    {
        TSQL tSQL;
        bool hasKey;
        public string callFormName;

        public KeyEmp()
        {
            InitializeComponent();
        }

        private void KeyEmp_Load(object sender, EventArgs e)
        {
            tSQL = new TSQL(base.RemoteDBAbsPath());

            hasKey = this.hasSetKey();
            if (!hasKey)
            {
                //MessageBox.Show("Please set new key for basic salary", "Set new key", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                btnUnlock.Text = "Set New Key";
                btnUnlock.ForeColor = Color.Red;
            }
        }

        private bool hasSetKey()
        {
            bool flag = false;
            DataTable dt = tSQL.getEmpPwdKey();
            if (base.obj2str(dt.Rows[0][0]) != string.Empty)
            {
                flag = true;
            }
            return flag;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string GrpID;
            string LASalary;
            string Incre_Amount;
            string Add_Amount;
            string BasicSalary;
            string Pcurrency;
            string Amount;

            bool flag;
            bool checkok = false;
            string Pwd = base.SaveKeyEncrypt(passBox.Text.Trim(), true);
            if (Pwd != string.Empty && !hasKey)
            {
                flag = tSQL.EmpPwdKey_Update(Pwd);
                if (flag)
                {
                    ___EmpPwdKey = passBox.Text.Trim();
                    checkok = true;

                    //all employee encryt
                    DataTable dt = tSQL.EmployeeData_SelectAll();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                        LASalary = base.obj2str(dt.Rows[i]["LASalary"]);
                        Incre_Amount = base.obj2str(dt.Rows[i]["Incre_Amount"]);
                        Add_Amount = base.obj2str(dt.Rows[i]["Add_Amount"]);
                        BasicSalary = base.obj2str(dt.Rows[i]["BasicSalary"]);

                        LASalary = base.empKeyEncryt(LASalary);
                        Incre_Amount = base.empKeyEncryt(Incre_Amount);
                        Add_Amount = base.empKeyEncryt(Add_Amount);
                        BasicSalary = base.empKeyEncryt(BasicSalary);
                        tSQL.EmployeeDate_SalaryUpdate(GrpID, LASalary, Incre_Amount, Add_Amount, BasicSalary);
                    }
                    //all employee received encryt
                    dt = tSQL.ReceivedData_SelectAll();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                        Pcurrency = base.obj2str(dt.Rows[i]["Pcurrency"]);
                        Amount = base.obj2str(dt.Rows[i]["ref_money"]);

                        Amount = base.empKeyEncryt(Amount);
                        tSQL.ReceivedData_Update(GrpID, Pcurrency, Amount);
                    }
                    MessageBox.Show("Successfully set new key.", "Basic Salary Key", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(tSQL.errMessage, "Basic Salary Key", MessageBoxButtons.OK);
                }
            }
            else if (Pwd != string.Empty && hasKey)
            {
                DataTable dt = tSQL.getEmpPwdKey();
                if (Pwd == base.obj2str(dt.Rows[0][0]))
                {
                    ___EmpPwdKey = passBox.Text.Trim();
                    checkok = true;
                }
                else
                {
                    MessageBox.Show("Error Key!", "Check Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passBox.Text = string.Empty;
                    passBox.Focus();
                }
            }

            if (checkok)
            {
                if (callFormName != string.Empty)
                {
                    Main FM = (Main)this.MdiParent;
                    FM.openChildForm(callFormName);
                }
                this.Close();
            }


        }

        private void passBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || passBox.Text.Length == 8)
            {
                btnUnlock_Click(null, null);
            }
        }

        private void passBox_TextChanged(object sender, EventArgs e)
        {
            if (passBox.Text.Length == 8)
            {
                btnUnlock_Click(null, null);
            }
        }

    }
}