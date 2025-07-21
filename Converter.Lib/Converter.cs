namespace Converter.Lib
{
    internal abstract class Converter<TValue>
    {
        private protected delegate ConverterUnit<TValue> ConvertCallback(ConverterUnit<TValue> inputType);
        private protected abstract HashSet<ConvertCallback> ConvertCallbacks { get; }
        internal void DoConvert(ConverterUnit<TValue> inputType, IOutput console)
        {
            foreach (var converterCallback in ConvertCallbacks)
            {
                console.WriteLine(converterCallback(inputType));
            }
        }
    }
}
