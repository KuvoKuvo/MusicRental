using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace MusicRental.Сonverters
{
    public class DiscountConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is decimal discount)) return null;

            switch (parameter as string)
            {
                case "Color":
                    return discount > 15 ?
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E8B57")) :
                        new SolidColorBrush(Colors.Black);

                case "Decorations":
                    return discount > 15 ? TextDecorations.Underline : null;

                case "Visibility":
                    return discount > 0 ? Visibility.Visible : Visibility.Collapsed;

                default:
                    return discount;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
