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
using Tarneeb;
using System.Collections;
using Cards;


using System.IO;




namespace Tarneeb
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {


            InitializeComponent();

            Uri iconUri = new Uri("../../CardBack/awesome.png", UriKind.Relative);
            this.Icon = BitmapFrame.Create(iconUri);

            BrushConverter bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom("#b97f3f");

            this.WindowState = WindowState.Maximized;
            _ = new _MenuPage(this);





        }




    }
}




