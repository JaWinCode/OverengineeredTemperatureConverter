namespace Converter.Cli
{
    using Converter.Lib;
    using Converter.Lib.TemperatureUnits;
    internal class Program
    {
        public static void Main(string[] args)
        {
            new TemperatureConverter().DoConvert((Celsius)30, new Output());
        }
    }
}
