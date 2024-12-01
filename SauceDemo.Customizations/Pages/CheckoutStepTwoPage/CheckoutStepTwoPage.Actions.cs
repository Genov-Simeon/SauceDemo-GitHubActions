using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutStepTwoPage : BasePage
    {
        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "/checkout-step-two.html")
        {
            base.Open(relativePath);
        }

        public decimal GetSubtotal()
        {
            string subtotalText = SummarySubtotalLabel.Text;

            string numericPart = subtotalText.Replace("Item total: $", "").Trim();

            return decimal.Parse(numericPart);
        }

        public bool IsDisplayed()
        {
            try
            {
                return CheckoutSummaryTitle.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetItemDescription(string productName)
        {
            var inventoryItem = Driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']/../../div[@class='inventory_item_desc']"));
            return inventoryItem.Text;
        }
    }
}
