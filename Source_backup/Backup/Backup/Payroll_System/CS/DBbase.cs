using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Payroll_System {
    class DBbase {        
        // Jacob
        public string _stratupPath;
        public string _backupPath;
        private string AccessPwd = "pQIBa9S3d8xovYsNLkHp/w==";
        public string errMessage;
        public string PayrollAbsFile;
        public string BackupAbsFile;
        public DBbase() {
        }
        public DBbase(string stratupPath) {
            _stratupPath = stratupPath;
        }
       
        public void joinDBString() {
            int len = _stratupPath.Length;
            string DBAbsolutePath = System.Configuration.ConfigurationManager.AppSettings["DBAbsolutePath"].ToString();
            connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();

            if (DBAbsolutePath != "") {
                if (_stratupPath.Substring(len - 1) == "\\") {
                    _stratupPath = _stratupPath.Substring(0, len - 1);
                }
                connectionString = connectionString.Replace("\\DB\\Payroll.mdb", _stratupPath + "\\Payroll.mdb");
                PayrollAbsFile = _stratupPath + "\\Payroll.mdb";
            } else {
                connectionString = connectionString.Replace("\\DB\\Payroll.mdb", _stratupPath + "\\DB\\Payroll.mdb");
                PayrollAbsFile = _stratupPath + "\\DB\\Payroll.mdb";
            }              
            connectionString += "Jet OLEDB:Database Password=" + sysDecrypt(AccessPwd) + ";";

            // C:\Users\Ericyeo\Documents\HR\Payroll\payroll system\Payroll DB
        }

        public void joinBackupString() {            
            string _today = DateTime.Today.ToString("yyyyMMdd");
            int len = _stratupPath.Length;
            backupConString = System.Configuration.ConfigurationManager.AppSettings["BackupDB"].ToString();

            if (len > 0) {
                if (_stratupPath.Substring(len - 1) == "\\") {
                    _stratupPath = _stratupPath.Substring(0, len - 1);
                }  
            }   
            BackupAbsFile = _stratupPath + "\\Backup\\" + _today + ".mdb";
            _backupPath = _stratupPath + "\\Backup\\";
            backupConString = backupConString.Replace("\\Backup", BackupAbsFile);
        }

        public void setDBPassWord() {
            Connection = new OleDbConnection(backupConString);
            string AlertPwd = "ALTER DATABASE PASSWORD " + sysDecrypt(AccessPwd) + " null ";
            this.RunSQL(AlertPwd);
        }

        private void appconfigWrite() {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //KeyValueConfigurationCollection settings = config.AppSettings.Settings;
            //settings["DBAbsolutePath"].Value = "sssss";

            //config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");
        }

        public void initDBbase() {
            this.joinDBString();
            Connection = new OleDbConnection(connectionString);
        }

        private string sysDecrypt(string enTxt) {
            string reval = IBCCrypt.IBCCrypt.Decrypt(enTxt, "12345678");
            return reval;
        }

        // Jacob
        protected void closeConn(){
            if (Connection.State == ConnectionState.Open) {
                Connection.Close();
            }
        }

        #region Declare
        protected OleDbConnection Connection;
        private string connectionString;
        private string backupConString;
        #endregion

        

        #region Properties
        /// <summary>
        /// Protected property that exposes the connection string
        /// to inheriting classes. Read-Only.
        /// </summary>
        public string ConnectionString {
            get {
                return connectionString;
            }
            set { 
                connectionString = value;
            }
        }

        public string BackupConnectionString {
            get {
                return backupConString;
            }
            set {
                backupConString = value;
            }
        }



        /// <summary>
        /// Private routine allowed only by this base class, it automates the task
        /// of building a OleDbCommand object designed to obtain a return value from
        /// the stored procedure.
        /// </summary>
        /// <param name="storedProcName">Name of the stored procedure in the DB, eg. sp_DoTask</param>
        /// <param name="parameters">Array of IDataParameter objects containing parameters to the stored proc</param>
        /// <returns>Newly instantiated OleDbCommand instance</returns>
        //private  OleDbCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters) {
        //    OleDbCommand command = BuildQueryCommand(storedProcName, parameters);
             
        //    command.Parameters.Add(new OleDbParameter("ReturnValue",
        //         sqlType.Int,
        //        4, /* Size */
        //        ParameterDirection.ReturnValue,
        //        false, /* is nullable */
        //        0, /* byte precision */
        //        0, /* byte scale */
        //        string.Empty,
        //        DataRowVersion.Default,
        //        null));

        //    return command;
        //}


        /// <summary>
        /// Builds a OleDbCommand designed to return a OleDbDataReader, and not
        /// an actual integer value.
        /// </summary>
        /// <param name="storedProcName">Name of the stored procedure</param>
        /// <param name="parameters">Array of IDataParameter objects</param>
        /// <returns></returns>
        private OleDbCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters) {
            OleDbCommand command = new OleDbCommand(storedProcName, Connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            foreach (OleDbParameter parameter in parameters) {
                command.Parameters.Add(parameter);
            }

            return command;

        }

        /// <summary>
        /// Runs a stored procedure, can only be called by those classes deriving
        /// from this base. It returns an integer indicating the return value of the
        /// stored procedure, and also returns the value of the RowsAffected aspect
        /// of the stored procedure that is returned by the ExecuteNonQuery method.
        /// </summary>
        /// <param name="storedProcName">Name of the stored procedure</param>
        /// <param name="parameters">Array of IDataParameter objects</param>
        /// <param name="rowsAffected">Number of rows affected by the stored procedure.</param>
        /// <returns>An integer indicating return value of the stored procedure</returns>
        //protected int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected) {
        //    int result = 0;
        //    rowsAffected = 0;
        //    try {
        //        Connection.Open();
        //        OleDbCommand command = BuildIntCommand(storedProcName, parameters);
        //        rowsAffected = command.ExecuteNonQuery();
        //        result = (int)command.Parameters["ReturnValue"].Value;
        //        Connection.Close();
        //    } catch (Exception ex) {
        //        //Utility ut = new Utility();
        //        string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
        //        //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
        //        //LIB_Utility.DebugLog(sLog);
        //        Connection.Close();
        //    }
        //    return result;
        //}

        /// <summary>
        /// Will run a stored procedure, can only be called by those classes deriving
        /// from this base. It returns a OleDbDataReader containing the result of the stored
        /// procedure.
        /// </summary>
        /// <param name="storedProcName">Name of the stored procedure</param>
        /// <param name="parameters">Array of parameters to be passed to the procedure</param>
        /// <returns>A newly instantiated OleDbDataReader object</returns>
        protected OleDbDataReader RunProcedure(string storedProcName, IDataParameter[] parameters) {
            OleDbDataReader returnReader = null;
            try {
                Connection.Open();
                OleDbCommand command = BuildQueryCommand(storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;

                returnReader = command.ExecuteReader();
                //Connection.Close();
            } catch (Exception ex) {
                //Utility ut = new Utility();
                string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
                //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
                //LIB_Utility.DebugLog(sLog);
                Connection.Close();
            }
            return returnReader;
        }

        /// <summary>
        /// Creates a DataSet by running the stored procedure and placing the results
        /// of the query/proc into the given tablename.
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName) {
            DataSet dataSet = new DataSet();
            try {
                Connection.Open();                 
                OleDbDataAdapter sqlDA = new OleDbDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                Connection.Close();
            } catch (Exception ex) {
                //Utility ut = new Utility();
                string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
                //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
                //LIB_Utility.DebugLog(sLog);
                Connection.Close();
            }
            return dataSet;
        }

        //protected OleDbParameterCollection  RunProcedure_SPC(string storedProcName, IDataParameter[] parameters) {
        //    OleDbParameterCollection result = null;
        //    try {
        //        Connection.Open();
        //        OleDbCommand command = BuildIntCommand(storedProcName, parameters);
        //        command.ExecuteNonQuery();
        //        result = command.Parameters;
        //        Connection.Close();
        //    } catch (Exception ex) {
        //        //Utility ut = new Utility();
        //        string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
        //        //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
        //        //LIB_Utility.DebugLog(sLog);
        //        Connection.Close();
        //    }
        //    return result;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //protected string RunProcedure_S(string storedProcName, IDataParameter[] parameters) {
        //    string result = "";
        //    try {
        //        Connection.Open();
        //        OleDbCommand command = BuildIntCommand(storedProcName, parameters);
        //        result = command.ExecuteScalar().ToString();
        //        Connection.Close();
        //    } catch (Exception ex) {
        //        //Utility ut = new Utility();
        //        string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
        //        //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
        //        //LIB_Utility.DebugLog(sLog);
        //        Connection.Close();
        //    }
        //    return result;
        //}

        ///// <summary>
        /// Takes an -existing- dataset and fills the given table name with the results
        /// of the stored procedure.
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        //protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName) {
        //    try {
        //        Connection.Open();
        //        OleDbDataAdapter sqlDA = new OleDbDataAdapter();
        //        sqlDA.SelectCommand = BuildIntCommand(storedProcName, parameters);
        //        sqlDA.Fill(dataSet, tableName);
        //        Connection.Close();
        //    } catch (Exception ex) {
        //        //Utility ut = new Utility();
        //        string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
        //        //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
        //        //LIB_Utility.DebugLog(sLog);
        //        Connection.Close();
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected bool RunSQL(string _sql) {
            bool result = true;
            try {
                Connection.Open();
                OleDbCommand command = new OleDbCommand(_sql, Connection);
                command.ExecuteNonQuery();
                Connection.Close();
            } catch (Exception ex) {
                result = false;

                //Utility ut = new Utility();
                string sLog = "===================================" + DateTime.Now.ToString() + "============================\r\n" + ex.ToString() + "\r\n";
                //ut.Write2File("Logs\\" + DateTime.Now.ToShortDateString() + "DBErrorLog.txt", sLog);
                //LIB_Utility.DebugLog(sLog);
                Connection.Close();
            }
            return result;
        }
        #endregion


        /// <summary>
        /// 送出 sql 指令
        /// </summary>    
        protected bool sendSql_Command(string _SQLtxt) {
            bool flag = true;            
            OleDbCommand cmd = new OleDbCommand();
            try {
                if (Connection.State != ConnectionState.Open) {
                    Connection.Open();
                }
                cmd.CommandTimeout = 300;
                cmd.Connection = Connection;
                cmd.CommandText = _SQLtxt;
                cmd.ExecuteNonQuery();
            } catch(Exception ex)  {  
                flag = false;
                errMessage = ex.Message;
            }
            return flag;
        }

        /// <summary>
        /// 取得 DataTable
        /// </summary>
        /// <param name="defDT">out DataTable</param>
        /// <returns>a DataTable</returns>
        protected bool getSql_DataTable(string _SQLtxt, out DataTable defDT) {
            bool flag = true;
            defDT = new DataTable();
            try {
                OleDbDataAdapter objDadp = new OleDbDataAdapter(_SQLtxt, Connection);
                objDadp.SelectCommand.CommandTimeout = 300;
                objDadp.Fill(defDT);
            } catch (Exception ex) {
                flag = false;
                errMessage = ex.Message;
            }
            return flag;
        }

    }
}
