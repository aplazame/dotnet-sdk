// ReSharper disable InconsistentNaming

using System;

namespace Aplazame.BusinessModel
{
    public class Merchant
    {
        /// <summary>
        /// url that the JS client sent to confirming the order.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string confirmation_url;

        /// <summary>
        /// url that the customer is sent to if there is an error in the checkout.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string cancel_url;

        /// <summary>
        /// url that the customer is sent to after confirming their order.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string success_url;

        /// <summary>
        /// url that the customer is sent to if the customer chooses to back to the e-commerce, by default is /.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string checkout_url = "/";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "url")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public Merchant(string confirmation_url, string cancel_url, string success_url)
        {
            if (null == confirmation_url) throw new ArgumentNullException(nameof(confirmation_url));
            this.confirmation_url = confirmation_url;

            if (null == cancel_url) throw new ArgumentNullException(nameof(cancel_url));
            this.cancel_url = cancel_url;

            if (null == success_url) throw new ArgumentNullException(nameof(success_url));
            this.success_url = success_url;
        }
    }
}
