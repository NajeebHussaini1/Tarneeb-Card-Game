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
using System.Windows.Controls;
/// <summary>
/// cards namespace library 
/// </summary>
namespace Cards
{
    /// <summary>
    /// enums class that holds both the ranks and suits 
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// suit enum for the 4 suits 
        /// </summary>
        public enum Suit
        {
            Clubs = 1,
            Diamonds = 2,
            Hearts = 3,
            Spades = 4,
        }
        /// <summary>
        /// rank enum for card number 
        /// </summary>
        public enum CardNumber
        {
            
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jack = 10,
            Queen = 11,
            King = 12,
            Ace = 13,

        }




    }
    /// <summary>
    /// card ckass that sets rank and suit of card
    /// </summary>
    public class Card : Button
    {
        
        public Enums.Suit Suit { get; set; }
        public Enums.CardNumber CardNumber { get; set; }

        public override string ToString()
        {

            return "The Suit is: " + this.Suit + " The card number is: " + this.CardNumber;


        }
    }
    /// <summary>
    /// deck class that shuffles and contains list of cards 
    /// </summary>
    public class Deck
    {
        public Deck()
        {
            Reset();
        }

        public List<Card> Cards { get; set; }
        /// <summary>
        /// reset method that gets the deck 
        /// </summary>
        public void Reset()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                                    .Select(c => new Card()
                                    {
                                        Suit = (Enums.Suit)s,
                                        CardNumber = (Enums.CardNumber)c
                                    }
                                            )
                            )
                   .ToList();
        }
        /// <summary>
        /// shuffle method that shuffle the deck 
        /// </summary>
        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid())
                         .ToList();
        }
        /// <summary>
        /// take card method that removes when cars is taken 
        /// </summary>
        /// <returns></returns>
        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }
        /// <summary>
        /// take card method that returns a list for each player 
        /// </summary>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public List<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            //var takeCards = cards as Card[] ?? cards.ToArray();
            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }
        /// <summary>
        /// method that sorts the deck 
        /// </summary>
        /// <param name="listOfCards"></param>
        /// <returns></returns>
        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

            return sorted;

        }
    }

    //**********************************************************************






}
