using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Shapes;

namespace View.Converters
{
    internal class MineLocationVisibilityConverter : IValueConverter
    { 
        public object Mine { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            bool b = (bool)value;
            if (b)
            {
                return Mine;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
