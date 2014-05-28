namespace Payroll_System {
    partial class Report_List {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_List));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.companyBox = new System.Windows.Forms.ComboBox();
            this.bankGrid = new System.Windows.Forms.DataGridView();
            this.cNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIncrement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAdditional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunpaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "Root.GIF");
            this.imageList.Images.SetKeyName(16, "contacts.gif");
            this.imageList.Images.SetKeyName(17, "folder.gif");
            this.imageList.Images.SetKeyName(18, "圖片14.png");
            this.imageList.Images.SetKeyName(19, "圖片6.png");
            this.imageList.Images.SetKeyName(20, "圖片5.png");
            this.imageList.Images.SetKeyName(21, "圖片185.png");
            this.imageList.Images.SetKeyName(22, "rbEdit.gif");
            this.imageList.Images.SetKeyName(23, "_active__yes.gif");
            this.imageList.Images.SetKeyName(24, "_active__cancel.gif");
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel|*.xls";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Payroll_System.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(670, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(64, 29);
            this.btnExport.TabIndex = 43;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::Payroll_System.Properties.Resources.find;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(600, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(64, 29);
            this.btnQuery.TabIndex = 42;
            this.btnQuery.Text = "Query";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Department";
            // 
            // DeptBox
            // 
            this.DeptBox.BackColor = System.Drawing.SystemColors.Control;
            this.DeptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(390, 20);
            this.DeptBox.MaxDropDownItems = 10;
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(204, 21);
            this.DeptBox.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Company";
            // 
            // companyBox
            // 
            this.companyBox.BackColor = System.Drawing.SystemColors.Control;
            this.companyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companyBox.FormattingEnabled = true;
            this.companyBox.Location = new System.Drawing.Point(63, 20);
            this.companyBox.MaxDropDownItems = 10;
            this.companyBox.Name = "companyBox";
            this.companyBox.Size = new System.Drawing.Size(228, 21);
            this.companyBox.TabIndex = 38;
            this.companyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // bankGrid
            // 
            this.bankGrid.AllowUserToAddRows = false;
            this.bankGrid.AllowUserToDeleteRows = false;
            this.bankGrid.AllowUserToResizeRows = false;
            this.bankGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.bankGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bankGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bankGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNo,
            this.cCompany,
            this.cDepartment,
            this.cName,
            this.cNick,
            this.cDoc,
            this.cLA,
            this.cIncrement,
            this.cAdditional,
            this.cGross,
            this.cunpaid,
            this.cAdv,
            this.cLoan,
            this.cNet,
            this.cReceived});
            this.bankGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.bankGrid.Location = new System.Drawing.Point(12, 46);
            this.bankGrid.MultiSelect = false;
            this.bankGrid.Name = "bankGrid";
            this.bankGrid.ReadOnly = true;
            this.bankGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.bankGrid.RowTemplate.Height = 24;
            this.bankGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bankGrid.Size = new System.Drawing.Size(960, 580);
            this.bankGrid.TabIndex = 37;
            // 
            // cNo
            // 
            this.cNo.HeaderText = "No";
            this.cNo.Name = "cNo";
            this.cNo.ReadOnly = true;
            this.cNo.Width = 46;
            // 
            // cCompany
            // 
            this.cCompany.HeaderText = "Company";
            this.cCompany.Name = "cCompany";
            this.cCompany.ReadOnly = true;
            this.cCompany.Width = 76;
            // 
            // cDepartment
            // 
            this.cDepartment.HeaderText = "Department";
            this.cDepartment.Name = "cDepartment";
            this.cDepartment.ReadOnly = true;
            this.cDepartment.Width = 87;
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 60;
            // 
            // cNick
            // 
            this.cNick.HeaderText = "Nick";
            this.cNick.Name = "cNick";
            this.cNick.ReadOnly = true;
            this.cNick.Width = 54;
            // 
            // cDoc
            // 
            this.cDoc.HeaderText = "Doc";
            this.cDoc.Name = "cDoc";
            this.cDoc.ReadOnly = true;
            this.cDoc.Width = 52;
            // 
            // cLA
            // 
            this.cLA.HeaderText = "Probation Salary";
            this.cLA.Name = "cLA";
            this.cLA.ReadOnly = true;
            // 
            // cIncrement
            // 
            this.cIncrement.HeaderText = "Increment Salary";
            this.cIncrement.Name = "cIncrement";
            this.cIncrement.ReadOnly = true;
            this.cIncrement.Width = 102;
            // 
            // cAdditional
            // 
            this.cAdditional.HeaderText = "Additional Salary";
            this.cAdditional.Name = "cAdditional";
            this.cAdditional.ReadOnly = true;
            this.cAdditional.Width = 101;
            // 
            // cGross
            // 
            this.cGross.HeaderText = "Total Gross Salary";
            this.cGross.Name = "cGross";
            this.cGross.ReadOnly = true;
            this.cGross.Width = 82;
            // 
            // cunpaid
            // 
            this.cunpaid.HeaderText = "Unpaid Leave";
            this.cunpaid.Name = "cunpaid";
            this.cunpaid.ReadOnly = true;
            this.cunpaid.Width = 91;
            // 
            // cAdv
            // 
            this.cAdv.HeaderText = "Salary Advance";
            this.cAdv.Name = "cAdv";
            this.cAdv.ReadOnly = true;
            this.cAdv.Width = 98;
            // 
            // cLoan
            // 
            this.cLoan.HeaderText = "Loan";
            this.cLoan.Name = "cLoan";
            this.cLoan.ReadOnly = true;
            this.cLoan.Width = 56;
            // 
            // cNet
            // 
            this.cNet.HeaderText = "Total Net Salary";
            this.cNet.Name = "cNet";
            this.cNet.ReadOnly = true;
            this.cNet.Width = 73;
            // 
            // cReceived
            // 
            this.cReceived.HeaderText = "Amount to be received";
            this.cReceived.Name = "cReceived";
            this.cReceived.ReadOnly = true;
            this.cReceived.Width = 74;
            // 
            // Report_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 648);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeptBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.companyBox);
            this.Controls.Add(this.bankGrid);
            this.Name = "Report_List";
            this.Text = "Payout List Report";
            this.Load += new System.EventHandler(this.Report_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridView bankGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox companyBox;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNick;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIncrement;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAdditional;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunpaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReceived;
    }
}