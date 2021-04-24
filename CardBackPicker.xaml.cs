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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CardBackPicker : Window
    {
        private String cardBack;

        public string CardBack { get => cardBack; set => cardBack = value; }

        public CardBackPicker()
        {
          
            InitializeComponent();
            
        }

        private void generic_Click(object sender, RoutedEventArgs e)
        {
            Button sent = (Button)sender;
            switch (sent.Name)
            {
                case "btnDarkGeode":
                    CardBack = "../../CardBack/blue geode.png";
                    break;

                case "btnAbstract":
                    CardBack = "../../CardBack/Card_Back_Abstract.png"; 
                    break;

                case "btnGradient":
                    CardBack = "../../CardBack/Card_Back_Gradient.png";
                    break;

                case "btnLandscape":
                    CardBack = "../../CardBack/Card_Back_Landscape.png";
                    break;

                case "btnMountains":
                    CardBack = "../../CardBack/Card_Back_Mountains.png";
                    break;

                case "btnGreyComb":
                    CardBack = "../../CardBack/Card_Back_Pattern.png";
                    break;


                case "btnRedDiagonals":
                    CardBack = "../../CardBack/Card_Back_Red.png";
                    break;

                case "btnGreyStripes":
                    CardBack = "../../CardBack/Card_Back_Stripes.png";
                    break;

                case "btnSky":
                    CardBack = "../../CardBack/Card_Back_Sky.png";
                    break;

                case "btnLightGeode":
                    CardBack = "../../CardBack/light blue geode.png";
                    break;

                case "btnTropicalPlant":
                    CardBack = "../../CardBack/tropical_plant.png";
                    break;

                default:
                    CardBack = "../../CardBack/tropical_plant.png";
                    break;
            }
            
        }

    }
}

