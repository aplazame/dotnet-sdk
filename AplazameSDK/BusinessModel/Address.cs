// ReSharper disable InconsistentNaming

using System;

namespace Aplazame.BusinessModel
{
    public class Address
    {
        /// <summary>
        /// First name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string first_name;

        /// <summary>
        /// Last name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string last_name;

        /// <summary>
        /// Street.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string street;

        /// <summary>
        /// City.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string city;

        /// <summary>
        /// State.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string state;

        /// <summary>
        /// Country code.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string country;

        /// <summary>
        /// postcode.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string postcode;

        /// <summary>
        /// Phone number.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string phone;

        /// <summary>
        /// Alternative number.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string alt_phone;

        /// <summary>
        /// Address addition.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string address_addition;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "name")]
        public Address(string first_name, string last_name, string street, string city, string state, string country, string postcode)
        {
            if (null == first_name) throw new ArgumentNullException(nameof(first_name));
            this.first_name = first_name;

            if (null == last_name) throw new ArgumentNullException(nameof(last_name));
            this.last_name = last_name;

            if (null == street) throw new ArgumentNullException(nameof(street));
            this.street = street;

            if (null == city) throw new ArgumentNullException(nameof(city));
            this.city = city;

            if (null == state) throw new ArgumentNullException(nameof(state));
            this.state = state;

            if (null == country) throw new ArgumentNullException(nameof(country));
            this.country = country;

            if (null == postcode) throw new ArgumentNullException(nameof(postcode));
            this.postcode = postcode;
        }
    }
}
