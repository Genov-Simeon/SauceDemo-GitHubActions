using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutStepTwoPage
    {
        public IWebElement CheckoutSummaryTitle => Driver.FindElement(By.ClassName("title"));
        
        public IReadOnlyCollection<IWebElement> SummaryItems => Driver.FindElements(By.ClassName("cart_item"));
        
        public IWebElement SummarySubtotalLabel => Driver.FindElement(By.ClassName("summary_subtotal_label"));
        
        public IWebElement SummaryTaxLabel => Driver.FindElement(By.ClassName("summary_tax_label"));
        
        public IWebElement SummaryTotalLabel => Driver.FindElement(By.ClassName("summary_total_label"));
        
        public IWebElement FinishButton => Driver.FindElement(By.Id("finish"));
        
        public IWebElement CancelButton => Driver.FindElement(By.Id("cancel"));

        public IWebElement ItemName(string itemName) =>
            Driver.FindElement(By.XPath($"//div[contains(@class, 'inventory_item_name') and text()='{itemName}']"));
        
        public IWebElement ItemPrice(string itemName) =>
            Driver.FindElement(By.XPath($"//div[contains(@class, 'inventory_item_name') and text()='{itemName}']/ancestor::div[contains(@class, 'cart_item')]//div[@class='inventory_item_price']"));
    }
}
