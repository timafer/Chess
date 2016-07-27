using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Label[,] squares= new Label[8, 8];
        const int boardsize= 8;
        int coloralt = 0;
        public MainWindow()
        {
            InitializeComponent();
            for (int i=0;i<boardsize;i++)
            {
                for (int o = 0; o < boardsize; o++)
                {
                    squares[o, i] = new Label();
                    board.Children.Add(squares[o, i]);
                    squares[o, i].SetValue(Grid.RowProperty, o);
                    squares[o, i].SetValue(Grid.ColumnProperty, i);
                    if (coloralt==0)
                    {
                        squares[o, i].Background = Brushes.Black;
                        coloralt++;
                    }
                    else
                    {
                        squares[o, i].Background = Brushes.White;
                        coloralt = 0;
                    }
                }
                //makes it so that the columns and rows dant all match
                if (coloralt == 0)
                {
                    coloralt++;
                }
                else
                {
                    coloralt = 0;
                }
            }
        }
    }
}
