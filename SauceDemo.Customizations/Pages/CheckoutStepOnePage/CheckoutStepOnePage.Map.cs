using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutStepOnePage
    {
        public IWebElement FirstNameField => Driver.FindElement(By.Id("first-name"));
        
        public IWebElement LastNameField => Driver.FindElement(By.Id("last-name"));
        
        public IWebElement PostalCodeField => Driver.FindElement(By.Id("postal-code"));
        
        public IWebElement ContinueButton => Driver.FindElement(By.Id("continue"));

        public IWebElement ErrorMessage => Driver.FindElement(By.ClassName("error-message-container"));

        public IWebElement ContinueShoppingButton => Driver.FindElement(By.Id("continue-shopping"));

    }
}
