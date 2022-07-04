using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// represent prize
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// represent the number of places that can win the prize
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// represent the name of place
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// represent prize amount
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// represent percentage of prize to win
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
