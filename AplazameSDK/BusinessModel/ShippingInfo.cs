// ReSharper disable InconsistentNaming

using System;

namespace Aplazame.BusinessModel
{
    public class ShippingInfo : Address
    {
        /// <summary>
        /// Name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string name;

        /// <summary>
        /// Shipping price (tax is not included).
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int price;

        /// <summary>
        /// Shipping tax_rate.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? tax_rate;

        /// <summary>
        /// The discount amount of the article.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? discount;

        /// <summary>
        /// The rate discount of the article.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? discount_rate;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "name")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public ShippingInfo(string first_name, string last_name, string street, string city, string state, string country, string postcode, string name, int price) : base(first_name, last_name, street, city, state, country, postcode)
        {
            if (null == name) throw new ArgumentNullException(nameof(name));
            this.name = name;
            
            this.price = price;
        }
    }
}