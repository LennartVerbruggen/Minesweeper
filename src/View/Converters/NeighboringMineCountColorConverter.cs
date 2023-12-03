using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    internal class NeighboringMineCountColorConverter : IValueConverter
    {
        public object One { get; set; }
        public object Two { get; set; }
        public object Three { get; set; }
        public object Four { get; set; }
        public object Five { get; set; }
        public object Six { get; set; }
        public object Seven { get; set; }
        public object Eight { get; set; }
        public object Nine { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = (int)value;

            switch (count)
            {
                case 0:
                case 1:
                    return One;
                case 2:
                    return Two;
                case 3:
                    return Three;
                case 4:
                    return Four;
                case 5:
                    return Five;
                case 6:
                    return Six;
                case 7:
                    return Seven;
                case 8:
                    return Eight;
                case 9:
                    return Nine;
                default:
                    throw new ArgumentException("Invalid argument value. Unexpected NeighboringMineCount value.", nameof(value));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
