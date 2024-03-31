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
            int idx = isSelectedN1 ? 0 : 1;
            int len = nstrs[idx].Length;
            List<char> preList = [.. nstrs[idx]];
            preList.RemoveAt(len - 1);
            nstrs[idx] = string.Join(null, preList);
        });

        public ICommand ButtonClear => new DelegateCommand(() => Text = "");

        public ICommand Button1 => new DelegateCommand(() => {
            nstrs[isSelectedN1 ? 0 : 1] += "1";
            isSelectedN1 = !isSelectedN1;
            Text = string.Join(Sign, nstrs);
        });

        public ICommand Calculate => new DelegateCommand(() => {
            double[] values = [double.Parse(nstrs[0]), double.Parse(nstrs[^1])];
            Text = (Sign switch {
                '+' => values.First() + values.Last(),
                '-' => values.First() - values.Last(),
                '×' or '*' => values.First() * values.Last(),
                '÷' or '/' => values.First() / values.Last(),
                _ => throw new Exception()
            }).ToString();
            OnPropertyChanged(this);
        });

        public ICommand Sum => new DelegateCommand(() => Sign = '+');
        public ICommand Sub => new DelegateCommand(() => Sign = '-');
        public ICommand Mul => new DelegateCommand(() => Sign = '×');
        public ICommand Div => new DelegateCommand(() => Sign = '÷');
    }
}
