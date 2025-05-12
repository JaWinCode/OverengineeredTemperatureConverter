namespace Converter.Lib.TemperatureUnits
{
    internal class Kelvin : ConverterUnit
    {
        private Kelvin(decimal value) : base(value) { } 

        public override string Suffix { get; } = "K";

        public static implicit operator Kelvin(decimal value) => new(value);

        public static explicit operator Kelvin(Celsius inputValue) => new (inputValue.Value + 273.15m);
        public static explicit operator Kelvin(Fahrenheit inputValue) => new ((inputValue.Value - 32) * 5 / 9 + 273.15m);
        public static explicit operator Kelvin(Rankine inputValue) => new (inputValue.Value * 5 / 9);
        public static explicit operator Kelvin(Reaumur inputValue) => new ((inputValue.Value * 5 / 4) + 273.15m);
    }
}
