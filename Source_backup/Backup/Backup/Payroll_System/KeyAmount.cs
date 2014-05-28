using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System {
    public partial class KeyAmount : First {
        TSQL tSQL;
        bool hasKey;
        public string callFormName;
        string thisMonthyStr;

        public KeyAmount() {
            InitializeComponent();
        }
                
        private void KeyAmount_Load(object sender, EventArgs e) {
            tSQL = new TSQL(base.remoteDBAbsPath());

            thisMonthyStr = tSQL.LockData_openMonth();
            hasKey = this.hasSetKey();
            if (!hasKey) {
                //MessageBox.Show("Please set new key for monthly payment", "Set new key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button1.Text = "Set New Key (" + thisMonthyStr + ")";
                button1.ForeColor = Color.Red;
            } else {
                button1.Text += " (" + thisMonthyStr + ")";
            }
        }

        private bool hasSetKey() {
            bool flag = false;
            DataTable dt = tSQL.getMonthlyPwdKey(thisMonthyStr);
            if (dt.Rows.Count > 0) {
                if (base.obj2str(dt.Rows[0][0]) != "") {
                    flag = true;
                }
            }
            return flag;
        }

        private void button1_Click(object sender, EventArgs e) {
            bool flag;
            bool checkok = false;
            DataTable dt;
            string Pwd = base.SaveKeyEncrypt(passBox.Text.Trim(), true);
            if (Pwd != "" && !hasKey) {
                flag = tSQL.MonthlyPwdKey_Update(thisMonthyStr, Pwd);
                if (flag) {
                    ___MonthlyPwdKey = passBox.Text.Trim();
                    checkok = true;

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

                    dt = tSQL.KeyData_MainSelectAll(thisMonthyStr);
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

                        Prob_Salary = base.payKeyEncryt(Prob_Salary);
                        Incre_Amount = base.payKeyEncryt(Incre_Amount);
                        Add_Amount = base.payKeyEncryt(Add_Amount);
                        Gross_Total = base.payKeyEncryt(Gross_Total);
                        Unpaid_Amount = base.payKeyEncryt(Unpaid_Amount);
                        Adv_Amount = base.payKeyEncryt(Adv_Amount);
                        Loan_Amount = base.payKeyEncryt(Loan_Amount);
                        Dedu_Total = base.payKeyEncryt(Dedu_Total);
                        Net_Salary = base.payKeyEncryt(Net_Salary);
                        Show_VarianceRM = base.payKeyEncryt(Show_VarianceRM);
                        MYR_Gross = base.payKeyEncryt(MYR_Gross);
                        MYR_Dedu = base.payKeyEncryt(MYR_Dedu);
                        MYR_Net = base.payKeyEncryt(MYR_Net);

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

                        Amount = base.payKeyEncryt(Amount);
                        MYR_Amount = base.payKeyEncryt(MYR_Amount);

                        tSQL.KeyData_UpdateEncryBank(thisMonthyStr, GrpID, Mid, Lid, Amount, MYR_Amount);
                    }

                    //all received
                    string Pcurrency;
                    dt = tSQL.KeyData_ReceivedSelectAll(thisMonthyStr);
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        GrpID = base.obj2str(dt.Rows[i]["GrpID"]);
                        Pcurrency = base.obj2str(dt.Rows[i]["Pcurrency"]);
                        Amount = base.obj2str(dt.Rows[i]["Amount"]);

                        Amount = base.payKeyEncryt(Amount);

                        tSQL.KeyData_UpdateEncryReceived(thisMonthyStr, GrpID, Pcurrency, Amount);
                    }

                    MessageBox.Show("Successfully set new key.", "Set Key", MessageBoxButtons.OK);
                } else {
                    MessageBox.Show(tSQL.errMessage, "Set Key", MessageBoxButtons.OK);
                }
            } else if (Pwd != "" && hasKey) {
                dt = tSQL.getMonthlyPwdKey(thisMonthyStr);
                if (Pwd == base.obj2str(dt.Rows[0][0])) {
                    ___MonthlyPwdKey = passBox.Text.Trim();
                    checkok = true;
                } else {
                    MessageBox.Show("Error Key!", "Check Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passBox.Text = "";
                    passBox.Focus();
                }
            }

            if (checkok) {
                if (callFormName != "") {
                    Main FM = (Main)this.MdiParent;
                    FM.openChildForm(callFormName);
                }
                this.Close();
            }    
        }

        private void passBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                button1_Click(null, null);
            }
        }

    }
}