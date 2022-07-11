using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// represent the tournament
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// represent tournament name 
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// represent entry fee
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// represent list of teams that will compete
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        /// <summary>
        /// represent list of prizes
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// represent list of rounds in tournament
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    }
}
