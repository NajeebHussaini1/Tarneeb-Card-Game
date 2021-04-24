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

namespace TarneebSandbox
{
    /// <summary>
    /// Interaction logic for GuideWindow.xaml
    /// </summary>
    public partial class GuideWindow : Window
    {
        public GuideWindow()
        {
            InitializeComponent();

            BrushConverter bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom("#f38181");


            this.guideFrame.Navigate(new Uri("http://teamawesome.somee.com/"));


        }
        private void CloseGuide_Click(object sender, RoutedEventArgs e)
        {
            // Window.GetWindow(this).Close();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
