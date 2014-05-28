using System;
using System.Collections.Generic;
using System.Text;
using Excel;// = Microsoft.Office.Interop.Excel; 
using System.IO;
using System.Runtime.InteropServices;

namespace InternalLibrary
{
    public class baseExport2Excel
    {
        private string _ReportFilePath = "";
        private string _ReportFileXls = "";
        private string _Rpt_ReportExportFilePath = "";
        private string _Rpt_ReportExportFileName = "";
        private Excel.ApplicationClass _ExcelApp;
        private Excel.Workbook _WorkBook;
        private Excel.Worksheet _WorkSheet;
        private Excel.Worksheet _TempSheet;
        protected int ScanEOFLine;
        private bool _EOF;
        private string _TemplateFile = "";
        public string messageString;

        public baseExport2Excel() { }

        public Excel.ApplicationClass Rpt_ExcelApp
        {
            get { return _ExcelApp; }
            set { _ExcelApp = value; }
        }

        /// <summary>
        /// _TemplateFile
        /// </summary>
        public string TemplateFileSource {
            get { return _TemplateFile; }
            set { _TemplateFile = value; }
        }

        /// <summary>
        /// Xls File
        /// </summary>
        public string Rpt_ReportFileXls
        {
            get { return _ReportFileXls; }
            set { _ReportFileXls = value; }
        }

        /// <summary>
        /// Xls Path
        /// </summary>
        public string Rpt_ReportFilePath
        {
            get { return _ReportFilePath; }
            set { _ReportFilePath = value; }
        }

        /// <summary>
        /// Export Xls Path
        /// </summary>
        public string Rpt_ReportExportFilePath
        {
            get { return _Rpt_ReportExportFilePath; }
            set { _Rpt_ReportExportFilePath = value; }
        }

        /// <summary>
        /// Export Xls Path
        /// </summary>
        public string Rpt_ReportExportFileName
        {
            set { _Rpt_ReportExportFileName = value; }
            get { return _Rpt_ReportExportFileName; }
        }


        /// <summary>
        /// Work Sheet
        /// </summary>
        public Excel.Worksheet Rpt_WorkSheet
        {
            get { return _WorkSheet; }
            set { _WorkSheet = value; }
        }

        // Temp sheet
        public Excel.Worksheet Rpt_TempSheet
        {
            get { return _TempSheet; }
            set { _TempSheet = value; }
        }

        /// <summary>
        /// Work Book
        /// </summary>
        public Excel.Workbook Rpt_WorkBook
        {
            get { return _WorkBook; }
            set { _WorkBook = value; }
        }

        /// <summary>
        /// Open Excel file
        /// </summary>
        /// <param name="iSheets"></param>
        /// <returns></returns>
        public bool OpenExcelFile(int iSheets)
        {
            string fPath = Path.GetFullPath(this._ReportFilePath + this._ReportFileXls);
            FileInfo getFile = new FileInfo(fPath);
            getFile.CopyTo(_Rpt_ReportExportFilePath + _Rpt_ReportExportFileName);

            bool result = false;
            Object missing = System.Reflection.Missing.Value;
            if (System.IO.File.Exists(_Rpt_ReportExportFilePath + _Rpt_ReportExportFileName) == true)
            {
                this._WorkBook = _ExcelApp.Workbooks.Open(_Rpt_ReportExportFilePath + _Rpt_ReportExportFileName, missing, false, missing, missing,
                missing, missing, missing,missing, true, missing, missing, missing);
                this._WorkSheet = (Excel.Worksheet)_WorkBook.Sheets[iSheets];
                result = true;
            }
            return result;
        }

