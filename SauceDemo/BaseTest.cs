using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Customizations.Pages;

namespace SauceDemoTests
{
    public class BaseTest
    {
        private IWebDriver _driver;

        protected CartPage CartPage { get; set; }
        protected InventoryPage InventoryPage { get; set; }
        protected InventoryItemPage InventoryItemPage { get; set; }
        protected LoginPage LoginPage { get; set; }

        [SetUp]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            _driver = new ChromeDriver(options);

            CartPage = new CartPage(_driver);
            InventoryPage = new InventoryPage(_driver);
            InventoryItemPage = new InventoryItemPage(_driver);
            LoginPage = new LoginPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
