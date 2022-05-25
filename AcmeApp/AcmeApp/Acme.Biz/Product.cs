using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            // var colorOptions = new string[4];
            // colorOptions[0] = "Red";
            // colorOptions[1] = "Espresso";
            // colorOptions[2] = "White";
            // colorOptions[3] = "Navy";
            // Console.WriteLine(colorOptions);

            // can also declare it like this:
            // string[] colorOptions = new string[4] {"Red", "Espresso", "White", "Navy"};

            // or like this:
            // string[] colorOptions = {"Red", "Espresso", "White", "Navy"};
        
            // List<string> colorOptions = new List<string>();
            // colorOptions.Add("Red");
            // colorOptions.Add("Espresso");
            // colorOptions.Add("White");
            // colorOptions.Add("Navy");
            // colorOptions.Insert(2, "Purple");
            // colorOptions.Remove("White");
            
            List<string> colorOptions = new List<string>() {"Red", "Espresso", "White", "Navy"};
            Console.WriteLine(colorOptions);

            // Dictionary<string, string> states = new Dictionary<string, string>();
            // states.Add("TX", "Texas");
            // states.Add("CA", "California");
            // states.Add("NY", "New York");
            // states.Add("FL", "Florida");

            Dictionary<string, string> states = new Dictionary<string, string>() {
                {"TX", "Texas"},
                {"CA", "California"},
                {"NY", "New York"},
                {"FL", "Florida"}
            };
            Console.WriteLine(states);
        }

        public Product(int productId, string productName, string? description) : this()
        {
            this.ProductId = productId;
            if (validProductName(productName)) {
                this.productName = productName;
                this.ProductName = productName;
            }
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public int ProductId { get; set; }

        private string? productName;
        public string? ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value != null && validProductName(value)) {
                    productName = value;
                }
            }
        }

        private Vendor? productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor(1, "company", "email");
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string? ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent) {
            var message = "";
            if (markupPercent <= 0m) {
                message = "Invalid markup percentage";
            } else if (markupPercent < 10) {
                message = "Below recommended markup percentage";
            }
            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResult<decimal>(value, message);
            return operationResult;
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }

        /// <summary>
        /// checks the product name input for valid length
        /// </summary>
        /// <param name="productName">name of the product being tested.</param>
        /// <returns>true if valid product name</returns>
        private bool validProductName(string productName) {
            if (productName.Length < 3) {
                ValidationMessage = "Product Name must be at least 3 characters";
            } else if (productName.Length > 20) {
                ValidationMessage = "Product Name cannot be more than 20 characters";

            } else {
                return true;  // valid name
            }
            return false;  // was invalid
        }
    }
}
