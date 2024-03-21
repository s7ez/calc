using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    internal class Calc {
        public string Text { get; private set; } = "計算結果";
        public char Sign { get; private set; } = '+';

        public ICommand ButtonClear { get; private set; }

        public Calc() {
            ButtonClear = new UICommand() { proc = () => Clear() };
        }

        readonly string[] nstrs = new string[2];
        bool isN1 = true;

        public void Clear() => Text = "";

        public void Button1() {
            nstrs[isN1 ? 0 : 1] += "1";
            isN1 = !isN1;
            Text = $"{nstrs[0]}:{nstrs[1]}";
        }

        public void DoCalc() {
            Text = (double.Parse(nstrs[0]) + double.Parse(nstrs[1])).ToString();
        }
    }
}
