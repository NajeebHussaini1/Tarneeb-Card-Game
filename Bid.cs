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
/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace Tarneeb
{
    /// <summary>
    /// bid class 
    /// </summary>
    class Bid : IEquatable<Bid>
    {
        //ATTRIBUTES 
        String playName;
        private string trumpSuit;
        private int bidNum;
        /// <summary>
        /// Constructor of the class 
        /// </summary>
        /// <param name="playName"></param>
        /// <param name="trumpSuit"></param>
        /// <param name="bidNum"></param>
        public Bid(string playName, string trumpSuit, int bidNum)
        {
            this.playName = playName;
            this.trumpSuit = trumpSuit;
            this.bidNum = bidNum;
        }
        //ACCESSORS AND MUTATORS 
        public string PlayName { get => playName; set => playName = value; }
        public string TrumpSuit { get => trumpSuit; set => trumpSuit = value; }
        public int BidNum { get => bidNum; set => bidNum = value; }


        #region Operator Overrides
        /// <summary>
        /// Equals operator ovveride 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Bid bid &&
                   playName == bid.playName &&
                   trumpSuit == bid.trumpSuit &&
                   bidNum == bid.bidNum;
        }
        /// <summary>
        /// boolean equals method 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Bid other)
        {
            return other != null &&
                   playName == other.playName &&
                   trumpSuit == other.trumpSuit &&
                   bidNum == other.bidNum;
        }
        /// <summary>
        /// overrides the gethashcode 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = -1746040354;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(playName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(trumpSuit);
            hashCode = hashCode * -1521134295 + bidNum.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// == operator overload 
        /// </summary>
        /// <param name="bid1"></param>
        /// <param name="bid2"></param>
        /// <returns></returns>
        public static bool operator ==(Bid bid1, Bid bid2)
        {
            return (bid1.BidNum == bid2.BidNum);
        }
        /// <summary>
        /// != operator overload 
        /// </summary>
        /// <param name="bid1"></param>
        /// <param name="bid2"></param>
        /// <returns></returns>
        public static bool operator !=(Bid bid1, Bid bid2)
        {
            return (bid1.BidNum != bid2.BidNum);
        }
        /// <summary>
        /// > operator overload 
        /// </summary>
        /// <param name="bid1"></param>
        /// <param name="bid2"></param>
        /// <returns></returns>
        public static bool operator >(Bid bid1, Bid bid2)
        {
            return (bid1.BidNum > bid2.BidNum);
        }
        /// <summary>
        /// < operator overload 
        /// </summary>
        /// <param name="bid1"></param>
        /// <param name="bid2"></param>
        /// <returns></returns>
        public static bool operator <(Bid bid1, Bid bid2)
        {
            return (bid1.BidNum < bid2.BidNum);
        }
        #endregion
    }
}
