namespace Converter.Lib
{
    internal abstract class ConverterUnit<TValue>
    {
        internal ConverterUnit(TValue value)
        {
            Value = value;
        }

        internal TValue Value { get; set; }
        public abstract string Suffix { get; }
        public override string ToString() => $"{Value} {Suffix}";
    }
}
