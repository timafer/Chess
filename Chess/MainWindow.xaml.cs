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
        Label[,] squares = new Label[8, 8];
        Image[,] im = new Image[8, 8];
        const int boardsize = 8;
        int coloralt = 0;
        Chessinconsolebecausewhy.Model.Board b;
        int fcol = -1;
        int frow = -1;
        bool fmove = false;
        public MainWindow()
        {
            b = new Chessinconsolebecausewhy.Model.Board();
            InitializeComponent();
            for (int i = 0; i < boardsize; i++)
            {
                for (int o = 0; o < boardsize; o++)
                {
                    squares[o, i] = new Label();
                    im[o, i] = new Image();
                    board.Children.Add(squares[o, i]);
                    board.Children.Add(im[o, i]);
                    squares[o, i].SetValue(Grid.RowProperty, o);
                    im[o, i].SetValue(Grid.RowProperty, o);
                    squares[o, i].SetValue(Grid.ColumnProperty, i);
                    im[o, i].SetValue(Grid.ColumnProperty, i);
                    MultiBinding bind = new MultiBinding
                    {
                        Converter = new boardsquaretodispaltcon(),
                        NotifyOnSourceUpdated = true
                    };
                    bind.Bindings.Add(new Binding("piece") { Source = b.board[i, o] });
                    bind.Bindings.Add(new Binding("iswhite") { Source = b.board[i, o] });
                    im[o, i].SetBinding(Image.SourceProperty, bind);
                    im[o, i].MouseLeftButtonDown += lb_click;
                    im[o, i].MouseRightButtonDown += rb_click;
                    squares[o, i].MouseRightButtonDown += rb_click;
                    squares[o, i].MouseLeftButtonDown += lb_click;
                    if (coloralt == 0)
                    {
                        squares[o, i].Background = Brushes.Tan;
                        coloralt++;
                    }
                    else
                    {
                        squares[o, i].Background = Brushes.Wheat;
                        coloralt = 0;
                    }
                    im[o, i].Visibility = Visibility.Visible;
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
            movablepices();
        }
        public void start()
        {


        }
        public void lb_click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            if (sender.GetType() == typeof(Image))
            {
                Image ob = (Image)sender;
                x = Grid.GetColumn(ob);
                y = Grid.GetRow(ob);
            }
            else
            {
                Label ob = (Label)sender;
                x = Grid.GetColumn(ob);
                y = Grid.GetRow(ob);
            }
            if (!fmove)
            {
                if (b.board[x, y].piece != null)
                {
                    if (b.board[x, y].iswhite != b.iswhiteturn)
                    {
                        fmove = true;
                        frow = y;
                        fcol = x;
                        picemoves();
                        for (int i=0;i<8;i++)
                        {
                            for (int o = 0; o < 8; o++)
                            {
                                foreach(model.xy xy in b.board[x, y].piece.moves)
                                {
                                    if (xy.x==o&&xy.y==i)
                                    {
                                        squares[i, o].BorderBrush = Brushes.Maroon;
                                        squares[i, o].BorderThickness = new Thickness(1.5);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (b.board[x, y].piece != null)
                {
                    if (b.capture(fcol, frow, x, y))
                    {
                        fmove = false;
                        move.Content += "" + (char)(frow+65) + "" + (fcol+1) + " " + (char)(y+65) + "" + (x+1) + "*\n";
                        recolorboard();
                        movablepices();
                    }
                }
                else
                {
                    if (b.move(fcol, frow, x, y))
                    {
                        fmove = false;
                        string history = (string)move.Content;
                        move.Content = "" + (char)(frow+65) + "" + (fcol+1) + " " + (char)(y+65) + "" + (x+1)+"\n";
                        move.Content += history;
                        recolorboard();
                        movablepices();
                    }

                }
            }
        }
        public void rb_click(object sender, EventArgs e)
        {
            fmove = false;
            recolorboard();
        }
        public void recolorboard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    squares[i, o].BorderThickness = new Thickness(0);
                }
            }
        }
        public void movablepices()
        {
            pos.Content = "";
            int count = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    if (b.board[o, i].iswhite != b.iswhiteturn && b.board[o, i].piece != null)
                    {
                        if (b.board[o, i].piece.moves.Count != 0)
                        {
                            pos.Content += count + ":" + (char)(i + 65) + "" + (o+1) + "\n";
                            count++;
                        }
                    }
                }
            }
        }
        public void picemoves()
        {
            pos.Content = "";
            int count = 1;
           foreach(Chess.model.xy xy in b.board[fcol, frow].piece.moves)
            {
               
                            pos.Content += count + ":" + (char)(xy.y + 65) + "" + (xy.x+1) + "\n";
                            count++;

            }
            
        }
    }
}
