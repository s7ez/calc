using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    public class UICommand : ICommand {
        public Action proc { get; set; }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => proc();
    }
}

// http://mikeo410.minim.ne.jp/cms/~programingseparatebuttonevent
