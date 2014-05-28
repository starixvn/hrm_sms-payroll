using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using IBCCrypt;
using System.IO;
using System.Configuration;

namespace Payroll_System {
    public partial class First : Form {
        public static string ___queryHisticalPaymentGrpID;
        public static bool ___LoginPass = false;
        public static string ___LoginUser = "";
        public static string ___EmpPwdKey = "";
        public static string ___MonthlyPwdKey = "";

        protected Form fObj;

        public First() {
            InitializeComponent();
        }

        protected bool findChildForm(string FormName) {
            //bool flag = false;
            //foreach (Form child in this.MdiChildren) {
            //    if (child.Name == FormName) {
            //        fObj = child;                   
            //        flag = true;
            //        break;
            //    }
            //}
            //return flag;

            //close all child
            foreach (Form child in this.MdiChildren) {
                child.Close();
            }
            return false;
        }

        protected string remoteDBAbsPath() {
            string DBAbsolutePath = System.Configuration.ConfigurationManager.AppSettings["DBAbsolutePath"].ToString();
            if (DBAbsolutePath == "") {
                return Application.StartupPath;
            } else {
                return DBAbsolutePath;
            }
        }

        protected string SaveKeyEncrypt(string txt, bool showErrMsg) {
            string reval = "";
            if (txt.Trim().Length != 8) {
                if(showErrMsg)
                    MessageBox.Show("2nd-Lock encrypt need 8 characters.", "2nd Lock Encrypt", MessageBoxButtons.OK);
            } else {
                reval = IBCCrypt.IBCCrypt.Encrypt(txt + txt, txt);
            }
            return reval;
        }

        protected string SaveKeyDecrypt(string txt, bool showErrMsg) {
            string reval = "";
            if (txt.Trim().Length != 8) {
                if (showErrMsg)
                    MessageBox.Show("2nd-Lock decrypt need 8 characters.", "2nd Lock Decrypt", MessageBoxButtons.OK);
            } else {
                reval = IBCCrypt.IBCCrypt.Decrypt(txt + txt, txt);
            }
            return reval;
        }

        protected string empKeyEncryt(string txt) {
            string reval = IBCCrypt.IBCCrypt.Encrypt(txt, ___EmpPwdKey);
            return reval;
        }

        protected string empKeyDecrypt(string enTxt) {
            string reval = IBCCrypt.IBCCrypt.Decrypt(enTxt, ___EmpPwdKey);
            return reval;
        }

        protected string emp_pay_KeyEncryt(string txt, string hidekey) {
            string reval = IBCCrypt.IBCCrypt.Encrypt(txt, hidekey);
            return reval;
        }

        protected string emp_pay_KeyDecrypt(string enTxt, string hidekey) {
            string reval = IBCCrypt.IBCCrypt.Decrypt(enTxt, hidekey);
            return reval;
        }

        protected string payKeyEncryt(string txt) {
            string reval = IBCCrypt.IBCCrypt.Encrypt(txt, ___MonthlyPwdKey);
            return reval;
        }

        protected string payKeyDecrypt(string enTxt) {
            string reval = IBCCrypt.IBCCrypt.Decrypt(enTxt, ___MonthlyPwdKey);
            return reval;
        }

        protected string sysEncryt(string txt) {
            string reval = IBCCrypt.IBCCrypt.Encrypt(txt, "12345678");
            return reval;
        }

        protected string sysDecrypt(string enTxt) {
            string reval = IBCCrypt.IBCCrypt.Decrypt(enTxt, "12345678");
            return reval;
        }

        private void First_Load(object sender, EventArgs e) {
            
        }

        protected string Cash_cryt2txt(string cry) {
            string Str;
            if (cry == null)
                Str = "0";
            else if (cry.Trim() == "")
                Str = "0";
            else
                Str = cry;

            return Str;
        }

        protected string obj2str(object obj) {
            string reval = "";
            if (obj != null) {
                reval = obj.ToString().Trim();
            }
            return reval;
        }

        protected double obj2double(object obj) {
            double val = 0;
            string reval = "";
            if (obj != null) {
                reval = obj.ToString().Trim();
                val = this.txt2double(reval);
            }
            return val;
        }

        protected double txt2double(string cry) {
            if (IsNumeric(cry)) {
                return Convert.ToDouble(cry);
            } else {
                return 0;
            }
        }

