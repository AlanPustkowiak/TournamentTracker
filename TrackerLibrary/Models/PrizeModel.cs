using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// represent prize
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// represent the id in database
        /// </summary>
        public int Id { get; set; }
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

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
