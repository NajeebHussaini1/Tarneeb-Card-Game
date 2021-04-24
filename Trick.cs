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
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// Class responsible for Tricks(rounds) of the game
    /// </summary>
    public class Trick : ObservableCollection<UIcard>
    {
        //ATTRIBUTES 
        private TarneebGame tarneebGame;
        private ScoreBoard scoreBoard;
        private UIcard highCard;
        private String suit;
        private bool trump;
        private String winner;
        private int position;
        private int trickNum;

        /// <summary>
        /// Constructor for the trick class 
        /// </summary>
        /// <param name="TarneebGame"></param>
        /// <param name="scoreBoard"></param>
        public Trick(TarneebGame TarneebGame, ScoreBoard scoreBoard)
        {
            tarneebGame = TarneebGame;
            TrickNum = 1;
            ScoreBoard = scoreBoard;
        }

        //ACCESSORS AND MUTATORS 
        public string Suit { get => suit; set => suit = value; }
        public bool Trump { get => trump; set => trump = value; }
        public string Winner { get => winner; set => winner = value; }
        public int Position { get => position; set => position = value; }
        public int TrickNum { get => trickNum; set => trickNum = value; }
        public UIcard HighCard { get => highCard; set => highCard = value; }
        public ScoreBoard ScoreBoard { get => scoreBoard; set => scoreBoard = value; }

        /// <summary>
        /// Add card event to the trick 
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(UIcard card)
        {
            // add card to trick
            this.Add(card);
            
            if (this.Count == 1)
            {
                // setiing the base suit for the trick based on the first card played.
                this.Suit = card.CardSuit;

            }


            
            // MessageBox.Show("card added");


            if (Count >= 4)
            {
                this.Suit = String.Empty;
                // get winner
                HighCard = GetHighCard();
                tarneebGame.DisplayTrickWinner(this.HighCard.Content1);
                //MessageBox.Show(String.Format("{0} wins this trick.", this.HighCard.Content1));

                // when trick is over, update scoreboard. add point to team.
                // update score
                /***************************************************************************/

                scoreBoard.UpdateTrickWinner(HighCard);
                this.trickNum++;

                scoreBoard.UpdateTrickNum();
                
                scoreBoard.TrickWinner(HighCard);

                //tarneebGame.UpdateTrickNumber();// GameStatus.updateTrickNum();

                /**************************************************************************/
                if (trickNum > 13)
                {
                    //end game
                    MessageBox.Show("Game Ended");
                    
                }
                tarneebGame.Wait(1000);
                tarneebGame.HideTrickWinner();
                foreach (UIcard item in this)
                {                 
                    item.Visibility = Visibility.Hidden;
                }

                this.Clear();
            }

           // MessageBox.Show(String.Format("Trick count: {0}",this.Count));
        }
        /// <summary>
        /// get high card event, compares the card values 
        /// </summary>
        /// <returns></returns>
        public UIcard GetHighCard()
        {
            UIcard tempHighCard = null;
            //HighCard
            int highVal = 0;
            foreach (UIcard item in this)
            {
                if (item.CardValue > highVal)
                {
                    highVal = item.CardValue;
                    tempHighCard = item;

                }
            }
            return tempHighCard;
            //MessageBox.Show("Trick finished.");
        }
        /// <summary>
        /// updates the score 
        /// </summary>
        public void UpdateScore()
        {
            // eg. player 2 won this trick
        }

        /* code reference:
         * https://stackoverflow.com/questions/10458118/wait-one-second-in-running-program
         * author: Savaş SERTER
         * posted: Mar 3 '19 
         */
        /// <summary>
        /// method for wait time for each player to place card 
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
        /// method for do events 
        /// </summary>
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                                  new Action(delegate { }));
        }



    }
    /// <summary>
    /// class for trick comparer 
    /// </summary>
    public class TrickComparer : IComparer<UIcard>
    {
        /// <summary>
        /// compare method 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(UIcard x, UIcard y)
        {
            return x.CardValue - y.CardValue;
        }
    }



}
