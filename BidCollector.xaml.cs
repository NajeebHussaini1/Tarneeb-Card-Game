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

namespace Tarneeb
{
    /// <summary>
    /// Interaction logic for BidCollector.xaml
    /// </summary>
    public partial class BidCollector : Window
    {
        public String trump = String.Empty;
        public int bid = 7;
        public BidCollector()
        {

            // BrushConverter bc = new BrushConverter();
            // this.Background = (Brush)bc.ConvertFrom("625772");

            this.Background = Brushes.CadetBlue;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            InitializeComponent();
        }

        // sets the current trump bid
        private void btnBid_Click(object sender, RoutedEventArgs e)
        {

            if (rHearts.IsChecked == true)
            {
                trump = "Hearts";
            }
            else if (rClubs.IsChecked == true)
            {
                trump = "Clubs";
            }
            else if (rDiamonds.IsChecked == true)
            {
                trump = "Diamonds";
            }
            else if (rSpades.IsChecked == true)
            {
                trump = "Spades";
            }

            bid = (int)slideBidVal.Value;

        this.Close();

        }

    }
}
