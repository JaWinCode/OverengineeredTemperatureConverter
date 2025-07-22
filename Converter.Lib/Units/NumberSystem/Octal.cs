namespace Converter.Lib.Units.NumberSystem
{
    internal class Octal : ConverterUnit<string>
    {
        private Octal(string value) : base(value) { }

        public override string Suffix { get; } = "oct";

        public static implicit operator Octal(string value) => new(value);

        public static explicit operator Octal(DecimalSys inputValue) => new(ConvertDecToOctal(inputValue));
        public static explicit operator Octal(Binary inputValue) => new(ConvertBinToOctal(inputValue));
        public static explicit operator Octal(Hex inputValue) => new(ConvertHexToOctal(inputValue));

        private static string ConvertDecToOctal(DecimalSys dec) => Convert.ToString(int.Parse(dec.Value), 8);
        private static string ConvertBinToOctal(Binary bin) => Convert.ToString(Convert.ToInt32(bin.Value, 2), 8);
        private static string ConvertHexToOctal(Hex hex) => Convert.ToString(Convert.ToInt32(hex.Value, 16), 8);
    }
}
