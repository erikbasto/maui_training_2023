using System.Globalization;

namespace MauiTraining.Converters;

/// <summary>
/// Price color converter based on two thresholds.
/// </summary>
public class PriceColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var precio = (decimal)value;
        if (precio >= 0 && precio <= 100)
        {
            return Colors.Green;
        }

        return Colors.Red;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

