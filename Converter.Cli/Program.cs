namespace Converter.Cli
{
    using Converter.Lib;
    using Converter.Lib.Units.NumberSystem;
    using Converter.Lib.Units.TemperatureUnits;

    internal class Program
    {
        public static void Main(string[] args)
        {
            new TemperatureConverter().DoConvert((Celsius)30, new Output());
            new NumberSystemConverter().DoConvert((Binary)"10", new Output());
        }
    }
}
