using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.API.Demo.Models
{
    public class Contact
    {
        /// <summary>
        /// Constructs a Contact object
        /// </summary>
        public Contact()
        {
            Phones = new List<Phone>();
        }

        /// <summary>
        /// Gets or sets an enumeration of phones
        /// </summary>
        public IList<Phone> Phones { get; }

        /// <summary>
        /// Gets or sets an email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets an email address
        /// </summary>
        /// <value>
        /// The secondary email address.
        /// </value>
        public string SecondaryEmailAddress
        {
            get; set;
        }
    }
}
