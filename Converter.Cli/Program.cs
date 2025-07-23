namespace Converter.Cli
{
    using Converter.Lib;
    using Converter.Lib.Units.NumberSystem;
    using Converter.Lib.Units.TemperatureUnits;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var output = new Output();
            new TemperatureConverter().DoConvert((Celsius)1, output);
            new NumberSystemConverter().DoConvert((Binary)"1010", output);
        }
    }
}
