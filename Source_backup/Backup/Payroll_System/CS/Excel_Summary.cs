using System;
using System.Collections.Generic;
using System.Text;
using Excel;
using System.Data;

namespace Payroll_System {
    class Excel_Summary : InternalLibrary.baseExport2Excel {
        public void addTitle(string txt) {
            base.Rpt_CopyCells(1, 1, 1, 1, 1, 1, 1, 11);
            setCelltxt(1, 1, txt);
        }

        public void addDeptTitle(int row, string txt_dept, string txt_people) {
            base.Rpt_CopyCells(row, 1, row, 1, 5, 1, 8, 11);
            setCelltxt(row+1, 1, txt_dept); //dept
            setCelltxt(row+2, 2, txt_people); //people
        }

        public void addLocationLine(int row, string location, string rate, string cury, string netsalary, string advance, string overadvance, string actadvance, 
                                    string diffGross, string MYRGross, string diffAct, string MYRAct) {
            base.Rpt_CopyCells(row, 1, row, 5, 9, 1, 9, 11);
            setCelltxt(row, 1, location);
            setCelltxt(row, 2, rate);
            setCelltxt(row, 3, cury);
            setCelltxt(row, 4, netsalary);
            setCelltxt(row, 5, advance);
            setCelltxt(row, 6, overadvance);
            setCelltxt(row, 7, actadvance);
            setCelltxt(row, 8, diffGross);
            setCelltxt(row, 9, MYRGross);
            setCelltxt(row, 10, diffAct);
            setCelltxt(row, 11, MYRAct);
        }

        public void addSubAmount(int row, string gross, string act) {
            base.Rpt_CopyCells(row, 1, row, 1, 10, 1, 10, 11);
            setCelltxt(row, 9, gross);
            setCelltxt(row, 11, act); 
        }

        public void addTotalMYR(int row, string gross, string act) {
            base.Rpt_CopyCells(row, 1, row, 1, 12, 1, 12, 11);
            setCelltxt(row, 9, gross);
            setCelltxt(row, 11, act);
        }

        public void addTotalPeople(int row, string people) {
            base.Rpt_CopyCells(row, 1, row, 1, 14, 1, 14, 11);
            setCelltxt(row, 5, people);
        }

        public void addSummaryTitle(int row) {
            base.Rpt_CopyCells(row, 1, row, 1, 16, 1, 17, 4);
        }

        public void addSummaryLine(int row, string company, string people, string gross) {
            base.Rpt_CopyCells(row, 1, row, 1, 18, 1, 18, 4);
            setCelltxt(row, 1, company);
            setCelltxt(row, 2, people);
            setCelltxt(row, 3, gross);
        }

        public void addSummaryFoot(int row, string people, string gross) {
            base.Rpt_CopyCells(row, 1, row, 1, 19, 1, 19, 4);
            setCelltxt(row, 2, people);
            setCelltxt(row, 3, gross);
        }

        public void addFootTitle(int row, string months) {
            base.Rpt_CopyCells(row, 1, row, 1, 21, 1, 21, 6);
            setCelltxt(row, 1, "Exchange Rate as of " + months);
        }

        public void addFootRate(int row, string txt, string val) {
            base.Rpt_CopyCells(row, 1, row, 1, 22, 1, 22, 6);
            setCelltxt(row, 1, txt + " to MYR");
            setCelltxt(row, 2, val);
        }

        
    }
}
