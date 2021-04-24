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

/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// class that is responsible for computer player and their actions 
    /// </summary>
   public class ComputerPlayer
    {
        //ATTRIBUTES 
        public List<Player> players;
        private int heartsCount;
        private int spadesCount;
        private int clubsCount;
        private int diamondsCount;
        private String difficulty;
        private TarneebGame tarneebGame;
        private String trickSuit;


        /// <summary>
        /// Constructor for the computer player class 
        /// </summary>
        /// <param name="player2"></param>
        /// <param name="player3"></param>
        /// <param name="player4"></param>
        /// <param name="difficultyLevel"></param>
        /// <param name="TarneebGame"></param>
        public ComputerPlayer(Player player2, Player player3, Player player4, String difficultyLevel, TarneebGame TarneebGame)
        {
            tarneebGame = TarneebGame;

            players = new List<Player>();
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            difficulty = difficultyLevel;

            foreach (Player player in this.players)
            {
                SetBid(player);
                bidTrump(player);
            }
            
        }

    
        /// <summary>
        /// play cards event for computer player to move the card it picks 
        /// </summary>
        public void PlayCards()
        {
            trickSuit = tarneebGame.GetTrickSuit();
            //MessageBox.Show("trick is: " + trickSuit);

            foreach (Player player in players)
            {
                int index = DecideWhatCard(player);
                player.playersCards[index].PlayCard();
                player.playersCards.RemoveAt(index);
            }
            //roundCards.Add(player1.playersCards[count]); //BEING ABLE TO PAUSE LOOP EACH ITERATION HERE, AND GRAB VALUE THE PLAYER PICKS
            
        }
        /// <summary>
        /// method that decides which card to be put for the computer player 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int DecideWhatCard(Player player)
        {

            //int index = 0;// player.playersCards.Count - 1;

            //HARD COMPUTER SELECTION (PERFORM THIS LOOP INSTEAD WITH IF STATEMENT to check if hard is selected)
            if (difficulty == "Hard")
            {
                int LastCardOfSuit = player.playersCards.FindLastIndex(x => x.CardSuit == trickSuit);

                if (LastCardOfSuit == -1)
                {
                    int LastCardOfTrump = player.playersCards.FindLastIndex(x => x.CardSuit == tarneebGame.GameTrump);
                    if (LastCardOfTrump == -1)
                    {
                        return 0;
                    }

                    for (int i = player.playersCards.Count - 2; i >= 0; i--)
                    {
                        if (player.playersCards[i] < player.playersCards[i])
                        {
                            if (i <= player.playersCards.Count - 1 && i >= 0)
                            {
                                return i;
                            }
                        }
                    }
                }

                if (LastCardOfSuit <= player.playersCards.Count - 1 && LastCardOfSuit >= 0)
                {
                    return LastCardOfSuit;
                }


            }

            //MEDIUM COMPUTER SELECTION (PERFORM THIS INSTEAD WITH IF STATEMENT to check if medium is selected)
            if (difficulty == "Medium")
            {

                int LastCardOfSuit = player.playersCards.FindLastIndex(x => x.CardSuit == trickSuit);
                
                if (LastCardOfSuit == -1)
                {
                    for (int i = player.playersCards.Count - 2; i >= 0; i--)
                    {
                        if (player.playersCards[i] < player.playersCards[i])
                        {
                            if (i <= player.playersCards.Count - 1 && i >= 0)
                            {
                                return i;
                            }
                        }
                    }
                }

                if (LastCardOfSuit <= player.playersCards.Count - 1 && LastCardOfSuit >= 0)
                {
                    return LastCardOfSuit;
                }
                
            }

            //EASY COMPUTER SELECTION (PERFORM THIS LOOP INSTEAD WITH IF STATEMENT to check if easy is selected)
            if (difficulty == "Easy")
            {            
                int firstCardOfSuit = player.playersCards.FindIndex(x => x.CardSuit == trickSuit);

                if (firstCardOfSuit == -1)
                {
                    for (int i = player.playersCards.Count - 2; i >= 0; i--)
                    {
                        if (player.playersCards[i] > player.playersCards[i])
                        {
                            if (i <= player.playersCards.Count - 1 && i >= 0)
                            {
                                return i;
                            } 

                            
                        }
                    }
                }

                if (firstCardOfSuit <= player.playersCards.Count - 1 && firstCardOfSuit >= 0)
                {
                    return firstCardOfSuit;
                }      
                
            }
            return 0;
        }
        /// <summary>
        /// method for computer player to bid trump 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public String bidTrump(Player player)
        {
            if (clubsCount > heartsCount && clubsCount > diamondsCount && clubsCount > spadesCount)
            {
                return "Clubs";
            }
            else if (heartsCount > clubsCount && heartsCount > diamondsCount && heartsCount > spadesCount)
            {
                return "Hearts";
            }
            else if (diamondsCount > clubsCount && diamondsCount > heartsCount && diamondsCount > spadesCount)
            {
                return "Diamonds";
            }
            else
            {
                return "Spades";
            }
        }
        /// <summary>
        /// method for computer player to set bid 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int SetBid(Player player)
        {
            int bidCount = 0;

            foreach (UIcard card in player.playersCards)
            {

                switch (card.Suit)
                {
                    case 1:
                        clubsCount++;
                        break;
                    case 2:
                        diamondsCount++;
                        break;
                    case 3:
                        heartsCount++;
                        break;
                    case 4:
                        spadesCount++;
                        break;

                    default:
                        break;
                }



                if (card.CardValue >= 10)
                {
                    bidCount++;
                }

            }
            if (bidCount < 7)
            {
                // if there are less than 7 cards valued over 10 points
                //    then return min bid of 7.
                return 7;

            }
            else if (bidCount > 13)
            {
                // final bidcount
                return 13;
            }

            // final bidcount
            return bidCount;

        }


    }
}
