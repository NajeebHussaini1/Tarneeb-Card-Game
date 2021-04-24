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
using TarneebSandbox;

namespace Tarneeb
{
    /// <summary>
    /// Interaction logic for _MenuPage.xaml
    /// </summary>
    public partial class _MenuPage : UserControl
    {
       
        private MainWindow Main;
        public _MenuPage(MainWindow main)
        {
           
            this.Main = main;
            // Menu Panel
            #region menu controls
            Canvas menu = new Canvas
            {
                Height = 500,
                Width = 500

            };

            // menu page background colour
            BrushConverter bc1 = new BrushConverter();
            menu.Background = (Brush)bc1.ConvertFrom("#a9eee6");

            // GAME LOGO path
            String game_logo_path = "../../CardBack/LOGOTeamAwesome.png";
            //String game_logo_path = "../../Guide/tarneebimages/tarneeblogo.png";
            //LOGOTeamAwesome.png


            // add GAME LOGO to page    
            Uri cardPathBack = new Uri(game_logo_path, UriKind.Relative);
            ImageBrush gameLogo = new ImageBrush
            {
                ImageSource = new BitmapImage(cardPathBack)
            };
            Label titleLogo = new Label
            {
                Background = gameLogo,
                Height = 200,
                Width = 200,
                Margin = new Thickness(150, 25, 0, 0)
            };


            // button to start the game
            Button startGame = new Button
            {
                Content = "Start Game",
                Height = 50,
                Width = 100,
                Margin = new Thickness(50, 250, 0, 0)
            };
            startGame.Click += new RoutedEventHandler(StartGame);


            // button to show the user guide
            Button showGuide = new Button
            {
                Content = "User Guide",
                Height = 50,
                Width = 100,
                Margin = new Thickness(200, 250, 0, 0)
            };
            showGuide.Click += new RoutedEventHandler(ShowGuide);

            // button to exit
            Button exitGame = new Button
            {
                Content = "Exit Game",
                Height = 50,
                Width = 100,
                Margin = new Thickness(350, 250, 0, 0)
            };
            exitGame.Click += new RoutedEventHandler(ExitThisGame);

            // button to show the user guide
            Button showSettings = new Button
            {
                Content = "Settings",
                Height = 50,
                Width = 100,
                Margin = new Thickness(200, 350, 0, 0)
            };
            showSettings.Click += new RoutedEventHandler(Settings);

            menu.Children.Add(exitGame);
            menu.Children.Add(showSettings);
            menu.Children.Add(startGame);
            menu.Children.Add(showGuide);
            menu.Children.Add(titleLogo);
            main.root.Children.Add(menu);

        }
        #endregion
        public void Settings(object sender, EventArgs e)
        {
            //MessageBox.Show("Settings would have gone here");
            CardBackPicker picker = new CardBackPicker();
            picker.ShowDialog();

        }

        public void ExitThisGame(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void StartGame(object sender, EventArgs e)
        {
            _ = new TarneebGame(this.Main);
        }

        public void ShowGuide(object sender, EventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow();
            guideWindow.ShowDialog();

        }


    }
}
