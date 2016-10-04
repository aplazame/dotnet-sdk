// ReSharper disable InconsistentNaming

using System;

namespace Aplazame.BusinessModel
{
    public class Checkout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public bool toc;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Merchant merchant;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Order order;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Customer customer;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Address billing;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ShippingInfo shipping;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public object meta;

        public Checkout(bool toc, Merchant merchant, Order order, Customer customer)
        {
            this.toc = toc;

            if (null == merchant) throw new ArgumentNullException(nameof(merchant));
            this.merchant = merchant;

            if (null == order) throw new ArgumentNullException(nameof(order));
            this.order = order;

            if (null == customer) throw new ArgumentNullException(nameof(customer));
            this.customer = customer;
        }
    }
}