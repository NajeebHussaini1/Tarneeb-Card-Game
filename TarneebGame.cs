/*                  GROUP 2 FINAL PROJECT : TARNEEB GAME
 * EDWARD, NAJEEBULLA, AYESHA, RAMONA, MICHAELA 
 * 2021-04-16
 * PROF: ALAADIN ADDAS 
 */
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
using System.Windows.Threading;
using System.Threading;
using TarneebSandbox;

/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// class responsible for the whole tarneeb game being played and implemented 
    /// </summary>
    public class TarneebGame
    {
        //ATTRIBUTES 
        private static _Board gameBoard;
        private static DealCards dealCards;
        private static MainWindow main;
        private static TarneebGame _instance;
        private static ComputerPlayer computerPlayer;
        private static ScoreBoard scoreBoard;
        private static BidCollector collector;
        private static Trick currentTrick;
        private Gameplay_db gameDB;

        // setting strings

        private static String bidTrump;
        private static int bidTricks;
        private String currentTrickSuit;
        private String gameTrump;

        //ACCESSORS AND MUTATORS 
        public static ScoreBoard ScoreBoard { get => scoreBoard; set => scoreBoard = value; }
        public static string BidTrump { get => bidTrump; set => bidTrump = value; }
        public static int BidTricks { get => bidTricks; set => bidTricks = value; }
        public static BidCollector Collector { get => collector; set => collector = value; }
        public string CurrentTrickSuit { get => currentTrickSuit; set => currentTrickSuit = value; }
        public static Trick CurrentTrick { get => currentTrick; set => currentTrick = value; }
        public string GameTrump { get => gameTrump; set => gameTrump = value; }
        internal Gameplay_db GameDB { get => gameDB; set => gameDB = value; }




        // Singleton pattern to prevent duplicate instances of the game.
        public static TarneebGame GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TarneebGame(main);
            }
            return _instance;
        }

        // constructor
        public TarneebGame(MainWindow Main)
        {

            main = Main;

            ScoreBoard = new ScoreBoard();
            gameBoard = new _Board();
            GameDB = new Gameplay_db();


            CurrentTrick = new Trick(this, ScoreBoard);

            dealCards = new DealCards(main, this);

            gameBoard.gbRoot.Children.Add(ScoreBoard);

            main.WindowState = WindowState.Maximized;
            StartGame();

        }
        /// <summary>
        /// Method to allow bidding at start of game 
        /// </summary>
        public void Bidding()
        {
            Collector = new BidCollector();
            Collector.ShowDialog();

            MessageBox.Show(String.Format("Trump is: {0} and the bid is {1}", Collector.trump, Collector.bid));
            this.SetWinningBid(Collector.trump, Collector.bid);

        }
        /// <summary>
        /// method to set winning bid 
        /// </summary>
        /// <param name="trump"></param>
        /// <param name="bid"></param>
        public void SetWinningBid(String trump, int bid)
        {
            this.GameTrump = trump;

            ScoreBoard.SetTrump(trump);
            ScoreBoard.SetBid(bid);

        }
        /// <summary>
        /// method to start the game that implements everything 
        /// </summary>
        public void StartGame()
        {
            
            main.root.Children.Add(gameBoard);

            // generating hands for each player
            Player player1 = new Player("Player 1", dealCards.p1);
            Player player2 = new Player("Player 2", dealCards.p2);
            Player player3 = new Player("Player 3", dealCards.p3);
            Player player4 = new Player("Player 4", dealCards.p4);


            computerPlayer = new ComputerPlayer(player2, player3, player4, "Easy", this);

            dealCards.ComputerPlayer = computerPlayer;
            // adding hands to gameboard
            // PLAYER 1
            foreach (UIcard card in player1.playersCards)
            {
                gameBoard.gbRoot.Children.Add(card);
            }
            // PLAYER 2
            foreach (UIcard card in player2.playersCards)
            {
                gameBoard.gbRoot.Children.Add(card);
            }
            // PLAYER 3
            foreach (UIcard card in player3.playersCards)
            {
                gameBoard.gbRoot.Children.Add(card);
            }
            // PLAYER 4
            foreach (UIcard card in player4.playersCards)
            {
                gameBoard.gbRoot.Children.Add(card);
            }

            Bidding();


            // start a trick

            // calculate score

            // update scoreboard


        }
        /// <summary>
        /// method for next turn for each computer player 
        /// </summary>
        public void NextTurn()
        {
            computerPlayer.PlayCards();

        }
        /// <summary>
        /// method to add card to trick 
        /// </summary>
        /// <param name="card"></param>
        public void AddToTrick(UIcard card)
        {
            CurrentTrick.AddCard(card);
        }
        /// <summary>
        /// method that gets trick suit 
        /// </summary>
        /// <returns></returns>
        public String GetTrickSuit()
        {
            return CurrentTrick.Suit;
        }
        /// <summary>
        /// method that displays the trick winner 
        /// </summary>
        /// <param name="winner"></param>
        public void DisplayTrickWinner(String winner)
        {
            //gameBoard.lblTrickWinner.Visibility = Visibility.Visible;
            gameBoard.lblTrickWinner.Content = String.Format("Trick winner is: {0}", winner);
        }
        /// <summary>
        /// Method used to hide the trick winner 
        /// </summary>
        public void HideTrickWinner()
        {
            gameBoard.lblTrickWinner.Content = "";
            //gameBoard.lblTrickWinner.Visibility = Visibility.Hidden;
        }

        /* code reference:
 * https://stackoverflow.com/questions/10458118/wait-one-second-in-running-program
 * author: Savaş SERTER
 * posted: Mar 3 '19 
 */
        /// <summary>
        /// method for the wait time for each player to play 
        /// </summary>
        /// <param name="time"></param>
        public void Wait(int time)
        {
            Thread thread = new Thread(delegate ()
            {
                System.Threading.Thread.Sleep(time);
            });
            thread.Start();
            while (thread.IsAlive)

                DoEvents();
        }
        /* code reference:
         * https://stackoverflow.com/questions/4502037/where-is-the-application-doevents-in-wpf
         * author: Fredrik Hedblad
         * posted: Dec 21 '10
         * 
         */
        /// <summary>
        /// method for do event
        /// </summary>
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                                  new Action(delegate { }));
        }

    }




}
