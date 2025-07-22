using Converter.Lib.Units.NumberSystem;

namespace Converter.Lib
{
    internal class NumberSystemConverter : Converter<string>
    {
        internal NumberSystemConverter()
        {
            ConvertCallbacks = new HashSet<ConvertCallback>()
            {
                new ConvertCallback((inputType) => (DecimalSys)(dynamic)inputType),
                new ConvertCallback((inputType) => (Binary)(dynamic)inputType),
                new ConvertCallback((inputType) => (Hex)(dynamic)inputType),
                new ConvertCallback((inputType) => (Octal)(dynamic)inputType),
            };
        }

        private protected override HashSet<ConvertCallback> ConvertCallbacks { get; }
    }
}
