namespace Converter.Wpf
{
    using System.Globalization;
    using System.Windows.Data;

    public class BoolToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum enumValue && parameter is string enumString)
            {
                return enumValue.ToString() == enumString;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue && parameter is string enumString)
            {
                return Enum.Parse(targetType, enumString);
            }
            return Binding.DoNothing;
        }
    }
}