using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System{
    public partial class Main : First {
        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {            
            Login cf = new Login();
            cf.MdiParent = this;
            cf.Show();         
        }

        protected bool hasEmpPwdKey(string FormName) {
            bool flag = false;
            if (___EmpPwdKey == "") {
                KeyEmp cf = new KeyEmp();
                cf.MdiParent = this;
                cf.callFormName = FormName;
                cf.Show();                
            } else {
                flag = true;
            }
            return flag;
        }

        protected bool hasPaymentPwdKey(string FormName) {
            bool flag = false;
            if (___MonthlyPwdKey == "") {
                KeyAmount cf = new KeyAmount();
                cf.MdiParent = this;
                cf.callFormName = FormName;
                cf.Show();                
            } else {
                flag = true;
            }
            return flag;
        }

        public void openMenu() {
            menuStrip1.Items["setpuToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["paymentToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["monthlyExRateToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["reportToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["payslipToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["backupToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["changeKeyToolStripMenuItem"].Enabled = true;
            menuStrip1.Items["bugFixToolStripMenuItem"].Enabled = true;
            
            this.hasPaymentPwdKey("");
            this.hasEmpPwdKey("");
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        public void openChildForm(string formName) {
            switch (formName) { 
                case "Employee":
                    staffToolStripMenuItem_Click(null, null);
                    break;
                case "Payment":
                    payrollInputToolStripMenuItem_Click(null, null);
                    break;
                case "Report_List":
                    payrollListToolStripMenuItem_Click(null, null);
                    break;
                case "Report_Summary":
                    payrollSummaryToolStripMenuItem_Click(null, null);
                    break;
                case "Report_Banking":
                    bankingDetailsToolStripMenuItem_Click(null, null);
                    break;
                case "Report_Expenses":
                    expensesReportToolStripMenuItem_Click(null, null);
                    break;
                case "PayslipMail":
                    payslipMailToolStripMenuItem_Click(null, null);
                    break;
                case "KeyChange":
                    changeKeyToolStripMenuItem1_Click(null, null);
                    break;
            }
        }

        public void checkLoginCloseOrNot() {
            if (!___LoginPass) Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {
                MessageBox.Show("Bye Bye.", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasEmpPwdKey("Employee")) {
                if (!base.findChildForm("Employee")) {
                    Employee cf = new Employee();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }
        
        private void companyToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!base.findChildForm("Company")) {
                Company cf = new Company();
                cf.MdiParent = this;
                cf.Show();
            } else {
                base.fObj.Activate();
            }
            base.fObj = null;
        }



        private void payoutRelationshipMethodLocationToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!base.findChildForm("PayRelationShip")) {
                PayRelationShip cf = new PayRelationShip();
                cf.MdiParent = this;
                cf.Show();
            } else {
                base.fObj.Activate();
            }
            base.fObj = null;
        }

        private void loginAccountToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!base.findChildForm("Employee")) {
                LoginAccount cf = new LoginAccount();
                cf.MdiParent = this;
                cf.Show();
            } else {
                base.fObj.Activate();
            }
            base.fObj = null;
        }

        private void currencyTypeToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!base.findChildForm("Currency")) {
                Currency cf = new Currency();
                cf.MdiParent = this;
                cf.Show();
            } else {
                base.fObj.Activate();
            }
            base.fObj = null;
        }

        private void payrollInputToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasEmpPwdKey("Payment") && this.hasPaymentPwdKey("Payment")) {
                if (!base.findChildForm("Payment")) {
                    Payment cf = new Payment();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }


        private void monthlyExchangeRateToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (!base.findChildForm("ExRate")) {
                ExRate cf = new ExRate();
                cf.MdiParent = this;
                cf.Show();
            } else {
                base.fObj.Activate();
            }
            base.fObj = null;
        }
        
        private void monthsLockedToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!base.findChildForm("MonthLock")) {
                MonthLock cf = new MonthLock();
                cf.MdiParent = this;
                cf.Show();
            } else {
                base.fObj.Activate();
            }
            base.fObj = null;
        }

        private void payrollListToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasPaymentPwdKey("Report_List")) {
                if (!base.findChildForm("Report_List")) {
                    Report_List cf = new Report_List();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }

        private void payrollSummaryToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasPaymentPwdKey("Report_Summary")) {
                if (!base.findChildForm("Report_Summary")) {
                    Report_Summary cf = new Report_Summary();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }

        private void bankingDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasPaymentPwdKey("Report_Banking")) {
                if (!base.findChildForm("Report_Banking")) {
                    Report_Banking cf = new Report_Banking();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }

       
        private void payslipMailToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasEmpPwdKey("PayslipMail") && this.hasPaymentPwdKey("PayslipMail")) {
                if (!base.findChildForm("PayslipMail")) {
                    PayslipMail cf = new PayslipMail();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }

        private void expensesReportToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.hasPaymentPwdKey("Report_Expenses")) {
                if (!base.findChildForm("Report_Expenses")) {
                    Report_Expenses cf = new Report_Expenses();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }


        private void backUpDataToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result;
            string reMsg;
            result = MessageBox.Show("Run [back up database]?", "Backup", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                base.findChildForm("");
                reMsg = CompactAccess.CompactAccessDB(base.remoteDBAbsPath());
                if (reMsg == "")
                    MessageBox.Show("Successfully back up database.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.None);
                else
                    MessageBox.Show("Back up failed : " + reMsg + "\n\nPlease restart the payroll system and then try again.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result;

            DBbase AccessDB = new DBbase();
            AccessDB._stratupPath = base.remoteDBAbsPath();
            AccessDB.joinDBString();
            AccessDB.joinBackupString();
           
            string reMsg;
            result = MessageBox.Show("Run [recover database]?", "Recover", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                base.findChildForm("");
                openFileDialog1.FileName = AccessDB.BackupAbsFile;
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    reMsg = CompactAccess.RecoverAccessDB(base.remoteDBAbsPath(), openFileDialog1.FileName);
                    if (reMsg == "")
                        MessageBox.Show("Successfully recover database.", "Recover", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Back up failed : " + reMsg + "\n\nPlease restart the payroll system and then try again.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ___EmpPwdKey = "";
            ___MonthlyPwdKey = "";

        }

        private void changeKeyToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (this.hasEmpPwdKey("KeyChange") && this.hasPaymentPwdKey("KeyChange")) {
                if (!base.findChildForm("KeyChange")) {
                    KeyChange cf = new KeyChange();
                    cf.MdiParent = this;
                    cf.Show();
                } else {
                    base.fObj.Activate();
                }
                base.fObj = null;
            }
        }

        private void cannotSaveTwoBankAccountToolStripMenuItem_Click(object sender, EventArgs e) {
            TSQL tSQL = new TSQL(base.remoteDBAbsPath());
            tSQL.fixbankaccountkey();
            MessageBox.Show("fixed.");
        }

        private void fixReceiveBalanceToolStripMenuItem_Click(object sender, EventArgs e) {
            TSQL tSQL = new TSQL(base.remoteDBAbsPath());
            tSQL.fixreceivekey();
            MessageBox.Show("fixed.");
        }
      

    }
}