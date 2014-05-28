namespace Payroll_System {
    partial class ExRate {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExRate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RecGrid = new System.Windows.Forms.DataGridView();
            this.ccMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecGrid)).BeginInit();
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RecGrid);
            this.groupBox3.Controls.Add(this.txtCurry);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.YearBox);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(22, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(936, 458);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exchange Rate";
            // 
            // RecGrid
            // 
            this.RecGrid.AllowUserToAddRows = false;
            this.RecGrid.AllowUserToDeleteRows = false;
            this.RecGrid.AllowUserToResizeRows = false;
            this.RecGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RecGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.RecGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RecGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ccMonth});
            this.RecGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.RecGrid.Location = new System.Drawing.Point(96, 74);
            this.RecGrid.MultiSelect = false;
            this.RecGrid.Name = "RecGrid";
            this.RecGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RecGrid.RowHeadersVisible = false;
            this.RecGrid.RowHeadersWidth = 5;
            this.RecGrid.RowTemplate.Height = 24;
            this.RecGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RecGrid.ShowCellToolTips = false;
            this.RecGrid.ShowEditingIcon = false;
            this.RecGrid.Size = new System.Drawing.Size(834, 349);
            this.RecGrid.TabIndex = 25;
            this.RecGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.RecGrid_CellBeginEdit);
            this.RecGrid.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.RecGrid_CancelRowEdit);
            this.RecGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecGrid_CellEndEdit);
            // 
            // ccMonth
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccMonth.DefaultCellStyle = dataGridViewCellStyle1;
            this.ccMonth.HeaderText = "Month";
            this.ccMonth.Name = "ccMonth";
            this.ccMonth.Width = 45;
            // 
            // txtCurry
            // 
            this.txtCurry.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtCurry.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurry.ForeColor = System.Drawing.Color.Yellow;
            this.txtCurry.FormattingEnabled = true;
            this.txtCurry.Location = new System.Drawing.Point(13, 220);
            this.txtCurry.MaxDropDownItems = 10;
            this.txtCurry.Name = "txtCurry";
            this.txtCurry.Size = new System.Drawing.Size(77, 24);
            this.txtCurry.TabIndex = 40;
            this.txtCurry.Text = "MYR";
            this.txtCurry.SelectedIndexChanged += new System.EventHandler(this.txtCurry_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "Open Month:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 349);
            this.label9.TabIndex = 34;
            this.label9.Text = "Base Currency";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(94, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "label3";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(712, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "Save (base Currency must is [MYR]";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "Year:";
            // 
            // YearBox
            // 
            this.YearBox.BackColor = System.Drawing.SystemColors.Control;
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(54, 48);
            this.YearBox.MaxDropDownItems = 10;
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(73, 20);
            this.YearBox.TabIndex = 26;
            this.YearBox.SelectedIndexChanged += new System.EventHandler(this.YearBox_SelectedIndexChanged);
            // 
            // ExRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Name = "ExRate";
            this.Text = "Monthly Exchange Rate";
            this.Load += new System.EventHandler(this.ExRate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExRate_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView RecGrid;
        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtCurry;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccMonth;
    }
}