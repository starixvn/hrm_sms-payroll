using System;
using System.Collections.Generic;
using System.Text;
using Excel;
using System.Data;

namespace Payroll_System {
    class Employee_Excel : InternalLibrary.baseExport2Excel {
        string GrpID;
        string FirstName;
        string MiddleName;
        string FamilyName;
        string CallName;
        string IdentityID;
        string IdentityCountryName;
        string DateofBirth;
        string Sex;
        string AddressM;
        string CityName;
        string PostalCodeM;
        string CountryName;
        string EmailPersonal;
        string CompanyID;
        string DepartmentID;
        string PositionName;
        string DateJoined;
        string EmailWork;

        private string obj2str(object obj) {
            string reval = "";
            if (obj != null) {
                reval = obj.ToString();
            }
            return reval;
        }

        public void readData(TSQL tSQL) {
            object[,] obj;            
            base.ScanEOFLine = 2; //start scan line 
            while (base.EOF) {
                obj = (object[,])base.readLine(19);
                if (obj == null) break;

                GrpID = obj2str(obj[1, 1]);
                FirstName = obj2str(obj[1, 2]);
                MiddleName = obj2str(obj[1, 3]);
                FamilyName = obj2str(obj[1, 4]);
                CallName = obj2str(obj[1, 5]);
                IdentityID = obj2str(obj[1, 6]);
                IdentityCountryName = obj2str(obj[1, 7]);
                DateofBirth = obj2str(obj[1, 8]);
                Sex = obj2str(obj[1, 9]);
                AddressM = obj2str(obj[1, 10]);
                CityName = obj2str(obj[1, 11]);
                PostalCodeM = obj2str(obj[1, 12]);
                CountryName = obj2str(obj[1, 13]);
                EmailPersonal = obj2str(obj[1, 14]);
                CompanyID = obj2str(obj[1, 15]);
                DepartmentID = obj2str(obj[1, 16]);
                PositionName = obj2str(obj[1, 17]);
                DateJoined = obj2str(obj[1, 18]);
                EmailWork = obj2str(obj[1, 19]);

                tSQL.EmployeeData_InsertUpdate("XlsUpdate", GrpID,
                                               FirstName,
                                               MiddleName,
                                               FamilyName,
                                               CallName,
                                               IdentityID,
                                               IdentityCountryName,
                                               DateofBirth,
                                               Sex,
                                               AddressM,
                                               CityName,
                                               PostalCodeM,
                                               CountryName,
                                               EmailPersonal,
                                               CompanyID,
                                               DepartmentID,
                                               PositionName,
                                               DateJoined,
                                               "",
                                               EmailWork,
                                               "",
                                               "",
                                               "",
                                               "",
                                               "",
                                               "");

            }
        }

        public void outData(TSQL tSQL) {
            base.SaveExcelFile_II();

            System.Data.DataTable dt = tSQL.EmployeeData_SelectAll();
            
            int _CurrentRow = 2;
            for (int i = 0; i < dt.Rows.Count; i++) {
                GrpID = dt.Rows[i]["GrpID"].ToString();
                FirstName = dt.Rows[i]["FirstName"].ToString();
                MiddleName = dt.Rows[i]["MiddleName"].ToString();
                FamilyName = dt.Rows[i]["FamilyName"].ToString();
                CallName = dt.Rows[i]["CallName"].ToString();
                IdentityID = dt.Rows[i]["IdentityID"].ToString();
                IdentityCountryName = dt.Rows[i]["IdentityCountryName"].ToString();
                DateofBirth = dt.Rows[i]["DateofBirth"].ToString();
                Sex = dt.Rows[i]["Sex"].ToString();
                AddressM = dt.Rows[i]["AddressM"].ToString();
                CityName = dt.Rows[i]["CityName"].ToString();
                PostalCodeM = dt.Rows[i]["PostalCodeM"].ToString();
                CountryName = dt.Rows[i]["CountryName"].ToString();
                EmailPersonal = dt.Rows[i]["EmailPersonal"].ToString();
                CompanyID = dt.Rows[i]["CompanyID"].ToString();
                DepartmentID = dt.Rows[i]["DepartmentID"].ToString();
                PositionName = dt.Rows[i]["PositionName"].ToString();
                DateJoined = dt.Rows[i]["DateJoined"].ToString();
                EmailWork = dt.Rows[i]["EmailWork"].ToString();


                this.Rpt_WorkSheet.Cells[_CurrentRow, 1] = GrpID;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 2] = FirstName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 3] = MiddleName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 4] = FamilyName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 5] = CallName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 6] = IdentityID;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 7] = IdentityCountryName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 8] = DateofBirth;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 9] = Sex;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 10] = AddressM;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 11] = CityName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 12] = PostalCodeM;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 13] = CountryName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 14] = EmailPersonal;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 15] = CompanyID;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 16] = DepartmentID;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 17] = PositionName;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 18] = DateJoined;
                this.Rpt_WorkSheet.Cells[_CurrentRow, 19] = EmailWork;
           

                _CurrentRow++;
            }

        }

        public void outPayrollList(System.Windows.Forms.DataGridView grid) {            
            int i,j;
            int _CurrentRow;
            int _ColCount = grid.Columns.Count;
            int _RowCount = grid.Rows.Count;
            string Str;
            base.SaveExcelFile_II();

            //head
            _CurrentRow = 1;
            for (i = 1; i <= _ColCount; i++) {
                Str = grid.Columns[i-1].HeaderText;
                this.Rpt_WorkSheet.Cells[_CurrentRow, i] = Str;
            }

            //content
            _CurrentRow = 2;
            for (j = 1; j <= _RowCount; j++) {
                for (i = 1; i <= _ColCount; i++) {
                    Str = ((grid.Rows[j - 1].Cells[i - 1].Value == null) ? "" : grid.Rows[j - 1].Cells[i - 1].Value.ToString());
                    this.Rpt_WorkSheet.Cells[_CurrentRow, i] = Str;
                }
                _CurrentRow++;
            }
            
  
   
        }

    }
}
