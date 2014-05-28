namespace Payroll_System
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileDialogDb = new System.Windows.Forms.OpenFileDialog();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.setpuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.monthsLockedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.currencyTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.payoutRelationshipMethodLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyExRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyExchangeRateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankingDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payslipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payslipMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeKeyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogDb
            // 
            this.openFileDialogDb.Filter = "Access|*.mdb";
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setpuToolStripMenuItem,
            this.monthlyExRateToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.payslipToolStripMenuItem,
            this.changeKeyToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.MdiWindowListItem = this.setpuToolStripMenuItem;
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(984, 24);
            this.menuStripTop.TabIndex = 1;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // setpuToolStripMenuItem
            // 
            this.setpuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginAccountToolStripMenuItem,
            this.toolStripSeparator4,
            this.monthsLockedToolStripMenuItem,
            this.toolStripSeparator2,
            this.currencyTypeToolStripMenuItem,
            this.toolStripSeparator3,
            this.payoutRelationshipMethodLocationToolStripMenuItem,
            this.toolStripSeparator1,
            this.companyToolStripMenuItem,
            this.staffToolStripMenuItem});
            this.setpuToolStripMenuItem.Enabled = false;
            this.setpuToolStripMenuItem.Name = "setpuToolStripMenuItem";
            this.setpuToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.setpuToolStripMenuItem.Text = "&Management";
            // 
            // loginAccountToolStripMenuItem
            // 
            this.loginAccountToolStripMenuItem.Name = "loginAccountToolStripMenuItem";
            this.loginAccountToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.loginAccountToolStripMenuItem.Text = "Login Account";
            this.loginAccountToolStripMenuItem.Click += new System.EventHandler(this.loginAccountToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(291, 6);
            // 
            // monthsLockedToolStripMenuItem
            // 
            this.monthsLockedToolStripMenuItem.Name = "monthsLockedToolStripMenuItem";
            this.monthsLockedToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.monthsLockedToolStripMenuItem.Text = "* Months Lock";
            this.monthsLockedToolStripMenuItem.Click += new System.EventHandler(this.monthsLockedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(291, 6);
            // 
            // currencyTypeToolStripMenuItem
            // 
            this.currencyTypeToolStripMenuItem.Name = "currencyTypeToolStripMenuItem";
            this.currencyTypeToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.currencyTypeToolStripMenuItem.Text = "&Currency";
            this.currencyTypeToolStripMenuItem.Click += new System.EventHandler(this.currencyTypeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // payoutRelationshipMethodLocationToolStripMenuItem
            // 
            this.payoutRelationshipMethodLocationToolStripMenuItem.Name = "payoutRelationshipMethodLocationToolStripMenuItem";
            this.payoutRelationshipMethodLocationToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.payoutRelationshipMethodLocationToolStripMenuItem.Text = "Payout Relationship (&Method && Location)";
            this.payoutRelationshipMethodLocationToolStripMenuItem.Click += new System.EventHandler(this.payoutRelationshipMethodLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(291, 6);
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.companyToolStripMenuItem.Text = "Company / &Department";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.companyToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.staffToolStripMenuItem.Text = "&Employee / Payout / Bank Account";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // monthlyExRateToolStripMenuItem
            // 
            this.monthlyExRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlyExchangeRateToolStripMenuItem1});
            this.monthlyExRateToolStripMenuItem.Enabled = false;
            this.monthlyExRateToolStripMenuItem.Name = "monthlyExRateToolStripMenuItem";
            this.monthlyExRateToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.monthlyExRateToolStripMenuItem.Text = "&Rate";
            // 
            // monthlyExchangeRateToolStripMenuItem1
            // 
            this.monthlyExchangeRateToolStripMenuItem1.Name = "monthlyExchangeRateToolStripMenuItem1";
            this.monthlyExchangeRateToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.monthlyExchangeRateToolStripMenuItem1.Text = "Monthly &Exchange Rate";
            this.monthlyExchangeRateToolStripMenuItem1.Click += new System.EventHandler(this.monthlyExchangeRateToolStripMenuItem1_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payrollInputToolStripMenuItem});
            this.paymentToolStripMenuItem.Enabled = false;
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.paymentToolStripMenuItem.Text = "&Payment";
            // 
            // payrollInputToolStripMenuItem
            // 
            this.payrollInputToolStripMenuItem.Name = "payrollInputToolStripMenuItem";
            this.payrollInputToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.payrollInputToolStripMenuItem.Text = "Payroll &Keyin";
            this.payrollInputToolStripMenuItem.Click += new System.EventHandler(this.payrollInputToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payrollListToolStripMenuItem,
            this.payrollSummaryToolStripMenuItem,
            this.bankingDetailsToolStripMenuItem,
            this.expensesReportToolStripMenuItem});
            this.reportToolStripMenuItem.Enabled = false;
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // payrollListToolStripMenuItem
            // 
            this.payrollListToolStripMenuItem.Name = "payrollListToolStripMenuItem";
            this.payrollListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.payrollListToolStripMenuItem.Text = "Payroll List";
            this.payrollListToolStripMenuItem.Click += new System.EventHandler(this.payrollListToolStripMenuItem_Click);
            // 
            // payrollSummaryToolStripMenuItem
            // 
            this.payrollSummaryToolStripMenuItem.Name = "payrollSummaryToolStripMenuItem";
            this.payrollSummaryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.payrollSummaryToolStripMenuItem.Text = "Payroll Summary";
            this.payrollSummaryToolStripMenuItem.Click += new System.EventHandler(this.payrollSummaryToolStripMenuItem_Click);
            // 
            // bankingDetailsToolStripMenuItem
            // 
            this.bankingDetailsToolStripMenuItem.Name = "bankingDetailsToolStripMenuItem";
            this.bankingDetailsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.bankingDetailsToolStripMenuItem.Text = "Banking Details";
            this.bankingDetailsToolStripMenuItem.Click += new System.EventHandler(this.bankingDetailsToolStripMenuItem_Click);
            // 
            // expensesReportToolStripMenuItem
            // 
            this.expensesReportToolStripMenuItem.Name = "expensesReportToolStripMenuItem";
            this.expensesReportToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.expensesReportToolStripMenuItem.Text = "Expenses Report";
            this.expensesReportToolStripMenuItem.Click += new System.EventHandler(this.expensesReportToolStripMenuItem_Click);
            // 
            // payslipToolStripMenuItem
            // 
            this.payslipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payslipMailToolStripMenuItem});
            this.payslipToolStripMenuItem.Enabled = false;
            this.payslipToolStripMenuItem.Name = "payslipToolStripMenuItem";
            this.payslipToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.payslipToolStripMenuItem.Text = "Pays&lip";
            // 
            // payslipMailToolStripMenuItem
            // 
            this.payslipMailToolStripMenuItem.Name = "payslipMailToolStripMenuItem";
            this.payslipMailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.payslipMailToolStripMenuItem.Text = "Payslip &Mail";
            this.payslipMailToolStripMenuItem.Click += new System.EventHandler(this.payslipMailToolStripMenuItem_Click);
            // 
            // changeKeyToolStripMenuItem
            // 
            this.changeKeyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeKeyToolStripMenuItem1});
            this.changeKeyToolStripMenuItem.Enabled = false;
            this.changeKeyToolStripMenuItem.Name = "changeKeyToolStripMenuItem";
            this.changeKeyToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.changeKeyToolStripMenuItem.Text = "&Key";
            // 
            // changeKeyToolStripMenuItem1
            // 
            this.changeKeyToolStripMenuItem1.Name = "changeKeyToolStripMenuItem1";
            this.changeKeyToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.changeKeyToolStripMenuItem1.Text = "Change &Key";
            this.changeKeyToolStripMenuItem1.Click += new System.EventHandler(this.changeKeyToolStripMenuItem1_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backUpDataToolStripMenuItem,
            this.restoreDatabaseToolStripMenuItem});
            this.backupToolStripMenuItem.Enabled = false;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "&Backup";
            // 
            // backUpDataToolStripMenuItem
            // 
            this.backUpDataToolStripMenuItem.Name = "backUpDataToolStripMenuItem";
            this.backUpDataToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.backUpDataToolStripMenuItem.Text = "&Back up Database";
            this.backUpDataToolStripMenuItem.Click += new System.EventHandler(this.backUpDataToolStripMenuItem_Click);
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            this.restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            this.restoreDatabaseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.restoreDatabaseToolStripMenuItem.Text = "Re&cover Database";
            this.restoreDatabaseToolStripMenuItem.Click += new System.EventHandler(this.restoreDatabaseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.menuStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripTop;
            this.MinimizeBox = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll System";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem setpuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currencyTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payoutRelationshipMethodLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loginAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem monthsLockedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyExRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyExchangeRateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankingDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payslipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payslipMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDb;
        private System.Windows.Forms.ToolStripMenuItem changeKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeKeyToolStripMenuItem1;

      
  


    }
}

