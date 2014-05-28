namespace Payroll_System {
    partial class Report_Banking {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_Banking));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LidBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CuyBox = new System.Windows.Forms.ComboBox();
            this.MidBox = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Location";
            // 
            // LidBox
            // 
            this.LidBox.BackColor = System.Drawing.SystemColors.Control;
            this.LidBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LidBox.FormattingEnabled = true;
            this.LidBox.Location = new System.Drawing.Point(125, 57);
            this.LidBox.MaxDropDownItems = 10;
            this.LidBox.Name = "LidBox";
            this.LidBox.Size = new System.Drawing.Size(149, 21);
            this.LidBox.TabIndex = 46;
            this.LidBox.SelectedIndexChanged += new System.EventHandler(this.LidBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Currency";
            // 
            // CuyBox
            // 
            this.CuyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CuyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CuyBox.FormattingEnabled = true;
            this.CuyBox.Location = new System.Drawing.Point(125, 86);
            this.CuyBox.MaxDropDownItems = 10;
            this.CuyBox.Name = "CuyBox";
            this.CuyBox.Size = new System.Drawing.Size(91, 21);
            this.CuyBox.TabIndex = 48;
            // 
            // MidBox
            // 
            this.MidBox.BackColor = System.Drawing.SystemColors.Control;
            this.MidBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MidBox.FormattingEnabled = true;
            this.MidBox.Location = new System.Drawing.Point(125, 29);
            this.MidBox.MaxDropDownItems = 10;
            this.MidBox.Name = "MidBox";
            this.MidBox.Size = new System.Drawing.Size(149, 21);
            this.MidBox.TabIndex = 55;
            this.MidBox.SelectedIndexChanged += new System.EventHandler(this.MidBox_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Payroll_System.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(280, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 74);
            this.btnExport.TabIndex = 43;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Report_Banking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 805);
            this.Controls.Add(this.MidBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CuyBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LidBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Name = "Report_Banking";
            this.Text = "Banking Report";
            this.Load += new System.EventHandler(this.Report_Banking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LidBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CuyBox;
        private System.Windows.Forms.ComboBox MidBox;
        private System.Windows.Forms.Button btnExport;
    }
}