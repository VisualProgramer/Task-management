using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TaskManagement.Converter
{
    public class PriorityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (int)value;

            try
            {
                switch (priority)
                {
                    case 1:
                        return new SolidColorBrush(Colors.BlueViolet);
                        break;
                    case 2:
                        return new SolidColorBrush(Colors.Turquoise);
                        break;
                    case 3:
                        return new SolidColorBrush(Colors.Salmon);
                        break;
                    default: return new SolidColorBrush(Colors.Black);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
