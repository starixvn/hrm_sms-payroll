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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.MonthLockList = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NowOpenMonth = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(917, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 24);
            this.button4.TabIndex = 24;
            this.button4.Text = "Close";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MonthLockList
            // 
            this.MonthLockList.CheckOnClick = true;
            this.MonthLockList.FormattingEnabled = true;
            this.MonthLockList.Location = new System.Drawing.Point(27, 73);
            this.MonthLockList.Name = "MonthLockList";
            this.MonthLockList.Size = new System.Drawing.Size(538, 259);
            this.MonthLockList.TabIndex = 25;
            this.MonthLockList.Click += new System.EventHandler(this.MonthLockList_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "add [2009-06] record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Save Changed";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "Year:";
            // 
            // YearBox
            // 
            this.YearBox.BackColor = System.Drawing.SystemColors.Control;
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(61, 47);
            this.YearBox.MaxDropDownItems = 10;
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(91, 20);
            this.YearBox.TabIndex = 33;
            this.YearBox.SelectedIndexChanged += new System.EventHandler(this.YearBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NowOpenMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(27, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 57);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "Open Month:";
            // 
            // NowOpenMonth
            // 
            this.NowOpenMonth.AutoSize = true;
            this.NowOpenMonth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NowOpenMonth.ForeColor = System.Drawing.Color.BlueViolet;
            this.NowOpenMonth.Location = new System.Drawing.Point(102, 27);
            this.NowOpenMonth.Name = "NowOpenMonth";
            this.NowOpenMonth.Size = new System.Drawing.Size(46, 16);
            this.NowOpenMonth.TabIndex = 34;
            this.NowOpenMonth.Text = "label3";
            // 
            // MonthLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;  this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MonthLockList);
            this.Controls.Add(this.button4);
            this.Name = "MonthLock";
            this.Text = "Months Lock";
            this.Load += new System.EventHandler(this.MonthLock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckedListBox MonthLockList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NowOpenMonth;
    }
}