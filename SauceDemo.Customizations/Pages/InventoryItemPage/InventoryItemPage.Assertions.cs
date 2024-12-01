using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class InventoryItemPage
    {
        public bool IsOnProductPageByUrl(int productId)
        {
            return Driver.Url.Contains($"inventory-item.html?id={productId}");
        }

        public bool IsOnProductPageByName(string expectedProductName)
        {
            try
            {
                return ProductName.Text.Equals(expectedProductName, StringComparison.OrdinalIgnoreCase);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ValidateProductDetails(string expectedName, string expectedDescription, string expectedPrice)
        {
            Assert.AreEqual(expectedName, ProductName.Text, "Product name does not match.");
            Assert.AreEqual(expectedDescription, ProductDescription.Text, "Product description does not match.");
            Assert.AreEqual(expectedPrice, ProductPrice.Text, "Product price does not match.");
        }
    }
}
