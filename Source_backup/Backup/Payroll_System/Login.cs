using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Payroll_System {

    

    public partial class Login : First {
        
        TSQL tSQL;

        public Login() {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e) {
            tSQL = new TSQL(base.remoteDBAbsPath());

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e) {
            Main AA = (Main)this.MdiParent;
            AA.checkLoginCloseOrNot();
        }

        private void button1_Click(object sender, EventArgs e) {
            //default: admin / 000000
            if (accountBox.Text.Trim() == "") {
                MessageBox.Show("Please enter [Account ID]", "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                accountBox.Focus();
                return;
            }
            if (passBox.Text.Trim() == "") {
                MessageBox.Show("Please enter [Password]", "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                passBox.Focus();
                return;
            }

            //if (!File.Exists(tSQL.PayrollAbsFile)) {
            //    MessageBox.Show("Error: Database file not exist.\nPath: " + tSQL.PayrollAbsFile);
            //    MessageBox.Show("You must correctly set the [Payroll_System.exe.config] and the key word:[DBAbsolutePath] ");
            //}

            ___LoginPass = tSQL.LoginCheck(accountBox.Text.Trim(), base.sysEncryt(passBox.Text.Trim()));

            if (___LoginPass) {
                ___LoginUser = accountBox.Text.Trim();
                Main AA = (Main)this.MdiParent;
                AA.openMenu();
                this.Close();
            } else {
                MessageBox.Show(tSQL.errMessage, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void passBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                button1_Click(null, null);
            }
        }

      
    }
}