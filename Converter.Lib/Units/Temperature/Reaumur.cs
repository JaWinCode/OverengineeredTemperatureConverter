namespace Converter.Lib.Units.TemperatureUnits
{
    internal class Reaumur : ConverterUnit<decimal>
    {
        private Reaumur(decimal value) : base(value) { }

        public override string Suffix => "°Re";
        public static string Name = "Réaumur";

        public static implicit operator Reaumur(decimal value) => new(value);

        public static explicit operator Reaumur(Celsius inputValue) => new(inputValue.Value * 4m / 5m);
        public static explicit operator Reaumur(Kelvin inputValue) => new((inputValue.Value - 273.15m) * 4m / 5m);
        public static explicit operator Reaumur(Fahrenheit inputValue) => new((inputValue.Value - 32m) * 4m / 9m);
        public static explicit operator Reaumur(Rankine inputValue) => new((inputValue.Value - 491.67m) * 4m / 9m);
    }
}
