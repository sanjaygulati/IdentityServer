using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.API.Demo.Models
{
    public class Phone
    {
        /// <summary>
        /// The Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Is a customer's preferred phone
        /// </summary>
        public bool IsPreferredPhone { get; set; }

        /// <summary>
        /// The phone's contact type
        /// </summary>
        public string ContactType { get; set; }
    }
}
