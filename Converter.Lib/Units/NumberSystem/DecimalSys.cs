namespace Converter.Lib.Units.NumberSystem
{
    internal class DecimalSys : ConverterUnit<string>
    {
        private DecimalSys(string value) : base(value) { }

        public override string Suffix { get; } = "dec";

        public static implicit operator DecimalSys(string value) => new(value);

        public static explicit operator DecimalSys(Binary inputValue) => new(ConvertBinToDec(inputValue));
        public static explicit operator DecimalSys(Hex inputValue) => new(ConvertHexToDec(inputValue));
        public static explicit operator DecimalSys(Octal inputValue) => new(ConvertOctalToDec(inputValue));

        private static string ConvertBinToDec(Binary bin) => Convert.ToInt32(bin.Value, 2).ToString();
        private static string ConvertHexToDec(Hex hex) => Convert.ToInt32(hex.Value, 16).ToString();
        private static string ConvertOctalToDec(Octal oct) => Convert.ToInt32(oct.Value, 8).ToString();
    }
}
