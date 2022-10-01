using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represent one person
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// represent the id in database
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The first name of the person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the person
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// address email of the person
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// phone number to the person
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
