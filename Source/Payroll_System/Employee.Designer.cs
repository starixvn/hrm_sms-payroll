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
            System.Windows.Forms.ColumnHeader InService;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialogExport = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxDataOutput = new System.Windows.Forms.GroupBox();
            this.ExcelOutput = new System.Windows.Forms.Button();
            this.groupBoxDataInput = new System.Windows.Forms.GroupBox();
            this.ExcelImport = new System.Windows.Forms.Button();
            this.groupBoxEmp = new System.Windows.Forms.GroupBox();
            this.multipleEditSalaryGroupBox = new System.Windows.Forms.GroupBox();
            this.txtIncrementSalary = new System.Windows.Forms.NumericUpDown();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblNewIncrement = new System.Windows.Forms.Label();
            this.actionBar = new System.Windows.Forms.ToolBar();
            this.companyAdd = new System.Windows.Forms.ToolBarButton();
            this.companyEdit = new System.Windows.Forms.ToolBarButton();
            this.companyDel = new System.Windows.Forms.ToolBarButton();
            this.companySave = new System.Windows.Forms.ToolBarButton();
            this.companyCel = new System.Windows.Forms.ToolBarButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.txtBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtDateJoin = new System.Windows.Forms.DateTimePicker();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.txtResigned = new System.Windows.Forms.DateTimePicker();
            this.txtInOfficeN = new System.Windows.Forms.RadioButton();
            this.txtInOfficeY = new System.Windows.Forms.RadioButton();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtWorkEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPersonalEmail = new System.Windows.Forms.TextBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tabSalary = new System.Windows.Forms.TabPage();
            this.txtBasicSalary = new System.Windows.Forms.NumericUpDown();
            this.probationCheckbox = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBoxReceivedRef = new System.Windows.Forms.GroupBox();
            this.receivedRefGrid = new System.Windows.Forms.DataGridView();
            this.label23 = new System.Windows.Forms.Label();
            this.txtProbationSalary = new System.Windows.Forms.TextBox();
            this.tabBank = new System.Windows.Forms.TabPage();
            this.labelHelpDeleteBankAcc = new System.Windows.Forms.Label();
            this.bankGrid = new System.Windows.Forms.DataGridView();
            this.AcHolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCury = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBoxEmpList = new System.Windows.Forms.GroupBox();
            this.inServiceBox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.empListView = new System.Windows.Forms.ListView();
            this.GroupID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CallName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateJoined = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Increment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InProbationTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.deptBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.companyBox = new System.Windows.Forms.ComboBox();
            InService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxDataOutput.SuspendLayout();
            this.groupBoxDataInput.SuspendLayout();
            this.groupBoxEmp.SuspendLayout();
            this.multipleEditSalaryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncrementSalary)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.tabSalary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary)).BeginInit();
            this.groupBoxReceivedRef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receivedRefGrid)).BeginInit();
            this.tabBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).BeginInit();
            this.groupBoxEmpList.SuspendLayout();
            this.SuspendLayout();
            // 
            // InService
            // 
            InService.Text = "In Service";
            InService.Width = 70;
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
            this.imageList.Images.SetKeyName(22, "yes.gif");
            this.imageList.Images.SetKeyName(23, "_active__no.gif");
            // 
            // openFileDialogExport
            // 
            this.openFileDialogExport.Filter = "Excel|*.xls";
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "Excel|*.xls";
            // 
            // groupBoxDataOutput
            // 
            this.groupBoxDataOutput.Controls.Add(this.ExcelOutput);
            this.groupBoxDataOutput.Location = new System.Drawing.Point(836, 100);
            this.groupBoxDataOutput.Name = "groupBoxDataOutput";
            this.groupBoxDataOutput.Size = new System.Drawing.Size(127, 83);
            this.groupBoxDataOutput.TabIndex = 27;
            this.groupBoxDataOutput.TabStop = false;
            this.groupBoxDataOutput.Text = "Employee Data Export";
            // 
            // ExcelOutput
            // 
            this.ExcelOutput.Location = new System.Drawing.Point(28, 52);
            this.ExcelOutput.Name = "ExcelOutput";
            this.ExcelOutput.Size = new System.Drawing.Size(69, 25);
            this.ExcelOutput.TabIndex = 0;
            this.ExcelOutput.Text = "Export";
            this.ExcelOutput.UseVisualStyleBackColor = true;
            this.ExcelOutput.Click += new System.EventHandler(this.ExcelOutput_Click);
            // 
            // groupBoxDataInput
            // 
            this.groupBoxDataInput.Controls.Add(this.ExcelImport);
            this.groupBoxDataInput.Location = new System.Drawing.Point(836, 13);
            this.groupBoxDataInput.Name = "groupBoxDataInput";
            this.groupBoxDataInput.Size = new System.Drawing.Size(127, 80);
            this.groupBoxDataInput.TabIndex = 2;
            this.groupBoxDataInput.TabStop = false;
            this.groupBoxDataInput.Text = "Employee Data Import";
            // 
            // ExcelImport
            // 
            this.ExcelImport.Location = new System.Drawing.Point(28, 49);
            this.ExcelImport.Name = "ExcelImport";
            this.ExcelImport.Size = new System.Drawing.Size(69, 25);
            this.ExcelImport.TabIndex = 0;
            this.ExcelImport.Text = "Import";
            this.ExcelImport.UseVisualStyleBackColor = true;
            this.ExcelImport.Click += new System.EventHandler(this.ExcelImport_Click);
            // 
            // groupBoxEmp
            // 
            this.groupBoxEmp.Controls.Add(this.multipleEditSalaryGroupBox);
            this.groupBoxEmp.Controls.Add(this.actionBar);
            this.groupBoxEmp.Controls.Add(this.tabControl);
            this.groupBoxEmp.Location = new System.Drawing.Point(12, 192);
            this.groupBoxEmp.Name = "groupBoxEmp";
            this.groupBoxEmp.Size = new System.Drawing.Size(951, 436);
            this.groupBoxEmp.TabIndex = 1;
            this.groupBoxEmp.TabStop = false;
            this.groupBoxEmp.Text = "Employee Profile";
            // 
            // multipleEditSalaryGroupBox
            // 
            this.multipleEditSalaryGroupBox.Controls.Add(this.txtIncrementSalary);
            this.multipleEditSalaryGroupBox.Controls.Add(this.lblPercent);
            this.multipleEditSalaryGroupBox.Controls.Add(this.lblNewIncrement);
            this.multipleEditSalaryGroupBox.Location = new System.Drawing.Point(335, 19);
            this.multipleEditSalaryGroupBox.Name = "multipleEditSalaryGroupBox";
            this.multipleEditSalaryGroupBox.Size = new System.Drawing.Size(250, 79);
            this.multipleEditSalaryGroupBox.TabIndex = 45;
            this.multipleEditSalaryGroupBox.TabStop = false;
            this.multipleEditSalaryGroupBox.Text = "Multiple Salary Increment";
            // 
            // txtIncrementSalary
            // 
            this.txtIncrementSalary.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncrementSalary.Location = new System.Drawing.Point(111, 37);
            this.txtIncrementSalary.Name = "txtIncrementSalary";
            this.txtIncrementSalary.Size = new System.Drawing.Size(60, 18);
            this.txtIncrementSalary.TabIndex = 43;
            this.txtIncrementSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(162, 38);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(18, 15);
            this.lblPercent.TabIndex = 44;
            this.lblPercent.Text = "%";
            // 
            // lblNewIncrement
            // 
            this.lblNewIncrement.AutoSize = true;
            this.lblNewIncrement.Location = new System.Drawing.Point(62, 39);
            this.lblNewIncrement.Name = "lblNewIncrement";
            this.lblNewIncrement.Size = new System.Drawing.Size(43, 13);
            this.lblNewIncrement.TabIndex = 42;
            this.lblNewIncrement.Text = "Amount";
            // 
            // actionBar
            // 
            this.actionBar.AutoSize = false;
            this.actionBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.companyAdd,
            this.companyEdit,
            this.companyDel,
            this.companySave,
            this.companyCel});
            this.actionBar.ButtonSize = new System.Drawing.Size(45, 30);
            this.actionBar.Dock = System.Windows.Forms.DockStyle.None;
            this.actionBar.DropDownArrows = true;
            this.actionBar.ImageList = this.imageList;
            this.actionBar.Location = new System.Drawing.Point(10, 29);
            this.actionBar.Name = "actionBar";
            this.actionBar.ShowToolTips = true;
            this.actionBar.Size = new System.Drawing.Size(243, 39);
            this.actionBar.TabIndex = 0;
            this.actionBar.TabStop = true;
            this.actionBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.actionBar_ButtonClick);
            // 
            // companyAdd
            // 
            this.companyAdd.ImageIndex = 0;
            this.companyAdd.Name = "companyAdd";
            this.companyAdd.Text = "&AddNew";
            // 
            // companyEdit
            // 
            this.companyEdit.ImageIndex = 1;
            this.companyEdit.Name = "companyEdit";
            this.companyEdit.Text = "&Modify";
            // 
            // companyDel
            // 
            this.companyDel.ImageIndex = 2;
            this.companyDel.Name = "companyDel";
            this.companyDel.Text = "&Delete";
            // 
            // companySave
            // 
            this.companySave.ImageIndex = 3;
            this.companySave.Name = "companySave";
            this.companySave.Text = "&Save";
            // 
            // companyCel
            // 
            this.companyCel.ImageIndex = 4;
            this.companyCel.Name = "companyCel";
            this.companyCel.Text = "&Cancel";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Controls.Add(this.tabSalary);
            this.tabControl.Controls.Add(this.tabBank);
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Location = new System.Drawing.Point(6, 81);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(939, 348);
            this.tabControl.TabIndex = 1;
            this.tabControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabControl_KeyPress);
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.txtBirthday);
            this.tabPage.Controls.Add(this.txtDateJoin);
            this.tabPage.Controls.Add(this.groupBoxStatus);
            this.tabPage.Controls.Add(this.txtMiddleName);
            this.tabPage.Controls.Add(this.label3);
            this.tabPage.Controls.Add(this.label21);
            this.tabPage.Controls.Add(this.txtGroupID);
            this.tabPage.Controls.Add(this.txtJobTitle);
            this.tabPage.Controls.Add(this.label4);
            this.tabPage.Controls.Add(this.label20);
            this.tabPage.Controls.Add(this.txtFirstName);
            this.tabPage.Controls.Add(this.txtWorkEmail);
            this.tabPage.Controls.Add(this.label5);
            this.tabPage.Controls.Add(this.label19);
            this.tabPage.Controls.Add(this.label6);
            this.tabPage.Controls.Add(this.txtPersonalEmail);
            this.tabPage.Controls.Add(this.txtFamilyName);
            this.tabPage.Controls.Add(this.label18);
            this.tabPage.Controls.Add(this.label7);
            this.tabPage.Controls.Add(this.label17);
            this.tabPage.Controls.Add(this.txtCallName);
            this.tabPage.Controls.Add(this.txtDeptID);
            this.tabPage.Controls.Add(this.label8);
            this.tabPage.Controls.Add(this.label16);
            this.tabPage.Controls.Add(this.txtIdentityID);
            this.tabPage.Controls.Add(this.txtCompanyID);
            this.tabPage.Controls.Add(this.label9);
            this.tabPage.Controls.Add(this.txtPostalCode);
            this.tabPage.Controls.Add(this.txtNationality);
            this.tabPage.Controls.Add(this.label15);
            this.tabPage.Controls.Add(this.label10);
            this.tabPage.Controls.Add(this.txtCity);
            this.tabPage.Controls.Add(this.label14);
            this.tabPage.Controls.Add(this.label11);
            this.tabPage.Controls.Add(this.txtCountry);
            this.tabPage.Controls.Add(this.txtSex);
            this.tabPage.Controls.Add(this.label13);
            this.tabPage.Controls.Add(this.label12);
            this.tabPage.Controls.Add(this.txtAddress);
            this.tabPage.ImageIndex = 16;
            this.tabPage.Location = new System.Drawing.Point(4, 23);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(931, 321);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Information";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // txtBirthday
            // 
            this.txtBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtBirthday.Location = new System.Drawing.Point(414, 166);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(121, 20);
            this.txtBirthday.TabIndex = 12;
            this.txtBirthday.Value = new System.DateTime(1984, 8, 25, 0, 0, 0, 0);
            // 
            // txtDateJoin
            // 
            this.txtDateJoin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateJoin.Location = new System.Drawing.Point(81, 140);
            this.txtDateJoin.Name = "txtDateJoin";
            this.txtDateJoin.Size = new System.Drawing.Size(121, 20);
            this.txtDateJoin.TabIndex = 5;
            this.txtDateJoin.Value = new System.DateTime(2014, 3, 11, 0, 0, 0, 0);
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.txtResigned);
            this.groupBoxStatus.Controls.Add(this.txtInOfficeN);
            this.groupBoxStatus.Controls.Add(this.txtInOfficeY);
            this.groupBoxStatus.Controls.Add(this.label22);
            this.groupBoxStatus.Location = new System.Drawing.Point(12, 190);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(305, 98);
            this.groupBoxStatus.TabIndex = 41;
            this.groupBoxStatus.TabStop = false;
            // 
            // txtResigned
            // 
            this.txtResigned.Enabled = false;
            this.txtResigned.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtResigned.Location = new System.Drawing.Point(93, 48);
            this.txtResigned.Name = "txtResigned";
            this.txtResigned.Size = new System.Drawing.Size(121, 20);
            this.txtResigned.TabIndex = 44;
            this.txtResigned.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // txtInOfficeN
            // 
            this.txtInOfficeN.AutoSize = true;
            this.txtInOfficeN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInOfficeN.ForeColor = System.Drawing.Color.Red;
            this.txtInOfficeN.Location = new System.Drawing.Point(93, 23);
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
            this.txtInOfficeY.Location = new System.Drawing.Point(17, 23);
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
            this.label22.Location = new System.Drawing.Point(6, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 13);
            this.label22.TabIndex = 39;
            this.label22.Text = "Resigned Date";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.Color.White;
            this.txtMiddleName.Location = new System.Drawing.Point(415, 59);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(86, 20);
            this.txtMiddleName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Group ID";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 143);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "Date Joined";
            // 
            // txtGroupID
            // 
            this.txtGroupID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtGroupID.Location = new System.Drawing.Point(81, 9);
            this.txtGroupID.MaxLength = 6;
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(60, 20);
            this.txtGroupID.TabIndex = 0;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.BackColor = System.Drawing.Color.White;
            this.txtJobTitle.Location = new System.Drawing.Point(81, 88);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(236, 20);
            this.txtJobTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "First Name";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "Job Title";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(415, 31);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(86, 20);
            this.txtFirstName.TabIndex = 7;
            // 
            // txtWorkEmail
            // 
            this.txtWorkEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtWorkEmail.Location = new System.Drawing.Point(81, 114);
            this.txtWorkEmail.Name = "txtWorkEmail";
            this.txtWorkEmail.Size = new System.Drawing.Size(236, 20);
            this.txtWorkEmail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Middle Name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "Work Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Family Name";
            // 
            // txtPersonalEmail
            // 
            this.txtPersonalEmail.BackColor = System.Drawing.Color.White;
            this.txtPersonalEmail.Location = new System.Drawing.Point(415, 289);
            this.txtPersonalEmail.MaxLength = 256;
            this.txtPersonalEmail.Name = "txtPersonalEmail";
            this.txtPersonalEmail.Size = new System.Drawing.Size(263, 20);
            this.txtPersonalEmail.TabIndex = 18;
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.BackColor = System.Drawing.Color.White;
            this.txtFamilyName.Location = new System.Drawing.Point(415, 4);
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(86, 20);
            this.txtFamilyName.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(335, 294);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "Personal Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Call Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Department";
            // 
            // txtCallName
            // 
            this.txtCallName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtCallName.Location = new System.Drawing.Point(415, 88);
            this.txtCallName.Name = "txtCallName";
            this.txtCallName.Size = new System.Drawing.Size(86, 20);
            this.txtCallName.TabIndex = 9;
            // 
            // txtDeptID
            // 
            this.txtDeptID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDeptID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDeptID.FormattingEnabled = true;
            this.txtDeptID.Location = new System.Drawing.Point(81, 61);
            this.txtDeptID.MaxDropDownItems = 10;
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(162, 21);
            this.txtDeptID.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Identity ID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Company";
            // 
            // txtIdentityID
            // 
            this.txtIdentityID.BackColor = System.Drawing.Color.White;
            this.txtIdentityID.Location = new System.Drawing.Point(415, 114);
            this.txtIdentityID.MaxLength = 30;
            this.txtIdentityID.Name = "txtIdentityID";
            this.txtIdentityID.Size = new System.Drawing.Size(121, 20);
            this.txtIdentityID.TabIndex = 10;
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCompanyID.FormattingEnabled = true;
            this.txtCompanyID.Location = new System.Drawing.Point(81, 35);
            this.txtCompanyID.MaxDropDownItems = 10;
            this.txtCompanyID.Name = "txtCompanyID";
            this.txtCompanyID.Size = new System.Drawing.Size(162, 21);
            this.txtCompanyID.TabIndex = 1;
            this.txtCompanyID.SelectedIndexChanged += new System.EventHandler(this.txtCompanyID_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Nationality";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.White;
            this.txtPostalCode.Location = new System.Drawing.Point(618, 235);
            this.txtPostalCode.MaxLength = 10;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(60, 20);
            this.txtPostalCode.TabIndex = 16;
            // 
            // txtNationality
            // 
            this.txtNationality.BackColor = System.Drawing.Color.White;
            this.txtNationality.Location = new System.Drawing.Point(415, 140);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(121, 20);
            this.txtNationality.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(547, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Postal Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(345, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Date of Brith";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.White;
            this.txtCity.Location = new System.Drawing.Point(415, 237);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(121, 20);
            this.txtCity.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(387, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "City";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Gender";
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.White;
            this.txtCountry.Location = new System.Drawing.Point(415, 212);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(121, 20);
            this.txtCountry.TabIndex = 14;
            // 
            // txtSex
            // 
            this.txtSex.BackColor = System.Drawing.Color.White;
            this.txtSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSex.FormattingEnabled = true;
            this.txtSex.Items.AddRange(new object[] {
            "male",
            "female",
            "unspecified"});
            this.txtSex.Location = new System.Drawing.Point(415, 190);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(121, 21);
            this.txtSex.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(368, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Country";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(366, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(414, 263);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(511, 20);
            this.txtAddress.TabIndex = 17;
            // 
            // tabSalary
            // 
            this.tabSalary.Controls.Add(this.txtBasicSalary);
            this.tabSalary.Controls.Add(this.probationCheckbox);
            this.tabSalary.Controls.Add(this.label28);
            this.tabSalary.Controls.Add(this.txtCurrency);
            this.tabSalary.Controls.Add(this.label27);
            this.tabSalary.Controls.Add(this.groupBoxReceivedRef);
            this.tabSalary.Controls.Add(this.label23);
            this.tabSalary.Controls.Add(this.txtProbationSalary);
            this.tabSalary.ImageIndex = 18;
            this.tabSalary.Location = new System.Drawing.Point(4, 23);
            this.tabSalary.Name = "tabSalary";
            this.tabSalary.Size = new System.Drawing.Size(931, 321);
            this.tabSalary.TabIndex = 2;
            this.tabSalary.Text = "Salary / Received";
            this.tabSalary.UseVisualStyleBackColor = true;
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicSalary.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtBasicSalary.Location = new System.Drawing.Point(126, 55);
            this.txtBasicSalary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(96, 18);
            this.txtBasicSalary.TabIndex = 41;
            this.txtBasicSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // probationCheckbox
            // 
            this.probationCheckbox.AutoSize = true;
            this.probationCheckbox.Location = new System.Drawing.Point(252, 25);
            this.probationCheckbox.Name = "probationCheckbox";
            this.probationCheckbox.Size = new System.Drawing.Size(104, 17);
            this.probationCheckbox.TabIndex = 40;
            this.probationCheckbox.Text = "In probation time";
            this.probationCheckbox.UseVisualStyleBackColor = true;
            this.probationCheckbox.CheckedChanged += new System.EventHandler(this.probationCheckbox_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(47, 57);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 13);
            this.label28.TabIndex = 38;
            this.label28.Text = "Basic Salary";
            // 
            // txtCurrency
            // 
            this.txtCurrency.BackColor = System.Drawing.Color.White;
            this.txtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCurrency.FormattingEnabled = true;
            this.txtCurrency.Items.AddRange(new object[] {
            "male",
            "female"});
            this.txtCurrency.Location = new System.Drawing.Point(126, 24);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(96, 21);
            this.txtCurrency.TabIndex = 37;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(39, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(81, 13);
            this.label27.TabIndex = 36;
            this.label27.Text = "Salary Currency";
            // 
            // groupBoxReceivedRef
            // 
            this.groupBoxReceivedRef.Controls.Add(this.receivedRefGrid);
            this.groupBoxReceivedRef.Location = new System.Drawing.Point(14, 130);
            this.groupBoxReceivedRef.Name = "groupBoxReceivedRef";
            this.groupBoxReceivedRef.Size = new System.Drawing.Size(903, 107);
            this.groupBoxReceivedRef.TabIndex = 35;
            this.groupBoxReceivedRef.TabStop = false;
            this.groupBoxReceivedRef.Text = "Received Reference";
            // 
            // receivedRefGrid
            // 
            this.receivedRefGrid.AllowUserToAddRows = false;
            this.receivedRefGrid.AllowUserToDeleteRows = false;
            this.receivedRefGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.receivedRefGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.receivedRefGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.receivedRefGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receivedRefGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.receivedRefGrid.Location = new System.Drawing.Point(6, 19);
            this.receivedRefGrid.MultiSelect = false;
            this.receivedRefGrid.Name = "receivedRefGrid";
            this.receivedRefGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.receivedRefGrid.RowHeadersVisible = false;
            this.receivedRefGrid.RowHeadersWidth = 5;
            this.receivedRefGrid.RowTemplate.Height = 24;
            this.receivedRefGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.receivedRefGrid.ShowCellToolTips = false;
            this.receivedRefGrid.ShowEditingIcon = false;
            this.receivedRefGrid.Size = new System.Drawing.Size(891, 81);
            this.receivedRefGrid.StandardTab = true;
            this.receivedRefGrid.TabIndex = 25;
            this.receivedRefGrid.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.receivedRefGrid_CancelRowEdit);
            this.receivedRefGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.receivedRefGrid_CellBeginEdit);
            this.receivedRefGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.receivedRefGrid_CellEndEdit);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(253, 57);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(103, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Probation Salary(LA)";
            // 
            // txtProbationSalary
            // 
            this.txtProbationSalary.BackColor = System.Drawing.Color.White;
            this.txtProbationSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProbationSalary.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProbationSalary.Location = new System.Drawing.Point(360, 54);
            this.txtProbationSalary.MaxLength = 12;
            this.txtProbationSalary.Name = "txtProbationSalary";
            this.txtProbationSalary.Size = new System.Drawing.Size(96, 18);
            this.txtProbationSalary.TabIndex = 22;
            this.txtProbationSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabBank
            // 
            this.tabBank.Controls.Add(this.labelHelpDeleteBankAcc);
            this.tabBank.Controls.Add(this.bankGrid);
            this.tabBank.ImageIndex = 21;
            this.tabBank.Location = new System.Drawing.Point(4, 23);
            this.tabBank.Name = "tabBank";
            this.tabBank.Size = new System.Drawing.Size(931, 321);
            this.tabBank.TabIndex = 3;
            this.tabBank.Text = "Bank Account";
            this.tabBank.UseVisualStyleBackColor = true;
            // 
            // labelHelpDeleteBankAcc
            // 
            this.labelHelpDeleteBankAcc.AutoSize = true;
            this.labelHelpDeleteBankAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelpDeleteBankAcc.ForeColor = System.Drawing.Color.Red;
            this.labelHelpDeleteBankAcc.Location = new System.Drawing.Point(716, 23);
            this.labelHelpDeleteBankAcc.Name = "labelHelpDeleteBankAcc";
            this.labelHelpDeleteBankAcc.Size = new System.Drawing.Size(157, 13);
            this.labelHelpDeleteBankAcc.TabIndex = 27;
            this.labelHelpDeleteBankAcc.Text = "How to delete a bank account?";
            this.labelHelpDeleteBankAcc.Click += new System.EventHandler(this.labelHelpDeleteBankAcc_Click);
            // 
            // bankGrid
            // 
            this.bankGrid.AllowUserToResizeRows = false;
            this.bankGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bankGrid.ColumnHeadersHeight = 27;
            this.bankGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AcHolder,
            this.Bank,
            this.AcNumber,
            this.ACCury});
            this.bankGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.bankGrid.Location = new System.Drawing.Point(15, 70);
            this.bankGrid.MultiSelect = false;
            this.bankGrid.Name = "bankGrid";
            this.bankGrid.RowHeadersWidth = 25;
            this.bankGrid.Size = new System.Drawing.Size(820, 233);
            this.bankGrid.TabIndex = 26;
            this.bankGrid.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.bankGrid_CancelRowEdit);
            this.bankGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.bankGrid_CellBeginEdit);
            this.bankGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.bankGrid_CellEndEdit);
            this.bankGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.bankGrid_DataError);
            this.bankGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.bankGrid_RowsAdded);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.ACCury.DefaultCellStyle = dataGridViewCellStyle2;
            this.ACCury.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ACCury.DisplayStyleForCurrentCellOnly = true;
            this.ACCury.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ACCury.HeaderText = "Payout Method & Location";
            this.ACCury.MaxDropDownItems = 25;
            this.ACCury.Name = "ACCury";
            this.ACCury.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACCury.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ACCury.Width = 350;
            // 
            // groupBoxEmpList
            // 
            this.groupBoxEmpList.Controls.Add(this.inServiceBox);
            this.groupBoxEmpList.Controls.Add(this.label24);
            this.groupBoxEmpList.Controls.Add(this.empListView);
            this.groupBoxEmpList.Controls.Add(this.label2);
            this.groupBoxEmpList.Controls.Add(this.deptBox);
            this.groupBoxEmpList.Controls.Add(this.label1);
            this.groupBoxEmpList.Controls.Add(this.companyBox);
            this.groupBoxEmpList.Location = new System.Drawing.Point(12, 13);
            this.groupBoxEmpList.Name = "groupBoxEmpList";
            this.groupBoxEmpList.Size = new System.Drawing.Size(818, 170);
            this.groupBoxEmpList.TabIndex = 0;
            this.groupBoxEmpList.TabStop = false;
            this.groupBoxEmpList.Text = "Query Employee";
            // 
            // inServiceBox
            // 
            this.inServiceBox.BackColor = System.Drawing.SystemColors.Control;
            this.inServiceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inServiceBox.FormattingEnabled = true;
            this.inServiceBox.Location = new System.Drawing.Point(659, 12);
            this.inServiceBox.MaxDropDownItems = 10;
            this.inServiceBox.Name = "inServiceBox";
            this.inServiceBox.Size = new System.Drawing.Size(129, 21);
            this.inServiceBox.TabIndex = 2;
            this.inServiceBox.SelectedIndexChanged += new System.EventHandler(this.InOfficeBox_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(600, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "In Service";
            // 
            // empListView
            // 
            this.empListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            InService,
            this.GroupID,
            this.CallName,
            this.Gender,
            this.JobTitle,
            this.DateJoined,
            this.LastSalary,
            this.Increment,
            this.CurrentSalary,
            this.InProbationTime});
            this.empListView.FullRowSelect = true;
            this.empListView.GridLines = true;
            this.empListView.HideSelection = false;
            this.empListView.Location = new System.Drawing.Point(6, 40);
            this.empListView.Name = "empListView";
            this.empListView.Size = new System.Drawing.Size(806, 123);
            this.empListView.SmallImageList = this.imageList;
            this.empListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.empListView.StateImageList = this.imageList;
            this.empListView.TabIndex = 3;
            this.empListView.UseCompatibleStateImageBehavior = false;
            this.empListView.View = System.Windows.Forms.View.Details;
            this.empListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.empListView_ColumnClick);
            this.empListView.SelectedIndexChanged += new System.EventHandler(this.empListView_SelectedIndexChanged);
            this.empListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empListView_KeyPress);
            this.empListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.empListView_MouseDoubleClick);
            // 
            // GroupID
            // 
            this.GroupID.Tag = "GrpID";
            this.GroupID.Text = "Group ID";
            this.GroupID.Width = 70;
            // 
            // CallName
            // 
            this.CallName.Tag = "CallName";
            this.CallName.Text = "Call Name";
            this.CallName.Width = 73;
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
            this.JobTitle.Text = "Job Title";
            this.JobTitle.Width = 130;
            // 
            // DateJoined
            // 
            this.DateJoined.Tag = "DateJoined";
            this.DateJoined.Text = "Date Joined";
            this.DateJoined.Width = 80;
            // 
            // LastSalary
            // 
            this.LastSalary.Text = "Last Salary";
            this.LastSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LastSalary.Width = 70;
            // 
            // Increment
            // 
            this.Increment.Text = "+ %";
            this.Increment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Increment.Width = 40;
            // 
            // CurrentSalary
            // 
            this.CurrentSalary.Text = "Current Salary";
            this.CurrentSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CurrentSalary.Width = 80;
            // 
            // InProbationTime
            // 
            this.InProbationTime.Text = "In Probation";
            this.InProbationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InProbationTime.Width = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Department";
            // 
            // deptBox
            // 
            this.deptBox.BackColor = System.Drawing.SystemColors.Control;
            this.deptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deptBox.FormattingEnabled = true;
            this.deptBox.Location = new System.Drawing.Point(414, 12);
            this.deptBox.MaxDropDownItems = 10;
            this.deptBox.Name = "deptBox";
            this.deptBox.Size = new System.Drawing.Size(171, 21);
            this.deptBox.TabIndex = 1;
            this.deptBox.SelectedIndexChanged += new System.EventHandler(this.DeptBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Company";
            // 
            // companyBox
            // 
            this.companyBox.BackColor = System.Drawing.SystemColors.Control;
            this.companyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companyBox.FormattingEnabled = true;
            this.companyBox.Location = new System.Drawing.Point(186, 12);
            this.companyBox.MaxDropDownItems = 10;
            this.companyBox.Name = "companyBox";
            this.companyBox.Size = new System.Drawing.Size(157, 21);
            this.companyBox.TabIndex = 0;
            this.companyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 648);
            this.Controls.Add(this.groupBoxDataOutput);
            this.Controls.Add(this.groupBoxDataInput);
            this.Controls.Add(this.groupBoxEmp);
            this.Controls.Add(this.groupBoxEmpList);
            this.Name = "Employee";
            this.Text = "Employee / Salary / Bank Account / Account to Received";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Employee_Load);
            this.groupBoxDataOutput.ResumeLayout(false);
            this.groupBoxDataInput.ResumeLayout(false);
            this.groupBoxEmp.ResumeLayout(false);
            this.multipleEditSalaryGroupBox.ResumeLayout(false);
            this.multipleEditSalaryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncrementSalary)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.tabSalary.ResumeLayout(false);
            this.tabSalary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary)).EndInit();
            this.groupBoxReceivedRef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.receivedRefGrid)).EndInit();
            this.tabBank.ResumeLayout(false);
            this.tabBank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankGrid)).EndInit();
            this.groupBoxEmpList.ResumeLayout(false);
            this.groupBoxEmpList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBoxEmpList;
        private System.Windows.Forms.ComboBox companyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox deptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView empListView;
        private System.Windows.Forms.ColumnHeader GroupID;
        private System.Windows.Forms.ColumnHeader CallName;
        private System.Windows.Forms.ColumnHeader JobTitle;
        private System.Windows.Forms.ColumnHeader Gender;
        private System.Windows.Forms.ColumnHeader DateJoined;
        private System.Windows.Forms.GroupBox groupBoxEmp;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtWorkEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPersonalEmail;
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.ComboBox txtSex;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TabPage tabSalary;
        private System.Windows.Forms.TabPage tabBank;
        private System.Windows.Forms.ToolBar actionBar;
        private System.Windows.Forms.ToolBarButton companyAdd;
        private System.Windows.Forms.ToolBarButton companyEdit;
        private System.Windows.Forms.ToolBarButton companyDel;
        private System.Windows.Forms.ToolBarButton companySave;
        private System.Windows.Forms.ToolBarButton companyCel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtProbationSalary;
        private System.Windows.Forms.GroupBox groupBoxReceivedRef;
        private System.Windows.Forms.DataGridView receivedRefGrid;
        private System.Windows.Forms.DataGridView bankGrid;
        private System.Windows.Forms.GroupBox groupBoxDataInput;
        private System.Windows.Forms.GroupBox groupBoxDataOutput;
        private System.Windows.Forms.Button ExcelImport;
        private System.Windows.Forms.Button ExcelOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialogExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.RadioButton txtInOfficeN;
        private System.Windows.Forms.RadioButton txtInOfficeY;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox inServiceBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox txtCurrency;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label labelHelpDeleteBankAcc;
        private System.Windows.Forms.CheckBox probationCheckbox;
        private System.Windows.Forms.NumericUpDown txtBasicSalary;
        private System.Windows.Forms.DateTimePicker txtDateJoin;
        private System.Windows.Forms.DateTimePicker txtBirthday;
        private System.Windows.Forms.DateTimePicker txtResigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcHolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcNumber;
        private System.Windows.Forms.ColumnHeader LastSalary;
        private System.Windows.Forms.ColumnHeader Increment;
        private System.Windows.Forms.ColumnHeader CurrentSalary;
        private System.Windows.Forms.NumericUpDown txtIncrementSalary;
        private System.Windows.Forms.Label lblNewIncrement;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.GroupBox multipleEditSalaryGroupBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn ACCury;
        private System.Windows.Forms.ColumnHeader InProbationTime;

    }
}