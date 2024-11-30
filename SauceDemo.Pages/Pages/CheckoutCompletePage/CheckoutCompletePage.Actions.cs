using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutCompletePage : BasePage
    {
        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "checkout-complete.html")
        {
            base.Open(relativePath);
        }
    }
}
