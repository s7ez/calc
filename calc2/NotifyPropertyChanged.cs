using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace calc2 {
    // 試験的にクラス化
    internal class NotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged<T>(T t, [CallerMemberName] string name = "") => PropertyChanged?.Invoke(t, new(name));
    }
}

// https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8 
