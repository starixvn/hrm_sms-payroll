using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class PayslipMail : First
    {
        TSQL tSQL;
        string thisMonthy;
        string htmlFile;
        string TextAll = "======= All =======";

        public PayslipMail()
        {
            InitializeComponent();
        }

        private void PayslipMail_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.RemoteDBAbsPath());

            thisMonthy = tSQL.LockData_openMonth();

            DataTable profile = tSQL.getMailProfile();

            // content, mailserver, port, Sender, subject, testRecipient
            txtMailServer.Text = base.obj2str(profile.Rows[0]["mailserver"]);
            txtMailPort.Text = base.obj2str(profile.Rows[0]["port"]);
            txtSender.Text = base.obj2str(profile.Rows[0]["Sender"]);
            txtSubject.Text = base.obj2str(profile.Rows[0]["subject"]);
            txtContent.Text = base.obj2str(profile.Rows[0]["content"]);
            txtTestAddr.Text = base.obj2str(profile.Rows[0]["testRecipient"]);

            htmlFile = base.RemoteDBAbsPath() + "\\HtmlTemplate\\PayslipMail.html";

            SetProgressBar(0, 0, 0);

            load_CompanyListBox();
            load_DeptListBox(CompanyBox, DeptBox);
        }

        private void load_CompanyListBox()
        {
            DataTable tb;
            CompanyBox.Items.Clear();
            tb = tSQL.CompanyData_SelectAll();
            string formatStr;
            CompanyBox.Items.Add(TextAll);
            foreach (DataRow row in tb.Rows)
            {
                formatStr = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                CompanyBox.Items.Add(formatStr);
            }
            if (CompanyBox.Items.Count > 0)
                CompanyBox.SelectedIndex = 0;
            else
                CompanyBox.Text = string.Empty;
        }
        private void load_DeptListBox(ComboBox Comp, ComboBox Dept)
        {
            DataTable tb;
            Dept.Items.Clear();
            tb = tSQL.DeptData_SelectAll(this.GetIDFromBox(Comp));
            string format;
            Dept.Items.Add(TextAll);
            foreach (DataRow row in tb.Rows)
            {
                format = string.Format("{0}", row.ItemArray.GetValue(0).ToString());
                Dept.Items.Add(format);
            }
            if (Dept.Items.Count > 0)
                Dept.SelectedIndex = 0;
            else
                Dept.Text = string.Empty;
        }
        private void load_DeptEmptoGrid()
        {
            empGrid.Rows.Clear();
            string company = this.GetIDFromBox(CompanyBox);
            string dept = this.GetIDFromBox(DeptBox);

            if (company != string.Empty)
            {
                DataTable empDT = tSQL.EmployeeData_SelectAll(company, dept, "Y", "");
                int idx = 0;
                foreach (DataRow row in empDT.Rows)
                {
                    empGrid.Rows.Add();
                    empGrid.Rows[idx].Cells[0].Value = false;
                    empGrid.Rows[idx].Cells[1].Value = FormatGroupID(row["GrpID"]);
                    this.markGridCell(idx, 1);
                    empGrid.Rows[idx].Cells[2].Value = base.obj2str(row["CallName"]);
                    this.markGridCell(idx, 2);
                    empGrid.Rows[idx].Cells[3].Value = base.obj2str(row["EmailWork"]);
                    this.markGridCell(idx, 3);
                    idx++;
                }
            }
        }

        private string GetGroupIDs()
        {
            string groupPeople = string.Empty;
            string tmp = string.Empty;
            int count = empGrid.Rows.Count;
            int idx;
            for (idx = 0; idx < count; idx++)
            {
                tmp = base.obj2str(empGrid.Rows[idx].Cells[0].Value);
                if (tmp.ToLower() == "true")
                {
                    if (groupPeople != string.Empty) groupPeople += ",";
                    groupPeople += "'" + base.obj2str(FormatGroupIDForQuery(empGrid.Rows[idx].Cells[1].Value)) + "'";
                }
            }
            return groupPeople;
        }

        private void markGridCell(int rows, int cells)
        {
            empGrid.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
            empGrid.Rows[rows].Cells[cells].Style.SelectionForeColor = Color.Wheat;
            empGrid.Rows[rows].Cells[cells].ReadOnly = true;
        }

        private string GetIDFromBox(ComboBox Lx)
        {
            string result = string.Empty;
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null)
            {
                if (Lx.SelectedItem.ToString() != TextAll)
                    result = Lx.SelectedItem.ToString();
            }
            return result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendDemo_Click(object sender, EventArgs e)
        {
            Mail _Mail = new Mail();
            if (txtUserName.Text.Trim() != string.Empty)
            {
                _Mail.UserName = txtUserName.Text.Trim();
                _Mail.Password = txtPassword.Text.Trim();
            }

            string doc;
            try
            {

                if (!File.Exists(htmlFile))
                {
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
                _Mail.Host = txtMailServer.Text;
                _Mail.MailOne = txtTestAddr.Text;
                _Mail.Port = Convert.ToInt16(txtMailPort.Text);
                _Mail.Send();

                MessageBox.Show("Sent.", "Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void SendMailOrExportPDF(bool isTester, bool isExportPDF, string folderPath, bool isAttachFile)
        {
            Mail _Mail;
            string doc;
            string personal;
            string groupID = string.Empty;
            string employeeName = string.Empty;
            string nickName = string.Empty;
            string payoutMethod = string.Empty;
            int count;
            int i;
            string workMail = string.Empty;
            string fulldate = base.YYMM2EnglishDate(thisMonthy);
            string fulldatetime = base.YYMMDD2EnglishDate(DateTime.Today);
            string bankList = string.Empty;
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
            DataTable CurrencyDT = tSQL.Report_CurrencyData_SelectAll(thisMonthy);
            string exchangeRate = string.Empty;
            foreach (DataRow row in CurrencyDT.Rows)
            {
                exchangeRate += string.Format(exchangeItem, base.obj2str(row["Pcurrency"]) + " To MYR", base.obj2str(row["showRate"]));
            }

            double _subAmount;
            double _BankTotal;
            string _CompanyBox = GetIDFromBox(CompanyBox);
            string _DeptBox = GetIDFromBox(DeptBox);
            if (_CompanyBox == TextAll) _CompanyBox = string.Empty;
            if (_DeptBox == TextAll) _DeptBox = string.Empty;
            DataTable data;
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
            labCount.Text = string.Empty;
            Dictionary<string, string> txtLog = new Dictionary<string, string>();
            textLog.Text = string.Empty;
            string month = this.thisMonthy.Substring(4, 2) + this.thisMonthy.Substring(0, 4); 

            try
            {
                doc = base.getFileTxt(htmlFile);

                string headerContent = txtContent.Text.Replace(Environment.NewLine, "<BR>");

                doc = doc.Replace("{{Body}}", headerContent);
                doc = doc.Replace("{{Message}}", "Payslip");

                data = tSQL.Report_getEmpList(thisMonthy, _CompanyBox, _DeptBox, this.GetGroupIDs());
                count = data.Rows.Count;
                SetProgressBar(count, 0, 0);
                for (i = 0; i < count; i++)
                {
                    groupID = base.obj2str(data.Rows[i]["GrpID"]);
                    employeeName = base.obj2str(data.Rows[i]["eName"]);
                    txtLog.Add(groupID, employeeName + " wait.");
                }

                for (i = 0; i < count; i++)
                {
                    groupID = FormatGroupID(data.Rows[i]["GrpID"]);
                    employeeName = base.obj2str(data.Rows[i]["eName"]);
                    nickName = base.obj2str(data.Rows[i]["CallName"]);
                    workMail = base.obj2str(data.Rows[i]["EmailWork"]);

                    personal = doc;
                    personal = personal.Replace("{{FullDate}}", fulldate);
                    personal = personal.Replace("{{FullName}}", base.obj2str(data.Rows[i]["eName"]));
                    personal = personal.Replace("{{Nick}}", nickName);
                    personal = personal.Replace("{{GroupID}}", groupID);

                    personal = personal.Replace("{{Email}}", workMail);
                    personal = personal.Replace("{{Dept}}", base.obj2str(data.Rows[i]["DepartmentID"]));
                    personal = personal.Replace("{{JobTitle}}", base.obj2str(data.Rows[i]["PositionName"]));
                    personal = personal.Replace("{{Doc}}", base.obj2str(data.Rows[i]["DateJoined"]));

                    BasicSalary = base.empKeyDecrypt(base.obj2str(data.Rows[i]["BasicSalary"]));
                    personal = personal.Replace("{{BasicSalary}}", base.obj2str(data.Rows[i]["Pcurrency"]) + " " + base.obj2thousand(BasicSalary));

                    personal = personal.Replace("{{ProCurry}}", base.obj2str(data.Rows[i]["Pcurrency"]));
                    ProSalary = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Prob_Salary"]));
                    personal = personal.Replace("{{ProSalary}}", base.obj2thousand(ProSalary));
                    Incre_Amount = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Incre_Amount"]));
                    personal = personal.Replace("{{IncreSalary}}", base.obj2thousand(Incre_Amount));
                    Add_Amount = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Add_Amount"]));
                    personal = personal.Replace("{{Additional}}", base.obj2thousand(Add_Amount));
                    personal = personal.Replace("{{BasicSalaryRemark}}", base.obj2str(data.Rows[i]["BasicSalaryRemark"]));
                    personal = personal.Replace("{{IncRemark}}", base.obj2str(data.Rows[i]["IncreRemark"]));
                    personal = personal.Replace("{{AddRemark}}", base.obj2str(data.Rows[i]["OtherRemark"]));
                    Gross_Total = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Gross_Total"]));
                    personal = personal.Replace("{{Gross}}", base.obj2thousand(Gross_Total));

                    personal = personal.Replace("{{UnpaidCurry}}", base.obj2str(data.Rows[i]["Unpaidcury"]));
                    Unpaid_Amount = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Unpaid_Amount"]));
                    personal = personal.Replace("{{Unpaid}}", base.obj2thousand(Unpaid_Amount));
                    personal = personal.Replace("{{AdvCurry}}", base.obj2str(data.Rows[i]["Advcury"]));
                    Adv_Amount = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Adv_Amount"]));
                    personal = personal.Replace("{{Advance}}", base.obj2thousand(Adv_Amount));
                    personal = personal.Replace("{{LoanCurry}}", base.obj2str(data.Rows[i]["Loancury"]));
                    Loan_Amount = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Loan_Amount"]));
                    personal = personal.Replace("{{Loan}}", base.obj2thousand(Loan_Amount));
                    Dedu_Total = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Dedu_Total"]));
                    personal = personal.Replace("{{Dedu_Total}}", base.obj2thousand(Dedu_Total));

                    Net_Salary = base.payKeyDecrypt(base.obj2str(data.Rows[i]["Net_Salary"]));
                    personal = personal.Replace("{{NetSalary}}", base.obj2thousand(Net_Salary));

                    bankDT = tSQL.KeyData_getBankInList(groupID, thisMonthy);
                    bankList = string.Empty;
                    _BankTotal = 0;

                    foreach (DataRow row in bankDT.Rows)
                    {
                        payoutMethod = base.obj2str(row["payoutRelation"]);
                        if (payoutMethod != string.Empty)
                        {
                            payoutMethod = payoutMethod.Split(splitchar, StringSplitOptions.None)[0];
                        }
                        Amount = base.payKeyDecrypt(base.obj2str(row["Amount"]));
                        _subAmount = calculate_Amount_byCurrency(ref CurrencyDT, "Pcurrency", "showRate", base.obj2str(data.Rows[i]["Pcurrency"]), base.obj2str(row["Cury"]), Amount);
                        _BankTotal += _subAmount;
                        bankList += string.Format(bankListItem, payoutMethod, base.obj2str(row["Cury"]), base.obj2thousand(Amount), base.double2thousand(_subAmount));
                    }
                    personal = personal.Replace("<!--{{BankList}}-->", bankList);
                    personal = personal.Replace("{{PaidInProCurry}}", base.double2thousand(_BankTotal));

                    personal = personal.Replace("<!--{{ExchangeRateList}}-->", exchangeRate);
                    personal = personal.Replace("{{FullDateTime}}", fulldatetime);

                    var fileName = string.Empty;
                    if (isExportPDF)
                    {
                        var pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(personal);
                        fileName = folderPath + "\\" + nickName + "_" + month + ".pdf";
                        File.WriteAllBytes(@fileName, pdfBytes);
                        txtLog[groupID] = employeeName + " exported.";
                    }
                    else
                    {
                        _Mail = new Mail();

                        if (isAttachFile)
                        {
                            var pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(personal);
                            fileName = folderPath + "\\" + nickName + "_" + month + ".pdf";
                            File.WriteAllBytes(@fileName, pdfBytes);
                            _Mail.AddAttachmentFile(@fileName);
                        }

                        if (txtUserName.Text.Trim() != string.Empty)
                        {
                            _Mail.UserName = txtUserName.Text.Trim();
                            _Mail.Password = txtPassword.Text.Trim();
                        }

                        string subject = txtSubject.Text.Trim();
                        subject = subject.Replace("{{FullDate}}", fulldate);
                        subject = subject.Replace("{{Nick}}", base.obj2str(data.Rows[i]["CallName"]));

                        _Mail.Subject = subject;
                        _Mail.Body = personal;
                        _Mail.From = txtSender.Text;
                        _Mail.Host = txtMailServer.Text;
                        
                        if (!isTester)
                        {
                            _Mail.MailOne = workMail;
                        }
                        else
                        {
                            _Mail.MailOne = txtTestAddr.Text.Trim();
                        }

                        _Mail.Port = Convert.ToInt16(txtMailPort.Text);
                        _Mail.Send();
                        txtLog[groupID] = employeeName + " sent.";
                    }

                    SetProgressBar(-1, -1, i + 1);
                }

                MessageBox.Show("Sent.", "Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n stop: GroupID: " + groupID + " name is " + employeeName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                StringBuilder cb = new StringBuilder();
                foreach (string im in txtLog.Keys)
                {
                    cb.AppendLine(im + " " + txtLog[im] + "\n");
                }

                textLog.Text = cb.ToString();

                // Clipboard.SetDataObject(cb.ToString(), true);
                // System.Diagnostics.Process.Start("NOTEPAD.exe");
                // SendKeys.Send("^v");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Send payslip to selected employees ?", "Send payslip", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                result = MessageBox.Show("Are you want to attach pay slip?", "Attach File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(folderBrowserDialog.SelectedPath);
                        this.SendMailOrExportPDF(false, false, folderBrowserDialog.SelectedPath, true);
                    }
                }
                else
                {
                    this.SendMailOrExportPDF(false, false, string.Empty, false);
                }
            }
        }

        private void SetProgressBar(int _max, int _min, int val)
        {
            if (_max >= 0) progressBar1.Maximum = _max;
            if (_min >= 0) progressBar1.Minimum = _min;
            progressBar1.Value = val;
            if (val <= 0)
                labCount.Text = string.Empty;
            else
                labCount.Text = val.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Save
            bool flag = tSQL.MailProfile_Update(txtMailServer.Text,
                                                txtMailPort.Text,
                                                txtSender.Text,
                                                txtSubject.Text,
                                                txtContent.Text,
                                                txtTestAddr.Text
                                                );

            if (flag)
            {
                MessageBox.Show("Saved.", "Save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(tSQL.errMessage, "Save", MessageBoxButtons.OK);
            }
        }

        private void btnSendDemoMail_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Send selected payslip to tester ?", "Send payslips to tester", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.SendMailOrExportPDF(true, false, string.Empty, false);
            }
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_DeptListBox(CompanyBox, DeptBox);
            load_DeptEmptoGrid();
        }

        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_DeptEmptoGrid();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog.SelectedPath);

                this.SendMailOrExportPDF(false, true, folderBrowserDialog.SelectedPath, false);
            }
        }
    }
}