using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace calc2 {
    internal class Config {
        public int Columns => 4;
        public int FontSize => 16;

        public V ButtonSize { get; private set; }
        public V GridSize { get; private set; }

        public string CalcTextMargin =>
            //"0, 64, 0, 342";
            "0, 0, 0, 0";

        public Config() {
            ButtonSize = new(FontSize * 4, (int)(FontSize * 4 * 0.75));
            GridSize = new(FontSize * FontSize, ButtonSize.Y * 5);
        }
    }
}
