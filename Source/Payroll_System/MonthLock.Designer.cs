namespace Payroll_System {
    partial class MonthLock {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthLock));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NowOpenMonth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.MonthLockList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NowOpenMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(12, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 62);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // NowOpenMonth
            // 
            this.NowOpenMonth.AutoSize = true;
            this.NowOpenMonth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NowOpenMonth.ForeColor = System.Drawing.Color.Blue;
            this.NowOpenMonth.Location = new System.Drawing.Point(80, 34);
            this.NowOpenMonth.Name = "NowOpenMonth";
            this.NowOpenMonth.Size = new System.Drawing.Size(103, 16);
            this.NowOpenMonth.TabIndex = 34;
            this.NowOpenMonth.Text = "Current Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Open Month";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Payroll_System.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(360, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 25);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save Changed";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Year";
            // 
            // YearBox
            // 
            this.YearBox.BackColor = System.Drawing.SystemColors.Control;
            this.YearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(46, 16);
            this.YearBox.MaxDropDownItems = 10;
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(91, 21);
            this.YearBox.TabIndex = 33;
            this.YearBox.SelectedIndexChanged += new System.EventHandler(this.YearBox_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Payroll_System.Properties.Resources.multiple;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdd.Location = new System.Drawing.Point(378, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(172, 25);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "add [2009-06] record";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MonthLockList
            // 
            this.MonthLockList.CheckOnClick = true;
            this.MonthLockList.FormattingEnabled = true;
            this.MonthLockList.Location = new System.Drawing.Point(12, 44);
            this.MonthLockList.Name = "MonthLockList";
            this.MonthLockList.Size = new System.Drawing.Size(538, 274);
            this.MonthLockList.TabIndex = 25;
            this.MonthLockList.Click += new System.EventHandler(this.MonthLockList_Click);
            // 
            // MonthLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 628);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.MonthLockList);
            this.Name = "MonthLock";
            this.Text = "Months Lock";
            this.Load += new System.EventHandler(this.MonthLock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckedListBox MonthLockList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NowOpenMonth;
    }
}