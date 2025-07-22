using System.ComponentModel;
using System.Runtime.CompilerServices;
using Converter.Lib;
using Converter.Lib.Units.NumberSystem;
using Converter.Lib.Units.TemperatureUnits;

namespace Converter.Wpf
{
    internal enum ConverterTypes
    {
        Temperatur,
        NumberSystems
    }

    internal class MainWindowVM : INotifyPropertyChanged
    {

        private NumberSystemConverter _numSysConv = new NumberSystemConverter();
        private TemperatureConverter _tempConv = new TemperatureConverter();
        private ConverterTypes _converterType = ConverterTypes.Temperatur;
        private List<ResultData> _tempUnitValues;
        private List<ResultData> _numberSystemUnitValues;
        private List<ResultData> _results = new List<ResultData>();

        internal MainWindowVM()
        {
            _tempUnitValues = new List<ResultData>()
            {
                new ResultData() { UnitName = Celsius.Name },
                new ResultData() { UnitName =  Kelvin.Name },
                new ResultData() { UnitName =  Fahrenheit.Name },
                new ResultData() { UnitName =  Rankine.Name },
                new ResultData() { UnitName =  Reaumur.Name }
            };

            _numberSystemUnitValues = new List<ResultData>()
            {
                new ResultData() { UnitName = DecimalSys.Name },
                new ResultData() { UnitName = Binary.Name },
                new ResultData() { UnitName = Hex.Name },
                new ResultData() { UnitName = Octal.Name }
            };

            UpdateResultList();
        }

        public ConverterTypes ConverterType
        {
            get => _converterType;
            set
            {
                _converterType = value;
                UpdateResultList();
                OnPropertyChanged();
            }
        }

        private void UpdateResultList()
        {
            switch (_converterType)
            {
                case ConverterTypes.Temperatur:
                    _results = _tempUnitValues;
                    break;
                case ConverterTypes.NumberSystems:
                    _results = _numberSystemUnitValues;
                    break;
            }
        }

        public List<ResultData> Results { get => _results; set { OnPropertyChanged(); } }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

    }
}
