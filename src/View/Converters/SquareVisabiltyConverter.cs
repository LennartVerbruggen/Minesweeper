using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace View.Converters
{
    public class SquareVisabiltyConverter : IValueConverter
    {

        public object Uncovered { get; set; }
        public object Covered { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SquareStatus))
            {
                throw new ArgumentException("Invalid argument type. Expected SquareStatus.", nameof(value));
            }

            var squareStatus = (SquareStatus)value;

            switch (squareStatus)
            {
                case SquareStatus.Uncovered:
                    return Uncovered;
                case SquareStatus.Covered:
                    return Covered;
                case SquareStatus.Flagged:
                    return Covered;
                case SquareStatus.Mine:
                    return Covered;

                default:
                    throw new ArgumentException("Invalid argument value. Unexpected SquareStatus value.", nameof(value));
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
