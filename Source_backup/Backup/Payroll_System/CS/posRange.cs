using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_System {
    class posRange {
        public int colStart;
        public int colEnd;
        public posRange(int pstart, int pend) {
            colStart = pstart;
            colEnd = pend;
        }
    }

    class OOtestA {
        
        public OOtestA() { }
        public OOtestA(int i) { }
        public OOtestA(string s) {
            string cc = s;
        }
        public OOtestA(string i, string s) { }

        public void printA() { }
    }
    class OOtestB : OOtestA {
        public OOtestB() { }
        public OOtestB(int i) { }
        public OOtestB(string s)
            : base("123", s) {
            string dd = s;
        }
        public void printB() {  }
    }
}
