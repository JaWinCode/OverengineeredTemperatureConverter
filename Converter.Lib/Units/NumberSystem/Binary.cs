namespace Converter.Lib.Units.NumberSystem
{
    internal class Binary : ConverterUnit<string>
    {
        private Binary(string value) : base(value) { }

        public override string Suffix => "bin";
        public static string Name = "Binary";

        public static implicit operator Binary(string value) => new(value);

        public static explicit operator Binary(DecimalSys inputValue) => new(ConvertDecToBin(inputValue));
        public static explicit operator Binary(Hex inputValue) => new(ConvertHexToBin(inputValue));
        public static explicit operator Binary(Octal inputValue) => new(ConvertOctToBin(inputValue));

        private static string ConvertDecToBin(DecimalSys dec) => Convert.ToString(int.Parse(dec.Value), 2);
        private static string ConvertHexToBin(Hex hex) => Convert.ToString(Convert.ToInt32(hex.Value, 16), 2);
        private static string ConvertOctToBin(Octal oct) => Convert.ToString(Convert.ToInt32(oct.Value, 8), 2);

    }
}
