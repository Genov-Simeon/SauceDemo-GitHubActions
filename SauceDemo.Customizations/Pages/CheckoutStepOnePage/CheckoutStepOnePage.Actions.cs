using OpenQA.Selenium;
using SauceDemo.Customizations.Factories;
using SauceDemo.Customizations.Models;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutStepOnePage : BasePage
    {
        public CheckoutStepOnePage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "/checkout-step-one.html")
        {
            base.Open(relativePath);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public void FillAllFields(UserData userData)
        {
            FirstNameField.SendKeys(userData.FirstName);
            LastNameField.SendKeys(userData.LastName);
            PostalCodeField.SendKeys(userData.PostalCode);
        }

        public void FillAllFields()
        {
            UserData userData = UserDataFactory.Generate();
            FillAllFields(userData);
        }
    }
}
