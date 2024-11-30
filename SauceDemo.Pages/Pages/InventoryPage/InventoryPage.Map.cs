using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Customizations.Pages
{
    public partial class InventoryPage
    {
        private IWebElement ShoppingCartBadge => Driver.FindElement(By.Id("shopping_cart_badge"));
        
        private IWebElement ShoppingCartLink => Driver.FindElement(By.Id("shopping_cart_link"));
        
        private IReadOnlyCollection<IWebElement> Products => Driver.FindElements(By.ClassName("inventory_item"));

        private IWebElement InventoryContainer => Driver.FindElement(By.Id("inventory_container"));

        private IWebElement GetProductContainer(string productName)
        {
            try
            {
                return Driver.FindElement(By.XPath($"//div[@class='inventory_item' and .//div[@class='inventory_item_name ' and text()='{productName}']]"));
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException($"Product with name '{productName}' could not be found.");
            }
        }

        public List<IWebElement> GetAllAddToCartButtons()
        {
            return new List<IWebElement>(Driver.FindElements(By.XPath("//button[contains(text(), 'Add to cart')]")));
        }
    }
}