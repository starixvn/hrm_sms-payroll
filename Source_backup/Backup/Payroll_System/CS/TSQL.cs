using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Payroll_System {
    class TSQL : DBbase {      
        public TSQL(string stratupPath) {
            DataTable tb = new DataTable();
            base._stratupPath = stratupPath;
            base.initDBbase();
        }


        public void closeConnection() {
            base.closeConn();
        }

        private string ReplaceChar(string str){
            str += "";
            return str.Replace("'", "`").Replace("\"", "`").Trim();
        }

        #region =======  Check Login ========
        public bool LoginCheck(string accountID, string password) {
            bool flag = false;
            accountID = ReplaceChar(accountID);
            password = ReplaceChar(password);
            DataTable tb;
            string sql = string.Format("Select accountID From Payroll_Account where accountID='{0}' and passwords='{1}'", accountID, password);
            flag = base.getSql_DataTable(sql, out tb);
            if (flag) {
                flag = false;
                if (tb.Rows.Count > 0) {
                    flag = true;
                }
                base.errMessage = "Login Failed! this account not exist.";
            } else { 
                //³s½u¿ù»~
                //base.errMessage = "«O¯d";
            }
            return flag;
        }
        #endregion =======  Check Login ========

        #region =======  Company ========
        public DataTable CompanyData_SelectAll() {
            DataTable tb;
            base.getSql_DataTable("Select CompanyID, CompDesc From Payroll_Company", out tb);
            return tb;
        }
        public bool CompanyData_Insert(string CompanyID, string CompDesc) {
            CompanyID = ReplaceChar(CompanyID);
            CompDesc = ReplaceChar(CompDesc);
            string sql = String.Format("INSERT INTO Payroll_Company (CompanyID, CompDesc) " +
                                        "VALUES ('{0}', '{1}') "
                                        , CompanyID, CompDesc);
            return base.sendSql_Command(sql);            
        }
        public bool CompanyData_Update(string CompanyID, string CompDesc, string whereCompanyID) {
            bool flag;
            CompanyID = ReplaceChar(CompanyID);
            CompDesc = ReplaceChar(CompDesc);
            string sql = String.Format("Update Payroll_Company Set " +
                                        "CompanyID = '{0}', CompDesc='{1}' Where CompanyID='{2}'"
                                         , CompanyID, CompDesc, whereCompanyID);
            flag  = base.sendSql_Command(sql);

            sql = String.Format("Update Payroll_Department Set " +
                                        "CompanyID = '{0}' Where " +
                                        "CompanyID = '{1}'"
                                         , CompanyID, whereCompanyID);
            flag = base.sendSql_Command(sql) && flag;
            return flag;
        }
        public bool CompanyData_Delete(string CompanyID) {
            bool flag;
            string sql = String.Format("Delete From Payroll_Company Where " +
                                        "CompanyID = '{0}'"
                                         , CompanyID);
            flag = base.sendSql_Command(sql);

            sql = String.Format("Delete From Payroll_Department Where " +
                                        "CompanyID = '{0}' "
                                        , CompanyID);
            flag = base.sendSql_Command(sql) && flag;

            return flag;
        }
        #endregion ====  Company ========

        #region =======  Login Account ========
        public DataTable AccountData_SelectAll() {
            DataTable tb;
            base.getSql_DataTable("Select accountID, fullname, passwords From Payroll_Account order by accountID", out tb);
            return tb;
        }
        public bool AccountData_Insert(string accountID, string fullname, string password) {
            accountID = ReplaceChar(accountID);
            fullname = ReplaceChar(fullname);
            string sql = String.Format("INSERT INTO Payroll_Account (accountID, fullname, passwords) " +
                                        "VALUES ('{0}', '{1}', '{2}') "
                                         , accountID, fullname, password);
            return base.sendSql_Command(sql);    
        }
        public bool AccountData_Update(string accountID, string fullname, string password) {
            string sql = String.Format("Update Payroll_Account set fullname='{1}' , passwords='{2}' " +
                                        "where accountID='{0}' "
                                         , accountID, fullname, password);
            return base.sendSql_Command(sql);    
        }
        public bool AccountData_Delete(string accountID) {
            bool flag;
            string sql = String.Format("Delete From Payroll_Account Where " +
                                        "accountID = '{0}'"
                                         , accountID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        #endregion =======  Login Account ========
        
        #region =======  Pay Method ========
        public DataTable PayMethodData_SelectAll() {
            DataTable tb;
            base.getSql_DataTable("Select methodID, methodStr From Payroll_method order by methodID", out tb);
            return tb;
        }
        public bool PayMethodData_Insert(string methodStr) {
            methodStr = ReplaceChar(methodStr);
            string sql = String.Format("INSERT INTO Payroll_method (methodStr) " +
                                        "VALUES ('{0}') "
                                        , methodStr);
            return base.sendSql_Command(sql);
        }
        public bool PayMethodData_Update(string methodStr, int methodID) {
            bool flag;
            methodStr = ReplaceChar(methodStr);
            string sql = String.Format("Update Payroll_method Set " +
                                        "methodStr = '{0}' Where methodID={1}"
                                         , methodStr, methodID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool PayMethodData_Delete(int methodID) {
            bool flag;
            string sql = String.Format("Delete From Payroll_method Where " +
                                        "methodID = {0}"
                                         , methodID);
            flag = base.sendSql_Command(sql);

            sql = String.Format("Delete From Payroll_PaymentRelationship Where " +
                                        "methodID = {0} "
                                        , methodID);
            flag = base.sendSql_Command(sql) && flag;

            return flag;
        }
        #endregion ====  Pay Method ========

        #region =======  Pay Location ========
        public DataTable PayLocationData_SelectAll() {
            DataTable tb;
            base.getSql_DataTable("Select locationID, locationStr From Payroll_location order by locationID", out tb);
            return tb;
        }
        public DataTable PayLocationData_SelectAll(string mid) {
            DataTable tb;
            string sql = string.Format("Select locationID, locationStr From Payroll_location Where locationID in (Select locationID From Payroll_PaymentRelationship Where methodID = {0}) " +
                                       "order by locationID", mid);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool PayLocationData_Insert(string locationStr) {
            locationStr = ReplaceChar(locationStr);
            string sql = String.Format("INSERT INTO Payroll_location (locationStr) " +
                                        "VALUES ('{0}') "
                                        , locationStr);
            return base.sendSql_Command(sql);
        }
        public bool PayLocationData_Update(string locationStr, int locationID) {
            bool flag;
            locationStr = ReplaceChar(locationStr);
            string sql = String.Format("Update Payroll_location Set " +
                                        "locationStr = '{0}' Where locationID={1}"
                                         , locationStr, locationID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool PayLocationData_Delete(int locationID) {
            bool flag;
            string sql = String.Format("Delete From Payroll_location Where " +
                                        "locationID = {0}"
                                         , locationID);
            flag = base.sendSql_Command(sql);

            sql = String.Format("Delete From Payroll_PaymentRelationship Where " +
                                        "locationID = {0} "
                                        , locationID);
            flag = base.sendSql_Command(sql) && flag;

            return flag;
        }
        #endregion ====  Pay Method ========

        #region =======  Pay Relation ========
        public DataTable PayRelationData_ShowTree() {
            DataTable tb;

            string sql = "SELECT m.methodStr + ' -- ' + l.locationStr + ' -- ' + R.Pcurrency + '       (' + str(m.methodID) + '|' + str(l.locationID) + '|' + R.Pcurrency as tree " +
                  "FROM (Payroll_PaymentRelationship R INNER JOIN Payroll_method m ON R.methodID = m.methodID) INNER JOIN Payroll_location l ON R.locationID = l.locationID " +
                  "Where R.Enable='Y' order by m.methodID, l.locationID, R.Pcurrency";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable PayRelationData_SelectAll() {
            DataTable tb;
            
            string sql = "SELECT m.methodID, m.methodStr, l.locationID, l.locationStr, R.Pcurrency " +
                  "FROM (Payroll_PaymentRelationship R INNER JOIN Payroll_method m ON R.methodID = m.methodID) INNER JOIN Payroll_location l ON R.locationID = l.locationID " +
                  "Where R.Enable='Y' order by m.methodID, l.locationID, R.Pcurrency";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool PayRelationData_Insert(string methodID, string locationID, string Pcurrency) {
            string sql = String.Format("INSERT INTO Payroll_PaymentRelationship (methodID, locationID, Pcurrency, Enable) " +
                                        "VALUES ({0}, {1}, '{2}', 'Y') "
                                         , methodID, locationID, Pcurrency);
            return base.sendSql_Command(sql);
        }
        public bool PayRelationData_Delete(string methodID, string locationID) {
            bool flag;
            string sql = String.Format("Delete From Payroll_PaymentRelationship Where " +
                                        "methodID = {0} and locationID = {1}"
                                         , methodID, locationID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool PayRelationData_DeleteByCurrency(string Pcurrency) {
            bool flag;
            string sql = String.Format("Delete From Payroll_PaymentRelationship Where " +
                                        "Pcurrency = '{0}' "
                                         , Pcurrency);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool PayRelationData_UpdateEanble(string Pcurrency, string _YN) {
            bool flag;
            string sql = String.Format("Update Payroll_PaymentRelationship Set Enable='{0}' Where " +
                                        "Pcurrency = '{1}' "
                                         , _YN, Pcurrency);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        #endregion ====  Pay Relation ========

        #region =======  Department ========
        public DataTable DeptData_SelectAll(string CompanyID) {
            DataTable tb;
            string sql = string.Format("Select DepartmentID From Payroll_Department where CompanyID='{0}'", CompanyID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable DeptData_SelectbyDeptID(string CompanyID, string DeptID) {
            DataTable tb;
            string sql = string.Format("Select DepartmentID From Payroll_Department where CompanyID='{0}' and DepartmentID='{1}'", CompanyID, DeptID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }        
        public bool DeptData_Insert(string CompanyID, string DepartmentID) {
            DepartmentID = ReplaceChar(DepartmentID);
            string sql = String.Format("INSERT INTO Payroll_Department (CompanyID, DepartmentID) " +
                                        "VALUES ('{0}', '{1}') "
                                         , CompanyID, DepartmentID);
            return base.sendSql_Command(sql);
        }
        public bool DeptData_Update(string CompanyID, string DepartmentID, string whereDeptID) {
            DepartmentID = ReplaceChar(DepartmentID);
            string sql = String.Format("Update Payroll_Department Set " +                                       
                                        "DepartmentID = '{0}' Where " + 
                                        "CompanyID = '{1}' and DepartmentID = '{2}'"
                                         , DepartmentID, CompanyID, whereDeptID);
            return base.sendSql_Command(sql);
        }
        public bool DeptData_Delete(string CompanyID, string DepartmentID) {
            string sql = String.Format("Delete From Payroll_Department Where " + 
                                        "CompanyID = '{0}' and " + 
                                        "DepartmentID = '{1}'"
                                        , CompanyID , DepartmentID);
            return base.sendSql_Command(sql);
        }
        #endregion ====  Department ========
        
        #region =======  Currency ========
        public DataTable CurrencyData_SelectAllandEnable() {
            DataTable tb;
            string sql = string.Format("Select Pcurrency, enable, showDecimal, showAtRate,strFormat From Payroll_Currency ");
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable CurrencyData_SelectAll() {
            DataTable tb;
            string sql = string.Format("Select Pcurrency, enable, showDecimal, showAtRate,strFormat From Payroll_Currency where enable='Y' ");
            base.getSql_DataTable(sql, out tb);
            return tb;
        }        
        public DataTable CurrencyData_SelectShowRate() {
            DataTable tb;
            string sql = string.Format("Select Pcurrency,strFormat,enable From Payroll_Currency where showAtRate='Y' ");
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool CurrencyData_Insert(string Pcurrency, decimal showDecimal, string _Enable) {
            Pcurrency = ReplaceChar(Pcurrency);
            string strFormat = "{0:f" + showDecimal.ToString() + "}";
            string sql = String.Format("INSERT INTO Payroll_Currency (Pcurrency, showDecimal, strFormat, showAtRate, enable) " +
                                        "VALUES ('{0}', {1}, '{2}', '{3}', '{4}') "
                                         , Pcurrency, showDecimal, strFormat, "Y", _Enable);
            return base.sendSql_Command(sql);
        }
        public bool CurrencyData_Update(string Pcurrency, decimal showDecimal, string _Enable) {
            bool flag;
            string strFormat = "{0:f" + showDecimal.ToString() + "}";
            string sql = String.Format("Update Payroll_Currency Set " +
                                        "showDecimal = {0}, strFormat='{1}', enable='{3}' Where Pcurrency='{2}'"
                                         , showDecimal, strFormat, Pcurrency, _Enable);
            flag = base.sendSql_Command(sql);
            flag = flag && this.PayRelationData_UpdateEanble(Pcurrency, _Enable);
            return flag;
        }
        public bool CurrencyData_Delete(string Pcurrency) {
            bool flag;
            string sql = String.Format("Delete From Payroll_Currency Where " +
                                        "Pcurrency = '{0}'"
                                         , Pcurrency);
            flag = base.sendSql_Command(sql);
            flag = flag && this.PayRelationData_DeleteByCurrency(Pcurrency);
            return flag;
        }
        #endregion ====  Currency ========
        
        #region =======================  Edit Employee ========================
        public DataTable EmployeeData_SelectAll(string companyID, string deptID)
        {
            DataTable tb;
            string sql = "Select * From Payroll_Employee where CompanyID='{0}'";
            if (deptID != "") sql += " and DepartmentID='{1}'";
            sql = string.Format(sql, companyID, deptID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable EmployeeData_SelectAll(string companyID, string deptID, string InOffice, string SortByColumn) {
            DataTable tb;
            string sql = "Select * From Payroll_Employee where CompanyID='{0}'";
            if (deptID != "") sql += " and DepartmentID='{1}'";
            if (InOffice != "") sql += " and InOffice='{2}'";
            sql = string.Format(sql, companyID, deptID, InOffice);
            if (SortByColumn != "") sql += " order by " + SortByColumn;
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable EmployeeData_SelectAll() {
            DataTable tb;
            string sql = "Select * From Payroll_Employee order by CompanyID, DepartmentID";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable EmployeeData_getOne(string GrpID) {
            DataTable tb;
            string sql = "Select * From Payroll_Employee where GrpID='{0}'";
            sql = string.Format(sql, GrpID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        //act : Insert / Update
        public bool EmployeeData_InsertUpdate(string act, string GrpID , 
                                        string FirstName , 
                                        string MiddleName , 
                                        string FamilyName , 
                                        string CallName , 
                                        string IdentityID , 
                                        string IdentityCountryName , 
                                        string DateofBirth , 
                                        string Sex , 
                                        string AddressM , 
                                        string CityName , 
                                        string PostalCodeM , 
                                        string CountryName , 
                                        string EmailPersonal , 
                                        string CompanyID , 
                                        string DepartmentID , 
                                        string PositionName , 
                                        string DateJoined , 
                                        string DateResigned,
                                        string EmailWork , 
                                        string Currency , 
                                        string LASalary , 
                                        string Incre_Amount , 
                                        string Add_Amount,
                                        string txtInOfficeYN,
                                        string BasicSalary) {

            DataTable tb;
            bool flag = false;
            string sql="";
            GrpID = ReplaceChar(GrpID);
            FirstName = ReplaceChar(FirstName);
            MiddleName = ReplaceChar(MiddleName);
            FamilyName = ReplaceChar(FamilyName);
            CallName = ReplaceChar(CallName);
            IdentityID = ReplaceChar(IdentityID);
            IdentityCountryName = ReplaceChar(IdentityCountryName);
            DateofBirth = ReplaceChar(DateofBirth);
            Sex = ReplaceChar(Sex);
            AddressM = ReplaceChar(AddressM);
            CityName = ReplaceChar(CityName);
            PostalCodeM = ReplaceChar(PostalCodeM);
            CountryName = ReplaceChar(CountryName);
            EmailPersonal = ReplaceChar(EmailPersonal);
            CompanyID = ReplaceChar(CompanyID);
            DepartmentID = ReplaceChar(DepartmentID);
            PositionName = ReplaceChar(PositionName);
            DateJoined = ReplaceChar(DateJoined);
            DateResigned = ReplaceChar(DateResigned);
            EmailWork = ReplaceChar(EmailWork);
            LASalary = ReplaceChar(LASalary);
            BasicSalary = ReplaceChar(BasicSalary);
            Incre_Amount = ReplaceChar(Incre_Amount);
            Add_Amount = ReplaceChar(Add_Amount);

            if (act == "Insert") {
                sql = String.Format("INSERT INTO Payroll_Employee (GrpID, FirstName, MiddleName, FamilyName, CallName, IdentityID, IdentityCountryName, DateofBirth, Sex, AddressM, CityName, PostalCodeM, CountryName, EmailPersonal, CompanyID, DepartmentID, PositionName, DateJoined, DateResigned, EmailWork, Pcurrency, LASalary, Incre_Amount, Add_Amount, InOffice, BasicSalary) " +
                                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}','{24}','{25}') "
                                , GrpID, FirstName, MiddleName, FamilyName, CallName, IdentityID, IdentityCountryName, DateofBirth, Sex, AddressM, CityName, PostalCodeM, CountryName, EmailPersonal, CompanyID, DepartmentID, PositionName, DateJoined, DateResigned, EmailWork, Currency, LASalary, Incre_Amount, Add_Amount, txtInOfficeYN, BasicSalary);
            } else if (act == "Update") {
                sql = String.Format("Update Payroll_Employee Set " +
                                    "FirstName = '{1}', " +
                                    "MiddleName = '{2}', " +
                                    "FamilyName = '{3}', " +
                                    "CallName = '{4}', " +
                                    "IdentityID = '{5}', " +
                                    "IdentityCountryName = '{6}', " +
                                    "DateofBirth = '{7}', " +
                                    "Sex = '{8}', " +
                                    "AddressM = '{9}', " +
                                    "CityName = '{10}', " +
                                    "PostalCodeM = '{11}', " +
                                    "CountryName = '{12}', " +
                                    "EmailPersonal = '{13}', " +
                                    "CompanyID = '{14}', " +
                                    "DepartmentID = '{15}', " +
                                    "PositionName = '{16}', " +
                                    "DateJoined = '{17}', " +
                                    "DateResigned = '{18}', " +
                                    "EmailWork = '{19}', " +
                                    "Pcurrency = '{20}', " +
                                    "LASalary = '{21}', " +
                                    "Incre_Amount = '{22}', " +
                                    "Add_Amount = '{23}', " +
                                    "InOffice = '{24}', BasicSalary='{25}' Where GrpID = '{0}'"
                                     , GrpID, FirstName, MiddleName, FamilyName, CallName, IdentityID, IdentityCountryName, DateofBirth, Sex, AddressM
                                     , CityName, PostalCodeM, CountryName, EmailPersonal, CompanyID, DepartmentID, PositionName, DateJoined, DateResigned
                                     , EmailWork, Currency, LASalary, Incre_Amount, Add_Amount, txtInOfficeYN, BasicSalary);
            } else if (act == "XlsUpdate") {
                tb = this.EmployeeData_getOne(GrpID);
                if (tb.Rows.Count > 0) {
                    sql = String.Format("Update Payroll_Employee Set " +
                            "FirstName = '{1}', " +
                            "MiddleName = '{2}', " +
                            "FamilyName = '{3}', " +
                            "CallName = '{4}', " +
                            "IdentityID = '{5}', " +
                            "IdentityCountryName = '{6}', " +
                            "DateofBirth = '{7}', " +
                            "Sex = '{8}', " +
                            "AddressM = '{9}', " +
                            "CityName = '{10}', " +
                            "PostalCodeM = '{11}', " +
                            "CountryName = '{12}', " +
                            "EmailPersonal = '{13}', " +
                            "CompanyID = '{14}', " +
                            "DepartmentID = '{15}', " +
                            "PositionName = '{16}', " +
                            "DateJoined = '{17}', " +
                            "DateResigned = '{18}', " +
                            "EmailWork = '{19}' " +
                            "Where GrpID = '{0}'"
                             , GrpID, FirstName, MiddleName, FamilyName, CallName, IdentityID, IdentityCountryName, DateofBirth, Sex, AddressM
                             , CityName, PostalCodeM, CountryName, EmailPersonal, CompanyID, DepartmentID, PositionName, DateJoined, DateResigned
                             , EmailWork);
                } else {
                    sql = String.Format("INSERT INTO Payroll_Employee (GrpID, FirstName, MiddleName, FamilyName, CallName, IdentityID, IdentityCountryName, DateofBirth, Sex, AddressM, CityName, PostalCodeM, CountryName, EmailPersonal, CompanyID, DepartmentID, PositionName, DateJoined, DateResigned, EmailWork,InOffice) " +
                                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}') "
                                , GrpID, FirstName, MiddleName, FamilyName, CallName, IdentityID, IdentityCountryName, DateofBirth, Sex, AddressM, CityName, PostalCodeM, CountryName, EmailPersonal, CompanyID, DepartmentID, PositionName, DateJoined, DateResigned, EmailWork,"Y");
                }
            }
            if (GrpID != "") {
                flag = base.sendSql_Command(sql);
            } else {
                this.errMessage = "Group ID is null!";
            }
            return flag;
        }
        public bool EmployeeDate_Delete(string GrpID) {
            string sql = String.Format("Delete From Payroll_Employee Where " +
                                        "GrpID = '{0}'"
                                        , GrpID);
            return base.sendSql_Command(sql);
        }
        public bool EmployeeDate_DeleteAll() {
            bool flag;
            string sql = "Delete From Payroll_Employee";
            flag =  base.sendSql_Command(sql);

            sql = "Delete From Payroll_Emp_Received";
            flag = flag && base.sendSql_Command(sql);

            sql = "Delete From Payroll_Emp_BankAccount";
            flag = flag && base.sendSql_Command(sql);

            return flag;
        }
        public bool EmployeeDate_SalaryUpdate(string GrpID,
                                        string LASalary,
                                        string Incre_Amount,
                                        string Add_Amount,
                                        string BasicSalary) {
            bool flag;
            string sql = "";

            sql = String.Format("Update Payroll_Employee Set " +
                                    "LASalary = '{1}', " +
                                    "Incre_Amount = '{2}', " +
                                    "Add_Amount = '{3}', " +
                                    "BasicSalary='{4}' Where GrpID = '{0}'"
                                     , GrpID, LASalary, Incre_Amount, Add_Amount, BasicSalary);

            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool ReceivedData_Insert(string GrpID, string Pcurrency, string ref_money){
            GrpID = ReplaceChar(GrpID);
            string sql = String.Format("INSERT INTO Payroll_Emp_Received (GrpID, Pcurrency, ref_money) " +
                                        "VALUES ('{0}', '{1}', '{2}') "
                                        , GrpID, Pcurrency, ref_money);
            return base.sendSql_Command(sql);
        }
        public bool ReceivedData_Update(string GrpID, string Pcurrency, string ref_money) {
            string sql = String.Format("Update Payroll_Emp_Received Set ref_money = '{2}' " +
                                        "Where GrpID = '{0}' and Pcurrency = '{1}' "
                                         , GrpID, Pcurrency, ref_money);
            return base.sendSql_Command(sql);
        }
        public bool ReceivedData_Delete(string GrpID)
        {
            GrpID = ReplaceChar(GrpID);
            bool flag;
            string sql = String.Format("Delete From Payroll_Emp_Received Where " +
                                        "GrpID = '{0}'"
                                         , GrpID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public DataTable ReceivedData_getOne(string GrpID) {
            DataTable tb;
            string sql = "Select Pcurrency, ref_money as Amount From Payroll_Emp_Received where GrpID='{0}'";
            sql = string.Format(sql, GrpID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable ReceivedData_SelectAll() {
            DataTable tb;
            string sql = "Select GrpID, Pcurrency, ref_money From Payroll_Emp_Received";            
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool BankData_Insert(string GrpID, string AcNumber, string AcHolder, string Bank, string payoutRelation) {
            GrpID = ReplaceChar(GrpID);
            bool flag = true;
            string mid = "0";
            string lid = "0";
            string cuy = "";
            string payout;
            int pos;
            if (payoutRelation.Trim() != "") {
                pos = payoutRelation.LastIndexOf("(");
                if (pos != -1) {
                    payout = payoutRelation.Substring(pos+1);
                    mid = payout.Split('|')[0];
                    lid = payout.Split('|')[1];
                    cuy = payout.Split('|')[2];
                }
            }

            if (mid != "0" && lid != "0") {
                string sql = String.Format("INSERT INTO Payroll_Emp_BankAccount (GrpID, AcNumber, AcHolder, Bank, payoutRelation, Mid, Lid, Cury) " +
                                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, '{7}') "
                                         , GrpID, AcNumber, AcHolder, Bank, payoutRelation, mid, lid, cuy);
                flag = base.sendSql_Command(sql);     
            }
            return flag;
                      
        }
        public bool BankData_Delete(string GrpID) {
            GrpID = ReplaceChar(GrpID);
            bool flag;
            string sql = String.Format("Delete From Payroll_Emp_BankAccount Where " +
                                        "GrpID = '{0}'"
                                         , GrpID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public DataTable BankData_getAll(string GrpID) {
            DataTable tb;
            string sql = "Select AcHolder, AcNumber, Bank, payoutRelation From Payroll_Emp_BankAccount where GrpID='{0}'";
            sql = string.Format(sql, GrpID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable BankData_getBankInList(string GrpID) {
            DataTable tb;
            string sql = "SELECT GrpID, payoutRelation, AcNumber, AcHolder, Bank, Cury " +
                         "FROM Payroll_Emp_BankAccount Where GrpID='{0}'";
            sql = string.Format(sql, GrpID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        #endregion =======================  Edit Employee ========================
        
        #region =======  Exchange Rate ========
        public DataTable ExRateData_selectbyYear() {
            DataTable tb;
            string sql = "Select left(monthly,4) as y1 From Payroll_MonthlyRate group by left(monthly,4) order by left(monthly,4)";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable ExRateData_selectbyMonthbyYear(string _year) {
            DataTable tb;
            string sql = string.Format("Select distinct mid(monthly,5,2) as m1 From Payroll_MonthlyRate where left(monthly,4) = '{0}' order by mid(monthly,5,2)", _year);            
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable ExRateData_getLastYear() {
            DataTable tb;
            string sql = "Select top 1 monthly From Payroll_MonthlyRate order by monthly desc";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable ExRateData_getAllbyDate(string _YM) {
            DataTable tb;
            string sql = string.Format("Select exchangeCurrency, showRate From Payroll_MonthlyRate where monthly = '{0}'", _YM);     
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool ExRateData_Delete(string _YM) {
            bool flag;
            string sql = String.Format("Delete From Payroll_MonthlyRate Where " +
                                        "monthly = '{0}'"
                                         , _YM);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool ExRateData_NewMonth(string _YM) {
            bool flag;      
            string sql = String.Format("INSERT INTO Payroll_MonthlyRate (baseCurrency, monthly, exchangeCurrency, showRate) " +
                                        "Select 'MYR', '{0}', Pcurrency,'0' From Payroll_Currency Where showAtRate='Y' and enable='Y'"
                                         , _YM);
            flag = base.sendSql_Command(sql);

            return flag;
        }
        public bool ExRateData_Insert(string baseCurrency, string _YM, string exchangeCurrency, string showRate) {
            bool flag;
            string sql = String.Format("INSERT INTO Payroll_MonthlyRate (baseCurrency, monthly, exchangeCurrency, showRate) " +
                                "VALUES ('{0}', '{1}', '{2}', '{3}') "
                                 , baseCurrency, _YM, exchangeCurrency, showRate);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        #endregion ====  Exchange Rate ========

        #region =======  Lock month ========
        public DataTable LockData_selectbyYear() {
            DataTable tb;
            string sql = "Select left(monthly,4) as y1 From Payroll_LockMonth group by left(monthly,4) order by left(monthly,4)";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable LockData_selectMonthbyYear(string _year) {
            DataTable tb;
            string sql = "Select monthly From Payroll_LockMonth Where left(monthly,4) = '{0}' order by monthly";
            sql = string.Format(sql, _year);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public string LockData_openMonth() {
            DataTable tb;
            string sql = "Select monthly From Payroll_LockMonth where opening='Y'";
            base.getSql_DataTable(sql, out tb);
            if (tb.Rows.Count > 0)
                return tb.Rows[0][0].ToString();
            else
                return "";
        }
        public DataTable LockData_getLastYear() {
            DataTable tb;
            string sql = "Select top 1 monthly From Payroll_LockMonth order by monthly desc";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool LockData_NewMonth(string _YM) {
            bool flag;
            string sql = String.Format("INSERT INTO Payroll_LockMonth (monthly, opening) " +
                                        "VALUES ('{0}','N')"
                                         , _YM);
            flag = base.sendSql_Command(sql);

            return flag;
        }
        public DataTable LockData_getAllbyYear(string _Y) {
            DataTable tb;
            string sql = string.Format("Select monthly, opening  From Payroll_LockMonth where left(monthly,4) = '{0}'", _Y);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool LockData_Update(string _YM) {
            bool flag;
            
            string sql = "Update Payroll_LockMonth Set opening='N'";
            flag = base.sendSql_Command(sql);

            sql = String.Format("Update Payroll_LockMonth Set " +
                                        "opening = 'Y' Where monthly='{0}'"
                                         , _YM);
            flag = flag && base.sendSql_Command(sql);
            return flag;
        }
        #endregion ====  Lock month ========

        #region =======  Keyin payment ========
        public DataTable KeyData_MainSelectAll(string monthly) {
            DataTable tb;
            string sql = "SELECT * FROM Payroll_MonthlyPay_Main Where monthly='{0}' ";
            sql = string.Format(sql, monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable KeyData_BankSelectAll(string monthly) {
            DataTable tb;
            string sql = "SELECT * FROM Payroll_MonthlyPay_Bank Where monthly='{0}' ";
            sql = string.Format(sql, monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable KeyData_ReceivedSelectAll(string monthly) {
            DataTable tb;
            string sql = "SELECT * FROM Payroll_MonthlyPay_Received Where monthly='{0}' ";
            sql = string.Format(sql, monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool KeyData_UpdateEncryMain(string monthly, string GrpID,                                  
                                    string Prob_Salary,
                                    string Incre_Amount,
                                    string Add_Amount,
                                    string Gross_Total,                                    
                                    string Unpaid_Amount,                                    
                                    string Adv_Amount,                                    
                                    string Loan_Amount,
                                    string Dedu_Total,
                                    string Net_Salary,
                                    string Show_VarianceRM,                                    
                                    string MYR_Gross, string MYR_Dedu, string MYR_Net) {
            bool flag;
            string sql = String.Format("Update Payroll_MonthlyPay_Main Set " +                                    
                                    "Prob_Salary = '{2}', " +
                                    "Incre_Amount = '{3}', " +
                                    "Add_Amount = '{4}', " +
                                    "Gross_Total = '{5}', " +                                    
                                    "Unpaid_Amount = '{6}', " +                                  
                                    "Adv_Amount = '{7}', " +                                  
                                    "Loan_Amount = '{8}', " +
                                    "Dedu_Total = '{9}', " +
                                    "Net_Salary = '{10}', " +
                                    "Show_VarianceRM = '{11}', " +
                                    "MYR_Gross= '{12}', MYR_Dedu= '{13}', MYR_Net= '{14}' Where monthly = '{0}' and GrpID = '{1}'"
                                     , monthly, GrpID, Prob_Salary, Incre_Amount, Add_Amount, Gross_Total,
                                     Unpaid_Amount, Adv_Amount, Loan_Amount, Dedu_Total,
                                     Net_Salary, Show_VarianceRM, MYR_Gross, MYR_Dedu, MYR_Net);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool KeyData_UpdateEncryBank(string monthly, string GrpID, string Mid, string Lid, string Amount, string MYR_Amount) {
            bool flag;
            string sql = String.Format("Update Payroll_MonthlyPay_Bank Set " +
                                    "Amount = '{4}', " +
                                    "MYR_Amount = '{5}' Where monthly = '{0}' and GrpID = '{1}' and Mid = {2} and Lid = {3} "
                                     , monthly, GrpID, Mid, Lid, Amount, MYR_Amount);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool KeyData_UpdateEncryReceived(string monthly, string GrpID, string Pcurrency, string Amount) {
            bool flag;
            string sql = String.Format("Update Payroll_MonthlyPay_Received Set " +
                                       "Amount = '{3}' Where monthly = '{0}' and GrpID = '{1}' and Pcurrency = '{2}'"
                                      , monthly, GrpID, Pcurrency, Amount);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public DataTable KeyData_getEmpList(string monthly, string CompanyID, string DeptID) {
            DataTable tb;
            string sql = "SELECT Emp.CompanyID, Emp.DepartmentID, Emp.GrpID, Emp.FirstName, Emp.MiddleName, Emp.FamilyName, Emp.Sex, " +
                         "Emp.PositionName, Emp.DateJoined, Emp.LASalary, Emp.Incre_Amount, Emp.Add_Amount, Emp.Pcurrency, " +
                         "(Select PayMain.monthly from Payroll_MonthlyPay_Main PayMain Where PayMain.monthly = '{0}' and PayMain.GrpID = Emp.GrpID) as monthly " +
                         "FROM Payroll_Employee Emp Where Emp.InOffice='Y' ";
            sql = string.Format(sql, monthly);
            if (CompanyID != "") {
                sql += "and Emp.CompanyID='" + CompanyID + "'";
            }
            if (DeptID != "") {
                sql += "and Emp.DepartmentID='" + DeptID + "'";
            }

            sql += " order by Emp.CompanyID, Emp.DepartmentID, Emp.GrpID";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable KeyData_getDeduction(string monthly, string GrpID) {
            DataTable tb;
            string sql = "SELECT Prob_Salary, Incre_Amount, Add_Amount, Gross_Total, Unpaidcury, Unpaid_Amount, Advcury, Adv_Amount, Loancury, " +
                         "Loan_Amount, Net_Salary, Remark, OtherRemark, IncreRemark, BasicSalaryRemark " +
                         "FROM Payroll_MonthlyPay_Main Where monthly='{0}' and GrpID='{1}' ";
            sql = string.Format(sql, monthly, GrpID);            
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool KeyData_InsertUpdate(string act,
                                    string monthly,
                                    string GrpID,
                                    string Pcurrency,
                                    string Prob_Salary,
                                    string Incre_Amount,
                                    string Add_Amount,
                                    string Gross_Total,
                                    string Unpaidcury,
                                    string Unpaid_Amount,
                                    string Advcury,
                                    string Adv_Amount,
                                    string Loancury,
                                    string Loan_Amount,
                                    string Dedu_Total,
                                    string Net_Salary,
                                    string Show_VarianceRM,
                                    string Remark,
                                    string MYR_Gross, string MYR_Dedu, string MYR_Net, string CompanyID, string DepartmentID, string OtherRemark, string IncreRemark, string BasicRemark) {
            bool flag;
            Remark = ReplaceChar(Remark);
            BasicRemark = ReplaceChar(BasicRemark);
            OtherRemark = ReplaceChar(OtherRemark);
            string sql="";
            if (act == "Insert") {
                sql = String.Format("INSERT INTO Payroll_MonthlyPay_Main (monthly, GrpID, Pcurrency, Prob_Salary, Incre_Amount, Add_Amount, Gross_Total, Unpaidcury, Unpaid_Amount, Advcury, Adv_Amount, Loancury, Loan_Amount, Dedu_Total, Net_Salary, Show_VarianceRM, Remark, MYR_Gross, MYR_Dedu, MYR_Net, CompanyID, DepartmentID,OtherRemark, IncreRemark, BasicSalaryRemark) " +
                                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}') "
                                    , monthly, GrpID, Pcurrency, Prob_Salary, Incre_Amount, Add_Amount, Gross_Total, Unpaidcury, Unpaid_Amount, Advcury, Adv_Amount, Loancury, Loan_Amount, Dedu_Total, Net_Salary, Show_VarianceRM, Remark, MYR_Gross, MYR_Dedu, MYR_Net, CompanyID, DepartmentID, OtherRemark, IncreRemark, BasicRemark);
            } else if(act =="Update") {
                sql = String.Format("Update Payroll_MonthlyPay_Main Set " +                                   
                                    "Pcurrency = '{2}', " +
                                    "Prob_Salary = '{3}', " +
                                    "Incre_Amount = '{4}', " +
                                    "Add_Amount = '{5}', " +
                                    "Gross_Total = '{6}', " +
                                    "Unpaidcury = '{7}', " +
                                    "Unpaid_Amount = '{8}', " +
                                    "Advcury = '{9}', " +
                                    "Adv_Amount = '{10}', " +
                                    "Loancury = '{11}', " +
                                    "Loan_Amount = '{12}', " +
                                    "Dedu_Total = '{13}', " +
                                    "Net_Salary = '{14}', " +
                                    "Show_VarianceRM = '{15}', " +
                                    "Remark = '{16}', MYR_Gross= '{17}', MYR_Dedu= '{18}', MYR_Net= '{19}', CompanyID= '{20}', DepartmentID= '{21}', OtherRemark= '{22}', IncreRemark='{23}', BasicSalaryRemark='{24}' Where monthly = '{0}' and GrpID = '{1}'"
                                     , monthly, GrpID, Pcurrency, Prob_Salary, Incre_Amount, Add_Amount, Gross_Total, 
                                     Unpaidcury, Unpaid_Amount, Advcury, Adv_Amount, Loancury, Loan_Amount, Dedu_Total,
                                     Net_Salary, Show_VarianceRM, Remark, MYR_Gross, MYR_Dedu, MYR_Net, CompanyID, DepartmentID, OtherRemark, IncreRemark, BasicRemark);
            }
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool KeyData_Delete( string monthly,
                                    string GrpID) {
            bool flag;           
            string sql = "";
            sql = String.Format("Delete From Payroll_MonthlyPay_Main Where monthly = '{0}' and GrpID = '{1}' " 
                                     , monthly, GrpID);
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool KeyData_ReceivedInsert(string act,
                                    string monthly,
                                    string GrpID,
                                    string Pcurrency,
                                    string Amount, string CompanyID, string DeptID) {
            bool flag;            
            string sql = "";
            if (act == "Insert") {
                sql = String.Format("INSERT INTO Payroll_MonthlyPay_Received (monthly, GrpID, Pcurrency, Amount, CompanyID, DepartmentID) " +
                                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') "
                                     , monthly, GrpID, Pcurrency, Amount, CompanyID, DeptID);
            } else if (act == "Delete") {
                sql = String.Format("Delete From Payroll_MonthlyPay_Received Where monthly = '{0}' and GrpID = '{1}'", monthly, GrpID);
            }
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public bool KeyData_BankInInsert(string act,
                                    string monthly , 
                                    string GrpID , 
                                    string Pcurrency,
                                    string Amount,
                                    string AcHolder,
                                    string Bank,
                                    string AcNumber,
                                    string payoutRelation,
                                    string CompanyID, string DepartmentID, string MYR_Amount) {
            bool flag;
            string sql = "";

            string mid = "0";
            string lid = "0";
            string cuy = "";
            string payout ="";
            int pos = -1;
            
            if (act == "Insert") {
                if (payoutRelation.Trim() != "") {
                    pos = payoutRelation.LastIndexOf("(");
                    if (pos != -1) {
                        payout = payoutRelation.Substring(pos + 1);
                        mid = payout.Split('|')[0];
                        lid = payout.Split('|')[1];
                        cuy = payout.Split('|')[2];
                    }

                }
                sql = String.Format("INSERT INTO Payroll_MonthlyPay_Bank (monthly, GrpID, Pcurrency, Amount, AcHolder, Bank, AcNumber, payoutRelation, Mid, Lid, Cury, CompanyID, DepartmentID, MYR_Amount) " +
                                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}, '{10}', '{11}', '{12}', '{13}') "
                                     , monthly, GrpID, Pcurrency, Amount, AcHolder, Bank, AcNumber, payoutRelation, mid, lid, cuy, CompanyID, DepartmentID, MYR_Amount);
            } else if (act == "Delete") {
                sql = String.Format("Delete From Payroll_MonthlyPay_Bank Where monthly = '{0}' and GrpID = '{1}'", monthly, GrpID);
            }
            flag = base.sendSql_Command(sql);
            return flag;
        }
        public DataTable KeyData_getBankInList(string GrpID, string monthly) {
            DataTable tb;
            string sql = "SELECT GrpID, payoutRelation, AcNumber, AcHolder, Bank, Amount, Cury " +
                         "FROM Payroll_MonthlyPay_Bank " +
                         "Where GrpID='{0}' and monthly='{1}' ";
            sql = string.Format(sql, GrpID, monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public int KeyData_getBankInCountMax(string monthly) {
            int HeadBankCountMax;
            DataTable tb;
            string sql = "SELECT count(GrpID) as Bcount " +
                         "FROM Payroll_MonthlyPay_Bank " +
                         "Where monthly='{0}' Group by GrpID Order by count(GrpID) desc";
            sql = string.Format(sql, monthly);
            base.getSql_DataTable(sql, out tb);
            if (tb.Rows.Count > 0)
                HeadBankCountMax = Convert.ToInt16(tb.Rows[0][0].ToString());
            else
                HeadBankCountMax = 0;
            return HeadBankCountMax;
        }
        public DataTable KeyData_ReceivedList(string GrpID, string monthly) {
            DataTable tb;
            string sql = "Select Pcurrency, Amount From Payroll_MonthlyPay_Received where GrpID='{0}' and monthly='{1}' ";
            sql = string.Format(sql, GrpID, monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        #endregion ====  Keyin payment ========

        #region =======  Report  ===========
        public DataTable Report_getEmpList(string monthly, string CompanyID, string DeptID, string groupPeople) {
            DataTable tb;

            string sql = "SELECT E.GrpID, E.FamilyName + ' ' + E.FirstName + ' ' + E.MiddleName As eName, E.CallName, E.CompanyID, E.DepartmentID, E.DateJoined, " +
                         "P.Prob_Salary, P.Incre_Amount, P.Add_Amount, P.Gross_Total, P.Unpaidcury, P.Unpaid_Amount, P.Advcury, P.Adv_Amount, P.Loancury, " +
                         "P.Loan_Amount, P.Dedu_Total, P.Net_Salary, P.Remark, P.Show_VarianceRM, P.Pcurrency, E.EmailWork, E.BasicSalary, E.PositionName, " +
                         "P.IncreRemark, P.OtherRemark, P.BasicSalaryRemark " +
                         "FROM Payroll_Employee E INNER JOIN Payroll_MonthlyPay_Main P ON E.GrpID = P.GrpID Where P.monthly='{0}' ";

            sql = string.Format(sql, monthly);
            if (CompanyID != "") {
                sql += "and E.CompanyID='" + CompanyID + "' ";
            }
            if (DeptID != "") {
                sql += "and E.DepartmentID='" + DeptID + "' ";
            }
            if (groupPeople != "") {
                sql += "and E.GrpID in (" + groupPeople + ") ";
            }
            sql += " Order by E.FirstName , E.MiddleName , E.FamilyName";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_getEmpMainByGrpID(string monthly, string GrpID) {
            DataTable tb;
            string sql = "Select * From Payroll_MonthlyPay_Main Where monthly='{0}' and GrpID='{1}' ";
            sql = string.Format(sql, monthly, GrpID);

            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_getEmpReceivedList(string monthly, string GrpID) {
            DataTable tb;
            string sql = "Select Pcurrency, Amount From Payroll_MonthlyPay_Received Where monthly='{0}' and GrpID='{1}' ";
            sql = string.Format(sql, monthly, GrpID);
        
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_getEmpBankList(string monthly, string GrpID) {
            DataTable tb;
            string sql = "Select AcHolder, Bank, AcNumber, Amount, payoutRelation From Payroll_MonthlyPay_Bank Where monthly='{0}' and GrpID='{1}' ";
            sql = string.Format(sql, monthly, GrpID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }        
        public DataTable Report_getBankingList(string monthly, string mid, string lid, string cury) {
            DataTable tb;
            string sql;

            sql = "SELECT Payroll_Employee.GrpID, Payroll_Employee.CallName, Payroll_MonthlyPay_Bank.Cury, Payroll_MonthlyPay_Bank.AcHolder, " +
                  "Payroll_MonthlyPay_Bank.Bank, Payroll_MonthlyPay_Bank.AcNumber, Payroll_MonthlyPay_Bank.Amount, " +
                  "Payroll_location.locationStr, Payroll_method.methodStr " +
                  "FROM Payroll_method INNER JOIN (Payroll_location INNER JOIN " +
                  "(Payroll_Employee INNER JOIN Payroll_MonthlyPay_Bank ON Payroll_Employee.GrpID = Payroll_MonthlyPay_Bank.GrpID)" +
                  "ON Payroll_location.locationID = Payroll_MonthlyPay_Bank.Lid) ON Payroll_method.methodID = Payroll_MonthlyPay_Bank.Mid ";
            sql += "Where Payroll_MonthlyPay_Bank.monthly = '" + monthly  + "' ";
            if (mid != "") {
                sql += "and Payroll_method.methodID=" + mid + " ";
            }
            if (lid != "") {
                sql += "and Payroll_location.locationID=" + lid + " ";
            }
            if (cury != "") {
                sql += "and Payroll_MonthlyPay_Bank.Cury='" + cury + "' ";
            }
            sql += "Order by Payroll_method.methodID, Payroll_location.locationID, Payroll_MonthlyPay_Bank.Cury";

            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_CurrencyData_SelectAll(string mid, string lid) {
            DataTable tb;
            string sql = "SELECT R.Pcurrency " +
                         "FROM (Payroll_PaymentRelationship R INNER JOIN Payroll_method m ON R.methodID = m.methodID) INNER JOIN Payroll_location l ON R.locationID = l.locationID " +
                         "Where m.methodID = {0} and l.locationID = {1} order by R.Pcurrency";

            sql = string.Format(sql, mid, lid);

            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_CurrencyData_SelectAll(string monthly) {
            DataTable tb;
            string sql = string.Format("Select exchangeCurrency as Pcurrency, showRate From Payroll_MonthlyRate where monthly='{0}' ", monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        } 
        public DataTable Report_GroupPeopleByDept(string CompanyID, string DeptID) {
            DataTable tb;            
            string where = "";
            string sql = "Select c.CompanyID, d.DepartmentID FROM Payroll_Company c Left JOIN Payroll_Department d ON d.CompanyID = c.CompanyID "; 
            
            if (CompanyID != "")
                where += "c.CompanyID = '" + CompanyID + "' ";

            if (DeptID != "") {
                if (where != "") where += "and ";
                where += "d.DepartmentID = '" + DeptID + "' ";
            }
            
            if (where != "") where = "where " + where;
            sql += where;
            sql += "order by c.CompanyID, d.DepartmentID";
            
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public object Report_getPeople(string companyID, string deptID) {
            DataTable tb;
            string sql = "Select count(*) as people FROM Payroll_Employee Where CompanyID='{0}' and DepartmentID='{1}' ";
            sql = string.Format(sql, companyID, deptID);
            base.getSql_DataTable(sql, out tb);
            return tb.Rows[0][0];
        }
        public DataTable Report_gerBankingLocation(string monthly, string CompanyID, string DeptID) {
            DataTable tb;
            string sql = "Select Lid, Cury from Payroll_MonthlyPay_Bank Where monthly='{0}' and CompanyID='{1}' and DepartmentID='{2}' group by Lid, Cury Order by Lid, Cury";
            sql = string.Format(sql, monthly, CompanyID, DeptID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_gerAmountByCompAndLocationPerEmp(string monthly, string CompanyID, string DeptID, string Lid, string Pcurrency) {
            DataTable tb;
            string sql = "Select Amount from Payroll_MonthlyPay_Bank Where monthly='{0}' and CompanyID='{1}' and DepartmentID='{2}' and Lid ={3} and Cury='{4}'";
            sql = string.Format(sql, monthly, CompanyID, DeptID, Lid, Pcurrency);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_get_DeductionByCompAndLocationPerEmp(string monthly, string CompanyID, string DeptID) {
            DataTable tb;
            string sql = "Select MYR_Dedu from Payroll_MonthlyPay_Main Where monthly='{0}' and CompanyID='{1}' and DepartmentID='{2}'"; //Base on MYR
            sql = string.Format(sql, monthly, CompanyID, DeptID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_get_OverPayByCompAndLocationPerEmp(string monthly, string CompanyID, string DeptID) {
            DataTable tb;
            string sql = "Select MYR_Net from Payroll_MonthlyPay_Main Where monthly='{0}' and CompanyID='{1}' and DepartmentID='{2}'"; //Base on MYR
            sql = string.Format(sql, monthly, CompanyID, DeptID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_get_BankinMYRAmountByCpDtMeLo(string monthly, string CompanyID, string DeptID, string mid, string lid) {
            DataTable tb;
            string sql = "Select MYR_Amount from Payroll_MonthlyPay_Bank Where monthly='{0}' and CompanyID='{1}' and DepartmentID='{2}' and Mid = {3} and " + 
                         "Lid = {4} "; //Base on MYR
            sql = string.Format(sql, monthly, CompanyID, DeptID, mid, lid);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_get_AllRateItemByYear(string _year) {
            DataTable tb;
            string sql = String.Format("Select exchangeCurrency From Payroll_MonthlyRate Where " +
                                        "left(monthly,4) = '{0}' group by exchangeCurrency", _year);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_get_oneMonthRateByMonth(string _year, string _cury, string _maxMonth) {
            DataTable tb;
            string sql = String.Format("Select monthly, showRate From Payroll_MonthlyRate Where " +
                                        "left(monthly,4) = '{0}' and exchangeCurrency='{1}' and monthly<='{2}' order by monthly", _year, _cury, _maxMonth);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_getBankinGroupByYear(string monthly) {
            DataTable tb;
            string sql = String.Format("Select Mid, Lid, (Select methodStr From Payroll_method where methodID=Mid) as method, " +
                                        "(Select locationStr From Payroll_location where locationID=Lid) as location From Payroll_MonthlyPay_Bank Where " +
                                        "monthly = '{0}' group by Mid, Lid order by Mid, Lid"
                                        , monthly);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public DataTable Report_getPeopleCountByMonth(string monthly, string CompanyID, string DeptID) {
            DataTable tb;
            string sql = String.Format("Select count(*) as total From Payroll_MonthlyPay_Main Where " +
                                        "monthly='{0}' and CompanyID='{1}' and DepartmentID='{2}' "
                                        , monthly, CompanyID, DeptID);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        #endregion =======  Report  ===========

        #region =======  Mail ========
        public DataTable getMailProfile() {
            DataTable tb;
            string sql = "Select content, mailserver, port, Sender, subject, testRecipient From Payroll_Mail";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool MailProfile_Update(string mailserver, string port, string Sender, string subject, string content, string testRecipient) {
            mailserver = ReplaceChar(mailserver);
            port = ReplaceChar(port);
            Sender = ReplaceChar(Sender);
            subject = ReplaceChar(subject);
            content = ReplaceChar(content);
            testRecipient = ReplaceChar(testRecipient);

            string sql = String.Format("Update Payroll_Mail Set " +
                                        "mailserver = '{0}', " +
                                        "port = '{1}', " +
                                        "Sender = '{2}', " +
                                        "subject = '{3}', " +
                                        "content = '{4}', " +
                                        "testRecipient = '{5}'"
                                         , mailserver, port, Sender, subject, content, testRecipient);
            return base.sendSql_Command(sql);    
        }
        #endregion ====  Mail ========

        #region =======  Second Encrypt  ========
        public DataTable getEmpPwdKey() {
            DataTable tb;
            string sql = "Select PwdKey From Pwd_Emp";
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool EmpPwdKey_Update(string PwdKey) {
            bool flag;
            string sql = String.Format("Update Pwd_Emp Set " +
                                        "PwdKey = '{0}'"
                                         , PwdKey);
            flag = base.sendSql_Command(sql);
            return flag;
        }        
        public DataTable getMonthlyPwdKey(string MonthyStr) {
            DataTable tb;
            string sql = string.Format("Select PwdKey From Pwd_Monthly where monthly = '{0}' ", MonthyStr);
            base.getSql_DataTable(sql, out tb);
            return tb;
        }
        public bool MonthlyPwdKey_Update(string MonthyStr, string PwdKey) {
            bool flag;
            string sql = string.Format("Delete From Pwd_Monthly where monthly = '{0}' ", MonthyStr);
            flag = base.sendSql_Command(sql);

            sql = String.Format("INSERT INTO Pwd_Monthly (monthly, PwdKey) " +
                                "VALUES ('{0}', '{1}') "
                                 , MonthyStr, PwdKey);
            flag = base.sendSql_Command(sql);
            return flag;
        }    
        #endregion ====  Second Encrypt ========

        #region =======  fixbug ========
        public void fixbankaccountkey() {
            string sql = "ALTER TABLE Payroll_Emp_BankAccount ADD serno Counter";
            base.sendSql_Command(sql);

            sql = "ALTER TABLE Payroll_Emp_BankAccount Drop CONSTRAINT PrimaryKey";
            base.sendSql_Command(sql);

            sql = "ALTER TABLE Payroll_Emp_BankAccount ADD CONSTRAINT PrimaryKey PRIMARY KEY(GrpID, Mid, Lid, serno)";
            base.sendSql_Command(sql);
        }

        public void fixreceivekey() {
            string sql = "ALTER TABLE Payroll_MonthlyPay_Bank ADD serno Counter";
            base.sendSql_Command(sql);

            sql = "ALTER TABLE Payroll_MonthlyPay_Bank Drop CONSTRAINT PrimaryKey";
            base.sendSql_Command(sql);

            sql = "ALTER TABLE Payroll_MonthlyPay_Bank ADD CONSTRAINT PrimaryKey PRIMARY KEY(monthly, GrpID, Mid, Lid, serno)";
            base.sendSql_Command(sql);
        }
        #endregion ====  fixbug ========
    }
}
