using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Customizations.Pages
{
    public partial class InventoryItemPage
    {
        private IWebElement ProductName => Driver.FindElement(By.ClassName("inventory_details_name"));
        
        private IWebElement ProductDescription => Driver.FindElement(By.XPath("//div[@data-test='inventory-item-desc']"));
        
        private IWebElement ProductPrice => Driver.FindElement(By.ClassName("inventory_details_price"));
        
        private IWebElement AddToCartButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add to cart')]"));

        private IWebElement SortDropdown => Driver.FindElement(By.ClassName("product_sort_container"));
    }
}
