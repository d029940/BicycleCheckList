using System.Globalization;

namespace BicycleCheckList.Utils
{
    public class MarginLeftRightConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Thickness(System.Convert.ToDouble(value), 0, System.Convert.ToDouble(value), 0);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
