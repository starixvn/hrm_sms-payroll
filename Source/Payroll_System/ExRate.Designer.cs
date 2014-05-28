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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RecGrid = new System.Windows.Forms.DataGridView();
            this.ccMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.yearSelection = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecGrid)).BeginInit();
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RecGrid);
            this.groupBox3.Controls.Add(this.txtCurrency);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.yearSelection);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(936, 496);
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
            this.RecGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RecGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RecGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RecGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ccMonth});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RecGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.RecGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.RecGrid.Location = new System.Drawing.Point(96, 80);
            this.RecGrid.MultiSelect = false;
            this.RecGrid.Name = "RecGrid";
            this.RecGrid.RowHeadersWidth = 5;
            this.RecGrid.RowTemplate.Height = 24;
            this.RecGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RecGrid.ShowCellToolTips = false;
            this.RecGrid.ShowEditingIcon = false;
            this.RecGrid.Size = new System.Drawing.Size(834, 378);
            this.RecGrid.TabIndex = 25;
            this.RecGrid.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.RecGrid_CancelRowEdit);
            this.RecGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.RecGrid_CellBeginEdit);
            this.RecGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecGrid_CellEndEdit);
            // 
            // ccMonth
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccMonth.DefaultCellStyle = dataGridViewCellStyle5;
            this.ccMonth.HeaderText = "Month";
            this.ccMonth.Name = "ccMonth";
            this.ccMonth.Width = 45;
            // 
            // txtCurrency
            // 
            this.txtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCurrency.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(3)), true);
            this.txtCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCurrency.FormattingEnabled = true;
            this.txtCurrency.Location = new System.Drawing.Point(13, 238);
            this.txtCurrency.MaxDropDownItems = 10;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(77, 28);
            this.txtCurrency.TabIndex = 40;
            this.txtCurrency.SelectedIndexChanged += new System.EventHandler(this.txtCurry_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Open Month";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 379);
            this.label9.TabIndex = 34;
            this.label9.Text = "\r\nBase Currency";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(93, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Fed 2014";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Payroll_System.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(712, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(218, 25);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save ( base Currency must be [MYR] )";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Year";
            // 
            // YearBox
            // 
            this.yearSelection.BackColor = System.Drawing.SystemColors.Control;
            this.yearSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearSelection.FormattingEnabled = true;
            this.yearSelection.Location = new System.Drawing.Point(96, 52);
            this.yearSelection.MaxDropDownItems = 10;
            this.yearSelection.Name = "YearBox";
            this.yearSelection.Size = new System.Drawing.Size(73, 21);
            this.yearSelection.TabIndex = 26;
            this.yearSelection.SelectedIndexChanged += new System.EventHandler(this.YearBox_SelectedIndexChanged);
            // 
            // ExRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 622);
            this.Controls.Add(this.groupBox3);
            this.Name = "ExRate";
            this.Text = "Monthly Exchange Rate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExRate_FormClosed);
            this.Load += new System.EventHandler(this.ExRate_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView RecGrid;
        private System.Windows.Forms.ComboBox yearSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccMonth;
    }
}