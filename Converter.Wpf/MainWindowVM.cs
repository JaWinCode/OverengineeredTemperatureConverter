using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Converter.Wpf
{
    internal class MainWindowVM
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private Converters _mode = Converters.Temperatur;
            public Converters Converter
            {
                get => _mode;
                set { _mode = value; OnPropertyChanged(); }
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string? p = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}
