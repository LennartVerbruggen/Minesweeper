using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    internal class GameStatusConverter : IValueConverter
    {

        public object Won { get; set; }
        public object Lost { get; set; }
        public object InProgress { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameStatus status = (GameStatus)value;

            switch (status)
            {
                case GameStatus.Lost:
                    return Lost;
                case GameStatus.Won:
                    return Won;
                case GameStatus.InProgress:
                    return InProgress;
                default:
                    throw new InvalidEnumArgumentException("Invalid game status");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
