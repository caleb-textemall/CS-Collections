using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        List<Vendor>? vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            string? companyName = null;
            string? email = null;
            // find email and company name

            // Create the instance of the Vendor class
            Vendor vendor = new Vendor(vendorId, companyName, email);

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        /// <summary>
        /// Retrieves all of the approved vendors
        /// </summary>
        /// <returns>list of the approved vendors</returns>
        public List<Vendor> Retrieve() {
            if (vendors == null) {
                // need to create vendor list
                vendors = new List<Vendor>();

                vendors.Add(new Vendor(1, "ABC Corp", "abc@abc.com"));
                vendors.Add(new Vendor(2, "XYZ Inc", "xyz@xyz.com"));
            }

            foreach (Vendor vendor in vendors) {
                Console.WriteLine(vendor);
            }
            
            return vendors;
        }

        /// <summary>
        /// Retrieves all of the approved vendors
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Vendor> RetrieveWithKeys() {
            Dictionary<string, Vendor> vendorsDict = new Dictionary<string, Vendor>() {
                {"ABC Corp", new Vendor(1, "ABC Corp", "abc@abc.com")},
                {"XYZ Inc", new Vendor(2, "XYZ Inc", "xyz@xyz.com")}
            };
            return vendorsDict;
        }

        public T Retrievevalue<T>(string sql, T defaultValue) {
            // call the database to retrieve the value
            // if no value is returned, return the default value
            T value = defaultValue;
            return value;
        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public List<Vendor>? RetrieveArray() { 
            return vendors;
        }

        /// <summary>
        /// Retrieves all of the approved vendors, one at a time
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> RetrieveWithIterator() {
            // get the data from the database 
            this.Retrieve();

            if (vendors == null) {
                vendors = new List<Vendor>();
            }

            foreach (var vendor in vendors) {
                Console.WriteLine($"vendor Id: {vendor.VendorId}");
                yield return vendor;
                // the yield statement returns the item then continues running the function
                // in this case, each vendor would be returned one at a time
            
                // this is referred to as deferred execution 

                // also provides lazy execution, only return one element at a time
            }
        }

        /// <summary>
        /// Retrieves all of the vendors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> RetrieveAll() {
            var vendors = new List<Vendor>() {
                { new Vendor(1, "ABC Corp", "abc@abc.com") },
                { new Vendor(2, "XYZ Inc", "xyz@xyz.com") },
                { new Vendor(12, "EFG Ltd", "efg@efg.com") },
                { new Vendor(17, "HIJ AG", "hij@hij.com") },
                { new Vendor(22, "Amalgamated Toys", "a@abc.com") },
                { new Vendor(28, "Toy Blocks Inc", "blocks@abc.com") },
                { new Vendor(31, "Home Products Inc", "home@abc.com") },
                { new Vendor(35, "Car Toys", "car@abc.com") },
                { new Vendor(42, "Toys for Fun", "fun@abc.com") }
            };

            return vendors;
        }
    }
}
