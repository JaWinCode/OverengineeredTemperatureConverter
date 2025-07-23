using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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

    internal enum AllUnits
    {
        Celsius,
        Kelvin,
        Fahrenheit,
        Rankine,
        Reaumur
    }

    internal class MainWindowVM : INotifyPropertyChanged
    {

        private NumberSystemConverter _numSysConv = new NumberSystemConverter();
        private TemperatureConverter _tempConv = new TemperatureConverter();
        private ConverterTypes _converterType = ConverterTypes.Temperatur;
        private List<ResultData> _tempUnitValues;
        private List<ResultData> _numberSystemUnitValues;
        private List<ResultData> _results = new List<ResultData>();
        private ResultData? _unitOption;
        private string? _unitValueInput;
        private Visibility _hintVisibility = Visibility.Visible;
        private readonly DelegateCommand _hideHintCommand;
        private readonly DelegateCommand _showHintCommand;
        private Output _output = new();

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

            _unitOption = _results.FirstOrDefault();

            _hideHintCommand = new DelegateCommand(() => HintVisibility = Visibility.Hidden);
            _showHintCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrWhiteSpace(UnitValueInput))
                {
                    HintVisibility = Visibility.Visible;
                }
            });
        }

        public ConverterTypes ConverterType
        {
            get
            {
                return _converterType;
            }

            set
            {
                _converterType = value;
                UpdateResultList();
                OnPropertyChanged();
            }
        }

        public ResultData? UnitOption
        {
            get => _unitOption;
            set
            {
                _unitOption = value;
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

                if (IsInputValid())
                {
                    Convert();
                }
            }
        }

        public Visibility HintVisibility
        {
            get => _hintVisibility;

            set
            {
                _hintVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand HideHintCommand => _hideHintCommand;

        public ICommand ShowHintCommand => _showHintCommand;
        public List<ResultData> Results
        {
            get => _results;
            set
            {
                _results = value;
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

            UnitOption = _results.FirstOrDefault();

        }

        private bool IsInputValid()
        {
            if (_unitValueInput != null)
            {
                switch (_converterType)
                {
                    case ConverterTypes.Temperatur:
                        return Regex.IsMatch(_unitValueInput, "^[0-9,]+$");
                    case ConverterTypes.NumberSystems:
                        return Regex.IsMatch(_unitValueInput, "^[0-9]+$");
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                return false;
            }
        }

        private void Convert()
        {
            if (UnitOption != null && UnitValueInput != null && Enum.TryParse(UnitOption.UnitName, true, out AllUnits unitValueInput))
            {
                _output.OutputList.Clear();
                switch (unitValueInput)
                {
                    case AllUnits.Celsius:
                        _tempConv.DoConvert((Celsius)decimal.Parse(UnitValueInput), _output);
                        break;
                    case AllUnits.Kelvin:
                        _tempConv.DoConvert((Kelvin)decimal.Parse(UnitValueInput), _output);
                        break;
                    case AllUnits.Fahrenheit:
                        _tempConv.DoConvert((Fahrenheit)decimal.Parse(UnitValueInput), _output);
                        break;
                    case AllUnits.Rankine:
                        _tempConv.DoConvert((Rankine)decimal.Parse(UnitValueInput), _output);
                        break;
                    case AllUnits.Reaumur:
                        _tempConv.DoConvert((Reaumur)decimal.Parse(UnitValueInput), _output);
                        break;

                }

                int count = Math.Min(Results.Count, _output.OutputList.Count);

                for (int i = 0; i < count; i++)
                {
                    Results[i].Result = _output.OutputList[i];

                }

                UpdateResultList();
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

    }
}
