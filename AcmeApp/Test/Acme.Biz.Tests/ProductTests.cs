namespace Acme.Biz.Tests {
    public class ProductTests {
        [Fact]
        public void CalculateSuggestedPriceTest()
        {
            // Arrange
            var currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;
            decimal expected = 55m;

            // Act
            decimal actual = currentProduct.CalculateSuggestedPrice(10m).result;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product_Null()
        {
            //Arrange
            Product? currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string? expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product(1, "  Steel Hammer  ", null);

            var expected = "Steel Hammer";

            //Act
            var actual = currentProduct.ProductName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product(1, "aw", null);

            string? expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product(1, "Steel Bladed Hand Saw", null);

            string? expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ProductName_JustRight()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", null);

            string expected = "Saw";
            string? expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}