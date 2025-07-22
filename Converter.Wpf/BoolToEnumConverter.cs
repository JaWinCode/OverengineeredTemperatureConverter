namespace Converter.Wpf
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    internal class BoolToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null || value == null)
                return DependencyProperty.UnsetValue;

            string enumString = parameter.ToString()!;
            return value.ToString()!.Equals(enumString, StringComparison.Ordinal);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null || value is not bool isChecked || !isChecked)
                return Binding.DoNothing;

            return Enum.Parse(targetType, parameter.ToString()!, ignoreCase: true);
        }
    }
}