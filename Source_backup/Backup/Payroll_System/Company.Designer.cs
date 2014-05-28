namespace Payroll_System {
    partial class Company {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Company));
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabCompany = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCompDesc = new System.Windows.Forms.TextBox();
            this.txtCompanyID = new System.Windows.Forms.TextBox();
            this.CompanyListView = new System.Windows.Forms.ListView();
            this.coID = new System.Windows.Forms.ColumnHeader();
            this.coDesc = new System.Windows.Forms.ColumnHeader();
            this.CompanyBar = new System.Windows.Forms.ToolBar();
            this.companyAdd = new System.Windows.Forms.ToolBarButton();
            this.companyEdit = new System.Windows.Forms.ToolBarButton();
            this.companyDel = new System.Windows.Forms.ToolBarButton();
            this.companySave = new System.Windows.Forms.ToolBarButton();
            this.companyCel = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TabDept = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.deptListView = new System.Windows.Forms.ListView();
            this.deName = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CompanyBox = new System.Windows.Forms.ComboBox();
            this.deptBar = new System.Windows.Forms.ToolBar();
            this.DeptAdd = new System.Windows.Forms.ToolBarButton();
            this.DeptEdit = new System.Windows.Forms.ToolBarButton();
            this.DeptDel = new System.Windows.Forms.ToolBarButton();
            this.DeptSave = new System.Windows.Forms.ToolBarButton();
            this.DeptCel = new System.Windows.Forms.ToolBarButton();
            this.tabControl1.SuspendLayout();
            this.TabCompany.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TabDept.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.button4.TabIndex = 23;
            this.button4.Text = "Close";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabCompany);
            this.tabControl1.Controls.Add(this.TabDept);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 433);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TabCompany
            // 
            this.TabCompany.Controls.Add(this.groupBox3);
            this.TabCompany.Controls.Add(this.CompanyBar);
            this.TabCompany.ImageIndex = 15;
            this.TabCompany.Location = new System.Drawing.Point(4, 23);
            this.TabCompany.Name = "TabCompany";
            this.TabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.TabCompany.Size = new System.Drawing.Size(574, 406);
            this.TabCompany.TabIndex = 0;
            this.TabCompany.Text = "Company";
            this.TabCompany.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCompDesc);
            this.groupBox3.Controls.Add(this.txtCompanyID);
            this.groupBox3.Controls.Add(this.CompanyListView);
            this.groupBox3.Location = new System.Drawing.Point(6, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 352);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // txtCompDesc
            // 
            this.txtCompDesc.Location = new System.Drawing.Point(94, 16);
            this.txtCompDesc.MaxLength = 200;
            this.txtCompDesc.Name = "txtCompDesc";
            this.txtCompDesc.Size = new System.Drawing.Size(354, 22);
            this.txtCompDesc.TabIndex = 28;
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.Location = new System.Drawing.Point(6, 16);
            this.txtCompanyID.MaxLength = 15;
            this.txtCompanyID.Name = "txtCompanyID";
            this.txtCompanyID.Size = new System.Drawing.Size(82, 22);
            this.txtCompanyID.TabIndex = 25;
            // 
            // CompanyListView
            // 
            this.CompanyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coID,
            this.coDesc});
            this.CompanyListView.FullRowSelect = true;
            this.CompanyListView.GridLines = true;
            this.CompanyListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CompanyListView.Location = new System.Drawing.Point(6, 40);
            this.CompanyListView.MultiSelect = false;
            this.CompanyListView.Name = "CompanyListView";
            this.CompanyListView.Size = new System.Drawing.Size(442, 306);
            this.CompanyListView.TabIndex = 27;
            this.CompanyListView.UseCompatibleStateImageBehavior = false;
            this.CompanyListView.View = System.Windows.Forms.View.Details;
            this.CompanyListView.Click += new System.EventHandler(this.CompanyListView_Click);
            // 
            // coID
            // 
            this.coID.Text = "Company ID";
            this.coID.Width = 82;
            // 
            // coDesc
            // 
            this.coDesc.Text = "Full Name";
            this.coDesc.Width = 340;
            // 
            // CompanyBar
            // 
            this.CompanyBar.AutoSize = false;
            this.CompanyBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.companyAdd,
            this.companyEdit,
            this.companyDel,
            this.companySave,
            this.companyCel});
            this.CompanyBar.ButtonSize = new System.Drawing.Size(45, 30);
            this.CompanyBar.Dock = System.Windows.Forms.DockStyle.None;
            this.CompanyBar.DropDownArrows = true;
            this.CompanyBar.ImageList = this.imageList1;
            this.CompanyBar.Location = new System.Drawing.Point(6, 6);
            this.CompanyBar.Name = "CompanyBar";
            this.CompanyBar.ShowToolTips = true;
            this.CompanyBar.Size = new System.Drawing.Size(243, 36);
            this.CompanyBar.TabIndex = 23;
            this.CompanyBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.CompanyBar_ButtonClick);
            // 
            // companyAdd
            // 
            this.companyAdd.ImageIndex = 0;
            this.companyAdd.Name = "companyAdd";
            this.companyAdd.Text = "AddNew";
            // 
            // companyEdit
            // 
            this.companyEdit.ImageIndex = 1;
            this.companyEdit.Name = "companyEdit";
            this.companyEdit.Text = "Modify";
            // 
            // companyDel
            // 
            this.companyDel.ImageIndex = 2;
            this.companyDel.Name = "companyDel";
            this.companyDel.Text = "Delete";
            // 
            // companySave
            // 
            this.companySave.ImageIndex = 3;
            this.companySave.Name = "companySave";
            this.companySave.Text = "Save";
            // 
            // companyCel
            // 
            this.companyCel.ImageIndex = 4;
            this.companyCel.Name = "companyCel";
            this.companyCel.Text = "Cancel";
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
            // 
            // TabDept
            // 
            this.TabDept.Controls.Add(this.groupBox2);
            this.TabDept.Controls.Add(this.groupBox1);
            this.TabDept.Controls.Add(this.deptBar);
            this.TabDept.ImageIndex = 6;
            this.TabDept.Location = new System.Drawing.Point(4, 23);
            this.TabDept.Name = "TabDept";
            this.TabDept.Padding = new System.Windows.Forms.Padding(3);
            this.TabDept.Size = new System.Drawing.Size(574, 406);
            this.TabDept.TabIndex = 1;
            this.TabDept.Text = "Department";
            this.TabDept.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDeptName);
            this.groupBox2.Controls.Add(this.deptListView);
            this.groupBox2.Location = new System.Drawing.Point(6, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 310);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Department";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(6, 21);
            this.txtDeptName.MaxLength = 50;
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(264, 22);
            this.txtDeptName.TabIndex = 30;
            // 
            // deptListView
            // 
            this.deptListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deName});
            this.deptListView.FullRowSelect = true;
            this.deptListView.GridLines = true;
            this.deptListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.deptListView.Location = new System.Drawing.Point(6, 45);
            this.deptListView.MultiSelect = false;
            this.deptListView.Name = "deptListView";
            this.deptListView.Size = new System.Drawing.Size(376, 259);
            this.deptListView.TabIndex = 28;
            this.deptListView.UseCompatibleStateImageBehavior = false;
            this.deptListView.View = System.Windows.Forms.View.Details;
            this.deptListView.Click += new System.EventHandler(this.deptListView_Click);
            // 
            // deName
            // 
            this.deName.Text = "DepartmentName";
            this.deName.Width = 260;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CompanyBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 36);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company";
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(234, 10);
            this.CompanyBox.MaxDropDownItems = 10;
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(148, 20);
            this.CompanyBox.TabIndex = 24;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // deptBar
            // 
            this.deptBar.AutoSize = false;
            this.deptBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.DeptAdd,
            this.DeptEdit,
            this.DeptDel,
            this.DeptSave,
            this.DeptCel});
            this.deptBar.ButtonSize = new System.Drawing.Size(45, 30);
            this.deptBar.Dock = System.Windows.Forms.DockStyle.None;
            this.deptBar.DropDownArrows = true;
            this.deptBar.ImageList = this.imageList1;
            this.deptBar.Location = new System.Drawing.Point(6, 6);
            this.deptBar.Name = "deptBar";
            this.deptBar.ShowToolTips = true;
            this.deptBar.Size = new System.Drawing.Size(242, 36);
            this.deptBar.TabIndex = 23;
            this.deptBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.deptBar_ButtonClick);
            // 
            // DeptAdd
            // 
            this.DeptAdd.ImageIndex = 0;
            this.DeptAdd.Name = "DeptAdd";
            this.DeptAdd.Text = "AddNew";
            // 
            // DeptEdit
            // 
            this.DeptEdit.ImageIndex = 1;
            this.DeptEdit.Name = "DeptEdit";
            this.DeptEdit.Text = "Modify";
            // 
            // DeptDel
            // 
            this.DeptDel.ImageIndex = 2;
            this.DeptDel.Name = "DeptDel";
            this.DeptDel.Text = "Delete";
            // 
            // DeptSave
            // 
            this.DeptSave.ImageIndex = 3;
            this.DeptSave.Name = "DeptSave";
            this.DeptSave.Text = "Save";
            // 
            // DeptCel
            // 
            this.DeptCel.ImageIndex = 4;
            this.DeptCel.Name = "DeptCel";
            this.DeptCel.Text = "Cancel";
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;  this.AutoScroll = true;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.Name = "Company";
            this.Text = "Company / Department";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Company_FormClosed);
            this.Load += new System.EventHandler(this.company_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabCompany.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.TabDept.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabCompany;
        private System.Windows.Forms.ToolBar CompanyBar;
        private System.Windows.Forms.ToolBarButton companyAdd;
        private System.Windows.Forms.ToolBarButton companyEdit;
        private System.Windows.Forms.ToolBarButton companyDel;
        private System.Windows.Forms.ToolBarButton companySave;
        private System.Windows.Forms.ToolBarButton companyCel;
        private System.Windows.Forms.TabPage TabDept;
        private System.Windows.Forms.ToolBar deptBar;
        private System.Windows.Forms.ToolBarButton DeptAdd;
        private System.Windows.Forms.ToolBarButton DeptEdit;
        private System.Windows.Forms.ToolBarButton DeptDel;
        private System.Windows.Forms.ToolBarButton DeptSave;
      
        private System.Windows.Forms.ToolBarButton DeptCel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtCompanyID;
        private System.Windows.Forms.ListView CompanyListView;
        private System.Windows.Forms.ColumnHeader coID;
        private System.Windows.Forms.ComboBox CompanyBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView deptListView;
        private System.Windows.Forms.ColumnHeader deName;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.TextBox txtCompDesc;
        private System.Windows.Forms.ColumnHeader coDesc;
    }
}