namespace Converter.Lib
{
    internal abstract class ConverterUnit
    {
        internal ConverterUnit(decimal value)
        {
            Value = value;
        }

        internal decimal Value { get; set; }
        public abstract string Suffix { get; }
        public override string ToString() => $"{Value} {Suffix}";
    }
}
