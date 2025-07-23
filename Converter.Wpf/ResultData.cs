using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Converter.Wpf
{
    internal class ResultData : INotifyPropertyChanged
    {
        private string? _result;
        private List<string> _listViewColors = new()
        {
            "#229B89",
            "#E7534F",
            "#2D87B6",
            "#8A58DC"
        };
        private short _selectedListViewColorIndex = 0;
        private string _selectedColor = string.Empty;

        public ResultData()
        {
            SelectedColor = _listViewColors[_selectedListViewColorIndex % _listViewColors.Count];
            _selectedListViewColorIndex++;
        }

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

        public string SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
