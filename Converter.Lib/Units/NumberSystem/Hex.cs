namespace Converter.Lib.Units.NumberSystem
{
    internal class Hex : ConverterUnit<string>
    {
        private Hex(string value) : base(value) { }

        public override string Suffix { get; } = "hex";

        public static implicit operator Hex(string value) => new(value);

        public static explicit operator Hex(Binary inputValue) => new(ConvertBinToHex(inputValue));
        public static explicit operator Hex(DecimalSys inputValue) => new(ConvertDecToHex(inputValue));
        public static explicit operator Hex(Octal inputValue) => new(ConvertOctalToHex(inputValue));


        private static string ConvertBinToHex(Binary bin) => Convert.ToInt32(bin.Value, 2).ToString("X");
        private static string ConvertDecToHex(DecimalSys dec) => Convert.ToInt32(dec.Value).ToString("X");
        private static string ConvertOctalToHex(Octal inputValue) => Convert.ToInt32(inputValue.Value, 8).ToString("X");
    }
}
