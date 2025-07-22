namespace Converter.Wpf
{
    internal class ResultData
    {
        public string UnitFirstLetter { get => UnitName.FirstOrDefault().ToString(); }
        public string UnitName { get; set; } = string.Empty;
        public string? Result { get; set; }
    }
}
