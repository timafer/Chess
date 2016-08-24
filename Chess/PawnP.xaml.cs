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
using System.Windows.Shapes;

namespace Chess.pics
{
    /// <summary>
    /// Interaction logic for PawnP.xaml
    /// </summary>
    public partial class PawnP : Window
    {
        private int _i;
        public int i { get { return _i; }
            set { _i = value; } }
        public PawnP()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i=1;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            i= 0;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            i= 2;
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            i= 3;
            this.Close();
        }
    }
}
