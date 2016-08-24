using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Chess
{
    class boardsquaretodispaltcon : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Chessinconsolebecausewhy.Model.BoardSquare b = (Chessinconsolebecausewhy.Model.BoardSquare)values;
            Chessinconsolebecausewhy.Model.Piece p = (Chessinconsolebecausewhy.Model.Piece)values[0];
            bool c = (bool)values[1];
            if (p == null)
            {
                return null;
            }
            else if (p.name == "King")
            {
                if (!c)
                {
                    return  new BitmapImage(new Uri("pics/whiteking.png", UriKind.RelativeOrAbsolute)); ;
                }
                else
                {
                    return new BitmapImage(new Uri("pics/blackking.png", UriKind.RelativeOrAbsolute));
                }
            }
            else if (p.name == "Pawn")
            {
                if (!c)
                {
                    return new BitmapImage(new Uri("pics/whitepawn.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("pics/blackpawn.png", UriKind.RelativeOrAbsolute));
                }
            }
            else if (p.name == "Queen")
            {
                if (!c)
                {
                    return new BitmapImage(new Uri("pics/whitequeen.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("pics/blackqueen.png", UriKind.RelativeOrAbsolute));
                }
            }
            else if (p.name == "Rook")
            {
                if (!c)
                {
                    return new BitmapImage(new Uri("pics/whiterook.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("pics/blackrook.png", UriKind.RelativeOrAbsolute));
                }
            }
            else if (p.name == "Knight")
            {
                if (!c)
                {
                    return new BitmapImage(new Uri("pics/whiteknight.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("pics/blacknight.png", UriKind.RelativeOrAbsolute));
                }
            }
            else if (p.name == "Bishop")
            {
                if (!c)
                {
                    return new BitmapImage(new Uri("pics/whitebishop.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("pics/blackbishhop.png", UriKind.RelativeOrAbsolute));
                }
            }
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    }
