using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutStepOnePage : BasePage
    {
        public CheckoutStepOnePage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "checkout-step-one.html")
        {
            base.Open(relativePath);
        }
    }
}
