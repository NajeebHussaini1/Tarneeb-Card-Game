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
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : UserControl
    {
        private String currentBid;
        private int turn;
        private int trickNum;
        private UIcard winningCard;
        public string CurrentBid { get => currentBid; set => currentBid = value; }
        public int TrickNum { get => trickNum; set => trickNum = value; }
        public UIcard WinningCard { get => winningCard; set => winningCard = value; }
        public int Turn { get => turn; set => turn = value; }


        private int p1TrickCounter;
        private int p2TrickCounter;
        private int p3TrickCounter;
        private int p4TrickCounter;


        public ScoreBoard()
        {
            p1TrickCounter = 0;
            p2TrickCounter = 0;
            p3TrickCounter = 0;
            p4TrickCounter = 0;

            BrushConverter bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom("#a9eee6");

            InitializeComponent();

        }

        public void UpdateScores()
        {

        }
        public void TrickWinner(UIcard card)
        {
            switch (card.Content1)
            {
                case "Player 1":
                    p1TrickCounter++;
                    p1TrickCount.Content = String.Format("Player 1: {0}",p1TrickCounter);
                        break;
                case "Player 2":
                    p2TrickCounter++;
                    p2TrickCount.Content = String.Format("Player 2: {0}", p2TrickCounter);
                        break;
                case "Player 3":
                    p3TrickCounter++;
                    p3TrickCount.Content = String.Format("Player 3: {0}", p3TrickCounter);
                        break;
                case "Player 4":
                    p4TrickCounter++;
                    p4TrickCount.Content = String.Format("Player 4: {0}", p4TrickCounter);
                        break;

                default:
                        break;
            }
        }
        public void UpdateTurn()
        {
            this.Turn++;
            lblTrickNum.Content = String.Format("Trick #: {0}", Turn);
        }
        public void UpdateTrickNum()
        {
            this.trickNum++;
            lblTrickNum.Content = String.Format("Trick #: {0}", trickNum);
        }
        public void UpdateTrickWinner(UIcard card)
        {
            lblLastTrickWinner.Content = String.Format("Last Trick Winner: {0}", card.Content1);
        }

        public void SetTrump(String trumpVal)
        {
            lblTrumpVal.Content = string.Format("Trump is: {0} ", trumpVal);
        }

        public void SetBid(int bid)
        {
            lblCurrentBid.Content = string.Format("Current Bid: {0}", bid);
        }


    }
}