        //jacob
        public bool OpenExcelAndCopy_FormTemplate() {
            bool result = true;

            if (System.IO.File.Exists(_TemplateFile)) {
                FileInfo getFile = new FileInfo(_TemplateFile);
                try {
                    getFile.CopyTo(_Rpt_ReportExportFileName, true);
                } catch (Exception ex) {
                    messageString = string.Format("Create Template File: {0} ", ex.Message);
                    result = false;
                }
            } else { 
                messageString = string.Format("Template File: {0} not exist!", _TemplateFile);
                result = false;
            }           

            Object missing = System.Reflection.Missing.Value;
            if (System.IO.File.Exists(_Rpt_ReportExportFileName) && result) {
                this._WorkBook = _ExcelApp.Workbooks.Open(_Rpt_ReportExportFileName, missing, false, missing, missing,
                missing, missing, missing, missing, true, missing, missing, missing);
                this._WorkSheet = (Excel.Worksheet)_WorkBook.Sheets[1];
                this._TempSheet = (Excel.Worksheet)_WorkBook.Sheets[2];
            } else {
                messageString = string.Format("Report File: {0} not exist!", _Rpt_ReportExportFileName);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Open Excel file
        /// </summary>
        /// <param name="iSheets"></param>
        /// <returns></returns>
        public bool OpenExcelFile_II() {
            bool result = false;
            Object missing = System.Reflection.Missing.Value;
            if (System.IO.File.Exists(_Rpt_ReportExportFileName) == true) {                
                this._WorkBook = _ExcelApp.Workbooks.Open(_Rpt_ReportExportFileName, missing, false, missing, missing,
                missing, missing, missing, missing, true, missing, missing, missing);
                this._WorkSheet = (Excel.Worksheet)_WorkBook.Sheets["Payroll_Employee"];
                result = true;
            }
            return result;
        }

        public void SaveExcelFile_II() {
            this._WorkBook = this._ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            this._WorkSheet = (Excel.Worksheet)_WorkBook.ActiveSheet;
            this._WorkSheet.Name = "Employee";
        }

        /// <summary>
        /// Show Content
        /// </summary>
        public void ShowDoc()
        {
            //this._ExcelApp.DisplayFullScreen = true;
            this._ExcelApp.Visible = true;
            //this._WorkBook.PrintPreview(false);
            //this._ExcelApp.DisplayFullScreen = false;
        }

        /// <summary>
        /// GCC
        /// </summary>
        protected internal void GCCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Exit
        /// </summary>
        public void close(){
            try {
                //_WorkBook.Save();
                _WorkBook.Close(true, Rpt_ReportExportFileName, true);
                _ExcelApp.Workbooks.Close();
                _ExcelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_WorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_WorkSheet);
            }catch{
            
            }
            _WorkSheet = null;
            _WorkBook = null;
            _ExcelApp = null;

            GC.Collect();
        }

        //Jacob
        public void DeltmpSheetAndSaveAndClose() {

            try {
                _WorkBook.Save();
                _WorkBook.Saved = true;
                _WorkBook.Close(null, null, null);
                _ExcelApp.Workbooks.Close();
                _ExcelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_WorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_WorkSheet);
            } catch {
            }
            _WorkSheet = null;
            _WorkBook = null;
            _ExcelApp = null;

            GC.Collect();
        }
        public void SaveAndClose() {
            try {                
                _WorkBook.SaveAs(Rpt_ReportExportFileName, Excel.XlFileFormat.xlWorkbookNormal,   
                   null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,   
                   false, false, null, null);
                _WorkBook.Saved = true;
                _WorkBook.Close(null, null, null);
                _ExcelApp.Workbooks.Close();
                _ExcelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_WorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_WorkSheet);
            } catch {
            }
            _WorkSheet = null;
            _WorkBook = null;
            _ExcelApp = null;

            GC.Collect();

        }

        /// <summary>
        /// Release All Reference
        /// </summary>
        /// <param name="obj"></param>
        protected internal void ReleaseAllRef(Object obj)
        {
            try
            {
                while (Marshal.ReleaseComObject(obj) > 1) ;
            }
            finally
            {
                obj = null;
            }

        }

        /// <summary>
        /// Insert Row 
        /// </summary>
        /// <param name="row_index"></param>
        /// <param name="col_index"></param>
        protected void Rpt_InsertRow(int row_index, int col_index)
        {

            object MissingValue = Type.Missing;

            const int xlShiftDown = -4121;
            Excel.Range oRange = Rpt_WorkSheet.get_Range(this.Rpt_ExcelApp.Cells[row_index, col_index], this.Rpt_ExcelApp.Cells[row_index, col_index]);
            Excel.Range oRow = oRange.EntireRow;
            oRow.Insert(xlShiftDown);
        }

