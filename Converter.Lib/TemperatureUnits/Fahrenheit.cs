namespace Converter.Lib.TemperatureUnits
{
    internal class Fahrenheit : ConverterUnit
    {
        private Fahrenheit(decimal value) : base(value) { } 

        public override string Suffix { get; } = "°F";

        public static implicit operator Fahrenheit(decimal value) => new (value);

        public static explicit operator Fahrenheit(Celsius inputValue) => new ((inputValue.Value * 9 / 5) + 32);
        public static explicit operator Fahrenheit(Kelvin inputValue) => new ((inputValue.Value * 9 / 5) - 459.67m);
        public static explicit operator Fahrenheit(Rankine inputValue) => new (inputValue.Value - 459.67m);
        public static explicit operator Fahrenheit(Reaumur inputValue) => new ((inputValue.Value * 9 / 4) + 32);
    }
}
