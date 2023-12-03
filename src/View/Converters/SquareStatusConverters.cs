using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace View.Converters
{
    public class SquareStatusConverter : IValueConverter
    {
        public object Covered;
        public object Flagged;
        public object Mine;
        public object Uncovered;

        //Getters and setters for the different square statuses
        public object CoveredStatus
        {
            get { return Covered; }
            set { Covered = value; }
        }
        public object FlaggedStatus
        {
            get { return Flagged; }
            set { Flagged = value; }
        }
        public object MineStatus
        {
            get { return Mine; }
            set { Mine = value; }
        }
        public object UncoveredStatus
        {
            get { return Uncovered; }
            set { Uncovered = value; }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        { 
            SquareStatus status = (SquareStatus)value;

            switch (status)
            {
                case SquareStatus.Covered:
                    return Covered;
                case SquareStatus.Flagged:
                    return Flagged; 
                case SquareStatus.Mine:
                    return Mine; 
                case SquareStatus.Uncovered:
                    return Uncovered;
                default:
                    throw new NotSupportedException("Status unknown: " + status.ToString());
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Brushes.Red; 
        }
    }
    }