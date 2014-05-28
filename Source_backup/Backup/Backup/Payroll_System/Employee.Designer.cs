namespace Payroll_System {
    partial class Employee {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button4 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InOfficeBox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.EmpListView = new System.Windows.Forms.ListView();
            this.Company = new System.Windows.Forms.ColumnHeader();
            this.deName = new System.Windows.Forms.ColumnHeader();
            this.GrpID = new System.Windows.Forms.ColumnHeader();
            this.FamilyName = new System.Windows.Forms.ColumnHeader();
            this.FirstName = new System.Windows.Forms.ColumnHeader();
            this.MiddleName = new System.Windows.Forms.ColumnHeader();
            this.Gender = new System.Windows.Forms.ColumnHeader();
            this.JobTitle = new System.Windows.Forms.ColumnHeader();
            this.DateJoined = new System.Windows.Forms.ColumnHeader();
            this.ResignedDate = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CompanyBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EmpBar = new System.Windows.Forms.ToolBar();
            this.companyAdd = new System.Windows.Forms.ToolBarButton();
            this.companyEdit = new System.Windows.Forms.ToolBarButton();
            this.companyDel = new System.Windows.Forms.ToolBarButton();
            this.companySave = new System.Windows.Forms.ToolBarButton();
            this.companyCel = new System.Windows.Forms.ToolBarButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabBase = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtInOfficeN = new System.Windows.Forms.RadioButton();
            this.txtInOfficeY = new System.Windows.Forms.RadioButton();
            this.label22 = new System.Windows.Forms.Label();
            this.txtResigned = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtDateJoin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtGrpID = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtWEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPEmail = new System.Windows.Forms.TextBox();
            this.txtFamilyName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCallName = new System.Windows.Forms.TextBox();
            this.txtDeptID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIdentityID = new System.Windows.Forms.TextBox();
            this.txtCompanyID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcountry = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tabSalary = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.txtCurry = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RecGrid = new System.Windows.Forms.DataGridView();
            this.label26 = new System.Windows.Forms.Label();
            this.txtAdditional = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLA = new System.Windows.Forms.TextBox();
            this.tabBank = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.bankGrid = new System.Windows.Forms.DataGridView();
            this.AcHolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCury = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ExcelImport = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ExcelOutput = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabBase.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabSalary.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecGrid)).BeginInit();
            this.tabBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InOfficeBox);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.EmpListView);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DeptBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CompanyBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 157);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query Employee";
            // 
            // InOfficeBox
            // 
            this.InOfficeBox.BackColor = System.Drawing.SystemColors.Control;
            this.InOfficeBox.FormattingEnabled = true;
            this.InOfficeBox.Location = new System.Drawing.Point(632, 11);
            this.InOfficeBox.MaxDropDownItems = 10;
            this.InOfficeBox.Name = "InOfficeBox";
            this.InOfficeBox.Size = new System.Drawing.Size(95, 20);
            this.InOfficeBox.TabIndex = 31;
            this.InOfficeBox.SelectedIndexChanged += new System.EventHandler(this.InOfficeBox_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(572, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 12);
            this.label24.TabIndex = 30;
            this.label24.Text = "In-service:";
            // 
            // EmpListView
            // 
            this.EmpListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Company,
            this.deName,
            this.GrpID,
            this.FamilyName,
            this.FirstName,
            this.MiddleName,
            this.Gender,
            this.JobTitle,
            this.DateJoined,
            this.ResignedDate});
            this.EmpListView.FullRowSelect = true;
            this.EmpListView.GridLines = true;
            this.EmpListView.Location = new System.Drawing.Point(6, 37);
            this.EmpListView.MultiSelect = false;
            this.EmpListView.Name = "EmpListView";
            this.EmpListView.Size = new System.Drawing.Size(730, 114);
            this.EmpListView.SmallImageList = this.imageList1;
            this.EmpListView.StateImageList = this.imageList1;
            this.EmpListView.TabIndex = 29;
            this.EmpListView.UseCompatibleStateImageBehavior = false;
            this.EmpListView.View = System.Windows.Forms.View.Details;
            this.EmpListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.EmpListView_ColumnClick);
            this.EmpListView.Click += new System.EventHandler(this.EmpListView_Click);
            // 
            // Company
            // 
            this.Company.Tag = "CompanyID";
            this.Company.Text = "(In-service)Company";
            this.Company.Width = 120;
            // 
            // deName
            // 
            this.deName.Tag = "DepartmentID";
            this.deName.Text = "Department";
            this.deName.Width = 70;
            // 
            // GrpID
            // 
            this.GrpID.Tag = "GrpID";
            this.GrpID.Text = "GrpID";
            // 
            // FamilyName
            // 
            this.FamilyName.Tag = "FamilyName";
            this.FamilyName.Text = "FamilyName";
            // 
            // FirstName
            // 
            this.FirstName.Tag = "FirstName";
            this.FirstName.Text = "FirstName";
            // 
            // MiddleName
            // 
            this.MiddleName.Tag = "MiddleName";
            this.MiddleName.Text = "MiddleName";
            // 
            // Gender
            // 
            this.Gender.Tag = "Sex";
            this.Gender.Text = "Gender";
            this.Gender.Width = 50;
            // 
            // JobTitle
            // 
            this.JobTitle.Tag = "PositionName";
            this.JobTitle.Text = "JobTitle";
            this.JobTitle.Width = 80;
            // 
            // DateJoined
            // 
            this.DateJoined.Tag = "DateJoined";
            this.DateJoined.Text = "Date Joined";
            this.DateJoined.Width = 80;
            // 
            // ResignedDate
            // 
            this.ResignedDate.Tag = "DateResigned";
            this.ResignedDate.Text = "Resigned Date";
            this.ResignedDate.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "Department:";
            // 
            // DeptBox
            // 
            this.DeptBox.BackColor = System.Drawing.SystemColors.Control;
            this.DeptBox.FormattingEnabled = true;
            this.DeptBox.Location = new System.Drawing.Point(362, 11);
            this.DeptBox.MaxDropDownItems = 10;
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(204, 20);
            this.DeptBox.TabIndex = 27;
            this.DeptBox.SelectedIndexChanged += new System.EventHandler(this.DeptBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "Company:";
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = System.Drawing.SystemColors.Control;
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(195, 11);
            this.CompanyBox.MaxDropDownItems = 10;
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(95, 20);
            this.CompanyBox.TabIndex = 25;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EmpBar);
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(951, 402);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Information";
            // 
            // EmpBar
            // 
            this.EmpBar.AutoSize = false;
            this.EmpBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.companyAdd,
            this.companyEdit,
            this.companyDel,
            this.companySave,
            this.companyCel});
            this.EmpBar.ButtonSize = new System.Drawing.Size(45, 30);
            this.EmpBar.Dock = System.Windows.Forms.DockStyle.None;
            this.EmpBar.DropDownArrows = true;
            this.EmpBar.ImageList = this.imageList1;
            this.EmpBar.Location = new System.Drawing.Point(10, 27);
            this.EmpBar.Name = "EmpBar";
            this.EmpBar.ShowToolTips = true;
            this.EmpBar.Size = new System.Drawing.Size(243, 36);
            this.EmpBar.TabIndex = 28;
            this.EmpBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.EmpBar_ButtonClick);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabBase);
            this.tabControl1.Controls.Add(this.tabSalary);
            this.tabControl1.Controls.Add(this.tabBank);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(6, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(939, 321);
            this.tabControl1.TabIndex = 27;
            // 
            // TabBase
            // 
            this.TabBase.Controls.Add(this.groupBox6);
            this.TabBase.Controls.Add(this.txtMiddleName);
            this.TabBase.Controls.Add(this.txtDateJoin);
            this.TabBase.Controls.Add(this.label3);
            this.TabBase.Controls.Add(this.label21);
            this.TabBase.Controls.Add(this.txtGrpID);
            this.TabBase.Controls.Add(this.txtJobTitle);
            this.TabBase.Controls.Add(this.label4);
            this.TabBase.Controls.Add(this.label20);
            this.TabBase.Controls.Add(this.txtFirstName);
            this.TabBase.Controls.Add(this.txtWEmail);
            this.TabBase.Controls.Add(this.label5);
            this.TabBase.Controls.Add(this.label19);
            this.TabBase.Controls.Add(this.label6);
            this.TabBase.Controls.Add(this.txtPEmail);
            this.TabBase.Controls.Add(this.txtFamilyName);
            this.TabBase.Controls.Add(this.label18);
            this.TabBase.Controls.Add(this.label7);
            this.TabBase.Controls.Add(this.label17);
            this.TabBase.Controls.Add(this.txtCallName);
            this.TabBase.Controls.Add(this.txtDeptID);
            this.TabBase.Controls.Add(this.label8);
            this.TabBase.Controls.Add(this.label16);
            this.TabBase.Controls.Add(this.txtIdentityID);
            this.TabBase.Controls.Add(this.txtCompanyID);
            this.TabBase.Controls.Add(this.label9);
            this.TabBase.Controls.Add(this.txtPostalCode);
            this.TabBase.Controls.Add(this.txtNationality);
            this.TabBase.Controls.Add(this.label15);
            this.TabBase.Controls.Add(this.label10);
            this.TabBase.Controls.Add(this.txtCity);
            this.TabBase.Controls.Add(this.txtBirth);
            this.TabBase.Controls.Add(this.label14);
            this.TabBase.Controls.Add(this.label11);
            this.TabBase.Controls.Add(this.txtcountry);
            this.TabBase.Controls.Add(this.txtSex);
            this.TabBase.Controls.Add(this.label13);
            this.TabBase.Controls.Add(this.label12);
            this.TabBase.Controls.Add(this.txtAddress);
            this.TabBase.ImageIndex = 16;
            this.TabBase.Location = new System.Drawing.Point(4, 23);
            this.TabBase.Name = "TabBase";
            this.TabBase.Padding = new System.Windows.Forms.Padding(3);
            this.TabBase.Size = new System.Drawing.Size(931, 294);
            this.TabBase.TabIndex = 0;
            this.TabBase.Text = "Information";
            this.TabBase.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtInOfficeN);
            this.groupBox6.Controls.Add(this.txtInOfficeY);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.txtResigned);
            this.groupBox6.Location = new System.Drawing.Point(12, 175);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(305, 90);
            this.groupBox6.TabIndex = 41;
            this.groupBox6.TabStop = false;
            // 
            // txtInOfficeN
            // 
            this.txtInOfficeN.AutoSize = true;
            this.txtInOfficeN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInOfficeN.ForeColor = System.Drawing.Color.Red;
            this.txtInOfficeN.Location = new System.Drawing.Point(93, 21);
            this.txtInOfficeN.Name = "txtInOfficeN";
            this.txtInOfficeN.Size = new System.Drawing.Size(74, 18);
            this.txtInOfficeN.TabIndex = 42;
            this.txtInOfficeN.Text = "Inactive";
            this.txtInOfficeN.UseVisualStyleBackColor = true;
            this.txtInOfficeN.CheckedChanged += new System.EventHandler(this.txtInOfficeN_CheckedChanged);
            // 
            // txtInOfficeY
            // 
            this.txtInOfficeY.AutoSize = true;
            this.txtInOfficeY.Checked = true;
            this.txtInOfficeY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInOfficeY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtInOfficeY.Location = new System.Drawing.Point(17, 21);
            this.txtInOfficeY.Name = "txtInOfficeY";
            this.txtInOfficeY.Size = new System.Drawing.Size(63, 18);
            this.txtInOfficeY.TabIndex = 41;
            this.txtInOfficeY.TabStop = true;
            this.txtInOfficeY.Text = "Active";
            this.txtInOfficeY.UseVisualStyleBackColor = true;
            this.txtInOfficeY.CheckedChanged += new System.EventHandler(this.txtInOfficeY_CheckedChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 51);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 12);
            this.label22.TabIndex = 39;
            this.label22.Text = "Resigned Date";
            // 
            // txtResigned
            // 
            this.txtResigned.BackColor = System.Drawing.Color.White;
            this.txtResigned.Location = new System.Drawing.Point(93, 48);
            this.txtResigned.Name = "txtResigned";
            this.txtResigned.Size = new System.Drawing.Size(138, 22);
            this.txtResigned.TabIndex = 7;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.Color.White;
            this.txtMiddleName.Location = new System.Drawing.Point(416, 54);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(86, 22);
            this.txtMiddleName.TabIndex = 9;
            // 
            // txtDateJoin
            // 
            this.txtDateJoin.BackColor = System.Drawing.Color.White;
            this.txtDateJoin.Location = new System.Drawing.Point(81, 129);
            this.txtDateJoin.Name = "txtDateJoin";
            this.txtDateJoin.Size = new System.Drawing.Size(121, 22);
            this.txtDateJoin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Group ID";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 132);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 12);
            this.label21.TabIndex = 37;
            this.label21.Text = "Date Joined";
            // 
            // txtGrpID
            // 
            this.txtGrpID.BackColor = System.Drawing.Color.White;
            this.txtGrpID.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGrpID.Location = new System.Drawing.Point(81, 8);
            this.txtGrpID.MaxLength = 5;
            this.txtGrpID.Name = "txtGrpID";
            this.txtGrpID.Size = new System.Drawing.Size(60, 22);
            this.txtGrpID.TabIndex = 1;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.BackColor = System.Drawing.Color.White;
            this.txtJobTitle.Location = new System.Drawing.Point(81, 81);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(236, 22);
            this.txtJobTitle.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "First Name";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 84);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 12);
            this.label20.TabIndex = 35;
            this.label20.Text = "Job Title";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(416, 29);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(86, 22);
            this.txtFirstName.TabIndex = 8;
            // 
            // txtWEmail
            // 
            this.txtWEmail.BackColor = System.Drawing.Color.White;
            this.txtWEmail.Location = new System.Drawing.Point(81, 105);
            this.txtWEmail.Name = "txtWEmail";
            this.txtWEmail.Size = new System.Drawing.Size(236, 22);
            this.txtWEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Middle Name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 12);
            this.label19.TabIndex = 33;
            this.label19.Text = "Work Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Family Name";
            // 
            // txtPEmail
            // 
            this.txtPEmail.BackColor = System.Drawing.Color.White;
            this.txtPEmail.Location = new System.Drawing.Point(562, 243);
            this.txtPEmail.Name = "txtPEmail";
            this.txtPEmail.Size = new System.Drawing.Size(284, 22);
            this.txtPEmail.TabIndex = 19;
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.BackColor = System.Drawing.Color.White;
            this.txtFamilyName.Location = new System.Drawing.Point(416, 4);
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(86, 22);
            this.txtFamilyName.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(482, 247);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "Personal Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "Call Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 30;
            this.label17.Text = "Department";
            // 
            // txtCallName
            // 
            this.txtCallName.BackColor = System.Drawing.Color.White;
            this.txtCallName.Location = new System.Drawing.Point(416, 81);
            this.txtCallName.Name = "txtCallName";
            this.txtCallName.Size = new System.Drawing.Size(86, 22);
            this.txtCallName.TabIndex = 11;
            // 
            // txtDeptID
            // 
            this.txtDeptID.BackColor = System.Drawing.Color.White;
            this.txtDeptID.FormattingEnabled = true;
            this.txtDeptID.Location = new System.Drawing.Point(81, 56);
            this.txtDeptID.MaxDropDownItems = 10;
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(220, 20);
            this.txtDeptID.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "Identity ID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 12);
            this.label16.TabIndex = 28;
            this.label16.Text = "Company";
            // 
            // txtIdentityID
            // 
            this.txtIdentityID.BackColor = System.Drawing.Color.White;
            this.txtIdentityID.Location = new System.Drawing.Point(416, 105);
            this.txtIdentityID.Name = "txtIdentityID";
            this.txtIdentityID.Size = new System.Drawing.Size(121, 22);
            this.txtIdentityID.TabIndex = 12;
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.BackColor = System.Drawing.Color.White;
            this.txtCompanyID.FormattingEnabled = true;
            this.txtCompanyID.Location = new System.Drawing.Point(81, 32);
            this.txtCompanyID.MaxDropDownItems = 10;
            this.txtCompanyID.Name = "txtCompanyID";
            this.txtCompanyID.Size = new System.Drawing.Size(119, 20);
            this.txtCompanyID.TabIndex = 2;
            this.txtCompanyID.SelectedIndexChanged += new System.EventHandler(this.txtCompanyID_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(348, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "Nationality";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.White;
            this.txtPostalCode.Location = new System.Drawing.Point(416, 243);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(60, 22);
            this.txtPostalCode.TabIndex = 18;
            // 
            // txtNationality
            // 
            this.txtNationality.BackColor = System.Drawing.Color.White;
            this.txtNationality.Location = new System.Drawing.Point(416, 129);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(121, 22);
            this.txtNationality.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(348, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "Postal Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(348, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "Date of Brith";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.White;
            this.txtCity.Location = new System.Drawing.Point(416, 219);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(121, 22);
            this.txtCity.TabIndex = 17;
            // 
            // txtBirth
            // 
            this.txtBirth.BackColor = System.Drawing.Color.White;
            this.txtBirth.Location = new System.Drawing.Point(416, 153);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(121, 22);
            this.txtBirth.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(348, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "City";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(348, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "Gender";
            // 
            // txtcountry
            // 
            this.txtcountry.BackColor = System.Drawing.Color.White;
            this.txtcountry.Location = new System.Drawing.Point(416, 196);
            this.txtcountry.Name = "txtcountry";
            this.txtcountry.Size = new System.Drawing.Size(121, 22);
            this.txtcountry.TabIndex = 16;
            // 
            // txtSex
            // 
            this.txtSex.BackColor = System.Drawing.Color.White;
            this.txtSex.FormattingEnabled = true;
            this.txtSex.Items.AddRange(new object[] {
            "male",
            "female"});
            this.txtSex.Location = new System.Drawing.Point(416, 175);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(68, 20);
            this.txtSex.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(348, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "Country";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(348, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(415, 266);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(431, 22);
            this.txtAddress.TabIndex = 20;
            // 
            // tabSalary
            // 
            this.tabSalary.Controls.Add(this.label28);
            this.tabSalary.Controls.Add(this.txtBasicSalary);
            this.tabSalary.Controls.Add(this.txtCurry);
            this.tabSalary.Controls.Add(this.label27);
            this.tabSalary.Controls.Add(this.groupBox3);
            this.tabSalary.Controls.Add(this.label26);
            this.tabSalary.Controls.Add(this.txtAdditional);
            this.tabSalary.Controls.Add(this.label25);
            this.tabSalary.Controls.Add(this.txtIncrement);
            this.tabSalary.Controls.Add(this.label23);
            this.tabSalary.Controls.Add(this.txtLA);
            this.tabSalary.ImageIndex = 18;
            this.tabSalary.Location = new System.Drawing.Point(4, 23);
            this.tabSalary.Name = "tabSalary";
            this.tabSalary.Size = new System.Drawing.Size(931, 294);
            this.tabSalary.TabIndex = 2;
            this.tabSalary.Text = "Salary / Received";
            this.tabSalary.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(58, 53);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 12);
            this.label28.TabIndex = 38;
            this.label28.Text = "Basic Salary";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.BackColor = System.Drawing.Color.White;
            this.txtBasicSalary.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBasicSalary.Location = new System.Drawing.Point(126, 50);
            this.txtBasicSalary.MaxLength = 12;
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(96, 22);
            this.txtBasicSalary.TabIndex = 39;
            // 
            // txtCurry
            // 
            this.txtCurry.BackColor = System.Drawing.Color.White;
            this.txtCurry.FormattingEnabled = true;
            this.txtCurry.Items.AddRange(new object[] {
            "male",
            "female"});
            this.txtCurry.Location = new System.Drawing.Point(126, 22);
            this.txtCurry.Name = "txtCurry";
            this.txtCurry.Size = new System.Drawing.Size(68, 20);
            this.txtCurry.TabIndex = 37;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label27.Location = new System.Drawing.Point(27, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 12);
            this.label27.TabIndex = 36;
            this.label27.Text = "Salary Currency";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RecGrid);
            this.groupBox3.Location = new System.Drawing.Point(14, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(903, 99);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Received Reference";
            // 
            // RecGrid
            // 
            this.RecGrid.AllowUserToAddRows = false;
            this.RecGrid.AllowUserToDeleteRows = false;
            this.RecGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RecGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.RecGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RecGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.RecGrid.Location = new System.Drawing.Point(6, 28);
            this.RecGrid.MultiSelect = false;
            this.RecGrid.Name = "RecGrid";
            this.RecGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RecGrid.RowHeadersVisible = false;
            this.RecGrid.RowHeadersWidth = 5;
            this.RecGrid.RowTemplate.Height = 24;
            this.RecGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RecGrid.ShowCellToolTips = false;
            this.RecGrid.ShowEditingIcon = false;
            this.RecGrid.Size = new System.Drawing.Size(891, 65);
            this.RecGrid.StandardTab = true;
            this.RecGrid.TabIndex = 25;
            this.RecGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.RecGrid_CellBeginEdit);
            this.RecGrid.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.RecGrid_CancelRowEdit);
            this.RecGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecGrid_CellEndEdit);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(273, 74);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(95, 12);
            this.label26.TabIndex = 33;
            this.label26.Text = "Additional Amount";
            // 
            // txtAdditional
            // 
            this.txtAdditional.BackColor = System.Drawing.Color.White;
            this.txtAdditional.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAdditional.Location = new System.Drawing.Point(384, 71);
            this.txtAdditional.MaxLength = 12;
            this.txtAdditional.Name = "txtAdditional";
            this.txtAdditional.Size = new System.Drawing.Size(96, 22);
            this.txtAdditional.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(273, 49);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 12);
            this.label25.TabIndex = 31;
            this.label25.Text = "Increment Amount";
            // 
            // txtIncrement
            // 
            this.txtIncrement.BackColor = System.Drawing.Color.White;
            this.txtIncrement.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIncrement.Location = new System.Drawing.Point(384, 46);
            this.txtIncrement.MaxLength = 12;
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(96, 22);
            this.txtIncrement.TabIndex = 23;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(273, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "Probation Salary(LA)";
            // 
            // txtLA
            // 
            this.txtLA.BackColor = System.Drawing.Color.White;
            this.txtLA.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLA.Location = new System.Drawing.Point(384, 21);
            this.txtLA.MaxLength = 12;
            this.txtLA.Name = "txtLA";
            this.txtLA.Size = new System.Drawing.Size(96, 22);
            this.txtLA.TabIndex = 22;
            // 
            // tabBank
            // 
            this.tabBank.Controls.Add(this.label29);
            this.tabBank.Controls.Add(this.bankGrid);
            this.tabBank.ImageIndex = 21;
            this.tabBank.Location = new System.Drawing.Point(4, 23);
            this.tabBank.Name = "tabBank";
            this.tabBank.Size = new System.Drawing.Size(931, 294);
            this.tabBank.TabIndex = 3;
            this.tabBank.Text = "Bank Account";
            this.tabBank.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(716, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(141, 12);
            this.label29.TabIndex = 27;
            this.label29.Text = "How to delete a bank accout?";
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // bankGrid
            // 
            this.bankGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bankGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bankGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AcHolder,
            this.Bank,
            this.AcNumber,
            this.ACCury});
            this.bankGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.bankGrid.Location = new System.Drawing.Point(15, 65);
            this.bankGrid.MultiSelect = false;
            this.bankGrid.Name = "bankGrid";
            this.bankGrid.RowHeadersWidth = 25;
            this.bankGrid.RowTemplate.Height = 24;
            this.bankGrid.Size = new System.Drawing.Size(842, 215);
            this.bankGrid.TabIndex = 26;
            this.bankGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.bankGrid_CellBeginEdit);
            this.bankGrid.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.bankGrid_CancelRowEdit);
            this.bankGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.bankGrid_RowsAdded);
            this.bankGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.bankGrid_CellEndEdit);
            this.bankGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.bankGrid_DataError);
            // 
            // AcHolder
            // 
            this.AcHolder.HeaderText = "A/c Holder";
            this.AcHolder.Name = "AcHolder";
            // 
            // Bank
            // 
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.Width = 180;
            // 
            // AcNumber
            // 
            this.AcNumber.HeaderText = "A/c Number";
            this.AcNumber.Name = "AcNumber";
            this.AcNumber.Width = 160;
            // 
            // ACCury
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.ACCury.DefaultCellStyle = dataGridViewCellStyle1;
            this.ACCury.HeaderText = "Payout Method & Location";
            this.ACCury.Name = "ACCury";
            this.ACCury.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACCury.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ACCury.Width = 350;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ExcelImport);
            this.groupBox4.Location = new System.Drawing.Point(760, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 74);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Employee Data Import";
            // 
            // ExcelImport
            // 
            this.ExcelImport.Location = new System.Drawing.Point(76, 45);
            this.ExcelImport.Name = "ExcelImport";
            this.ExcelImport.Size = new System.Drawing.Size(69, 23);
            this.ExcelImport.TabIndex = 1;
            this.ExcelImport.Text = "Import";
            this.ExcelImport.UseVisualStyleBackColor = true;
            this.ExcelImport.Click += new System.EventHandler(this.ExcelImport_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ExcelOutput);
            this.groupBox5.Location = new System.Drawing.Point(760, 92);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(151, 77);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Employee Data Output";
            // 
            // ExcelOutput
            // 
            this.ExcelOutput.Location = new System.Drawing.Point(76, 48);
            this.ExcelOutput.Name = "ExcelOutput";
            this.ExcelOutput.Size = new System.Drawing.Size(69, 23);
            this.ExcelOutput.TabIndex = 2;
            this.ExcelOutput.Text = "Export";
            this.ExcelOutput.UseVisualStyleBackColor = true;
            this.ExcelOutput.Click += new System.EventHandler(this.ExcelOutput_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel|*.xls";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xls";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 582);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Name = "Employee";
            this.Text = "Employee / Salary / Bank Account / Account to Received";
            this.Load += new System.EventHandler(this.Employee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TabBase.ResumeLayout(false);
            this.TabBase.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabSalary.ResumeLayout(false);
            this.tabSalary.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecGrid)).EndInit();
            this.tabBank.ResumeLayout(false);
            this.tabBank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CompanyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DeptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView EmpListView;
        private System.Windows.Forms.ColumnHeader deName;
        private System.Windows.Forms.ColumnHeader Company;
        private System.Windows.Forms.ColumnHeader GrpID;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader MiddleName;
        private System.Windows.Forms.ColumnHeader FamilyName;
        private System.Windows.Forms.ColumnHeader JobTitle;
        private System.Windows.Forms.ColumnHeader Gender;
        private System.Windows.Forms.ColumnHeader DateJoined;
        private System.Windows.Forms.ColumnHeader ResignedDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabBase;
        private System.Windows.Forms.TextBox txtResigned;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtDateJoin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtGrpID;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtWEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPEmail;
        private System.Windows.Forms.TextBox txtFamilyName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCallName;
        private System.Windows.Forms.ComboBox txtDeptID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtIdentityID;
        private System.Windows.Forms.ComboBox txtCompanyID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcountry;
        private System.Windows.Forms.ComboBox txtSex;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TabPage tabSalary;
        private System.Windows.Forms.TabPage tabBank;
        private System.Windows.Forms.ToolBar EmpBar;
        private System.Windows.Forms.ToolBarButton companyAdd;
        private System.Windows.Forms.ToolBarButton companyEdit;
        private System.Windows.Forms.ToolBarButton companyDel;
        private System.Windows.Forms.ToolBarButton companySave;
        private System.Windows.Forms.ToolBarButton companyCel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLA;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtIncrement;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtAdditional;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView RecGrid;
        private System.Windows.Forms.DataGridView bankGrid;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ExcelImport;
        private System.Windows.Forms.Button ExcelOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton txtInOfficeN;
        private System.Windows.Forms.RadioButton txtInOfficeY;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox InOfficeBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox txtCurry;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcHolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn ACCury;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.Label label29;

    }
}