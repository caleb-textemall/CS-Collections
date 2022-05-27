// using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    public class VendorTests
    {
        [Fact]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            Vendor vendor = new Vendor(1, "ABC Corp", null);
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor(1, "", null);
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor(1, null, null);
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlaceOrderTest()
        {
            // Arrange
            var vendor = new Vendor(1, null, null);
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                                     "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12);

            // Assert
            Assert.Equal(expected.result, actual.result);
            Assert.Equal(expected.Message, actual.Message);
        }
        
        [Fact]
        public void PlaceOrder_3Parameters()
        {
            // Arrange
            var vendor = new Vendor(1, null, null);
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                "\r\nDeliver By: " + new DateTime(DateTime.Now.Year + 1, 10, 25).ToString("d") +
                "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(DateTime.Now.Year + 1, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            // Assert
            Assert.Equal(expected.result, actual.result);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void PlaceOrder_NullProduct_Exception()
        {
            // Arrange
            var vendor = new Vendor(1, null, null);

            // Act
            bool exceptionThrown = false;
            try {
                var actual = vendor.PlaceOrder(null, 12);
                // makes it here => did not throw exception
            } catch {
                exceptionThrown = true;
            }

            // Assert
            // Expected exception
            // want bool to be true bc we want error to be thrown
            Assert.True(exceptionThrown);
        }

        [Fact]
        public void PlaceOrder_NoDeliveryDate()
        {
            // Arrange
            var vendor = new Vendor(1, null, null);
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                        "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                        "\r\nInstructions: Deliver to Suite 42");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                                instructions: "Deliver to Suite 42");

            // Assert
            Assert.Equal(expected.result, actual.result);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void ToStringTest()
        {
            // Arrange
            var vendor = new Vendor(1, null, null);
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp (1)";

            // Act
            var actual = vendor.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendEmailTestArray() {
            // arrange
            VendorRepository vendorRepository = new VendorRepository();
            var vendors = vendorRepository.RetrieveArray();
            var expected = new List<string>() {
                "Message sent: Important message for: ABC Corp",
                "Message sent: Important message for: XYZ Inc"
            };

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            // collection assert?
        }
    }
}