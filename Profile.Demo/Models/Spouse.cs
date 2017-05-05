using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.API.Demo.Models
{
    public class Spouse
    {
        /// <summary>
        /// Spouse First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Spouse Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the spouse birth date
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Gets or sets a Gender.
        /// </summary>
        public string Gender
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the business phone.
        /// </summary>
        /// <value>
        /// The business phone.
        /// </value>
        public Contact Contact
        {
            get;
            set;
        }
    }
}
