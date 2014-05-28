using System;
using System.Data;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class KeyChange : First
    {
        TSQL tSQL;
        string thisMonthy;

        public KeyChange()
        {
            InitializeComponent();
        }

        private void KeyChange_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.RemoteDBAbsPath());

            thisMonthy = tSQL.LockData_openMonth();
            label16.Text = base.YYMM2EnglishDate(thisMonthy);

            txtOldPwd.Text = ___EmpPwdKey;
            txtMontlyOldPwd.Text = ___MonthlyPwdKey;
        }

        private void btnSaveMontlyKey_Click(object sender, EventArgs e)
        {
            bool checkok = false;
            string oldPwd = string.Empty;
            string newPwd = string.Empty;
            string Pwd = this.returnMonthlyKey();
            if (Pwd == string.Empty)
            {
                // Not setting
                checkok = true;
            }
            else
            {
                // Check
                oldPwd = base.SaveKeyEncrypt(txtMontlyOldPwd.Text, false);
                if (oldPwd == Pwd)
                {
                    checkok = true;
                }
                else
                {
                    MessageBox.Show("Old password incorrect.", "Monthly Payment Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMontlyOldPwd.Focus();
                    txtMontlyOldPwd.SelectAll();
                    checkok = false;
                }
            }
            // New password
            if (checkok)
            {
                if (txtMontlyNewPwd.Text.Length == 8)
                {
                    checkok = true;
                }
                else
                {
                    MessageBox.Show("New password need 8 characters.", "Monthly Payment Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMontlyNewPwd.Focus();
                    txtMontlyNewPwd.SelectAll();
                    checkok = false;
                }
            }
            // Confirm
            if (checkok)
            {
                if (txtMontlyNewPwd.Text == txtMontlyConfirmPwd.Text)
                {
                    checkok = true;
                }
                else
                {
                    MessageBox.Show("Please confirm your new password.", "Monthly Payment Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMontlyConfirmPwd.Focus();
                    txtMontlyConfirmPwd.SelectAll();
                    checkok = false;
                }
            }

            if (checkok)
            {
                // Update password
                newPwd = base.SaveKeyEncrypt(txtMontlyNewPwd.Text, false);
                tSQL.MonthlyPwdKey_Update(thisMonthy, newPwd);

                // Batch update
                ___MonthlyPwdKey = txtMontlyNewPwd.Text;

                // All MonthlyPay_Main encrypt
                string GrpID;
                string Prob_Salary;
                string Incre_Amount;
                string Add_Amount;
                string Gross_Total;
                string Unpaid_Amount;
                string Adv_Amount;
                string Loan_Amount;
                string Dedu_Total;
                string Net_Salary;
                string Show_VarianceRM;
                string MYR_Gross;
                string MYR_Dedu;
                string MYR_Net;

                DataTable dt = tSQL.KeyData_MainSelectAll(thisMonthy);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Prob_Salary = base.obj2str(dt.Rows[i]["Prob_Salary"]);
                    Incre_Amount = base.obj2str(dt.Rows[i]["Incre_Amount"]);
                    Add_Amount = base.obj2str(dt.Rows[i]["Add_Amount"]);
                    Gross_Total = base.obj2str(dt.Rows[i]["Gross_Total"]);
                    Unpaid_Amount = base.obj2str(dt.Rows[i]["Unpaid_Amount"]);
                    Adv_Amount = base.obj2str(dt.Rows[i]["Adv_Amount"]);
                    Loan_Amount = base.obj2str(dt.Rows[i]["Loan_Amount"]);
                    Dedu_Total = base.obj2str(dt.Rows[i]["Dedu_Total"]);
                    Net_Salary = base.obj2str(dt.Rows[i]["Net_Salary"]);
                    Show_VarianceRM = base.obj2str(dt.Rows[i]["Show_VarianceRM"]);
                    MYR_Gross = base.obj2str(dt.Rows[i]["MYR_Gross"]);
                    MYR_Dedu = base.obj2str(dt.Rows[i]["MYR_Dedu"]);
                    MYR_Net = base.obj2str(dt.Rows[i]["MYR_Net"]);

                    // Restore
                    Prob_Salary = base.emp_pay_KeyDecrypt(Prob_Salary, txtMontlyOldPwd.Text);
                    Incre_Amount = base.emp_pay_KeyDecrypt(Incre_Amount, txtMontlyOldPwd.Text);
                    Add_Amount = base.emp_pay_KeyDecrypt(Add_Amount, txtMontlyOldPwd.Text);
                    Gross_Total = base.emp_pay_KeyDecrypt(Gross_Total, txtMontlyOldPwd.Text);
                    Unpaid_Amount = base.emp_pay_KeyDecrypt(Unpaid_Amount, txtMontlyOldPwd.Text);
                    Adv_Amount = base.emp_pay_KeyDecrypt(Adv_Amount, txtMontlyOldPwd.Text);
                    Loan_Amount = base.emp_pay_KeyDecrypt(Loan_Amount, txtMontlyOldPwd.Text);
                    Dedu_Total = base.emp_pay_KeyDecrypt(Dedu_Total, txtMontlyOldPwd.Text);
                    Net_Salary = base.emp_pay_KeyDecrypt(Net_Salary, txtMontlyOldPwd.Text);
                    Show_VarianceRM = base.emp_pay_KeyDecrypt(Show_VarianceRM, txtMontlyOldPwd.Text);
                    MYR_Gross = base.emp_pay_KeyDecrypt(MYR_Gross, txtMontlyOldPwd.Text);
                    MYR_Dedu = base.emp_pay_KeyDecrypt(MYR_Dedu, txtMontlyOldPwd.Text);
                    MYR_Net = base.emp_pay_KeyDecrypt(MYR_Net, txtMontlyOldPwd.Text);

                    // Reset
                    Prob_Salary = base.emp_pay_KeyEncryt(Prob_Salary, txtMontlyNewPwd.Text);
                    Incre_Amount = base.emp_pay_KeyEncryt(Incre_Amount, txtMontlyNewPwd.Text);
                    Add_Amount = base.emp_pay_KeyEncryt(Add_Amount, txtMontlyNewPwd.Text);
                    Gross_Total = base.emp_pay_KeyEncryt(Gross_Total, txtMontlyNewPwd.Text);
                    Unpaid_Amount = base.emp_pay_KeyEncryt(Unpaid_Amount, txtMontlyNewPwd.Text);
                    Adv_Amount = base.emp_pay_KeyEncryt(Adv_Amount, txtMontlyNewPwd.Text);
                    Loan_Amount = base.emp_pay_KeyEncryt(Loan_Amount, txtMontlyNewPwd.Text);
                    Dedu_Total = base.emp_pay_KeyEncryt(Dedu_Total, txtMontlyNewPwd.Text);
                    Net_Salary = base.emp_pay_KeyEncryt(Net_Salary, txtMontlyNewPwd.Text);
                    Show_VarianceRM = base.emp_pay_KeyEncryt(Show_VarianceRM, txtMontlyNewPwd.Text);
                    MYR_Gross = base.emp_pay_KeyEncryt(MYR_Gross, txtMontlyNewPwd.Text);
                    MYR_Dedu = base.emp_pay_KeyEncryt(MYR_Dedu, txtMontlyNewPwd.Text);
                    MYR_Net = base.emp_pay_KeyEncryt(MYR_Net, txtMontlyNewPwd.Text);

                    tSQL.KeyData_UpdateEncryMain(thisMonthy, GrpID,
                                 Prob_Salary,
                                 Incre_Amount,
                                 Add_Amount,
                                 Gross_Total,
                                 Unpaid_Amount,
                                 Adv_Amount,
                                 Loan_Amount,
                                 Dedu_Total,
                                 Net_Salary,
                                 Show_VarianceRM,
                                 MYR_Gross, MYR_Dedu, MYR_Net);
                }
                // All Bank encryt
                string Amount;
                string MYR_Amount;
                string Mid;
                string Lid;

                dt = tSQL.KeyData_BankSelectAll(thisMonthy);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Mid = base.obj2str(dt.Rows[i]["Mid"]);
                    Lid = base.obj2str(dt.Rows[i]["Lid"]);
                    Amount = base.obj2str(dt.Rows[i]["Amount"]);
                    MYR_Amount = base.obj2str(dt.Rows[i]["MYR_Amount"]);
                    // Restore
                    Amount = base.emp_pay_KeyDecrypt(Amount, txtMontlyOldPwd.Text);
                    MYR_Amount = base.emp_pay_KeyDecrypt(MYR_Amount, txtMontlyOldPwd.Text);
                    // Reset
                    Amount = base.emp_pay_KeyEncryt(Amount, txtMontlyNewPwd.Text);
                    MYR_Amount = base.emp_pay_KeyEncryt(MYR_Amount, txtMontlyNewPwd.Text);

                    tSQL.KeyData_UpdateEncryBank(thisMonthy, GrpID, Mid, Lid, Amount, MYR_Amount);
                }

                // All received
                string Pcurrency;
                dt = tSQL.KeyData_ReceivedSelectAll(thisMonthy);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Pcurrency = base.obj2str(dt.Rows[i]["Pcurrency"]);
                    Amount = base.obj2str(dt.Rows[i]["Amount"]);
                    // Restore
                    Amount = base.emp_pay_KeyDecrypt(Amount, txtMontlyOldPwd.Text);
                    // Reset
                    Amount = base.emp_pay_KeyEncryt(Amount, txtMontlyNewPwd.Text);

                    tSQL.KeyData_UpdateEncryReceived(thisMonthy, GrpID, Pcurrency, Amount);
                }

                MessageBox.Show("Successfully reset new key.", "Monthly Payment Key", MessageBoxButtons.OK);
                txtMontlyOldPwd.Text = ___MonthlyPwdKey;
                txtMontlyNewPwd.Text = string.Empty;
                txtMontlyConfirmPwd.Text = string.Empty;
            }

        }

        private string returnMonthlyKey()
        {
            string val = string.Empty;
            DataTable dt = tSQL.getMonthlyPwdKey(thisMonthy);
            if (dt.Rows.Count > 0)
            {
                val = base.obj2str(dt.Rows[0][0]);
            }
            return val;
        }

        private void btnSaveEmpKey_Click(object sender, EventArgs e)
        {
            // Check old pwd
            bool checkOk = false;
            string oldPwd = string.Empty;
            string newPwd = string.Empty;
            DataTable dt = tSQL.getEmpPwdKey();
            string EmpPwd = base.obj2str(dt.Rows[0][0]);

            if (EmpPwd == string.Empty)
            {
                // Not setting
                checkOk = true;
            }
            else
            {
                // Check
                oldPwd = base.SaveKeyEncrypt(txtOldPwd.Text, false);
                if (oldPwd == EmpPwd)
                {
                    checkOk = true;
                }
                else
                {
                    MessageBox.Show("Old password incorrect.", "Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOldPwd.Focus();
                    txtOldPwd.SelectAll();
                    checkOk = false;
                }
            }

            // New password
            if (checkOk)
            {
                if (txtNewPwd.Text.Length == 8)
                {
                    checkOk = true;
                }
                else
                {
                    MessageBox.Show("New password need 8 characters.", "Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPwd.Focus();
                    txtNewPwd.SelectAll();
                    checkOk = false;
                }
            }

            // Confirm
            if (checkOk)
            {
                if (txtNewPwd.Text == txtConfirmPwd.Text)
                {
                    checkOk = true;
                }
                else
                {
                    MessageBox.Show("Please confirm your new password.", "Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConfirmPwd.Focus();
                    txtConfirmPwd.SelectAll();
                    checkOk = false;
                }
            }

            if (checkOk)
            {
                // update password
                newPwd = base.SaveKeyEncrypt(txtNewPwd.Text, false);
                tSQL.EmpPwdKey_Update(newPwd);

                // batch update
                ___EmpPwdKey = txtNewPwd.Text;

                // all employee encryt
                string GrpID;
                string LASalary;
                string Incre_Amount;
                string Add_Amount;
                string BasicSalary;
                string Pcurrency;
                string Amount;
                dt = tSQL.EmployeeData_SelectAll();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    LASalary = base.obj2str(dt.Rows[i]["LASalary"]);
                    Incre_Amount = base.obj2str(dt.Rows[i]["Incre_Amount"]);
                    Add_Amount = base.obj2str(dt.Rows[i]["Add_Amount"]);
                    BasicSalary = base.obj2str(dt.Rows[i]["BasicSalary"]);

                    // Restore
                    LASalary = base.emp_pay_KeyDecrypt(LASalary, txtOldPwd.Text);
                    Incre_Amount = base.emp_pay_KeyDecrypt(Incre_Amount, txtOldPwd.Text);
                    Add_Amount = base.emp_pay_KeyDecrypt(Add_Amount, txtOldPwd.Text);
                    BasicSalary = base.emp_pay_KeyDecrypt(BasicSalary, txtOldPwd.Text);

                    // Reset
                    LASalary = base.emp_pay_KeyEncryt(LASalary, txtNewPwd.Text);
                    Incre_Amount = base.emp_pay_KeyEncryt(Incre_Amount, txtNewPwd.Text);
                    Add_Amount = base.emp_pay_KeyEncryt(Add_Amount, txtNewPwd.Text);
                    BasicSalary = base.emp_pay_KeyEncryt(BasicSalary, txtNewPwd.Text);

                    tSQL.EmployeeDate_SalaryUpdate(GrpID, LASalary, Incre_Amount, Add_Amount, BasicSalary);

                    // Reset salary in new db
                    DataTable months = tSQL.LockData_SelectAllMonthby();
                    string groupId = FormatGroupID(GrpID);
                    foreach (DataRow row in months.Rows)
                    {
                        string month = row[0] + string.Empty;
                        string figure = StorageHelper.GetProbationSalary(groupId, month);
                        if (!string.IsNullOrEmpty(figure))
                        {
                            figure = base.emp_pay_KeyDecrypt(figure, txtOldPwd.Text);
                            StorageHelper.SetProbationSalary(groupId, month, base.emp_pay_KeyEncryt(figure, txtNewPwd.Text));
                        }

                        figure = StorageHelper.GetBasicSalary(groupId, month);
                        if (!string.IsNullOrEmpty(figure))
                        {
                            figure = base.emp_pay_KeyDecrypt(figure, txtOldPwd.Text);
                            StorageHelper.SetBasicSalary(groupId, month, base.emp_pay_KeyEncryt(figure, txtNewPwd.Text));
                        }

                        figure = StorageHelper.GetIncrementSalary(groupId, month);
                        if (!string.IsNullOrEmpty(figure))
                        {
                            figure = base.emp_pay_KeyDecrypt(figure, txtOldPwd.Text);
                            StorageHelper.SetIncrementSalary(groupId, month, base.emp_pay_KeyEncryt(figure, txtNewPwd.Text));
                        }
                    }
                }

                // All employee received encryt
                dt = tSQL.ReceivedData_SelectAll();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Pcurrency = base.obj2str(dt.Rows[i]["Pcurrency"]);
                    Amount = base.obj2str(dt.Rows[i]["ref_money"]);
                    // Restore
                    Amount = base.emp_pay_KeyDecrypt(Amount, txtOldPwd.Text);
                    // Reset
                    Amount = base.emp_pay_KeyEncryt(Amount, txtNewPwd.Text);
                    tSQL.ReceivedData_Update(GrpID, Pcurrency, Amount);
                }

                MessageBox.Show("Successfully reset new key.", "Basic Salary Key", MessageBoxButtons.OK);
                txtOldPwd.Text = ___EmpPwdKey;
                txtNewPwd.Text = string.Empty;
                txtConfirmPwd.Text = string.Empty;
            }
        }
    }
}