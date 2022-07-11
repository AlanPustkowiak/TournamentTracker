using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represent one match in tournament
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// set of all teams in the match
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// winner of the match
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// which round is this match
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
