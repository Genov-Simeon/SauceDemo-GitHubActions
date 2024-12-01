using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Customizations;
using SauceDemo.Customizations.Pages;
using Unity;

namespace SauceDemoTests
{
    public class BaseTest
    {
        private IWebDriver _driver;

        protected CartPage CartPage { get; set; }

        protected CheckoutStepOnePage CheckoutStepOnePage { get; set; }

        protected CheckoutStepTwoPage CheckoutStepTwoPage { get; set; }

        protected CheckoutCompletePage CheckoutCompletePage { get; set; }

        protected InventoryPage InventoryPage { get; set; }
        
        protected InventoryItemPage InventoryItemPage { get; set; }
        
        protected LoginPage LoginPage { get; set; }

        protected PurchaseFacade PurchaseFacade { get; set; }

        protected IUnityContainer Container { get; private set; }


        [SetUp]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--headless");
            _driver = new ChromeDriver(options);

            Container = TestInitialize.ConfigureContainer(_driver);

            PurchaseFacade = Container.Resolve<PurchaseFacade>();
            CartPage = Container.Resolve<CartPage>();
            CheckoutStepOnePage = Container.Resolve<CheckoutStepOnePage>();
            CheckoutStepTwoPage = Container.Resolve<CheckoutStepTwoPage>();
            CheckoutCompletePage = Container.Resolve<CheckoutCompletePage>();
            InventoryPage = Container.Resolve<InventoryPage>();
            InventoryItemPage = Container.Resolve<InventoryItemPage>();
            LoginPage = Container.Resolve<LoginPage>();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
