namespace Converter.Lib.TemperatureUnits
{
    internal class Reaumur : ConverterUnit
    {
        private Reaumur(decimal value) : base(value) { } 

        public override string Suffix { get; } = "°Re";

        public static implicit operator Reaumur(decimal value) => new(value);

        public static explicit operator Reaumur(Celsius inputValue) => new (inputValue.Value * 4 / 5);
        public static explicit operator Reaumur(Kelvin inputValue) => new ((inputValue.Value - 273.15m) * 4 / 5);
        public static explicit operator Reaumur(Fahrenheit inputValue) => new ((inputValue.Value - 32) * 4 / 9);
        public static explicit operator Reaumur(Rankine inputValue) => new ((inputValue.Value - 491.67m) * 4 / 9);
    }
}
