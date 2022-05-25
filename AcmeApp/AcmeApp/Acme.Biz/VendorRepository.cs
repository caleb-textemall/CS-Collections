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

            Console.WriteLine("vendors: " + vendors);

            return vendors;
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
    }
}
