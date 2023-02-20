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
        /// represent the id in database
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// set of all teams in the match
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// the id from the database that will be used to indentify the winner.
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// The winnet of the match
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// which round is this match
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
