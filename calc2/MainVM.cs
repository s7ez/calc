using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    internal class MainVM : NotifyPropertyChanged {
        public Calculator Calculator { get; private set; }
        public Config Config { get; private set; }

        public MainVM() {
            Calculator = new();
            Config = new();
        }

        public string TestText { get; private set; } = "Test";
        public ICommand ChangeTestTextButton => new DelegateCommand(() => {
            TestText += "Test";
            OnPropertyChanged(this);
            Console.WriteLine("Click!");
        });
    }
}
