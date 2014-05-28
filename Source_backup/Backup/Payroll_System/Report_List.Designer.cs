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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
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
            this.label2 = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CompanyBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "Root.GIF");
            this.imageList1.Images.SetKeyName(16, "contacts.gif");
            this.imageList1.Images.SetKeyName(17, "folder.gif");
            this.imageList1.Images.SetKeyName(18, "圖片14.png");
            this.imageList1.Images.SetKeyName(19, "圖片6.png");
            this.imageList1.Images.SetKeyName(20, "圖片5.png");
            this.imageList1.Images.SetKeyName(21, "圖片185.png");
            this.imageList1.Images.SetKeyName(22, "rbEdit.gif");
            this.imageList1.Images.SetKeyName(23, "_active__yes.gif");
            this.imageList1.Images.SetKeyName(24, "_active__cancel.gif");
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(917, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 24);
            this.button4.TabIndex = 26;
            this.button4.Text = "Close";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bankGrid
            // 
            this.bankGrid.AllowUserToAddRows = false;
            this.bankGrid.AllowUserToDeleteRows = false;
            this.bankGrid.AllowUserToResizeRows = false;
            this.bankGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bankGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.bankGrid.Location = new System.Drawing.Point(12, 42);
            this.bankGrid.MultiSelect = false;
            this.bankGrid.Name = "bankGrid";
            this.bankGrid.ReadOnly = true;
            this.bankGrid.RowHeadersWidth = 25;
            this.bankGrid.RowTemplate.Height = 24;
            this.bankGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bankGrid.Size = new System.Drawing.Size(961, 519);
            this.bankGrid.TabIndex = 37;
            // 
            // cNo
            // 
            this.cNo.HeaderText = "No";
            this.cNo.Name = "cNo";
            this.cNo.ReadOnly = true;
            this.cNo.Width = 40;
            // 
            // cCompany
            // 
            this.cCompany.HeaderText = "Company";
            this.cCompany.Name = "cCompany";
            this.cCompany.ReadOnly = true;
            this.cCompany.Width = 80;
            // 
            // cDepartment
            // 
            this.cDepartment.HeaderText = "Department";
            this.cDepartment.Name = "cDepartment";
            this.cDepartment.ReadOnly = true;
            this.cDepartment.Width = 60;
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 110;
            // 
            // cNick
            // 
            this.cNick.HeaderText = "Nick";
            this.cNick.Name = "cNick";
            this.cNick.ReadOnly = true;
            this.cNick.Width = 70;
            // 
            // cDoc
            // 
            this.cDoc.HeaderText = "Doc";
            this.cDoc.Name = "cDoc";
            this.cDoc.ReadOnly = true;
            // 
            // cLA
            // 
            this.cLA.HeaderText = "Probation Salary";
            this.cLA.Name = "cLA";
            this.cLA.ReadOnly = true;
            this.cLA.Width = 60;
            // 
            // cIncrement
            // 
            this.cIncrement.HeaderText = "Increment Salary";
            this.cIncrement.Name = "cIncrement";
            this.cIncrement.ReadOnly = true;
            this.cIncrement.Width = 60;
            // 
            // cAdditional
            // 
            this.cAdditional.HeaderText = "Additional Salary";
            this.cAdditional.Name = "cAdditional";
            this.cAdditional.ReadOnly = true;
            this.cAdditional.Width = 60;
            // 
            // cGross
            // 
            this.cGross.HeaderText = "Total Gross Salary";
            this.cGross.Name = "cGross";
            this.cGross.ReadOnly = true;
            this.cGross.Width = 60;
            // 
            // cunpaid
            // 
            this.cunpaid.HeaderText = "Unpaid Leave";
            this.cunpaid.Name = "cunpaid";
            this.cunpaid.ReadOnly = true;
            this.cunpaid.Width = 60;
            // 
            // cAdv
            // 
            this.cAdv.HeaderText = "Salary Advance";
            this.cAdv.Name = "cAdv";
            this.cAdv.ReadOnly = true;
            this.cAdv.Width = 60;
            // 
            // cLoan
            // 
            this.cLoan.HeaderText = "Loan";
            this.cLoan.Name = "cLoan";
            this.cLoan.ReadOnly = true;
            this.cLoan.Width = 60;
            // 
            // cNet
            // 
            this.cNet.HeaderText = "Total Net Salary";
            this.cNet.Name = "cNet";
            this.cNet.ReadOnly = true;
            this.cNet.Width = 60;
            // 
            // cReceived
            // 
            this.cReceived.HeaderText = "Amount to be received";
            this.cReceived.Name = "cReceived";
            this.cReceived.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "Department:";
            // 
            // DeptBox
            // 
            this.DeptBox.BackColor = System.Drawing.SystemColors.Control;
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(284, 11);
            this.DeptBox.MaxDropDownItems = 10;
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(204, 20);
            this.DeptBox.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Company:";
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(63, 11);
            this.CompanyBox.MaxDropDownItems = 10;
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(150, 20);
            this.CompanyBox.TabIndex = 38;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(494, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 32);
            this.button3.TabIndex = 42;
            this.button3.Text = "Query";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(564, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 32);
            this.button1.TabIndex = 43;
            this.button1.Text = "Export";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xls";
            // 
            // Report_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeptBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.bankGrid);
            this.Controls.Add(this.button4);
            this.Name = "Report_List";
            this.Text = "Payout List Report";
            this.Load += new System.EventHandler(this.Report_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView bankGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CompanyBox;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}