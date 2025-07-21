namespace Converter.Lib.Units.NumberSystem
{
    internal class DecimalSys : ConverterUnit<string>
    {
        private DecimalSys(string value) : base(value) { }

        public override string Suffix { get; } = "dec";

        public static implicit operator DecimalSys(string value) => new(value);

        public static explicit operator DecimalSys(Binary inputValue) => new(ConvertBinToDec(inputValue));

        private static string ConvertBinToDec(Binary bin) => Convert.ToInt32(bin.Value).ToString();
    }
}
