namespace Payroll_System {
    partial class LoginAccount {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginAccount));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confirmBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.fullnameBox = new System.Windows.Forms.TextBox();
            this.accountBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AccListView = new System.Windows.Forms.ListView();
            this.Account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.pppAAdd = new System.Windows.Forms.ToolBarButton();
            this.pppAEdit = new System.Windows.Forms.ToolBarButton();
            this.pppADel = new System.Windows.Forms.ToolBarButton();
            this.pppASave = new System.Windows.Forms.ToolBarButton();
            this.pppACel = new System.Windows.Forms.ToolBarButton();
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
            this.groupBox1.Controls.Add(this.confirmBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.fullnameBox);
            this.groupBox1.Controls.Add(this.accountBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(365, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 447);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // confirmBox
            // 
            this.confirmBox.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.confirmBox.Location = new System.Drawing.Point(109, 151);
            this.confirmBox.MaxLength = 20;
            this.confirmBox.Name = "confirmBox";
            this.confirmBox.PasswordChar = '*';
            this.confirmBox.Size = new System.Drawing.Size(134, 20);
            this.confirmBox.TabIndex = 34;
            this.confirmBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.confirmBox.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "ConfirmPassword";
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.passwordBox.Location = new System.Drawing.Point(109, 109);
            this.passwordBox.MaxLength = 20;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(134, 20);
            this.passwordBox.TabIndex = 32;
            this.passwordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // fullnameBox
            // 
            this.fullnameBox.Location = new System.Drawing.Point(109, 72);
            this.fullnameBox.MaxLength = 50;
            this.fullnameBox.Name = "fullnameBox";
            this.fullnameBox.Size = new System.Drawing.Size(134, 20);
            this.fullnameBox.TabIndex = 31;
            // 
            // accountBox
            // 
            this.accountBox.Location = new System.Drawing.Point(109, 35);
            this.accountBox.MaxLength = 20;
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(134, 20);
            this.accountBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account ID";
            // 
            // AccListView
            // 
            this.AccListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Account,
            this.FullName,
            this.Password});
            this.AccListView.FullRowSelect = true;
            this.AccListView.GridLines = true;
            this.AccListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AccListView.Location = new System.Drawing.Point(12, 12);
            this.AccListView.MultiSelect = false;
            this.AccListView.Name = "AccListView";
            this.AccListView.Size = new System.Drawing.Size(347, 503);
            this.AccListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.AccListView.TabIndex = 31;
            this.AccListView.UseCompatibleStateImageBehavior = false;
            this.AccListView.View = System.Windows.Forms.View.Details;
            this.AccListView.Click += new System.EventHandler(this.AccListView_Click);
            // 
            // Account
            // 
            this.Account.Text = "AccountID";
            this.Account.Width = 100;
            // 
            // FullName
            // 
            this.FullName.Text = "Full Name";
            this.FullName.Width = 180;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 0;
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
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Location = new System.Drawing.Point(365, 12);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(243, 39);
            this.toolBar.TabIndex = 29;
            this.toolBar.TabStop = true;
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
            // LoginAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 605);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AccListView);
            this.Controls.Add(this.toolBar);
            this.Name = "LoginAccount";
            this.Text = "Login Accont Control";
            this.Load += new System.EventHandler(this.LoginAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton pppAAdd;
        private System.Windows.Forms.ToolBarButton pppAEdit;
        private System.Windows.Forms.ToolBarButton pppADel;
        private System.Windows.Forms.ToolBarButton pppASave;
        private System.Windows.Forms.ToolBarButton pppACel;
        private System.Windows.Forms.ListView AccListView;
        private System.Windows.Forms.ColumnHeader Account;
        private System.Windows.Forms.ColumnHeader FullName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox fullnameBox;
        private System.Windows.Forms.TextBox accountBox;
        private System.Windows.Forms.TextBox confirmBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Password;
    }
}