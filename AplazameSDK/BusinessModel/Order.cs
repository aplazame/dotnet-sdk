using System;
// ReSharper disable InconsistentNaming

namespace Aplazame.BusinessModel
{
    public class Order
    {
        /// <summary>
        /// Your order ID.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string id;

        /// <summary>
        /// Currency code of the order.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string currency;

        /// <summary>
        /// Order tax rate.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int tax_rate;

        /// <summary>
        /// Order total amount.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int total_amount;

        /// <summary>
        /// Articles in cart.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Article[] articles;

        /// <summary>
        /// The discount amount of the order.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? discount;

        /// <summary>
        /// The rate discount of the order.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? discount_rate;

        /// <summary>
        /// The discount amount of the cart.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? cart_discount;

        /// <summary>
        /// The rate discount of the cart.
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int? cart_discount_rate;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "rate")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "amount")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public Order(string id, string currency, int tax_rate, int total_amount, Article[] articles)
        {
            if (null == id) throw new ArgumentNullException(nameof(id));
            this.id = id;

            if (null == currency) throw new ArgumentNullException(nameof(currency));
            this.currency = currency;

            this.tax_rate = tax_rate;

            this.total_amount = total_amount;

            if (null == articles || 0 == articles.Length) throw new ArgumentException("articles must not to be empty");
            this.articles = articles;
        }
    }
}