using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutStepTwoPage : BasePage
    {
        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "checkout-step-two.html")
        {
            base.Open(relativePath);
        }

        public decimal GetSubtotal()
        {
            string subtotalText = SummarySubtotalLabel.Text;

            string numericPart = subtotalText.Replace("Item total: $", "").Trim();

            return decimal.Parse(numericPart);
        }
    }
}
