using OpenQA.Selenium;
using SauceDemo.Customizations.Models;

namespace SauceDemo.Customizations.Pages
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "")
        {
            base.Open(relativePath);
        }

        public void Login(UserInfo userInfo)
        {
            UsernameField.SendKeys(userInfo.UserName);
            PasswordField.SendKeys(userInfo.Password);
            LoginButton.Click();
        }
    }
}
