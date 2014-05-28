namespace Payroll_System {
    partial class Currency {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Currency));
            this.button4 = new System.Windows.Forms.Button();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.CuyListView = new System.Windows.Forms.ListView();
            this.CCCurrency = new System.Windows.Forms.ColumnHeader();
            this.CCCDecimal = new System.Windows.Forms.ColumnHeader();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.pppAAdd = new System.Windows.Forms.ToolBarButton();
            this.pppAEdit = new System.Windows.Forms.ToolBarButton();
            this.pppADel = new System.Windows.Forms.ToolBarButton();
            this.pppASave = new System.Windows.Forms.ToolBarButton();
            this.pppACel = new System.Windows.Forms.ToolBarButton();
            this.txtDecimal = new System.Windows.Forms.NumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtN = new System.Windows.Forms.RadioButton();
            this.txtY = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecimal)).BeginInit();
            this.SuspendLayout();
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
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(29, 68);
            this.txtCurrency.MaxLength = 20;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(203, 22);
            this.txtCurrency.TabIndex = 30;
            // 
            // CuyListView
            // 
            this.CuyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CCCurrency,
            this.CCCDecimal});
            this.CuyListView.FullRowSelect = true;
            this.CuyListView.GridLines = true;
            this.CuyListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CuyListView.LargeImageList = this.imageList1;
            this.CuyListView.Location = new System.Drawing.Point(29, 96);
            this.CuyListView.MultiSelect = false;
            this.CuyListView.Name = "CuyListView";
            this.CuyListView.Size = new System.Drawing.Size(269, 313);
            this.CuyListView.SmallImageList = this.imageList1;
            this.CuyListView.StateImageList = this.imageList1;
            this.CuyListView.TabIndex = 34;
            this.CuyListView.UseCompatibleStateImageBehavior = false;
            this.CuyListView.View = System.Windows.Forms.View.Details;
            this.CuyListView.Click += new System.EventHandler(this.CuyListView_Click);
            // 
            // CCCurrency
            // 
            this.CCCurrency.Text = "Currency";
            this.CCCurrency.Width = 200;
            // 
            // CCCDecimal
            // 
            this.CCCDecimal.Text = "Decimal";
            this.CCCDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CCCDecimal.Width = 50;
            // 
            // toolBar
            // 
            this.toolBar.AutoSize = false;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.pppAAdd,
            this.pppAEdit,
            this.pppADel,
            this.pppASave,
            this.pppACel});
            this.toolBar.ButtonSize = new System.Drawing.Size(45, 30);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList1;
            this.toolBar.Location = new System.Drawing.Point(29, 12);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(243, 36);
            this.toolBar.TabIndex = 33;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // pppAAdd
            // 
            this.pppAAdd.ImageIndex = 0;
            this.pppAAdd.Name = "pppAAdd";
            this.pppAAdd.Text = "AddNew";
            // 
            // pppAEdit
            // 
            this.pppAEdit.ImageIndex = 1;
            this.pppAEdit.Name = "pppAEdit";
            this.pppAEdit.Text = "Modify";
            // 
            // pppADel
            // 
            this.pppADel.ImageIndex = 2;
            this.pppADel.Name = "pppADel";
            this.pppADel.Text = "Delete";
            // 
            // pppASave
            // 
            this.pppASave.ImageIndex = 3;
            this.pppASave.Name = "pppASave";
            this.pppASave.Text = "Save";
            // 
            // pppACel
            // 
            this.pppACel.ImageIndex = 4;
            this.pppACel.Name = "pppACel";
            this.pppACel.Text = "Cancel";
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(233, 68);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(65, 22);
            this.txtDecimal.TabIndex = 35;
            this.txtDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.imageList1.Images.SetKeyName(22, "yes.gif");
            this.imageList1.Images.SetKeyName(23, "_active__no.gif");
            // 
            // txtN
            // 
            this.txtN.AutoSize = true;
            this.txtN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtN.ForeColor = System.Drawing.Color.Red;
            this.txtN.Location = new System.Drawing.Point(314, 86);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(68, 18);
            this.txtN.TabIndex = 44;
            this.txtN.Text = "Disable";
            this.txtN.UseVisualStyleBackColor = true;
            this.txtN.CheckedChanged += new System.EventHandler(this.txtN_CheckedChanged);
            // 
            // txtY
            // 
            this.txtY.AutoSize = true;
            this.txtY.Checked = true;
            this.txtY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtY.Location = new System.Drawing.Point(314, 67);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(65, 18);
            this.txtY.TabIndex = 43;
            this.txtY.TabStop = true;
            this.txtY.Text = "Enable";
            this.txtY.UseVisualStyleBackColor = true;
            this.txtY.CheckedChanged += new System.EventHandler(this.txtY_CheckedChanged);
            // 
            // Currency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;  this.AutoScroll = true;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.CuyListView);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.button4);
            this.Name = "Currency";
            this.Text = "Currency";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Currency_FormClosed);
            this.Load += new System.EventHandler(this.Currency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDecimal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.ListView CuyListView;
        private System.Windows.Forms.ColumnHeader CCCurrency;
        private System.Windows.Forms.ColumnHeader CCCDecimal;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton pppAAdd;
        private System.Windows.Forms.ToolBarButton pppAEdit;
        private System.Windows.Forms.ToolBarButton pppADel;
        private System.Windows.Forms.ToolBarButton pppASave;
        private System.Windows.Forms.ToolBarButton pppACel;
        private System.Windows.Forms.NumericUpDown txtDecimal;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton txtN;
        private System.Windows.Forms.RadioButton txtY;
    }
}