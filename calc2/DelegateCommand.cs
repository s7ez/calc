using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc2 {
    public class DelegateCommand(Action action) : ICommand {
        public Action action = action;
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) {
            //throw new NotImplementedException();
            return true;
        }

        public void Execute(object? parameter) => action();
    }
}
