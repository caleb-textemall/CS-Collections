// using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Biz.Tests
{
    public class VendorRepositoryTests
    {
        [Fact]
        public void RetrieveValueIntTest() {
            // Arrange
            VendorRepository repository = new VendorRepository();
            int expected = 42;

            // Act
            int actual = repository.Retrievevalue<int>("Select ...", 42);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveValueStringTest() {
            // Arrange
            VendorRepository repository = new VendorRepository();
            string expected = "test";

            // Act
            string actual = repository.Retrievevalue<string>("Select ...", "test");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveValueVendorTest() {
            // Arrange
            VendorRepository repository = new VendorRepository();
            Vendor vendor = new Vendor(1, null, null);
            Vendor expected = vendor;

            // Act
            Vendor actual = repository.Retrievevalue<Vendor>("Select ...", vendor);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveWithKeysTest() {
            // Arrange
            VendorRepository repository = new VendorRepository();
            Dictionary<string, Vendor> expected = new Dictionary<string, Vendor>() {
                {"ABC Corp", new Vendor(1, "ABC Corp", "abc@abc.com")},
                {"XYZ Inc", new Vendor(2, "XYZ Inc", "xyz@xyz.com")}
            };

            // Act
            Dictionary<string, Vendor> actual = repository.RetrieveWithKeys();

            // Assert
            // CollectionAssert.AreEqual(expected, actual);
        }

        [Fact]
        public void RetrieveAllTest() {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>() {
                { new Vendor(22, "Amalgamated Toys", "a@abc.com") },
                { new Vendor(28, "Toy Blocks Inc", "blocks@abc.com") },
                { new Vendor(35, "Car Toys", "car@abc.com") },
                { new Vendor(42, "Toys for Fun", "fun@abc.com") }
            };

            // Act
            var vendors = repository.RetrieveAll();
            // filtering vendors to only those with toy in the name
            // var vendorQuery = from v in vendors 
            //                   where v.CompanyName.Contains("Toy")
            //                   orderby v.CompanyName
            //                   select v;
            // this is the definition of the query

            // method linq syntax
            // var vendorQuery = vendors.Where(FilterCompanies)
            //                          .OrderBy(OrderCompaniesByName);

            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toy"))
                                     .OrderBy(v => v.CompanyName);

            // Assert
            // collection assert?
            // CollectionAssert.AreEqual(expected, vendorQuery.ToList());
            // query would be run here
            vendorQuery.ToList();
        }

        // private bool FilterCompanies(Vendor v) => v.CompanyName.Contains("Toy");

        // private string OrderCompaniesByName(Vendor v) => v.CompanyName;
    }
}