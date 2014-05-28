using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Payroll_System {
    public partial class Report_Banking : First {
        TSQL tSQL;
        string thisMonthyStr;
        string Str_ALL = "===== All =====";

        public Report_Banking() {
            InitializeComponent();
        }

        private void Report_Banking_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.remoteDBAbsPath());

            thisMonthyStr = tSQL.LockData_openMonth();
          
            load_MethodDDL();
            load_LocationDDL();
            load_CurrencyListBox();
        }
  
        private string get_IDformBox(ComboBox Lx) {
            string reval = "";
            if (Lx.Items.Count > 0 && Lx.SelectedItem != null) {
                if (Lx.SelectedItem.ToString() != Str_ALL)
                    reval = Lx.SelectedItem.ToString();
            }
            return reval;
        }
        private void load_CurrencyListBox() {
            DataTable tb;
            CuyBox.Items.Clear();
            
            string mid = "";
            string lid = "";
            string tmp;
            int pos;

            if (MidBox.SelectedItem != null) {
                tmp = MidBox.SelectedItem.ToString();
                pos = tmp.IndexOf(")");
                if (pos != -1) {
                    mid = tmp.Substring(0, pos);
                }
            }

            if (LidBox.SelectedItem != null) {
                tmp = LidBox.SelectedItem.ToString();
                if (tmp != Str_ALL) {
                    pos = tmp.IndexOf(")");
                    if (pos != -1) {
                        lid = tmp.Substring(0, pos);
                    }
                }
            }
          
            if (mid != "" && lid != "")
                tb = tSQL.Report_CurrencyData_SelectAll(mid, lid);
            else
                tb = tSQL.Report_CurrencyData_SelectAll(thisMonthyStr);

            string formatStr;
            CuyBox.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}", row["Pcurrency"].ToString());
                CuyBox.Items.Add(formatStr);
            }
            if (CuyBox.Items.Count > 0)
                CuyBox.SelectedIndex = 0;
            else
                CuyBox.Text = "";
        }
        private void load_MethodDDL() {
            DataTable tb;
            MidBox.Items.Clear();

            tb = tSQL.PayMethodData_SelectAll();
            string formatStr;
            MidBox.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {
                formatStr = string.Format("{0}) {1}", row["methodID"].ToString(), row["methodStr"].ToString());
                MidBox.Items.Add(formatStr);
            }
            if (MidBox.Items.Count > 0)
                MidBox.SelectedIndex = 0;
            else
                MidBox.Text = "";
        }
        private void load_LocationDDL() {
            DataTable tb;
            LidBox.Items.Clear();

            string mid = "";
            string tmp;
            int pos;
            if (MidBox.SelectedItem != null){
                tmp = MidBox.SelectedItem.ToString();
                if (tmp != Str_ALL) {
                    pos = tmp.IndexOf(")");
                    if (pos != -1) {
                        mid = tmp.Substring(0, pos);
                    }
                }
            }

            if (mid == "")
                tb = tSQL.PayLocationData_SelectAll();
            else
                tb = tSQL.PayLocationData_SelectAll(mid);

            string formatStr;
            LidBox.Items.Add(Str_ALL);
            foreach (DataRow row in tb.Rows) {                
                formatStr = string.Format("{0}) {1}", row["locationID"].ToString(), row["locationStr"].ToString());
                LidBox.Items.Add(formatStr);
            }
            if (LidBox.Items.Count > 0)
                LidBox.SelectedIndex = 0;
            else
                LidBox.Text = "";
        }

        private void MidBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_LocationDDL();
        }

        private void LidBox_SelectedIndexChanged(object sender, EventArgs e) {
            load_CurrencyListBox();
        }

        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            string mid = "";
            string lid = "";
            string cury = "";
            int pos;
            int i;
            int row;
            string tmp;

            #region ======== filter ==========            
            if (MidBox.SelectedItem != null) {
                tmp = MidBox.SelectedItem.ToString();
                if (tmp != Str_ALL) {
                    pos = tmp.IndexOf(")");
                    if (pos != -1) {
                        mid = tmp.Substring(0, pos);
                    }
                }
            }
            if (LidBox.SelectedItem != null) {
                tmp = LidBox.SelectedItem.ToString();
                if (tmp != Str_ALL) {
                    pos = tmp.IndexOf(")");
                    if (pos != -1) {
                        lid = tmp.Substring(0, pos);
                    }
                }
            }
            if (CuyBox.SelectedItem != null) {
                tmp = CuyBox.SelectedItem.ToString();
                if (tmp != Str_ALL) {
                    cury = tmp;
                }
            }
            #endregion ======== filter ==========

            DataTable dt = tSQL.Report_getBankingList(thisMonthyStr, mid, lid, cury);
            Hashtable CuryRate = new Hashtable();
            int RowCount = dt.Rows.Count;
            string upMLocation = "";
            string nowLcoation = "";
            string upcury = "";
            double sAmount = 0;
            double tmpAmount = 0;
            string amount;
            cury = "";

            saveFileDialog1.FileName = string.Format("{0}_BankingDetails.xls", thisMonthyStr);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                Excel_Banking EEX = new Excel_Banking();

                EEX.Rpt_ExcelApp = new Excel.ApplicationClass();                
                EEX.Rpt_ReportExportFileName = saveFileDialog1.FileName;
                EEX.TemplateFileSource = base.remoteDBAbsPath() + "\\ExcelTemplate\\BankingTemplate.xls";
                if (EEX.OpenExcelAndCopy_FormTemplate()) {
                    EEX.ShowDoc();
                    EEX.addTitle("List of Salary Payment & Banking Details - " + thisMonthyStr);
                    row = 4;
                    for (i = 0; i < RowCount; i++) {
                        cury = base.obj2str(dt.Rows[i]["Cury"]);
                        nowLcoation = base.obj2str(dt.Rows[i]["methodStr"]) + " -- " + base.obj2str(dt.Rows[i]["locationStr"]) + " (" + base.obj2str(dt.Rows[i]["Cury"]) + ")";                       
                        
                        if (upMLocation != nowLcoation || (i == 0) ) {
                            //foot
                            if (i > 0) {
                                EEX.addSubTotal(row, string.Format("Total ({0})", upcury), base.double2thousand(sAmount));
                                if (CuryRate.ContainsKey(upcury)) {
                                    tmp = base.obj2str(CuryRate[upcury]);
                                    tmpAmount = base.txt2double(tmp) + sAmount;
                                    CuryRate[upcury] = tmpAmount.ToString();
                                }
                                row++;
                            }
                            //head
                            EEX.addSubTitle(row, nowLcoation);                            
                            upMLocation = nowLcoation;
                            sAmount = 0;
                            row++;
                        }
                        //list
                        amount = base.payKeyDecrypt(base.obj2str(dt.Rows[i]["Amount"]));

                        EEX.addDetail(row, base.obj2str(dt.Rows[i]["CallName"]), base.obj2str(dt.Rows[i]["AcHolder"]),
                                           base.obj2str(dt.Rows[i]["Bank"]), base.obj2str(dt.Rows[i]["AcNumber"]), base.obj2thousand(amount));
                        sAmount += base.txt2double(amount);

                        upcury = cury;

                        if (!CuryRate.ContainsKey(cury)) {
                            CuryRate.Add(cury, "0");
                        }

                        row++;
                    }
                    //foot
                    if (RowCount > 0) {
                        EEX.addSubTotal(row, string.Format("Total ({0})", upcury), base.double2thousand(sAmount));
                        row++;
                    }

                    //show Rate      
                    EEX.addGrand(row, "Grand Total");                   
                    foreach (DictionaryEntry objDE in CuryRate) {
                        EEX.addGrandTotal(row, base.obj2str(objDE.Key), base.obj2thousand(objDE.Value));
                        row++;
                    }

                    EEX.DeltmpSheetAndSaveAndClose();                                                           
                    MessageBox.Show("Completed.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.None);

                    DosCommand.Open(saveFileDialog1.FileName);
                } else {
                    EEX.close();
                    MessageBox.Show(EEX.messageString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                
                
            }



        }

    

    }
}