namespace Converter.Lib.Units.TemperatureUnits
{
    internal class Kelvin : ConverterUnit<decimal>
    {
        private Kelvin(decimal value) : base(value) { }

        public override string Suffix { get; } = "K";

        public static implicit operator Kelvin(decimal value) => new(value);

        public static explicit operator Kelvin(Celsius inputValue) => new(inputValue.Value + 273.15m);
        public static explicit operator Kelvin(Fahrenheit inputValue) => new((inputValue.Value - 32m) * 5m / 9m + 273.15m);
        public static explicit operator Kelvin(Rankine inputValue) => new(inputValue.Value * 5m / 9m);
        public static explicit operator Kelvin(Reaumur inputValue) => new(inputValue.Value * 5m / 4m + 273.15m);
    }
}
