namespace Payroll_System {
    partial class PayslipMail {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayslipMail));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtMailServer = new System.Windows.Forms.TextBox();
            this.txtMailPort = new System.Windows.Forms.TextBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendDemoMail = new System.Windows.Forms.Button();
            this.btnSendDemo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEportWord = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.TextBox();
            this.empGrid = new System.Windows.Forms.DataGridView();
            this.ckGrpid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gGrpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gCallname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CompanyBox = new System.Windows.Forms.ComboBox();
            this.labCount = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtTestAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSendAndAttach = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).BeginInit();
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
            this.imageList.Images.SetKeyName(25, "refresh.gif");
            this.imageList.Images.SetKeyName(26, "del.gif");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtPassword);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtUserName);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Controls.Add(this.txtMailServer);
            this.groupBox6.Controls.Add(this.txtMailPort);
            this.groupBox6.Controls.Add(this.txtSender);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtContent);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtSubject);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(950, 314);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Mail Profile";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtPassword.Location = new System.Drawing.Point(797, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 26);
            this.txtPassword.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(697, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Outlook Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtUserName.Location = new System.Drawing.Point(797, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(138, 26);
            this.txtUserName.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(703, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Outlook Account";
            // 
            // button5
            // 
            this.button5.Image = global::Payroll_System.Properties.Resources.Save;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(811, 178);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 111);
            this.button5.TabIndex = 34;
            this.button5.Text = "Save Profile";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtMailServer
            // 
            this.txtMailServer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtMailServer.Location = new System.Drawing.Point(86, 38);
            this.txtMailServer.Name = "txtMailServer";
            this.txtMailServer.Size = new System.Drawing.Size(425, 26);
            this.txtMailServer.TabIndex = 33;
            this.txtMailServer.Text = "July 2009 payslip";
            // 
            // txtMailPort
            // 
            this.txtMailPort.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtMailPort.Location = new System.Drawing.Point(86, 73);
            this.txtMailPort.Name = "txtMailPort";
            this.txtMailPort.Size = new System.Drawing.Size(121, 26);
            this.txtMailPort.TabIndex = 32;
            this.txtMailPort.Text = "July 2009 payslip";
            // 
            // txtSender
            // 
            this.txtSender.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtSender.Location = new System.Drawing.Point(86, 107);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(425, 26);
            this.txtSender.TabIndex = 31;
            this.txtSender.Text = "July 2009 payslip";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Sender";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(86, 178);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(719, 111);
            this.txtContent.TabIndex = 30;
            this.txtContent.Text = "Dear Colleagues,\r\n\r\nThe details shown below for your reference.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mail Content";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Port";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(86, 142);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(719, 26);
            this.txtSubject.TabIndex = 3;
            this.txtSubject.Text = "July 2009 payslip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mail Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mail Subject";
            // 
            // btnSendDemoMail
            // 
            this.btnSendDemoMail.Location = new System.Drawing.Point(779, 577);
            this.btnSendDemoMail.Name = "btnSendDemoMail";
            this.btnSendDemoMail.Size = new System.Drawing.Size(168, 26);
            this.btnSendDemoMail.TabIndex = 46;
            this.btnSendDemoMail.Text = "Send payslips to tester";
            this.btnSendDemoMail.UseVisualStyleBackColor = true;
            this.btnSendDemoMail.Click += new System.EventHandler(this.btnSendDemoMail_Click);
            // 
            // btnSendDemo
            // 
            this.btnSendDemo.Location = new System.Drawing.Point(624, 577);
            this.btnSendDemo.Name = "btnSendDemo";
            this.btnSendDemo.Size = new System.Drawing.Size(150, 26);
            this.btnSendDemo.TabIndex = 2;
            this.btnSendDemo.Text = "Send template to tester";
            this.btnSendDemo.UseVisualStyleBackColor = true;
            this.btnSendDemo.Click += new System.EventHandler(this.btnSendDemo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSendAndAttach);
            this.groupBox3.Controls.Add(this.btnEportWord);
            this.groupBox3.Controls.Add(this.btnExportPDF);
            this.groupBox3.Controls.Add(this.textLog);
            this.groupBox3.Controls.Add(this.empGrid);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.DeptBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.CompanyBox);
            this.groupBox3.Controls.Add(this.labCount);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Location = new System.Drawing.Point(12, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(950, 224);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payslip Mail";
            // 
            // btnEportWord
            // 
            this.btnEportWord.Image = global::Payroll_System.Properties.Resources.Word;
            this.btnEportWord.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEportWord.Location = new System.Drawing.Point(900, 52);
            this.btnEportWord.Name = "btnEportWord";
            this.btnEportWord.Size = new System.Drawing.Size(35, 35);
            this.btnEportWord.TabIndex = 48;
            this.btnEportWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEportWord.Click += new System.EventHandler(this.btnEportWord_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Image = global::Payroll_System.Properties.Resources.pdf24x24;
            this.btnExportPDF.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnExportPDF.Location = new System.Drawing.Point(859, 52);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(35, 35);
            this.btnExportPDF.TabIndex = 47;
            this.btnExportPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(575, 93);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(360, 124);
            this.textLog.TabIndex = 48;
            // 
            // empGrid
            // 
            this.empGrid.AllowUserToAddRows = false;
            this.empGrid.AllowUserToDeleteRows = false;
            this.empGrid.AllowUserToOrderColumns = true;
            this.empGrid.AllowUserToResizeRows = false;
            this.empGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.empGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckGrpid,
            this.gGrpid,
            this.gCallname,
            this.gEmail});
            this.empGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.empGrid.Location = new System.Drawing.Point(18, 52);
            this.empGrid.Name = "empGrid";
            this.empGrid.RowHeadersVisible = false;
            this.empGrid.RowHeadersWidth = 25;
            this.empGrid.RowTemplate.Height = 24;
            this.empGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empGrid.Size = new System.Drawing.Size(551, 166);
            this.empGrid.TabIndex = 47;
            // 
            // ckGrpid
            // 
            this.ckGrpid.HeaderText = "";
            this.ckGrpid.Name = "ckGrpid";
            this.ckGrpid.Width = 25;
            // 
            // gGrpid
            // 
            this.gGrpid.HeaderText = "Group ID";
            this.gGrpid.Name = "gGrpid";
            this.gGrpid.Width = 80;
            // 
            // gCallname
            // 
            this.gCallname.HeaderText = "Call Name";
            this.gCallname.Name = "gCallname";
            this.gCallname.Width = 120;
            // 
            // gEmail
            // 
            this.gEmail.HeaderText = "Work Email";
            this.gEmail.Name = "gEmail";
            this.gEmail.Width = 240;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Department";
            // 
            // DeptBox
            // 
            this.DeptBox.BackColor = System.Drawing.SystemColors.Control;
            this.DeptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(365, 23);
            this.DeptBox.MaxDropDownItems = 10;
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(204, 21);
            this.DeptBox.TabIndex = 44;
            this.DeptBox.SelectedIndexChanged += new System.EventHandler(this.DeptBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Company";
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CompanyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(72, 23);
            this.CompanyBox.MaxDropDownItems = 10;
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(206, 21);
            this.CompanyBox.TabIndex = 42;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.BackColor = System.Drawing.Color.Transparent;
            this.labCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCount.ForeColor = System.Drawing.Color.Black;
            this.labCount.Location = new System.Drawing.Point(859, 28);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(58, 16);
            this.labCount.TabIndex = 4;
            this.labCount.Text = "labCount";
            this.labCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.progressBar1.Location = new System.Drawing.Point(575, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(278, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 50;
            // 
            // btnSend
            // 
            this.btnSend.Image = global::Payroll_System.Properties.Resources.send;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSend.Location = new System.Drawing.Point(575, 52);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(115, 35);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send payslip";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtTestAddr
            // 
            this.txtTestAddr.Location = new System.Drawing.Point(252, 581);
            this.txtTestAddr.Name = "txtTestAddr";
            this.txtTestAddr.Size = new System.Drawing.Size(366, 20);
            this.txtTestAddr.TabIndex = 5;
            this.txtTestAddr.Text = "quinn.vo@nexcel.vn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tester email";
            // 
            // btnSendAndAttach
            // 
            this.btnSendAndAttach.Image = global::Payroll_System.Properties.Resources.send;
            this.btnSendAndAttach.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSendAndAttach.Location = new System.Drawing.Point(696, 52);
            this.btnSendAndAttach.Name = "btnSendAndAttach";
            this.btnSendAndAttach.Size = new System.Drawing.Size(157, 35);
            this.btnSendAndAttach.TabIndex = 49;
            this.btnSendAndAttach.Text = "Send payslip && attach";
            this.btnSendAndAttach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendAndAttach.Click += new System.EventHandler(this.btnSendAndAttach_Click);
            // 
            // PayslipMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(974, 835);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnSendDemoMail);
            this.Controls.Add(this.btnSendDemo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtTestAddr);
            this.Controls.Add(this.label1);
            this.Name = "PayslipMail";
            this.Text = "Payslip Mail";
            this.Load += new System.EventHandler(this.PayslipMail_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnSendDemo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtTestAddr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CompanyBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.TextBox txtMailServer;
        private System.Windows.Forms.TextBox txtMailPort;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnSendDemoMail;
        private System.Windows.Forms.DataGridView empGrid;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ckGrpid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gGrpid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gCallname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gEmail;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnEportWord;
        private System.Windows.Forms.Button btnSendAndAttach;
    }
}