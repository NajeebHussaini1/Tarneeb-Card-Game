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
    /// bidding class responsible for bidding of the players 
    /// </summary>
    class Bidding
    {
        //ATTRIBUTES 
        private BidCollector collector;
        /// <summary>
        /// Constructor of the class 
        /// </summary>
        public Bidding()
        {
            this.collector = new BidCollector();



            startBidding();


        }

        /// <summary>
        /// method that starts the bidding, opens the bidding window 
        /// </summary>
        public void startBidding()
        {
            this.collector.ShowDialog();
        }

        


    }
}
