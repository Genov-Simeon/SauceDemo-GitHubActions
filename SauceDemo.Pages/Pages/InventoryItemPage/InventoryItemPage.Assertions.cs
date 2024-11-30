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
    }
}
