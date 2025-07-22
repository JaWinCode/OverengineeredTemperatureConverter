namespace Converter.Lib.Units.TemperatureUnits
{
    internal class Celsius : ConverterUnit<decimal>
    {
        private Celsius(decimal value) : base(value) { }

        public override string Suffix => "°C";
        public static string Name = "Celsius";

        public static implicit operator Celsius(decimal value) => new(value);

        public static explicit operator Celsius(Kelvin inputValue) => new(inputValue.Value - 273.15m);
        public static explicit operator Celsius(Fahrenheit inputValue) => new((inputValue.Value - 32m) * 5m / 9m);
        public static explicit operator Celsius(Rankine inputValue) => new((inputValue.Value - 491.67m) * 5m / 9m);
        public static explicit operator Celsius(Reaumur inputValue) => new(inputValue.Value * 1.25m);
    }
}
