using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace calc2 {
    internal class Config {
        public int Columns { get; private set; } = 4;
        //public const int FontSize = 32; // プロパティ以外はだめ？
        public int FontSize { get; private set; } = 16;

        //public int ButtonWidth { get; private set; }
        //public int ButtonHeight { get; private set; }

        //public int GridWidth { get; private set; }
        //public int GridHeight { get; private set; }

        public V ButtonSize { get; private set; }
        public V GridSize { get; private set; }

        public string CalcTextMargin { get; private set; } =
            //"0, 64, 0, 342";
            "0, 0, 0, 0";

        public Config() {
            //ButtonWidth = FontSize * 4;
            //ButtonHeight = (int)(FontSize * 4 * 0.75);
            ButtonSize = new(FontSize * 4, (int)(FontSize * 4 * 0.75));

            //GridWidth = FontSize * FontSize;
            //GridHeight = FontSize * FontSize / 2;
            //GridHeight = ButtonHeight * 5;
            GridSize = new(FontSize * FontSize, ButtonSize.Y * 5);
        }
    }
}
