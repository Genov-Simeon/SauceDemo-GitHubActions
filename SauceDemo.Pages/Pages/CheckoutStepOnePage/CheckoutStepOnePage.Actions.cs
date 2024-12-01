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

        public override void Open(string relativePath = "checkout-step-one.html")
        {
            base.Open(relativePath);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public void FillInformation(string firstName, string lastName, string postalCode)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            PostalCodeField.SendKeys(postalCode);
        }

        public void FillInformationFromFactory()
        {
            UserData userData = UserDataFactory.Generate();
            FillInformation(userData.FirstName, userData.LastName, userData.PostalCode);
        }
    }
}
