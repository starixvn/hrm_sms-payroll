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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.pppAAdd = new System.Windows.Forms.ToolBarButton();
            this.pppAEdit = new System.Windows.Forms.ToolBarButton();
            this.pppADel = new System.Windows.Forms.ToolBarButton();
            this.pppASave = new System.Windows.Forms.ToolBarButton();
            this.pppACel = new System.Windows.Forms.ToolBarButton();
            this.AccListView = new System.Windows.Forms.ListView();
            this.lvaccount = new System.Windows.Forms.ColumnHeader();
            this.lvfullname = new System.Windows.Forms.ColumnHeader();
            this.lvpassword = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confirmBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.fullnameBox = new System.Windows.Forms.TextBox();
            this.accountBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.toolBar.Location = new System.Drawing.Point(381, 29);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(243, 36);
            this.toolBar.TabIndex = 29;
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
            // AccListView
            // 
            this.AccListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvaccount,
            this.lvfullname,
            this.lvpassword});
            this.AccListView.FullRowSelect = true;
            this.AccListView.GridLines = true;
            this.AccListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AccListView.Location = new System.Drawing.Point(28, 29);
            this.AccListView.MultiSelect = false;
            this.AccListView.Name = "AccListView";
            this.AccListView.Size = new System.Drawing.Size(337, 465);
            this.AccListView.TabIndex = 31;
            this.AccListView.UseCompatibleStateImageBehavior = false;
            this.AccListView.View = System.Windows.Forms.View.Details;
            this.AccListView.Click += new System.EventHandler(this.AccListView_Click);
            // 
            // lvaccount
            // 
            this.lvaccount.Text = "AccountID";
            this.lvaccount.Width = 100;
            // 
            // lvfullname
            // 
            this.lvfullname.Text = "Full Nmae";
            this.lvfullname.Width = 180;
            // 
            // lvpassword
            // 
            this.lvpassword.Text = "Password";
            this.lvpassword.Width = 0;
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
            this.groupBox1.Location = new System.Drawing.Point(381, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 413);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // confirmBox
            // 
            this.confirmBox.Location = new System.Drawing.Point(109, 139);
            this.confirmBox.MaxLength = 20;
            this.confirmBox.Name = "confirmBox";
            this.confirmBox.PasswordChar = '*';
            this.confirmBox.Size = new System.Drawing.Size(134, 22);
            this.confirmBox.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "ConfirmPassword";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(109, 101);
            this.passwordBox.MaxLength = 20;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(134, 22);
            this.passwordBox.TabIndex = 32;
            // 
            // fullnameBox
            // 
            this.fullnameBox.Location = new System.Drawing.Point(109, 66);
            this.fullnameBox.MaxLength = 50;
            this.fullnameBox.Name = "fullnameBox";
            this.fullnameBox.Size = new System.Drawing.Size(134, 22);
            this.fullnameBox.TabIndex = 31;
            // 
            // accountBox
            // 
            this.accountBox.Location = new System.Drawing.Point(109, 32);
            this.accountBox.MaxLength = 20;
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(134, 22);
            this.accountBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account ID";
            // 
            // LoginAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;  this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AccListView);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.button4);
            this.Name = "LoginAccount";
            this.Text = "Login Accont Control";
            this.Load += new System.EventHandler(this.LoginAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton pppAAdd;
        private System.Windows.Forms.ToolBarButton pppAEdit;
        private System.Windows.Forms.ToolBarButton pppADel;
        private System.Windows.Forms.ToolBarButton pppASave;
        private System.Windows.Forms.ToolBarButton pppACel;
        private System.Windows.Forms.ListView AccListView;
        private System.Windows.Forms.ColumnHeader lvaccount;
        private System.Windows.Forms.ColumnHeader lvfullname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox fullnameBox;
        private System.Windows.Forms.TextBox accountBox;
        private System.Windows.Forms.TextBox confirmBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader lvpassword;
    }
}