using Converter.Lib.TemperatureUnits;

namespace Converter.Lib
{
    internal class TemperatureConverter : Converter
    {
        internal TemperatureConverter()
        {
            ConvertCallbacks = new HashSet<ConvertCallback>()
            {
                new ConvertCallback((inputType) => (Celsius)(dynamic)inputType),
                new ConvertCallback((inputType) => (Kelvin)(dynamic)inputType),
                new ConvertCallback((inputType) => (Fahrenheit)(dynamic) inputType),
                new ConvertCallback((inputType) => (Rankine)(dynamic)inputType),
                new ConvertCallback((inputType) => (Reaumur)(dynamic)inputType),
            };
        }

        private protected override HashSet<ConvertCallback> ConvertCallbacks { get; }
    }
}
