using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "")
        {
            base.Open(relativePath);
        }
    }
}