        protected string txt2Zero2Space(string Zero) {
            if (Zero == "0") Zero = "";
            return Zero;
        }

        protected string obj2thousand(object obj) {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            string reval = "";
            double _val = 0;
            if (obj != null) {
                reval = obj.ToString().Trim();
                _val = txt2double(reval);
                reval = _val.ToString("N0", nfi);
            }
            return reval;
        }

        protected string double2thousand(double dou) {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            string reval = dou.ToString("N0", nfi);      
            return reval;
        }

        protected bool IsNumeric(string ToBeChecked) {
            double dbl = 0;
            return double.TryParse(ToBeChecked, System.Globalization.NumberStyles.Any, null, out dbl);
        }

        protected string YYMM2EnglishDate(string YYYYMM){
            string _yy = YYYYMM.Substring(0,4);
            string _mm = YYYYMM.Substring(4,2);
            string _Mm = "";
            switch(_mm){
                case "01" : _Mm = "January"; break;
                case "02" : _Mm = "February"; break;
                case "03" : _Mm = "March"; break;
                case "04" : _Mm = "April"; break;
                case "05" : _Mm = "May"; break;
                case "06" : _Mm = "June"; break;
                case "07" : _Mm = "July"; break;
                case "08" : _Mm = "August"; break;
                case "09" : _Mm = "September"; break;
                case "10" : _Mm = "October"; break;
                case "11" : _Mm = "November"; break;
                case "12" : _Mm = "December"; break;
            }
            return string.Format("{0} {1}", _Mm, _yy);
        }

        protected string YYMMDD2EnglishDate(DateTime days) {
            string _yy = days.Year.ToString("0000");
            string _mm = days.Month.ToString("00");
            string _dd = days.Day.ToString("00");
            string _Mm = "";
            switch (_mm) {
                case "01": _Mm = "January"; break;
                case "02": _Mm = "February"; break;
                case "03": _Mm = "March"; break;
                case "04": _Mm = "April"; break;
                case "05": _Mm = "May"; break;
                case "06": _Mm = "June"; break;
                case "07": _Mm = "July"; break;
                case "08": _Mm = "August"; break;
                case "09": _Mm = "September"; break;
                case "10": _Mm = "October"; break;
                case "11": _Mm = "November"; break;
                case "12": _Mm = "December"; break;
            }
            return string.Format("{0}th {1} {2}", _dd, _Mm, _yy);
        }

        protected string getFileTxt(string absPathFile) { 
            //String theLine;                           
            StreamReader oSR = new StreamReader(absPathFile);
            return oSR.ReadToEnd();
        }


     
        protected double calculate_Amount_byCurrency(ref DataTable CurrencyDT, string db_currencyName, string db_RateName, string BaseCuryName, string CuryName, string baseAmount) {
            double _amount = 0;
            double _rate = 0;
            string _curyName;
            double _newrate = 0;
            double _base = 0;

            if (BaseCuryName == "MYR") {
                _base = 1;
            } else { 
                foreach (DataRow rs in CurrencyDT.Rows) {
                    _curyName = obj2str(rs[db_currencyName]);
                    if (_curyName == BaseCuryName) {
                        _base = txt2double(obj2str(rs[db_RateName]));           
                        break;               
                    }
                }
            }
            if (CuryName == "MYR") {
                _rate = 1;
            } else {
                foreach (DataRow rs in CurrencyDT.Rows) {
                    _curyName = obj2str(rs[db_currencyName]);
                    if (_curyName == CuryName) {
                        _rate = txt2double(obj2str(rs[db_RateName]));
                        break;
                    }
                }
            }

            if (_base != 0) {
                _newrate = (1 / _base * _rate);
                _amount = txt2double(baseAmount) * _newrate;
                _amount = Math.Round(_amount, 0, MidpointRounding.AwayFromZero);
            }            
            return _amount;
        }

        protected string calculate_Amount_byDiffCurrency(string CurrencyRate, string BaseCuryRate, string baseAmount) {
            double _amount = 0;
            double _rate = 0;
            double _newrate = 0;
            double _base = 0;

            _base = this.txt2double(BaseCuryRate);
            _rate = this.txt2double(CurrencyRate);
            
            if (_base != 0) {
                _newrate = (1 / _base * _rate);
                _amount = txt2double(baseAmount) * _newrate;
                _amount = Math.Round(_amount, 0, MidpointRounding.AwayFromZero);
            }
            return _amount.ToString();
        }

       
    }
}