using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.API.Demo.Models
{
    public class CustomerData
    {
        /// <summary>
        /// Gets or sets the Customer ID
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer's country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///  Gets or sets the country group
        /// </summary>
        public string CountryGroup { get; set; }

        /// <summary>
        /// Gets or sets the customer's country
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the customer's culture name
        /// </summary>
        public string CultureName { get; set; }

        /// <summary>
        /// Gets or sets the customer's spouse
        /// </summary>
        public Spouse Spouse { get; set; }

        /// <summary>
        /// Gets or sets the customer's gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the customer's birth date
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the customer type info
        /// </summary>
        public string CustomerTypeInfo { get; set; }

        /// <summary>
        /// Gets or sets the customer status type
        /// </summary>
        public string StatusType { get; set; }

        /// <summary>
        /// Gets or sets the customer status description
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the test customer flag
        /// </summary>
        public bool IsTestCustomer { get; set; }

        /// <summary>
        /// Customer First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a customer's contact information
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is permanent resident.
        /// </summary>
        public bool IsPermanentResident { get; set; }

        /// <summary>
        /// Gets or sets a bool representing the existence of MEPortrait customer picture.
        /// </summary>
        public bool CustomerPictureExists { get; set; }

        /// <summary>
        /// Gets or sets a the customer's occupation.
        /// </summary>
        public string CustomerOccupation { get; set; }
    }
}
