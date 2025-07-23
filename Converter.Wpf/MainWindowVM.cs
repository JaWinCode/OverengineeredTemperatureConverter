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
        private ResultData? _firstUnitOption;
        private string? _unitValueInput;
        private bool _isHintVisible;

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

            _firstUnitOption = _results.FirstOrDefault();
        }

        public ConverterTypes ConverterType
        {
            get 
            {
                UpdateResultList();
                return _converterType;
            }
            
            set
            {
                _converterType = value;
                OnPropertyChanged();
            }
        }

        public ResultData? GetFirstUnitOption
        {
            get => _firstUnitOption;
            set
            {
                _firstUnitOption = value;
                OnPropertyChanged();
            }
        }

        public string? UnitValueInput
        {
            get => _unitValueInput;
            set
            {
                _unitValueInput = value;
                OnPropertyChanged();

                if (!string.IsNullOrWhiteSpace(_unitValueInput))
                {
                    IsHintVisible = false;
                }
                else
                {
                    IsHintVisible = true;
                }
            }
        }

        public bool IsHintVisible
        {
            get => _isHintVisible;

            set
            {
                _isHintVisible = value;
                OnPropertyChanged();
            }
        }

        private void UpdateResultList()
        {
            switch (_converterType)
            {
                case ConverterTypes.Temperatur:
                    Results = _tempUnitValues;
                    break;
                case ConverterTypes.NumberSystems:
                    Results = _numberSystemUnitValues;
                    break;
            }
            GetFirstUnitOption = _results.FirstOrDefault();
        }

        public List<ResultData> Results 
        { 
            get => _results; 
            set { 
                OnPropertyChanged(); 
                _results = value;
            } 
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

    }
}
