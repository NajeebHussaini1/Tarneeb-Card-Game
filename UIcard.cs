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





/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// This is UI Card class that is responsibile for each individual card on the board. 
    /// </summary>
    public class UIcard : Label
    {
        //ATTRIBUTES 
        private const int CARD_HEIGHT = 150;
        private const int CARD_WIDTH = 100;
        protected const String FACE_PATH = "../../CardFaces/";
        protected const String BACK_PATH = "../../CardBack/";

      
        private String content;                         // text to show, if needed.
        private String cardFileNameFace;                // name of card picturefile for face
        private String cardFileNameBack;                // name of card picturefile for back of card
        private int myX;                                // card position X coodinate
        private int myY;                                // card position Y coodinate
        private bool faceUp;                            // true if face up, false if facedown
        private int cardValue;                           // how many points is this card worth
        private int suit;                                // card suit value
        private bool trump;                              // is this a trump card or not
        private bool sideways;                           // player 2 and 4 have their card displayed sideways
        private String cardSuit;                        // suit string

        
        private MainWindow main;
        private TarneebGame tarneebGame;
        private ComputerPlayer computerPlayer;

        //ACCESSORS AND MUTATORS 
        public string Content1 { get => content; set => content = value; }
        public string CardFileNameFace { get => cardFileNameFace; set => cardFileNameFace = value; }
        public string CardFileNameBack { get => cardFileNameBack; set => cardFileNameBack = value; }
        public int MyX { get => myX; set => myX = value; }
        public int MyY { get => myY; set => myY = value; }
        public bool FaceUp { get => faceUp; set => faceUp = value; }
        public int CardValue { get => cardValue; set => cardValue = value; }
        public bool Trump { get => trump; set => trump = value; }
        public bool Sideways { get => sideways; set => sideways = value; }
        public int Suit { get => suit; set => suit = value; }
        public string CardSuit { get => cardSuit; set => cardSuit = value; }
        public MainWindow Main { get => main; set => main = value; }
        public TarneebGame aTarneebGame { get => tarneebGame; set => tarneebGame = value; }

        internal ComputerPlayer ComputerPlayer { get => computerPlayer; set => computerPlayer = value; }




        // Default Constructor
        public UIcard() : base()
        {
        }

        // Parameterized Constructor
        public UIcard(string content, string cardFileNameFace,
            string cardFileNameBack, int myX, int myY,
            bool faceUp, int cardValue, bool trump, 
            bool sideways, int suit, MainWindow main, 
            TarneebGame tarneebGame, ComputerPlayer computerPlayer)
            : base()
        {

            this.Content1 = content;
            this.CardFileNameFace = cardFileNameFace;
            this.CardFileNameBack = cardFileNameBack;
            this.MyX = myX;
            this.MyY = myY;
            this.Height = CARD_HEIGHT;
            this.Width = CARD_WIDTH;
            this.FaceUp = faceUp;
            this.SetBackground();
            this.Margin = new Thickness(this.MyX, this.MyY, 0, 0);
            this.cardValue = GetCardValue(cardValue);
            this.trump = trump;
            this.BorderBrush = Brushes.White;
            this.BorderThickness = new Thickness(2);
            MakeHorizontal(sideways);
            AddEvents();
            this.Suit = suit;
            this.main = main;
            aTarneebGame = tarneebGame;
            ComputerPlayer = computerPlayer;
            this.CardSuit = GetCardSuit();
        }
        /// <summary>
        /// Method to add events to the card label 
        /// </summary>
        public void AddEvents()
        {
            if (this.Content1 == "Player 1")
            {
                this.MouseLeftButtonUp += new MouseButtonEventHandler(PlayEvent);
                this.MouseEnter += new MouseEventHandler(Mouse_Hover);
                this.MouseLeave += new MouseEventHandler(Mouse_Leave);
            }

        }


        //public void RemoveEvents()
        //{
        //    this.MouseLeftButtonUp -= PlayEvent;
        //    this.MouseEnter -= Mouse_Hover;
        //    this.MouseLeave -= Mouse_Leave;
        //}

        /// <summary>
        /// method responsible for getting card suit 
        /// </summary>
        /// <returns></returns>
        public String GetCardSuit()
        {
            String thisSuit = String.Empty;
            switch (this.Suit)
            {
                case 1:
                    thisSuit = "Clubs";
                    break;

                case 2:
                    thisSuit = "Diamonds";
                    break;

                case 3:
                    thisSuit = "Hearts";
                    break;

                case 4:
                    thisSuit = "Spades";
                    break;

                default:
                    break;

            }
            return thisSuit;

        }
        /// <summary>
        /// Method that plays the event for card to be moved when picked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayEvent(object sender, EventArgs e)
        {
           
            PlayCard();
        }

        /// <summary>
        /// method that does the moving for the card that is going to be played 
        /// </summary>
        public void PlayCard()

        {
            
            UIcard card = this;
            

            switch (card.Content1)
            {
                case "Player 1":
                    this.MouseLeftButtonUp -= PlayEvent;
                    this.MouseEnter -= Mouse_Hover;
                    this.MouseLeave -= Mouse_Leave;
                    card.Margin = new Thickness(0, 0, 0, 0);
                    
                    
                    break;

                case "Player 2":
                    tarneebGame.Wait(500);
                    card.Margin = new Thickness(-200, 0, 0, 0);
                    this.FlipCard();
                   
                   this.MakeVertical();

                    break;

                case "Player 3":
                    tarneebGame.Wait(500);
                    card.Margin = new Thickness(-200, -200, 0, 0);
                    this.FlipCard();
                    

                    break;

                case "Player 4":
                    tarneebGame.Wait(500);
                    card.Margin = new Thickness(0, -200, 0, 0);
                    this.FlipCard();
                    
                    this.MakeVertical();

                    break;
                default:
                    break;

            }
            
            // for updating log. not working.
            //tarneebGame.GameDB.AddGameToLog(card.Content1, DateTime.Now, card.CardSuit, card.CardValue.ToString());
            
            
            if (CardSuit == tarneebGame.GameTrump)
            {
                cardValue += 13;
            }
            aTarneebGame.AddToTrick(card);
            if (card.Content1 == "Player 1")
            {
                aTarneebGame.NextTurn();
            }
            
        }

        /// <summary>
        /// method to make card horizontal 
        /// </summary>
        /// <param name="sideways"></param>
        public void MakeHorizontal(bool sideways)
        {
            if (sideways)
            {
                RotateTransform ninetyD = new RotateTransform(90);
                this.RenderTransform = ninetyD;
            }
            else
            {

            }
            
        }
        /// <summary>
        /// method to make it vertical 
        /// </summary>
        public void MakeVertical()
        {

                RotateTransform vert = new RotateTransform(0);
                this.RenderTransform = vert;

        }

        /// <summary>
        /// method to get card value 
        /// </summary>
        /// <param name="cardValue"></param>
        /// <returns></returns>
        public int GetCardValue(int cardValue)
        {
            if (!trump)
            {
                this.cardValue = cardValue;
            }
            else
            {
                this.cardValue = cardValue + 13;
            }
            return cardValue;

        }
        /// <summary>
        /// method for mouse hover event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Mouse_Hover(object sender, EventArgs e)
        {
            UIcard card = sender as UIcard;
            {
                Height = CARD_HEIGHT * 1.1;
                Width = CARD_WIDTH * 1.1;
                
            }
                     
        }
        /// <summary>
        /// method for mouse leave event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Mouse_Leave(object sender, EventArgs e)
        {
            UIcard card = sender as UIcard;
            card.Height = CARD_HEIGHT;
            card.Width = CARD_WIDTH;
        }


        /// <summary>
        /// method to move card 
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        public void MoveCard(int newX, int newY)
        {
            this.Margin = new Thickness(newX, newY, 0, 0);
            //Panel.SetZIndex(this, 1);
        }

        /// <summary>
        /// method to set card background 
        /// </summary>
        public void SetBackground()
        {

            if (this.faceUp)
            {

                Uri cardPathBack = new Uri(BACK_PATH + CardFileNameBack, UriKind.Relative);
                ImageBrush brushBack = new ImageBrush
                {
                    ImageSource = new BitmapImage(cardPathBack)
                };
                this.Background = brushBack;
            }
            else
            {
                Uri cardPathFace = new Uri(FACE_PATH + CardFileNameFace, UriKind.Relative);
                ImageBrush brushFace = new ImageBrush
                {
                    ImageSource = new BitmapImage(cardPathFace)
                };
                this.Background = brushFace;
            }
        }
        /// <summary>
        /// method to flip the card 
        /// </summary>
        public void FlipCard()
        {
            if (this.faceUp)
            {
                this.faceUp = false;
            }
            else
            {
                this.faceUp = true;
            }
            SetBackground();
        }


        #region operator overloads

        /// <summary>
        /// overloaded operator for ==
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator ==(UIcard card1, UIcard card2)
        {
            if (card1.cardValue == card2.cardValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// overloaded operator for !=
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator !=(UIcard card1, UIcard card2)
        {
            if (card1.cardValue != card2.cardValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// overloaded operator for >
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >(UIcard card1, UIcard card2)
        {
            if (card1.cardValue > card2.cardValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// overloaded operator for < 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator <(UIcard card1, UIcard card2)
        {
            if (card1.cardValue < card2.cardValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
