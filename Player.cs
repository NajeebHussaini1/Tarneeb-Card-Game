/*                  GROUP 2 FINAL PROJECT : TARNEEB GAME
 * EDWARD, NAJEEBULLA, AYESHA, RAMONA, MICHAELA 
 * 2021-04-16
 * PROF: ALAADIN ADDAS 
 */
using System;
using System.Collections.Generic;
using System.Text;
using Cards;

/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// class responsible for player class
    /// </summary>
    public class Player
    {
        //ATTRIBUTES WITH ACCESSORS AND MUTATORS 
        public string name { get; set; }
        public int BidCount { get => bidCount; set => bidCount = value; }
        public string TrumpBid { get => trumpBid; set => trumpBid = value; }

        public List<UIcard> playersCards = new List<UIcard>();
        private int bidCount;
       
        private String trumpBid;

        /// <summary>
        /// Constructor for player class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="playersCards"></param>
        public Player(string name, List<UIcard> playersCards)
        {

            this.name = name;
            this.playersCards = playersCards;

           
        }

    

    }
}
