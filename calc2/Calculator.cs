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

        public ICommand ButtonClear => new DelegateCommand(() => Text = "");

        public ICommand Button1 => new DelegateCommand(() => {
            nstrs[isN1 ? 0 : 1] += "1";
            isN1 = !isN1;
            Text += string.Join(Sign, nstrs); // "1"; // $"{nstrs[0]}:{nstrs[1]}";
        });

        readonly string[] nstrs = new string[2];
        bool isN1 = true;

        public ICommand DoCalculate => new DelegateCommand(() => {
            double value0 = double.Parse(nstrs[0]), value1 = double.Parse(nstrs[1]);
            double dst = Sign switch {
                '+' => value0 + value1,
                '-' => value0 - value1,
                '×' => value0 * value1,
                '÷' => value0 / value1,
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
