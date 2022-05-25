// using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}