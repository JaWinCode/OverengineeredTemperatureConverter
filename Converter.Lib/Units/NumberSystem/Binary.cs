namespace Converter.Lib.Units.NumberSystem
{
    internal class Binary : ConverterUnit<string>
    {
        private Binary(string value) : base(value) { }

        public override string Suffix { get; } = "bin";

        public static implicit operator Binary(string value) => new(value);

        public static explicit operator Binary(DecimalSys inputValue) => new("100");

        private static string ConvertDecToBin(DecimalSys dec) => Convert.ToString(int.Parse(dec.Value), 2);
    }
}
