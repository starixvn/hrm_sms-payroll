using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_System {
    class Excel_Expenses : InternalLibrary.baseExport2Excel {
        public void addTitle(string txt) {
            base.Rpt_CopyCells(1, 2, 1, 12, 1, 2, 1, 12);
            setCelltxt(1, 2, txt);
        }

        public void addCompDeptTitle() {
            base.Rpt_CopyCells(3, 2, 5, 3, 3, 2, 5, 3);
        }
        
        public int addMonthsTitle(int monthCount, int posX) {
            int rightX = monthCount * 2 + 1;
            base.Rpt_CopyCells(3, 4, 5, rightX, 3, 4, 5, rightX);

            return rightX + 1;
        }

        public int addThisMonthsTitle(int posX, string _monthYear) {
            int rightX = posX + 1;
            base.Rpt_CopyCells(2, posX, 5, rightX, 2, 26, 5, 27);
            setCelltxt(2, posX, _monthYear);

            return rightX + 1;
        }

        public int addStevenTitle(int posX) {
            int rightX = posX + 1;
            base.Rpt_CopyCells(2, posX, 5, rightX, 2, 28, 5, 29);

            return rightX + 1;
        }

        public int addBankInTitle(int posX, string _method, string _location) {
            base.Rpt_CopyCells(2, posX, 5, posX, 2, 30, 5, 30);
            setCelltxt(4, posX, _method);
            setCelltxt(5, posX, _location);

            return posX + 1;
        }

        public void addTotalTitle(int posX) {
            base.Rpt_CopyCells(2, posX, 5, posX, 2, 43, 5, 43);            
        }

        public void margeColumn(int row, int startCol, int endCol) {
            int i;
            string val = base.getCells(row, startCol);
            for (i = startCol; i <= endCol; i++) {
                setCelltxt(row, i, "");
            }
            base.Rpt_Merge(row, startCol, row, endCol);
            setCelltxt(row, startCol, val);
        }

        public void addNewSpaceline(int tmpstart, int tmpend, int workRow, int workstart, int workend) {
            base.Rpt_CopyCells(workRow, workstart, workRow, workend, 6, tmpstart, 6, tmpend);
        }

        public void copyline(int SRow, int TRow, int startCol, int endCol) {
            base.Rpt_WorkCopyCells(TRow, startCol, TRow, endCol, SRow, startCol, SRow, endCol);
        }

        public void addValue_company(int row, string company, string dept) {
            setCelltxt(row, 2, company);
            setCelltxt(row, 3, dept);
        }

        public void addValue_Months(int row, int col, string people, string amount) {            
            setCelltxt(row, col, people);
            setCelltxt(row, col+1, amount);
        }

        public void addValue(int row, int col, string txt) {
            setCelltxt(row, col, txt);
        }

        public void copyFootTotal(int total_atrow, int total_lastcol) {
            base.Rpt_CopyCells(total_atrow, 2, total_atrow, total_lastcol, 7, 2, 7, total_lastcol); 
        }

        public void setFoot_D_SumFormula(int row, int fuRowStart, int fuRowEnd) {
            string Formula = string.Format("=SUM(D{0}:D{1})", fuRowStart, fuRowEnd);
            base.setWorkFormula(row, 4, Formula);
        }
        public void copyFoot_D_SumFormula(int TotalRow, int TotalStartCol, int TotalEndCol) {
            base.Rpt_WorkCopyCells(TotalRow, TotalStartCol, TotalRow, TotalEndCol, TotalRow, 4, TotalRow, 4);
        }

        public void addRateTitle(int row, int lastcol) {
            base.Rpt_CopyCells(row, 2, row , lastcol, 9, 2, 9, lastcol);
        }

        public void addRateSpaceLine(int row, int lastcol) {
            base.Rpt_CopyCells(row, 2, row, lastcol, 10, 2, 10, lastcol);
        }

        public void addRateValue(int row, string months, string rate) {
            int startCol = 5; // 1st month pos-Col
            int _month = Convert.ToInt16(months.Substring(4, 2));
            int monthsPosCol = startCol + ((_month - 1) * 2);
            setCelltxt(row, monthsPosCol, rate);
        }

    }
}
