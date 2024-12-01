using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public class SideBarSection
    {
        private readonly IWebDriver _driver;
        
        public SideBarSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AllItemsLink => _driver.FindElement(By.Id("inventory_sidebar_link"));

        public IWebElement AboutLink => _driver.FindElement(By.Id("about_sidebar_link"));

        public IWebElement LogoutLink => _driver.FindElement(By.Id("logout_sidebar_link"));

        public IWebElement ResetAppStateLink => _driver.FindElement(By.Id("reset_sidebar_link"));
    }
}