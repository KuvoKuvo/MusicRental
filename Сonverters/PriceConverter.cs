using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
namespace MusicRental.Сonverters
{
    public class PriceConverter : IMultiValueConverter
    {
        public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Цена и скидка 
            if (values.Length < 2 || !(values[0] is decimal price) || !(values[1] is decimal discount))
                return null;

            switch (parameter as string)
            {
                case "FinalPrice":
                    var finalPrice = price * (1 - discount / 100);
                    return finalPrice.ToString("F2");

                case "PriceVisibility":
                    return discount > 0 ? Visibility.Visible : Visibility.Collapsed;

                case "PriceForeground":
                    return discount > 0 ? Brushes.Red : Brushes.Black;

                case "PriceDecorations":
                    return discount > 0 ? TextDecorations.Strikethrough : null;

                default:
                    return price.ToString("F2");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
