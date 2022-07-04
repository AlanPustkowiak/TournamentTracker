using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represent one team
    /// </summary>
    public class TeamModel
    {
        /// <summary>
        /// Represent members of the team
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
        /// <summary>
        /// represent team name
        /// </summary>
        public string TeamName { get; set; }

    }
}
