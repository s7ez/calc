using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc2 {
    internal class MainVM {
        public Calc Calc { get; private set; }
        public Config Config { get; private set; }

        public MainVM() {
            Calc = new();
            Config = new();
        }
    }
}
