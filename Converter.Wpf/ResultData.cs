using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Converter.Wpf
{
    internal class ResultData
    {
        private string? _result;
        public string UnitFirstLetter { get => UnitName.FirstOrDefault().ToString(); }
        public string UnitName { get; set; } = string.Empty;
        public string? Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
