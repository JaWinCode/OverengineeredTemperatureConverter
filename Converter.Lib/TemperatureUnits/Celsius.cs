namespace Converter.Lib.TemperatureUnits
{
    internal class Celsius : ConverterUnit
    {
        private Celsius(decimal value) : base(value) { } 

        public override string Suffix { get; } = "°C";

        public static implicit operator Celsius(decimal value) => new (value);

        public static explicit operator Celsius(Kelvin inputValue) => new (inputValue.Value - 273.15m);
        public static explicit operator Celsius(Fahrenheit inputValue) => new ((inputValue.Value - 32) * 5 / 9);
        public static explicit operator Celsius(Rankine inputValue) => new ((inputValue.Value - 491.57m) * 5 / 9);
        public static explicit operator Celsius(Reaumur inputValue) => new (inputValue.Value * 1.25m);
    }
}