        /// <summary>
        /// Copy Cells
        /// </summary>
        /// <param name="row_01">Source Start Row</param>
        /// <param name="col_01">Source Start Col</param>
        /// <param name="row_02">Source End Row</param>
        /// <param name="col_02">Source End Col</param>
        /// <param name="row2_01">Destination Start Row</param>
        /// <param name="col2_01">Destination Start Col</param>
        /// <param name="row2_02">Destination End Row</param>
        /// <param name="col2_02">Destination End Col</param>
        protected void Rpt_CopyCells(int row_01, int col_01, int row_02, int col_02, int row2_01, int col2_01, int row2_02, int col2_02)
        {   
            Excel.Range range1 = Rpt_WorkSheet.get_Range(_WorkSheet.Cells[row_01, col_01],   _WorkSheet.Cells[row_02, col_02]);
            Excel.Range range2 = Rpt_TempSheet.get_Range(_TempSheet.Cells[row2_01, col2_01], _TempSheet.Cells[row2_02, col2_02]);
            range2.Copy(range1);
        }

        protected void Rpt_WorkCopyCells(int Targetrow_01, int Targetcol_01, int Targetrow_02, int Targetcol_02,
                                         int Sourcerow2_01, int Sourcecol2_01, int Sourcerow2_02, int Sourcecol2_02) {
            Excel.Range Target = Rpt_WorkSheet.get_Range(_WorkSheet.Cells[Targetrow_01, Targetcol_01], _WorkSheet.Cells[Targetrow_02, Targetcol_02]);
            Excel.Range Source = Rpt_WorkSheet.get_Range(_WorkSheet.Cells[Sourcerow2_01, Sourcecol2_01], _WorkSheet.Cells[Sourcerow2_02, Sourcecol2_02]);
            Source.Copy(Target);
        }


        /// <summary>
        /// Auto to Next Row
        /// </summary>
        /// <param name="row_01"></param>
        /// <param name="col_01"></param>
        /// <param name="row_02"></param>
        /// <param name="col_02"></param>
        protected void Rpt_WrapText(int row_01, int col_01, int row_02, int col_02)
        {
            Rpt_WorkSheet.get_Range(Rpt_WorkSheet.Cells[row_01, col_01], Rpt_WorkSheet.Cells[row_02, col_02]).WrapText = true;
        }

        /// <summary>
        /// Merge Cells
        /// </summary>
        /// <param name="row_01"></param>
        /// <param name="col_01"></param>
        /// <param name="row_02"></param>
        /// <param name="col_02"></param>
        protected void Rpt_Merge(int row_01, int col_01, int row_02, int col_02)
        {            
            Rpt_WorkSheet.get_Range(Rpt_WorkSheet.Cells[row_01, col_01], Rpt_WorkSheet.Cells[row_02, col_02]).Merge(true);            
        }


        // Jacob 
        protected string getCells(int row_01, int col_01) {
            Excel.Range oRange = null;
            try {
                oRange = Rpt_WorkSheet.get_Range(Rpt_WorkSheet.Cells[row_01, col_01], Rpt_WorkSheet.Cells[row_01, col_01]);
                if (oRange.Value != null)
                    return oRange.Value.ToString();
                else
                    return "";
            } catch {
                return "Error";
            }            
        }

        protected string getTmpCells(int row_01, int col_01) {
            Excel.Range oRange = Rpt_TempSheet.get_Range(_TempSheet.Cells[row_01, col_01], _TempSheet.Cells[row_01, col_01]);
            if (oRange.Value != null)
                return oRange.Value.ToString();
            else
                return "";
        }

        protected object getCells(int row_01, int col_01, int row_02, int col_02) {
            //maybe is array
            Excel.Range oRange = Rpt_WorkSheet.get_Range(this.Rpt_ExcelApp.Cells[row_01, col_01], this.Rpt_ExcelApp.Cells[row_02, col_02]);
            if (oRange.Value != null)
                return oRange.Value;
            else
                return null;
        }

        protected void setWorkFormula(int row, int col, string Formula) {            
            Excel.Range oRange = Rpt_WorkSheet.get_Range(Rpt_WorkSheet.Cells[row, col], Rpt_WorkSheet.Cells[row, col]);
            oRange.Formula = Formula;          
        }


        protected void setCelltxt(int row_01, int col_01, string txt) {
            Rpt_WorkSheet.Cells[row_01, col_01] = txt;
        }

        protected bool EOF {
            get {
                _EOF = true;
                string val = this.getCells(this.ScanEOFLine, 1) + "";
                if (val.Trim() == "") {
                    _EOF = false;                
                }
                return _EOF;
            }

        }

        protected object readLine(int endCol) {
            object obj = this.getCells(this.ScanEOFLine, 1, this.ScanEOFLine, endCol);
            this.ScanEOFLine++;
            return obj;
        }

    }
}
