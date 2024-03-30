using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    internal class Calculator : NotifyPropertyChanged {
        public string Text { get; private set; } = "";
        public char Sign { get; private set; } = '+';
        void SetSign(char newSign) => Sign = newSign;

        readonly string[] nstrs = new string[2];
        bool isSelectedN1 = true;

        public ICommand Backspace => new DelegateCommand(() => {
            int idx = isSelectedN1 ? 1 : 0,
                len = nstrs[idx].Length;
            List<char> preList = [.. nstrs[idx]];
            preList.RemoveAt(len);
            nstrs[idx] = preList.ToString();
        });

        public ICommand ButtonClear => new DelegateCommand(() => Text = "");

        public ICommand Button1 => new DelegateCommand(() => {
            nstrs[isSelectedN1 ? 0 : 1] += "1";
            isSelectedN1 = !isSelectedN1;
            Text = string.Join(Sign, nstrs);
        });

        public ICommand DoCalculate => new DelegateCommand(() => {
            double value0 = double.Parse(nstrs[0]), value1 = double.Parse(nstrs[1]);
            double dst = Sign switch {
                '+' => value0 + value1,
                '-' => value0 - value1,
                '×' or '*' => value0 * value1,
                '÷' or '/' => value0 / value1,
                _ => throw new Exception()
            };
            Text = dst.ToString();
            OnPropertyChanged(this);
        });

        public ICommand Sum => new DelegateCommand(() => Sign = '+');
        public ICommand Sub => new DelegateCommand(() => Sign = '-');
        public ICommand Mul => new DelegateCommand(() => Sign = '×');
        public ICommand Div => new DelegateCommand(() => Sign = '÷');
    }
}
