namespace Converter.Lib.Units.TemperatureUnits
{
    internal class Rankine : ConverterUnit<decimal>
    {
        private Rankine(decimal value) : base(value) { }

        public override string Suffix => "°R";
        public static string Name = "Rankine";

        public static implicit operator Rankine(decimal value) => new(value);

        public static explicit operator Rankine(Celsius inputValue) => new((inputValue.Value + 273.15m) * 1.8m);
        public static explicit operator Rankine(Kelvin inputValue) => new(inputValue.Value * 9m / 5m);
        public static explicit operator Rankine(Fahrenheit inputValue) => new(inputValue.Value + 459.67m);
        public static explicit operator Rankine(Reaumur inputValue) => new(inputValue.Value * 9m / 4m + 491.67m);
    }
}
