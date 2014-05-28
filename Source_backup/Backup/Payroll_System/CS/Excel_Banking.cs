using System;
using System.Collections.Generic;
using System.Text;
using Excel;
using System.Data;

namespace Payroll_System {
    class Excel_Banking : InternalLibrary.baseExport2Excel {
        public void addTitle(string txt) {
            base.Rpt_CopyCells(1, 1, 3, 5, 1, 1, 3, 5);
            setCelltxt(1, 1, txt);
        }

        public void addSubTitle(int row, string txt) {
            base.Rpt_CopyCells(row, 1, row, 5, 4, 1, 4, 5);
            setCelltxt(row, 1, txt);
        }

        public void addDetail(int row, string Nick, string acholder, string bank, string number, string amount) {
            base.Rpt_CopyCells(row, 1, row, 5, 5, 1, 5, 5);
            setCelltxt(row, 1, Nick);
            setCelltxt(row, 2, acholder);
            setCelltxt(row, 3, bank);
            setCelltxt(row, 4, number);
            setCelltxt(row, 5, amount);
        }

        public void addSubTotal(int row, string txt, string amount) {
            base.Rpt_CopyCells(row, 1, row, 5, 6, 1, 6, 5);
            setCelltxt(row, 1, txt);
            setCelltxt(row, 5, amount);
        }

        public void addGrand(int row, string txt) {
            base.Rpt_CopyCells(row, 1, row, 3, 7, 1, 7, 3);
            setCelltxt(row, 1, txt);
        }

        public void addGrandTotal(int row, string txt, string amount) {
            base.Rpt_CopyCells(row, 4, row, 5, 7, 4, 7, 5);
            setCelltxt(row, 4, txt);
            setCelltxt(row, 5, amount);
        }


    }
}
