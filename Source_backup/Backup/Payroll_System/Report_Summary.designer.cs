namespace Payroll_System {
    partial class Report_Summary {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_Summary));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CompanyBox = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.CuyBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LidBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "Department:";
            // 
            // DeptBox
            // 
            this.DeptBox.BackColor = System.Drawing.SystemColors.Control;
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(132, 49);
            this.DeptBox.MaxDropDownItems = 10;
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(204, 20);
            this.DeptBox.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Company:";
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(132, 23);
            this.CompanyBox.MaxDropDownItems = 10;
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(150, 20);
            this.CompanyBox.TabIndex = 38;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "Currency:";
            // 
            // CuyBox
            // 
            this.CuyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CuyBox.FormattingEnabled = true;
            this.CuyBox.Location = new System.Drawing.Point(132, 101);
            this.CuyBox.MaxDropDownItems = 10;
            this.CuyBox.Name = "CuyBox";
            this.CuyBox.Size = new System.Drawing.Size(99, 20);
            this.CuyBox.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 51;
            this.label4.Text = "Location:";
            // 
            // LidBox
            // 
            this.LidBox.BackColor = System.Drawing.SystemColors.Control;
            this.LidBox.FormattingEnabled = true;
            this.LidBox.Location = new System.Drawing.Point(132, 75);
            this.LidBox.MaxDropDownItems = 10;
            this.LidBox.Name = "LidBox";
            this.LidBox.Size = new System.Drawing.Size(120, 20);
            this.LidBox.TabIndex = 50;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(349, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 32);
            this.button1.TabIndex = 54;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Report_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CuyBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LidBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeptBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.button4);
            this.Name = "Report_Summary";
            this.Text = "Payroll Summary Report";
            this.Load += new System.EventHandler(this.Report_Summary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CompanyBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CuyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LidBox;
        private System.Windows.Forms.Button button1;
    }
}