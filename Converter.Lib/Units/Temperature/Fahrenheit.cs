namespace Converter.Lib.Units.TemperatureUnits
{
    internal class Fahrenheit : ConverterUnit<decimal>
    {
        private Fahrenheit(decimal value) : base(value) { }

        public override string Suffix => "°F";
        public static string Name = "Fahrenheit";

        public static implicit operator Fahrenheit(decimal value) => new(value);

        public static explicit operator Fahrenheit(Celsius inputValue) => new(inputValue.Value * 9m / 5m + 32m);
        public static explicit operator Fahrenheit(Kelvin inputValue) => new(inputValue.Value * 9m / 5m - 459.67m);
        public static explicit operator Fahrenheit(Rankine inputValue) => new(inputValue.Value - 459.67m);
        public static explicit operator Fahrenheit(Reaumur inputValue) => new(inputValue.Value * 9m / 4m + 32m);
    }
}
