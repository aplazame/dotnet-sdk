// ReSharper disable InconsistentNaming

using System;

namespace Aplazame.BusinessModel
{
    public class Customer
    {
        public const string TYPE_EXISTING = "e";
        public const string TYPE_GUEST = "g";
        public const string TYPE_NEW = "n";

        public const int GENDER_UNKNOWN = 0;
        public const int GENDER_MALE = 1;
        public const int GENDER_FEMALE = 2;
        public const int GENDER_NOT_APPLICABLE = 3;

        /// <summary>
        /// Customer ID.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string id;

        /// <summary>
        /// The customer email.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string email;

        /// <summary>
        /// Customer type, the choices are g:guest, n:new, e:existing.
        /// </summary>
        /// <see cref="Customer.TYPE_EXISTING"/>
        /// <see cref="Customer.TYPE_GUEST"/>
        /// <see cref="Customer.TYPE_NEW"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string type;

        /// <summary>
        /// Customer gender, the choices are 0: not known, 1: male, 2:female, 3: not applicable.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int gender;

        /// <summary>
        /// Customer first name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string first_name;

        /// <summary>
        /// Customer last name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string last_name;

        /// <summary>
        /// Customer birthday.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public DateTime? birthday;

        /// <summary>
        /// Customer language preferences.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string language;

        /// <summary>
        /// A datetime designating when the customer account was created.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public DateTime? date_joined;

        /// <summary>
        /// A datetime of the customer last login.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public DateTime? last_login;

        /// <summary>
        /// Customer address.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Address address;

        public Customer(string id, string email, string type, int gender)
        {
            if (null == id) throw new ArgumentNullException(nameof(id));
            this.id = id;

            if (null == email) throw new ArgumentNullException(nameof(email));
            this.email = email;

            if (null == type) throw new ArgumentNullException(nameof(type));
            this.type = type;
            
            this.gender = gender;
        }
    }
}