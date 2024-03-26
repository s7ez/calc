using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    internal class Calculator {
        public string Text { get; private set; } = "";
        public char Sign { get; private set; } = '+';

        public ICommand ButtonClear { get; private set; }
        public ICommand Button1 { get; private set; }

        public Calculator() {
            ButtonClear = new DelegateCommand(Clear);
            Button1 = new DelegateCommand(One);
        }

        readonly string[] nstrs = new string[2];
        bool isN1 = true;

        public void Clear() => Text = "";

        public void One() {
            nstrs[isN1 ? 0 : 1] += "1";
            isN1 = !isN1;
            Text += "1"; // $"{nstrs[0]}:{nstrs[1]}";
        }

        public void DoCalc() {
            Text = (double.Parse(nstrs[0]) + double.Parse(nstrs[1])).ToString();
        }
    }
}
