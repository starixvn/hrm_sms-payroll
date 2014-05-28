using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System {
    public partial class KeyChange : First {
        TSQL tSQL;
        string thisMonthyStr;

        public KeyChange() {
            InitializeComponent();
        }
        
        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void KeyChange_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            thisMonthyStr = tSQL.LockData_openMonth();
            label16.Text = base.YYMM2EnglishDate(thisMonthyStr);

            e_oldpwd.Text = ___EmpPwdKey;
            p_oldpwd.Text = ___MonthlyPwdKey;
        }

        private void btn_savepayment_Click(object sender, EventArgs e) {
            bool checkok = false;
            string oldPwd = "";
            string newPwd = "";
            string Pwd = this.returnMonthlyKey();
            if (Pwd == "") {
                // not setting
                checkok = true;
            } else {
                //check
                oldPwd = base.SaveKeyEncrypt(p_oldpwd.Text, false);
                if (oldPwd == Pwd) {
                    checkok = true;
                } else {
                    MessageBox.Show("Old password incorrect.", "Monthly Payment Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p_oldpwd.Focus();
                    p_oldpwd.SelectAll();
                    checkok = false;
                }
            }
            //new password
            if (checkok) {
                if (p_newpwd.Text.Length == 8) {
                    checkok = true;
                } else {
                    MessageBox.Show("New password need 8 characters.", "Monthly Payment Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p_newpwd.Focus();
                    p_newpwd.SelectAll();
                    checkok = false;
                }
            }
            //confirm
            if (checkok) {
                if (p_newpwd.Text == p_confirmpwd.Text) {
                    checkok = true;
                } else {
                    MessageBox.Show("Please confirm your new password.", "Monthly Payment Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p_confirmpwd.Focus();
                    p_confirmpwd.SelectAll();
                    checkok = false;
                }
            }

            if (checkok) {
                //update password
                newPwd = base.SaveKeyEncrypt(p_newpwd.Text, false);
                tSQL.MonthlyPwdKey_Update(thisMonthyStr, newPwd);

                //batch update
                ___MonthlyPwdKey = p_newpwd.Text;

                //all MonthlyPay_Main encryt                    
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

                DataTable dt = tSQL.KeyData_MainSelectAll(thisMonthyStr);
                for (int i = 0; i < dt.Rows.Count; i++) {
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
                    //restore
                    Prob_Salary = base.emp_pay_KeyDecrypt(Prob_Salary, p_oldpwd.Text);
                    Incre_Amount = base.emp_pay_KeyDecrypt(Incre_Amount, p_oldpwd.Text);
                    Add_Amount = base.emp_pay_KeyDecrypt(Add_Amount, p_oldpwd.Text);
                    Gross_Total = base.emp_pay_KeyDecrypt(Gross_Total, p_oldpwd.Text);
                    Unpaid_Amount = base.emp_pay_KeyDecrypt(Unpaid_Amount, p_oldpwd.Text);
                    Adv_Amount = base.emp_pay_KeyDecrypt(Adv_Amount, p_oldpwd.Text);
                    Loan_Amount = base.emp_pay_KeyDecrypt(Loan_Amount, p_oldpwd.Text);
                    Dedu_Total = base.emp_pay_KeyDecrypt(Dedu_Total, p_oldpwd.Text);
                    Net_Salary = base.emp_pay_KeyDecrypt(Net_Salary, p_oldpwd.Text);
                    Show_VarianceRM = base.emp_pay_KeyDecrypt(Show_VarianceRM, p_oldpwd.Text);
                    MYR_Gross = base.emp_pay_KeyDecrypt(MYR_Gross, p_oldpwd.Text);
                    MYR_Dedu = base.emp_pay_KeyDecrypt(MYR_Dedu, p_oldpwd.Text);
                    MYR_Net = base.emp_pay_KeyDecrypt(MYR_Net, p_oldpwd.Text);
                    //reset
                    Prob_Salary = base.emp_pay_KeyEncryt(Prob_Salary, p_newpwd.Text);
                    Incre_Amount = base.emp_pay_KeyEncryt(Incre_Amount, p_newpwd.Text);
                    Add_Amount = base.emp_pay_KeyEncryt(Add_Amount, p_newpwd.Text);
                    Gross_Total = base.emp_pay_KeyEncryt(Gross_Total, p_newpwd.Text);
                    Unpaid_Amount = base.emp_pay_KeyEncryt(Unpaid_Amount, p_newpwd.Text);
                    Adv_Amount = base.emp_pay_KeyEncryt(Adv_Amount, p_newpwd.Text);
                    Loan_Amount = base.emp_pay_KeyEncryt(Loan_Amount, p_newpwd.Text);
                    Dedu_Total = base.emp_pay_KeyEncryt(Dedu_Total, p_newpwd.Text);
                    Net_Salary = base.emp_pay_KeyEncryt(Net_Salary, p_newpwd.Text);
                    Show_VarianceRM = base.emp_pay_KeyEncryt(Show_VarianceRM, p_newpwd.Text);
                    MYR_Gross = base.emp_pay_KeyEncryt(MYR_Gross, p_newpwd.Text);
                    MYR_Dedu = base.emp_pay_KeyEncryt(MYR_Dedu, p_newpwd.Text);
                    MYR_Net = base.emp_pay_KeyEncryt(MYR_Net, p_newpwd.Text);

                    tSQL.KeyData_UpdateEncryMain(thisMonthyStr, GrpID,
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
                //all Bank encryt
                string Amount;
                string MYR_Amount;
                string Mid;
                string Lid;

                dt = tSQL.KeyData_BankSelectAll(thisMonthyStr);
                for (int i = 0; i < dt.Rows.Count; i++) {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Mid = base.obj2str(dt.Rows[i]["Mid"]);
                    Lid = base.obj2str(dt.Rows[i]["Lid"]);
                    Amount = base.obj2str(dt.Rows[i]["Amount"]);
                    MYR_Amount = base.obj2str(dt.Rows[i]["MYR_Amount"]);
                    //restore
                    Amount = base.emp_pay_KeyDecrypt(Amount, p_oldpwd.Text);
                    MYR_Amount = base.emp_pay_KeyDecrypt(MYR_Amount, p_oldpwd.Text);
                    //reset
                    Amount = base.emp_pay_KeyEncryt(Amount, p_newpwd.Text);
                    MYR_Amount = base.emp_pay_KeyEncryt(MYR_Amount, p_newpwd.Text);

                    tSQL.KeyData_UpdateEncryBank(thisMonthyStr, GrpID, Mid, Lid, Amount, MYR_Amount);
                }

                //all received
                string Pcurrency;
                dt = tSQL.KeyData_ReceivedSelectAll(thisMonthyStr);
                for (int i = 0; i < dt.Rows.Count; i++) {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Pcurrency = base.obj2str(dt.Rows[i]["Pcurrency"]);
                    Amount = base.obj2str(dt.Rows[i]["Amount"]);
                    //restore
                    Amount = base.emp_pay_KeyDecrypt(Amount, p_oldpwd.Text);
                    //reset
                    Amount = base.emp_pay_KeyEncryt(Amount, p_newpwd.Text);

                    tSQL.KeyData_UpdateEncryReceived(thisMonthyStr, GrpID, Pcurrency, Amount);
                }

                MessageBox.Show("Successfully reset new key.", "Monthly Payment Key", MessageBoxButtons.OK);
                p_oldpwd.Text = ___MonthlyPwdKey;
                p_newpwd.Text = "";
                p_confirmpwd.Text = "";
            }

        }

        private string returnMonthlyKey() {
            string val = "";
            DataTable dt = tSQL.getMonthlyPwdKey(thisMonthyStr);
            if (dt.Rows.Count > 0) {
                val = base.obj2str(dt.Rows[0][0]);
            }
            return val;
        }

        private void btn_saveEmp_Click(object sender, EventArgs e) {
            //check old pwd
            bool checkok = false;
            string oldPwd = "";
            string newPwd = "";
            DataTable dt = tSQL.getEmpPwdKey();
            string EmpPwd = base.obj2str(dt.Rows[0][0]);

            if (EmpPwd == "") {
                // not setting
                checkok = true;
            } else { 
                //check
                oldPwd = base.SaveKeyEncrypt(e_oldpwd.Text, false);
                if (oldPwd == EmpPwd) {
                    checkok = true;
                } else {
                    MessageBox.Show("Old password incorrect.", "Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e_oldpwd.Focus();
                    e_oldpwd.SelectAll();
                    checkok = false;
                }
            }

            //new password
            if (checkok) {
                if (e_newpwd.Text.Length == 8) {
                    checkok = true;
                } else {
                    MessageBox.Show("New password need 8 characters.", "Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e_newpwd.Focus();
                    e_newpwd.SelectAll();
                    checkok = false;
                }
            }
            //confirm
            if (checkok) {
                if (e_newpwd.Text == e_confirmpwd.Text) {
                    checkok = true;
                } else {
                    MessageBox.Show("Please confirm your new password.", "Basic Salary Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e_confirmpwd.Focus();
                    e_confirmpwd.SelectAll();
                    checkok = false;
                }
            }

            if (checkok) { 
                //update password
                newPwd = base.SaveKeyEncrypt(e_newpwd.Text, false);
                tSQL.EmpPwdKey_Update(newPwd);

                //batch update
                ___EmpPwdKey = e_newpwd.Text;
                
                //all employee encryt
                string GrpID;
                string LASalary;
                string Incre_Amount;
                string Add_Amount;
                string BasicSalary;
                string Pcurrency;
                string Amount;
                dt = tSQL.EmployeeData_SelectAll();
                for (int i = 0; i < dt.Rows.Count; i++) {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    LASalary = base.obj2str(dt.Rows[i]["LASalary"]);
                    Incre_Amount = base.obj2str(dt.Rows[i]["Incre_Amount"]);
                    Add_Amount = base.obj2str(dt.Rows[i]["Add_Amount"]);
                    BasicSalary = base.obj2str(dt.Rows[i]["BasicSalary"]);

                    //restore
                    LASalary = base.emp_pay_KeyDecrypt(LASalary, e_oldpwd.Text);
                    Incre_Amount = base.emp_pay_KeyDecrypt(Incre_Amount, e_oldpwd.Text);
                    Add_Amount = base.emp_pay_KeyDecrypt(Add_Amount, e_oldpwd.Text);
                    BasicSalary = base.emp_pay_KeyDecrypt(BasicSalary, e_oldpwd.Text);

                    //reset
                    LASalary = base.emp_pay_KeyEncryt(LASalary, e_newpwd.Text);
                    Incre_Amount = base.emp_pay_KeyEncryt(Incre_Amount, e_newpwd.Text);
                    Add_Amount = base.emp_pay_KeyEncryt(Add_Amount, e_newpwd.Text);
                    BasicSalary = base.emp_pay_KeyEncryt(BasicSalary, e_newpwd.Text);

                    tSQL.EmployeeDate_SalaryUpdate(GrpID, LASalary, Incre_Amount, Add_Amount, BasicSalary);
                }
                //all employee received encryt
                dt = tSQL.ReceivedData_SelectAll();
                for (int i = 0; i < dt.Rows.Count; i++) {
                    GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                    Pcurrency = base.obj2str(dt.Rows[i]["Pcurrency"]);
                    Amount = base.obj2str(dt.Rows[i]["ref_money"]);
                    //restore
                    Amount = base.emp_pay_KeyDecrypt(Amount, e_oldpwd.Text);
                    //reset
                    Amount = base.emp_pay_KeyEncryt(Amount, e_newpwd.Text);
                    tSQL.ReceivedData_Update(GrpID, Pcurrency, Amount);
                }
                MessageBox.Show("Successfully reset new key.", "Basic Salary Key", MessageBoxButtons.OK);
                e_oldpwd.Text = ___EmpPwdKey;
                e_newpwd.Text = "";
                e_confirmpwd.Text = "";
            }

        }

        

    }
}