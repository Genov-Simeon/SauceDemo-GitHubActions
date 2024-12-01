using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CartPage
    {
        public IWebElement CartTitle => Driver.FindElement(By.ClassName("title"));
        
        public IReadOnlyCollection<IWebElement> CartItems => Driver.FindElements(By.ClassName("cart_item"));
        
        public IWebElement CheckoutButton => Driver.FindElement(By.Id("checkout"));
        
        public IWebElement ContinueShoppingButton => Driver.FindElement(By.Id("continue-shopping"));

        public IWebElement CartQuantity(string itemName) =>
            Driver.FindElement(By.XPath($"//div[contains(@class, 'inventory_item_name') and text()='{itemName}']/ancestor::div[contains(@class, 'cart_item')]//div[@class='cart_quantity']"));
        
        public IWebElement RemoveButton(string itemName) =>
            Driver.FindElement(By.XPath($"//div[contains(@class, 'inventory_item_name') and text()='{itemName}']/ancestor::div[contains(@class, 'cart_item')]//button[contains(text(),'Remove')]"));
    }
}
