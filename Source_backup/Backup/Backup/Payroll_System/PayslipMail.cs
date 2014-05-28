using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Payroll_System {
    public partial class PayslipMail : First {

        TSQL tSQL;
        string thisMonthyStr;
        string htmlFile;
        string Str_ALL = "======= All =======";

        public PayslipMail() {
            InitializeComponent();
        }

        private void PayslipMail_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            thisMonthyStr = tSQL.LockData_openMonth();

            DataTable profile = tSQL.getMailProfile();

            //content, mailserver, port, Sender, subject, testRecipient
            Labmailserver.Text = base.obj2str(profile.Rows[0]["mailserver"]);
            Labmailport.Text = base.obj2str(profile.Rows[0]["port"]);
            txtSender.Text = base.obj2str(profile.Rows[0]["Sender"]);
            txtSubject.Text = base.obj2str(profile.Rows[0]["subject"]);
            txtContent.Text = base.obj2str(profile.Rows[0]["content"]);
            txtTestAddr.Text = base.obj2str(profile.Rows[0]["testRecipient"]);

            htmlFile = base.remoteDBAbsPath() + "\\HtmlTemplate\\PayslipMail.html";

            setPrgBar(0, 0, 0);

            load_CompanyListBox();
            load_DeptListBox(CompanyBox, DeptBox);
        }

        private void load_CompanyListBox() {
            DataTable tb;
            CompanyBox.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();
            string formatStr;
            CompanyBox.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                CompanyBox.Items.Add(formatStr);
            }
            if (CompanyBox.Items.Count > 0)
                CompanyBox.SelectedIndex = 0;
            else
                CompanyBox.Text = "";
        }
        private void load_DeptListBox(ComboBox Comp, ComboBox Dept) {
            DataTable tb;
            Dept.Items.Clear();
            tb = tSQL.DeptData_SelectAll(this.get_IDformBox(Comp));
            string formatStr;
            Dept.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                Dept.Items.Add(formatStr);
            }
            if (Dept.Items.Count > 0)
                Dept.SelectedIndex = 0;
            else
                Dept.Text = "";
        }
        private void load_DeptEmptoGrid() {
            EmpGrid.Rows.Clear();
            string comp = this.get_IDformBox(CompanyBox);
            string dept = this.get_IDformBox(DeptBox);
            if (comp != "") {
                DataTable empDT = tSQL.EmployeeData_SelectAll(comp, dept, "Y", "");
                int idx = 0;
                foreach (DataRow row in empDT.Rows) {
                    EmpGrid.Rows.Add();                   
                    //hidden --¡ô
                    EmpGrid.Rows[idx].Cells[0].Value = false;
                    EmpGrid.Rows[idx].Cells[1].Value = base.obj2str(row["GrpID"]);
                    this.markGridCell(idx, 1);
                    EmpGrid.Rows[idx].Cells[2].Value = base.obj2str(row["CallName"]);
                    this.markGridCell(idx, 2);
                    EmpGrid.Rows[idx].Cells[3].Value = base.obj2str(row["EmailWork"]);
                    this.markGridCell(idx, 3);
                    idx++;
                }   
            }
        }
        private string get_GridGrpid() { 
            string groupPeople = "";
            string tmp = "";
            int count = EmpGrid.Rows.Count;
            int idx;
            for (idx = 0; idx < count; idx++) {
                tmp = base.obj2str(EmpGrid.Rows[idx].Cells[0].Value);
                if (tmp.ToLower() == "true") {
                    if (groupPeople != "") groupPeople += ",";
                    groupPeople += "'" + base.obj2str(EmpGrid.Rows[idx].Cells[1].Value) + "'";
                }
            }
            return groupPeople;
        }

        private void markGridCell(int rows, int cells) {
            EmpGrid.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            EmpGrid.Rows[rows].Cells[cells].Style.SelectionForeColor = Color.Wheat;
            EmpGrid.Rows[rows].Cells[cells].ReadOnly = true;
        }

        private string get_IDformBox(ComboBox Lx) {
            string reval = "";
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null) {
                if (Lx.SelectedItem.ToString() != Str_ALL)
                    reval = Lx.SelectedItem.ToString();
            }
            return reval;
        }

        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            //test            
            Mail _Mail = new Mail();
            if (txtUserName.Text.Trim() != "") {
                _Mail.UserName = txtUserName.Text.Trim();
                _Mail.Password = txtPassword.Text.Trim();
            }

            string doc;
            try {
                
                if (!File.Exists(htmlFile)) {
                    MessageBox.Show("File not exists :" + htmlFile);
                }

                doc = base.getFileTxt(htmlFile);
                doc = doc.Replace("{{Body}}", txtContent.Text.Replace(Environment.NewLine, "<BR>"));
                doc = doc.Replace("{{Message}}", "Payslip");
                _Mail.Subject = txtSubject.Text.Trim();
                _Mail.Body = doc;
                //_Mail.Body = string.Format("This is system message from HRMIS.{0} Appraisal of employee {1}({2}) has been completed.",
                //        Environment.NewLine, employee.FullName, employee.EmployeeId);

                _Mail.From = txtSender.Text;
                _Mail.Host = Labmailserver.Text;
                _Mail.MailOne = txtTestAddr.Text;
                _Mail.Port = Convert.ToInt16(Labmailport.Text);
                _Mail.Send();
                MessageBox.Show("send", "OK");
            } catch (Exception ex) {
                MessageBox.Show("error", ex.Message);
            }
        }

        private void sendall(bool isTester) {
            Mail _Mail;
            string doc;
            string personal;
            string Grpid="";
            string ename = "";
            string payoutMethod="";
            int pcount;
            int i;
            string workMail = "";
            string fulldate = base.YYMM2EnglishDate(thisMonthyStr);
            string fulldatetime = base.YYMMDD2EnglishDate(DateTime.Today);
            string bankList = "";
            string bankListItem = "<tr>" + 
                              "<td bgcolor='#FFFFFF' class='intd' width='120'>{0}</td>" + 
                              "<td bgcolor='#CCCCFF' class='intd' width='180' align='right'>{1}</td>" + 
                              "<td bgcolor='#CCCCFF' class='intd' width='120' align='right'>{2}</td>" +
                              "<td bgcolor='#FFFFFF' class='intd' width='180' align='right'>{3}</td>" +
                              "</tr>";

            string exchangeItem = "<tr>" + 
					              "<td bgcolor='#FFFFFF' class='header2' width='150'>{0}</td>" +
					              "<td bgcolor='#FFFFFF' class='header2' width='150' align='center'>{1}</td>" +
                                  "</tr>";
            DataTable CurrencyDT = tSQL.Report_CurrencyData_SelectAll(thisMonthyStr);
            string exchangeRate = "";
            foreach (DataRow row in CurrencyDT.Rows) {
                exchangeRate += string.Format(exchangeItem, base.obj2str(row["Pcurrency"]) + " To MYR", base.obj2str(row["showRate"]));
            }

            double _subAmount;
            double _BankTotal;
            string _CompanyBox = get_IDformBox(CompanyBox);
            string _DeptBox = get_IDformBox(DeptBox);
            if (_CompanyBox == Str_ALL) _CompanyBox = "";
            if (_DeptBox == Str_ALL) _DeptBox = "";
            DataTable empDT;
            DataTable bankDT;
            string[] splitchar = { "--" };
            
            string BasicSalary;
            string ProSalary;
            string Incre_Amount;
            string Add_Amount;
            string Gross_Total;
            string Unpaid_Amount;
            string Adv_Amount;
            string Loan_Amount;
            string Dedu_Total;
            string Net_Salary;
            
            string Amount;

            Dictionary<string, string> txtlog = new Dictionary<string, string>();
            textLog.Text = "";            
            try {
                doc = base.getFileTxt(htmlFile);
                doc = doc.Replace("{{Body}}", txtContent.Text.Replace(Environment.NewLine, "<BR>"));
                doc = doc.Replace("{{Message}}", "Payslip");

                empDT = tSQL.Report_getEmpList(thisMonthyStr, _CompanyBox, _DeptBox, this.get_GridGrpid());
                pcount = empDT.Rows.Count;
                setPrgBar(pcount, 0, 0);
                for (i = 0; i < pcount; i++) {
                    Grpid = base.obj2str(empDT.Rows[i]["GrpID"]);
                    ename = base.obj2str(empDT.Rows[i]["eName"]);
                    txtlog.Add(Grpid, ename + " wait.");
                }
                for (i = 0; i < pcount; i++) {
                    Grpid = base.obj2str(empDT.Rows[i]["GrpID"]);
                    ename = base.obj2str(empDT.Rows[i]["eName"]);
                    personal = doc;
                    personal = personal.Replace("{{FullDate}}", fulldate);
                    personal = personal.Replace("{{Fullname}}", base.obj2str(empDT.Rows[i]["eName"]));
                    personal = personal.Replace("{{Nick}}", base.obj2str(empDT.Rows[i]["CallName"]));
                    personal = personal.Replace("{{Grpid}}", Grpid);
                    workMail = base.obj2str(empDT.Rows[i]["EmailWork"]);
                    personal = personal.Replace("{{Email}}", workMail);
                    personal = personal.Replace("{{Dept}}", base.obj2str(empDT.Rows[i]["DepartmentID"]));
                    personal = personal.Replace("{{Jobtitle}}", base.obj2str(empDT.Rows[i]["PositionName"]));
                    personal = personal.Replace("{{Doc}}", base.obj2str(empDT.Rows[i]["DateJoined"]));

                    BasicSalary = base.empKeyDecrypt(base.obj2str(empDT.Rows[i]["BasicSalary"]));
                    personal = personal.Replace("{{BasicSalary}}", base.obj2str(empDT.Rows[i]["Pcurrency"]) + " " + base.obj2thousand(BasicSalary));

                    personal = personal.Replace("{{ProCurry}}", base.obj2str(empDT.Rows[i]["Pcurrency"]));
                    ProSalary = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Prob_Salary"]));
                    personal = personal.Replace("{{ProSalary}}", base.obj2thousand(ProSalary));
                    Incre_Amount = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Incre_Amount"]));
                    personal = personal.Replace("{{IncreSalary}}", base.obj2thousand(Incre_Amount));
                    Add_Amount = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Add_Amount"]));
                    personal = personal.Replace("{{Additional}}", base.obj2thousand(Add_Amount));
                    personal = personal.Replace("{{BasicSalaryRemark}}", base.obj2str(empDT.Rows[i]["BasicSalaryRemark"]));
                    personal = personal.Replace("{{IncRemark}}", base.obj2str(empDT.Rows[i]["IncreRemark"]));
                    personal = personal.Replace("{{AddRemark}}", base.obj2str(empDT.Rows[i]["OtherRemark"]));
                    Gross_Total = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Gross_Total"]));
                    personal = personal.Replace("{{Gross}}", base.obj2thousand(Gross_Total));

                    personal = personal.Replace("{{UnpaidCurry}}", base.obj2str(empDT.Rows[i]["Unpaidcury"]));
                    Unpaid_Amount = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Unpaid_Amount"]));
                    personal = personal.Replace("{{Unpaid}}", base.obj2thousand(Unpaid_Amount));
                    personal = personal.Replace("{{AdvCurry}}", base.obj2str(empDT.Rows[i]["Advcury"]));
                    Adv_Amount = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Adv_Amount"]));
                    personal = personal.Replace("{{Advance}}", base.obj2thousand(Adv_Amount));
                    personal = personal.Replace("{{LoanCurry}}", base.obj2str(empDT.Rows[i]["Loancury"]));
                    Loan_Amount = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Loan_Amount"]));
                    personal = personal.Replace("{{Loan}}", base.obj2thousand(Loan_Amount));
                    Dedu_Total = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Dedu_Total"]));
                    personal = personal.Replace("{{Dedu_Total}}", base.obj2thousand(Dedu_Total));

                    Net_Salary = base.payKeyDecrypt(base.obj2str(empDT.Rows[i]["Net_Salary"]));
                    personal = personal.Replace("{{NetSalary}}", base.obj2thousand(Net_Salary));

                    bankDT = tSQL.KeyData_getBankInList(Grpid, thisMonthyStr);
                    bankList = "";
                    _BankTotal = 0;
                    foreach (DataRow row in bankDT.Rows) {
                        payoutMethod = base.obj2str(row["payoutRelation"]);
                        if (payoutMethod != "") {
                            payoutMethod = payoutMethod.Split(splitchar, StringSplitOptions.None)[0];
                        }
                        Amount = base.payKeyDecrypt(base.obj2str(row["Amount"]));
                        _subAmount = calculate_Amount_byCurrency(ref CurrencyDT, "Pcurrency", "showRate", base.obj2str(empDT.Rows[i]["Pcurrency"]), base.obj2str(row["Cury"]), Amount);
                        _BankTotal += _subAmount;
                        bankList += string.Format(bankListItem, payoutMethod, base.obj2str(row["Cury"]), base.obj2thousand(Amount), base.double2thousand(_subAmount));
                    }
                    personal = personal.Replace("<!--{{BankList}}-->", bankList);
                    personal = personal.Replace("{{PaidInProCurry}}", base.double2thousand(_BankTotal));

                    personal = personal.Replace("<!--{{ExchangeRateList}}-->", exchangeRate);
                    personal = personal.Replace("{{FullDateTime}}", fulldatetime);

                    _Mail = new Mail();
                    if (txtUserName.Text.Trim() != "") {
                        _Mail.UserName = txtUserName.Text.Trim();
                        _Mail.Password = txtPassword.Text.Trim();
                    }

                    _Mail.Subject = txtSubject.Text.Trim();
                    _Mail.Body = personal;
                    _Mail.From = txtSender.Text;
                    _Mail.Host = Labmailserver.Text;
                    if (!isTester) {
                        _Mail.MailOne = workMail;
                    } else {
                        _Mail.MailOne = txtTestAddr.Text.Trim();
                    }
                    _Mail.Port = Convert.ToInt16(Labmailport.Text);
                    _Mail.Send();

                    txtlog[Grpid] = ename + " send.";
                    setPrgBar(-1, -1, i + 1);
                }

                MessageBox.Show("send", "OK");
            } catch (Exception ex) {
                MessageBox.Show("error", ex.Message + "\n stop: GroupID: " + Grpid + " name is " + ename);
            } finally { 
                StringBuilder cb = new StringBuilder();
                foreach(string im in txtlog.Keys){
                    cb.AppendLine(im + " " + txtlog[im] + "\n");
                }

                textLog.Text = cb.ToString();
                //Clipboard.SetDataObject(cb.ToString(), true);
                //System.Diagnostics.Process.Start("NOTEPAD.exe");                
                //SendKeys.Send("^v");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            DialogResult result;
            result = MessageBox.Show("Send payslip to all employees?", "Send payslip to all", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                this.sendall(false);
            }
        }

        private void setPrgBar(int _max, int _min, int val) {
            if (_max >= 0) progressBar1.Maximum = _max;
            if (_min >= 0) progressBar1.Minimum = _min;
            progressBar1.Value = val;
            if (val <= 0) 
                labCount.Text = "";
            else
                labCount.Text = val.ToString();
        }

        

        private void button5_Click(object sender, EventArgs e) {
            //Save
            bool flag = tSQL.MailProfile_Update(Labmailserver.Text,
                                                Labmailport.Text,
                                                txtSender.Text,
                                                txtSubject.Text,
                                                txtContent.Text,
                                                txtTestAddr.Text
                                                );
           

            if (flag) {
                MessageBox.Show("Saved.", "Save", MessageBoxButtons.OK);                
            } else {
                MessageBox.Show(tSQL.errMessage, "Save", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult result;
            result = MessageBox.Show("Send all payslip to tester?", "Send payslip to tester", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                this.sendall(true);
            }            
           
        }
        
        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_DeptListBox(CompanyBox, DeptBox);
            load_DeptEmptoGrid();
        }
        
        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_DeptEmptoGrid();
        }


    }
}