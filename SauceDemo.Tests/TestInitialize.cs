using SauceDemo.Customizations.Pages;
using SauceDemo.Customizations;
using Unity;
using OpenQA.Selenium;

namespace SauceDemoTests
{
    public static class TestInitialize
    {
        public static UnityContainer? Container { get; private set; }

        public static IUnityContainer ConfigureContainer(IWebDriver driver)
        {
            Container = new UnityContainer();

            Container.RegisterInstance(driver);

            Container.RegisterType<PurchaseFacade>();
            Container.RegisterType<CartPage>();
            Container.RegisterType<CheckoutStepOnePage>();
            Container.RegisterType<CheckoutStepTwoPage>();
            Container.RegisterType<CheckoutCompletePage>();
            Container.RegisterType<InventoryPage>();
            Container.RegisterType<InventoryItemPage>();
            Container.RegisterType<LoginPage>();

            return Container;
        }
    }
}
