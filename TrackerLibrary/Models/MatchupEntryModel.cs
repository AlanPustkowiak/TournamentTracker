using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// represent the id in database
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represent one team in matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represent score for the team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represtent matchup that they came to win
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
