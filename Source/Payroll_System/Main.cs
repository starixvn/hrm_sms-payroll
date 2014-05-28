using System;
using System.Windows.Forms;
using System.Drawing;

namespace Payroll_System
{
    public partial class Main : First
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login cf = new Login();
            cf.MdiParent = this;
            cf.Show();
        }

        protected bool hasEmpPwdKey(string FormName)
        {
            bool flag = false;
            if (___EmpPwdKey == string.Empty)
            {
                KeyEmp cf = new KeyEmp();
                cf.MdiParent = this;
                cf.callFormName = FormName;
                cf.Show();
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        protected bool hasPaymentPwdKey(string FormName)
        {
            bool flag = false;
            if (___MonthlyPwdKey == string.Empty)
            {
                KeyAmount cf = new KeyAmount();
                cf.MdiParent = this;
                cf.callFormName = FormName;
                cf.Show();
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public void openMenu()
        {
            menuStripTop.Items["setpuToolStripMenuItem"].Enabled = true;
            menuStripTop.Items["paymentToolStripMenuItem"].Enabled = true;
            menuStripTop.Items["monthlyExRateToolStripMenuItem"].Enabled = true;
            menuStripTop.Items["reportToolStripMenuItem"].Enabled = true;
            menuStripTop.Items["payslipToolStripMenuItem"].Enabled = true;
            menuStripTop.Items["backupToolStripMenuItem"].Enabled = true;
            menuStripTop.Items["changeKeyToolStripMenuItem"].Enabled = true;

            this.hasPaymentPwdKey(string.Empty);
            this.hasEmpPwdKey(string.Empty);
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        public void openChildForm(string formName)
        {
            switch (formName)
            {
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

        public void checkLoginCloseOrNot()
        {
            if (!___LoginPass) Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasEmpPwdKey("Employee"))
            {
                if (!base.CloseChildForm("Employee"))
                {
                    Employee cf = new Employee();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!base.CloseChildForm("Company"))
            {
                Company cf = new Company();
                cf.MdiParent = this;
                cf.Show();
            }
            else
            {
                base.form.Activate();
            }
            base.form = null;
        }

        private void payoutRelationshipMethodLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!base.CloseChildForm("PayRelationShip"))
            {
                PayRelationShip cf = new PayRelationShip();
                cf.MdiParent = this;
                cf.Show();
            }
            else
            {
                base.form.Activate();
            }
            base.form = null;
        }

        private void loginAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!base.CloseChildForm("Employee"))
            {
                LoginAccount cf = new LoginAccount();
                cf.MdiParent = this;
                cf.Show();
            }
            else
            {
                base.form.Activate();
            }
            base.form = null;
        }

        private void currencyTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!base.CloseChildForm("Currency"))
            {
                Currency cf = new Currency();
                cf.MdiParent = this;
                cf.Show();
            }
            else
            {
                base.form.Activate();
            }
            base.form = null;
        }

        private void payrollInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasEmpPwdKey("Payment") && this.hasPaymentPwdKey("Payment"))
            {
                if (!base.CloseChildForm("Payment"))
                {
                    Payment cf = new Payment();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }


        private void monthlyExchangeRateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!base.CloseChildForm("ExRate"))
            {
                ExRate cf = new ExRate();
                cf.MdiParent = this;
                cf.Show();
            }
            else
            {
                base.form.Activate();
            }
            base.form = null;
        }

        private void monthsLockedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!base.CloseChildForm("MonthLock"))
            {
                MonthLock cf = new MonthLock();
                cf.MdiParent = this;
                cf.Show();
            }
            else
            {
                base.form.Activate();
            }
            base.form = null;
        }

        private void payrollListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasPaymentPwdKey("Report_List"))
            {
                if (!base.CloseChildForm("Report_List"))
                {
                    Report_List cf = new Report_List();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }

        private void payrollSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasPaymentPwdKey("Report_Summary"))
            {
                if (!base.CloseChildForm("Report_Summary"))
                {
                    Report_Summary cf = new Report_Summary();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }

        private void bankingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasPaymentPwdKey("Report_Banking"))
            {
                if (!base.CloseChildForm("Report_Banking"))
                {
                    Report_Banking cf = new Report_Banking();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }

        private void payslipMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasEmpPwdKey("PayslipMail") && this.hasPaymentPwdKey("PayslipMail"))
            {
                if (!base.CloseChildForm("PayslipMail"))
                {
                    PayslipMail cf = new PayslipMail();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }

        private void expensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.hasPaymentPwdKey("Report_Expenses"))
            {
                if (!base.CloseChildForm("Report_Expenses"))
                {
                    Report_Expenses cf = new Report_Expenses();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }
                base.form = null;
            }
        }

        private void backUpDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string reMsg;
            result = MessageBox.Show("Run [back up database]?", "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                base.CloseChildForm(string.Empty);
                reMsg = CompactAccess.CompactAccessDB(base.RemoteDBAbsPath());
                if (reMsg == string.Empty)
                {
                    StorageHelper.Backup();
                    MessageBox.Show("Successfully back up database.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Back up failed: " + reMsg + "\n\nPlease restart the payroll system and then try again.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;

            DbBase AccessDB = new DbBase();
            AccessDB._startupPath = base.RemoteDBAbsPath();
            AccessDB.joinDBString();
            AccessDB.joinBackupString();

            string reMsg;
            result = MessageBox.Show("Run [recover database]?", "Recover", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                base.CloseChildForm(string.Empty);
                openFileDialogDb.FileName = AccessDB.BackupAbsFile;
                if (openFileDialogDb.ShowDialog() == DialogResult.OK)
                {
                    reMsg = CompactAccess.RecoverAccessDB(base.RemoteDBAbsPath(), openFileDialogDb.FileName);
                    if (reMsg == string.Empty)
                    {
                        StorageHelper.Recover();
                        MessageBox.Show("Successfully recover database. Application now will be restarted.", "Recover", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("Back up failed : " + reMsg + "\n\nPlease restart the payroll system and then try again.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            ___EmpPwdKey = string.Empty;
            ___MonthlyPwdKey = string.Empty;

        }

        private void changeKeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.hasEmpPwdKey("KeyChange") && this.hasPaymentPwdKey("KeyChange"))
            {
                if (!base.CloseChildForm("KeyChange"))
                {
                    KeyChange cf = new KeyChange();
                    cf.MdiParent = this;
                    cf.Show();
                }
                else
                {
                    base.form.Activate();
                }

                base.form = null;
            }
        }
    }
}