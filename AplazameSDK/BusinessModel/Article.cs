// ReSharper disable InconsistentNaming

using System;

namespace Aplazame.BusinessModel
{
    public class Article
    {
        /// <summary>
        /// The article ID.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string id;

        /// <summary>
        /// Article name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string name;

        /// <summary>
        /// Article url.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string url;

        /// <summary>
        /// Article image url.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string image_url;

        /// <summary>
        /// Article quantity.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int quantity;

        /// <summary>
        /// Article price (tax is not included).
        /// </summary>
        /// <see cref="Decimal.FromDouble"/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public int price;

        /// <summary>
        /// Article description.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string description;

        /// <summary>
        /// Article tax_rate.
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "url")]
        public Article(string id, string name, string url, string image_url, int quantity, int price)
        {
            if (null == id) throw new ArgumentNullException(nameof(id));
            this.id = id;

            if (null == name) throw new ArgumentNullException(nameof(name));
            this.name = name;

            if (null == url) throw new ArgumentNullException(nameof(url));
            this.url = url;

            if (null == image_url) throw new ArgumentNullException(nameof(image_url));
            this.image_url = image_url;

            this.quantity = quantity;

            this.price = price;
        }
    }
}