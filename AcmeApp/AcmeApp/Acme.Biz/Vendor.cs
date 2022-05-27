using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the approved vendors from whom Acme purchases our inventory.
    /// </summary>
    public class Vendor
    {
        public int VendorId { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }

        public Vendor(int vendorId, string? companyName, string? email) {
            VendorId = vendorId;
            CompanyName = companyName;
            Email = email;
        }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <param name="deliverBy">Requested delivery date.</param>
        /// <param name="instructions">Delivery instructions.</param>
        /// <returns></returns>
        public OperationResult<bool> PlaceOrder(Product? product, int quantity,
                                            DateTimeOffset? deliverBy = null,
                                            string instructions = "standard delivery")
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;

            var orderTextBuilder = new StringBuilder("Order from Acme, Inc" +
                            System.Environment.NewLine +
                            "Product: " + product.ProductName +
                            System.Environment.NewLine +
                            "Quantity: " + quantity);
            if (deliverBy.HasValue)
            {
                orderTextBuilder.Append( System.Environment.NewLine +
                            "Deliver By: " + deliverBy.Value.ToString("d"));
            }
            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderTextBuilder.Append( System.Environment.NewLine +
                            "Instructions: " + instructions);
            }
            var orderText = orderTextBuilder.ToString();

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);
            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }
            var operationResult = new OperationResult<bool>(success, orderText);
            return operationResult;
        }

        public override string ToString()
        {
            return $"Vendor: {this.CompanyName} ({this.VendorId})";
        }


        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }

        /// <summary>
        /// sends an email too a set of vendors. 
        /// </summary>
        /// <param name="vendors">Collection of vendors</param>
        /// <param name="message">Message to send</param>
        /// returns>list of confirmations</returns>
        // NOTE: because the type is IList, the function can take in any type of collection that implements IList
        // it's basically making an argument saying, i just need the methods that IList requires be implemented and i can do what i need to do
        public static List<string> SendEmail(IList<Vendor>? vendors, string message) {
            List<string> confirmations = new List<string>();
            EmailService emailService = new EmailService();

            if (vendors == null) {
                return confirmations;
            }

            foreach (Vendor vendor in vendors) {
                string subject = "Important message for: " + vendor.CompanyName;
                string confirmation = emailService.SendMessage(subject, message, vendor.Email);

                confirmations.Add(confirmation);
            }

            return confirmations;
        }
    }
}
