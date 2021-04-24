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
using Cards;

/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// class responsible for dealing the cards to players 
    /// </summary>
    class DealCards
    {
        //ATTRIBUTES 
        private MainWindow main;
        private TarneebGame tarneebGame;
        private ComputerPlayer computerPlayer;
        private String cardBackFileName;     
        public string CardBackFileName { get => cardBackFileName; set => cardBackFileName = value; }
        public TarneebGame TarneebGame { get => tarneebGame; set => tarneebGame = value; }
        public ComputerPlayer ComputerPlayer { get => computerPlayer; set => computerPlayer = value; }

        public List<UIcard> p1 = new List<UIcard>();
        public List<UIcard> p2 = new List<UIcard>();
        public List<UIcard> p3 = new List<UIcard>();
        public List<UIcard> p4 = new List<UIcard>();
        /// <summary>
        /// Deal cards constructor that deals card to each player 
        /// </summary>
        /// <param name="Main"></param>
        /// <param name="tarneebGame"></param>
        public DealCards(MainWindow Main, TarneebGame tarneebGame)
        {

            this.main = Main;
            this.TarneebGame = tarneebGame;
           // this.ComputerPlayer = computerPlayer;
            this.cardBackFileName = "LOGOTeamAwesome.png";
            this.p1 = new List<UIcard>();
            this.p2 = new List<UIcard>();
            this.p3 = new List<UIcard>();
            this.p4 = new List<UIcard>();

            var deck = new Deck();

            deck.Shuffle();

            // dealing a hand to Player 1
            List<Card> handPlayer1 = deck.Sort(deck.TakeCards(13));
            p1.AddRange(DealP1(handPlayer1, cardBackFileName));


            List<Card> handPlayer2 = deck.Sort(deck.TakeCards(13));
            p2.AddRange(DealP2(handPlayer2, cardBackFileName));


            List<Card> handPlayer3 = deck.Sort(deck.TakeCards(13));
            p3.AddRange(DealP3(handPlayer3, cardBackFileName));


            List<Card> handPlayer4 = deck.Sort(deck.TakeCards(13));
            p4.AddRange(DealP4(handPlayer4, cardBackFileName));


        }
        /// <summary>
        /// gets the file name of the card 
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public String GetFileName(Card card)
        {
            String cardFileName = String.Format("{0}_of_{1}.png", card.CardNumber, card.Suit);
            return cardFileName;
        }

        /// <summary>
        /// method deals to player 1 
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="cardBack"></param>
        /// <returns></returns>
        public List<UIcard> DealP1(List<Card> hand, String cardBack)
        {
            List<UIcard> uiHand = new List<UIcard>();
            int x = -600;
            int y = 350;
            int xIncrement = 75;
            // i represents the card number for the loop
            for (int i = 0 ; i <= 12; i++ )
            {       
                uiHand.Add(new UIcard("Player 1", GetFileName(hand[i]), 
                    cardBack, x, y, 
                    false, (int)hand[i].CardNumber + 1, 
                    false, false, (int)hand[i].Suit, 
                    this.main, TarneebGame, 
                    ComputerPlayer));
                x += xIncrement;

            }
            return uiHand;
        }
        /// <summary>
        /// method that deals to player 2 
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="cardBack"></param>
        /// <returns></returns>
        public List<UIcard> DealP2(List<Card> hand, String cardBack)
        {
            List<UIcard> uiHand = new List<UIcard>();
            int x = -650;
            int y = -200;
            int yIncrement = 25;
            // i represents the card number for the loop
            for (int i = 0; i <= 12; i++)
            {
                uiHand.Add(new UIcard("Player 2", GetFileName(hand[i]), 
                    cardBack, x, y, 
                    true, (int)hand[i].CardNumber + 1, false, 
                    true, (int)hand[i].Suit,
                    this.main, TarneebGame, 
                    ComputerPlayer));
                y += yIncrement;
            }
            return uiHand;
        }
        /// <summary>
        /// method that deals to player 3 
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="cardBack"></param>
        /// <returns></returns>
        public List<UIcard> DealP3(List<Card> hand, String cardBack)
        {
            List<UIcard> uiHand = new List<UIcard>();
            int x = -300;
            int y = -600;
            int xIncrement = 25;
            // i represents the card number for the loop
            for (int i = 0; i <= 12; i++)
            {
                uiHand.Add(new UIcard("Player 3", GetFileName(hand[i]), 
                    cardBack, x, y, 
                    true, (int)hand[i].CardNumber + 1, false, 
                    false, (int)hand[i].Suit,
                    this.main,  TarneebGame, 
                    ComputerPlayer));
                x += xIncrement;
            }
            return uiHand;
        }
        /// <summary>
        /// method that deals to player 4 
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="cardBack"></param>
        /// <returns></returns>
        public List<UIcard> DealP4(List<Card> hand, String cardBack)
        {
            List<UIcard> uiHand = new List<UIcard>();
            int x = 800;
            int y = -200;
            int yIncrement = 25;
            // i represents the card number for the loop
            for (int i = 0; i <= 12; i++)
            {
                uiHand.Add(new UIcard("Player 4", GetFileName(hand[i]), 
                    cardBack, x, y, 
                    true, (int)hand[i].CardNumber + 1, false, 
                    true, (int)hand[i].Suit,
                    this.main,  TarneebGame, 
                    ComputerPlayer));
                y += yIncrement;
            }
            return uiHand;
        }




    }
}
