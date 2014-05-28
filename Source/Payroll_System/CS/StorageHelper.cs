// -----------------------------------------------------------------------
// <copyright file="EmpHelper.cs" company="Nexcel Solutions">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Payroll_System
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using Community.CsharpSqlite.SQLiteClient;
    using System.IO;

    /// <summary>
    /// Resolve employee information reference in each month.
    /// </summary>
    public static class StorageHelper
    {
        private static SqliteConnection connection = null;
        private const string SalaryKey = "$@l@ry";
        private const string ProbationSalaryKey = "Pr@b@t1@n$@l@ry";
        private const string PayoutErrorKey = "P@y0u+3rr@r";
        private const string IncrementSalaryKey = "1ncr3m3nt$@l@ry";
        private const string AdditionalAmountKey = "Add1t1@n@m@unt";
        private const string ProbationTimeKey = "Pr@b@t1@nT1m3";
        private const string MonthlyWorkDaysKey = "M0n+1yw0rkD@y";
        private const string KeyinWorkDaysKey = "K4y1nw0rkD@y";
        private const string MonthlyUnpaidDaysKey = "M0n+1yUnp@1dD@y5";
        private const string MonthlyTotalDeduction = "M0n+h1yT0t@l@dd1t10n";
        private const string Separator = "@#@";

        static StorageHelper()
        {
            string db2Path = remoteDBAbsPath() + System.Configuration.ConfigurationManager.AppSettings["DB2"];
            string cs = string.Format("Version=3,uri=file:{0}", db2Path);
            connection = new SqliteConnection(cs);
            connection.Open();
        }

        static string remoteDBAbsPath()
        {
            string DBAbsolutePath = System.Configuration.ConfigurationManager.AppSettings["DBAbsolutePath"].ToString();
            if (DBAbsolutePath == string.Empty)
            {
                return Application.StartupPath;
            }
            else
            {
                return DBAbsolutePath;
            }
        }

        private static string StripSql(string value)
        {
            return (value + "").Replace("'", "''");
        }

        private static void Set(string key, string value)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT value FROM hash WHERE key='" + StripSql(key) + "'";
            object existingValue = cmd.ExecuteScalar();
            if (existingValue == null)
            {
                cmd.CommandText = string.Format("INSERT INTO hash VALUES ('{0}', '{1}')", StripSql(key), StripSql(value));
                cmd.ExecuteNonQuery();
            }
            else {
                cmd.CommandText = string.Format("UPDATE hash SET value = '{1}' WHERE key = '{0}'", StripSql(key), StripSql(value));
                cmd.ExecuteNonQuery();
            }
        }

        private static string Get(string key)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT value FROM hash WHERE key='{0}'", StripSql(key));
            object existingValue = cmd.ExecuteScalar();

            return existingValue == null ? string.Empty : existingValue.ToString();
        }

        private static string MoveMonth(string month, bool increase)
        {
            if (month == null || month == string.Empty || month.Length < 6)
            {
                return string.Empty;
            }
            else
            {
                string yearNo = month.Substring(0, 4);
                string monthNo = month.Substring(4, 2);

                int yearValue = DateTime.Now.Year;
                int monthValue = DateTime.Now.Month;

                if (!int.TryParse(yearNo, out yearValue) || !int.TryParse(monthNo, out monthValue))
                {
                    return string.Empty;
                }
                else
                {
                    if (yearValue < 2000 || yearValue > 9999 || monthValue < 0 || monthValue > 12)
                    {
                        return string.Empty;
                    }

                    if (increase)
                    {
                        IncreaseMonth(ref yearValue, ref monthValue);
                    }
                    else
                    {
                        DecreaseMonth(ref yearValue, ref monthValue);
                    }

                    yearNo = yearValue.ToString();
                    monthNo = monthValue.ToString();
                    if (monthNo.Length < 2)
                    {
                        monthNo = "0" + monthNo;
                    }

                    return yearNo + monthNo;
                }
            }
        }

        private static void DecreaseMonth(ref int yearValue, ref int monthValue)
        {

            if (monthValue == 1)
            {
                monthValue = 12;
                yearValue -= 1;
            }
            else
            {
                monthValue -= 1;
            }
        }

        private static void IncreaseMonth(ref int yearValue, ref int monthValue)
        {
            if (monthValue == 12)
            {
                monthValue = 1;
                yearValue += 1;
            }
            else
            {
                monthValue += 1;
            }
        }

        public static void Backup()
        { 
            // Default /Backup
            string db2Path = remoteDBAbsPath() + System.Configuration.ConfigurationManager.AppSettings["DB2"];
            string db2PathBackup = remoteDBAbsPath() + "\\Backup\\Payroll2.mdb";

            if (File.Exists(db2Path))
            {
                connection.Close();
                File.Copy(db2Path, db2PathBackup, true);
                connection.Open();
            }
        }

        public static void Recover()
        {
            // Default Recover
            string db2Path = remoteDBAbsPath() + System.Configuration.ConfigurationManager.AppSettings["DB2"];
            string db2PathBackup = remoteDBAbsPath() + "\\Backup\\Payroll2.mdb";

            if (File.Exists(db2PathBackup))
            {
                connection.Close();
                File.Copy(db2PathBackup, db2Path, true);
                connection.Open();
            }
        }

        public static void SetTotalDeduction(string emp, string month, int value)
        {
            string key = string.Join(Separator, new string[] { MonthlyTotalDeduction, int.Parse("0" + emp).ToString(), month });
            Set(key, value.ToString());
        }

        public static int GetTotalDeduction(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { MonthlyTotalDeduction, int.Parse("0" + emp).ToString(), month });
            string value = Get(key);
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            return int.Parse(value);
        }

        public static void SetUnpaidDays(string emp, string month, int value)
        {
            string key = string.Join(Separator, new string[] { MonthlyUnpaidDaysKey, int.Parse("0" + emp).ToString(), month });
            Set(key, value.ToString());
        }

        public static int GetUnpaidDays(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { MonthlyUnpaidDaysKey, int.Parse("0" + emp).ToString(), month });
            string value = Get(key);
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            return int.Parse(value);
        }

        public static void SetKeyinWorkDays(string emp, string month, int value)
        {
            string key = string.Join(Separator, new string[] { KeyinWorkDaysKey, int.Parse("0" + emp).ToString(), month });
            Set(key, value.ToString());
        }

        public static int GetKeyinWorkDays(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { KeyinWorkDaysKey, int.Parse("0" + emp).ToString(), month });
            string value = Get(key);
            if (string.IsNullOrEmpty(value))
            {
                return GetMonthlyWorkDays(month);
            }
            else
            {
                return int.Parse(value);
            }
        }

        public static void SetMonthlyWorkDays(int value, string month)
        {
            string key = string.Join(Separator, new string[] { MonthlyWorkDaysKey, month });
            Set(key, value.ToString());
        }

        public static int GetMonthlyWorkDays(string month)
        {
            string key = string.Join(Separator, new string[] { MonthlyWorkDaysKey, month });
            string value = Get(key);
            if (string.IsNullOrEmpty(value))
            {
                return 23;
            }
            else 
            {
                return int.Parse(value);
            }
        }

        public static string GetLastMonth(string month)
        {
            return MoveMonth(month, false);
        }

        public static string GetNextMonth(string month)
        {
            return MoveMonth(month, true);
        }

        /// <summary>
        /// Get employee basic salary in a month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string GetBasicSalary(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { SalaryKey, int.Parse("0" + emp).ToString(), month });

            /* Auto query data for last month
            if (string.IsNullOrEmpty(Get(key)))
            {
                key = string.Join(Separator, new string[] { SalaryKey, int.Parse("0" + emp).ToString(), GetLastMonth(month) });
            }
             * */

            return Get(key);
        }

        /// <summary>
        /// Set employee basic salary in a month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <param name="value"></param>
        public static void SetBasicSalary(string emp, string month, string value)
        {
            string key = string.Join(Separator, new string[] { SalaryKey, int.Parse("0" + emp).ToString(), month });
            Set(key, value);
        }

        /// <summary>
        /// Get employee increment salary in a month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string GetIncrementSalary(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { IncrementSalaryKey, int.Parse("0" + emp).ToString(), month });
            return Get(key);
        }

        /// <summary>
        /// Set payout error for an employee
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <param name="error"></param>
        public static void SetPayoutError(string emp, string month, bool error)
        {
            string key = string.Join(Separator, new string[] { PayoutErrorKey, int.Parse("0" + emp).ToString(), month });
            Set(key, error ? "1" : "0");
        }

        /// <summary>
        /// Get payout error of an employee
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static bool GetPayoutError(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { PayoutErrorKey, int.Parse("0" + emp).ToString(), month });
            return Get(key) == "1";
        }

        /// <summary>
        /// Set employee increment salary in a month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <param name="value"></param>
        public static void SetIncrementSalary(string emp, string month, string value)
        {
            string key = string.Join(Separator, new string[] { IncrementSalaryKey, int.Parse("0" + emp).ToString(), month });
            Set(key, value);
        }

        /// <summary>
        /// Get employee probation salary.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static string GetProbationSalary(string emp)
        {
            string key = string.Join(Separator, new string[] { ProbationSalaryKey, int.Parse("0" + emp).ToString() });
            return Get(key);
        }

        /// <summary>
        /// Get employee probation salary.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string GetProbationSalary(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { ProbationSalaryKey, int.Parse("0" + emp).ToString(), month });

            /* Auto query data for last month
            if (string.IsNullOrEmpty(Get(key)))
            {
                key = string.Join(Separator, new string[] { ProbationSalaryKey, int.Parse("0" + emp).ToString(), GetLastMonth(month) });
            }
             * */

            return Get(key);
        }

        /// <summary>
        /// Set employee probation salary.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="value"></param>
        public static void SetProbationSalary(string emp, string value)
        {
            string key = string.Join(Separator, new string[] { ProbationSalaryKey, int.Parse("0" + emp).ToString() });
            Set(key, value);
        }

        /// <summary>
        /// Set employee probation salary.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <param name="value"></param>
        public static void SetProbationSalary(string emp, string month, string value)
        {
            string key = string.Join(Separator, new string[] { ProbationSalaryKey, int.Parse("0" + emp).ToString(), month });
            Set(key, value);
        }

        /// <summary>
        /// Check employee is in probation time at specified month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static bool GetInProbationTime(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { ProbationTimeKey, int.Parse("0" + emp).ToString(), month });

            /* Auto query data for last month
            if (string.IsNullOrEmpty(Get(key)))
            {
                key = string.Join(Separator, new string[] { ProbationTimeKey, emp, GetLastMonth(month) });
            }
             * */

            return Get(key) == "1";
        }

        /// <summary>
        /// Check employee is in probation time at current.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static bool GetInProbationTime(string emp)
        {
            string key = string.Join(Separator, new string[] { ProbationTimeKey, int.Parse("0" + emp).ToString() });
            return Get(key) == "1";
        }

        /// <summary>
        /// Set employee is in probation time or not
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="probation"></param>
        /// <param name="month"></param>
        public static void SetInProbationTime(string emp, string month, bool probation)
        {
            string key = string.Join(Separator, new string[] { ProbationTimeKey, int.Parse("0" + emp).ToString(), month });
            Set(key, probation ? "1" : "0");
        }

        /// <summary>
        /// Set employee is in probation time or not at current.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="probation"></param>
        public static void SetInProbationTime(string emp, bool probation)
        {
            string key = string.Join(Separator, new string[] { ProbationTimeKey, int.Parse("0" + emp).ToString() });
            Set(key, probation ? "1" : "0");
        }

        /// <summary>
        /// Get additional amount of an employee in a month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string GetAdditionalAmount(string emp, string month)
        {
            string key = string.Join(Separator, new string[] { AdditionalAmountKey, int.Parse("0" + emp).ToString(), month });

            /* Auto query data for last month
            if (string.IsNullOrEmpty(Get(key)))
            {
                key = string.Join(Separator, new string[] { AdditionalAmountKey, int.Parse("0" + emp).ToString(), GetLastMonth(month) });
            }
             * */

            return Get(key);
        }

        /// <summary>
        /// Set additional amount of an employee in a month.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="month"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetAdditionalAmount(string emp, string month, string value)
        {
            string key = string.Join(Separator, new string[] { AdditionalAmountKey, int.Parse("0" + emp).ToString(), month });
            Set(key, value);
        }
    }
}
