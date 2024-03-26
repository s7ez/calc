using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    internal class MainVM : INotifyPropertyChanged {
        public Calculator Calculator { get; private set; }
        public Config Config { get; private set; }

        public MainVM() {
            Calculator = new();
            Config = new();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new(name));
        string msg = "";
        public string Message {
            get => msg;
            set {
                if (value != msg) {
                    msg = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TestText { get; private set; } = "Test";
        public ICommand ChangeTestTextButton => new DelegateCommand(() => {
            TestText += "Test";
            Console.WriteLine("Click!");
        });
    }
}
