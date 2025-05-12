namespace Converter.Lib
{
    internal abstract class Converter
    {
        private protected delegate ConverterUnit ConvertCallback(ConverterUnit inputType);
        private protected abstract HashSet<ConvertCallback> ConvertCallbacks { get; }
        internal void DoConvert(ConverterUnit inputType, IOutput console)
        {
            foreach (var converterCallback in ConvertCallbacks)
            {
                console.WriteLine(converterCallback(inputType));
            }
        }
    }
}
