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

namespace Tarneeb
{
    /// <summary>
    /// Interaction logic for _Board.xaml
    /// </summary>
    public partial class _Board : UserControl
    {
        public _Board()
        {
            InitializeComponent();

            BrushConverter bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom("#a9eee6");

            gbRoot.Children.Add(ExitButton());

            //BrushConverter bc = new BrushConverter();
            //this.Background = (Brush)bc.ConvertFrom("#625772");

            //this.Background = Brushes.FloralWhite;

        }
        private Button ExitButton()
        {
            Button btnExitGame = new Button
            {
                Width = 50,
                Height = 20,
                Background = Brushes.CadetBlue,
                Margin = new Thickness(-700, -700, 0, 0),
                Content = "Exit"
            };

            btnExitGame.Click += ExitGame_Click;

            //exitGame.BorderBrush = System.Windows.Media.Brushes.Transparent;
            //exitGame.BorderThickness = new Thickness(0);

            return btnExitGame;
        }
        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
