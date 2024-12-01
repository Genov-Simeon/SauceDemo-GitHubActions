using OpenQA.Selenium;
using SauceDemo.Customizations.Models;
using SauceDemo.Customizations.Pages;

namespace SauceDemo.Customizations
{
    public class PurchaseFacade
    {
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutStepOnePage _checkoutStepOnePage;
        private readonly CheckoutStepTwoPage _checkoutStepTwoPage;

        public PurchaseFacade(InventoryPage inventoryPage, CartPage cartPage, CheckoutStepOnePage checkoutStepOnePage, CheckoutStepTwoPage checkoutStepTwoPage)
        {
            _inventoryPage = inventoryPage;
            _cartPage = cartPage;
            _checkoutStepOnePage = checkoutStepOnePage;
            _checkoutStepTwoPage = checkoutStepTwoPage;
        }

        public void CompletePurchase(List<ProductInfo> products)
        {
            foreach (var product in products)
            {
                _inventoryPage.AddItemToCart(product.Name);
            }

            _cartPage.Open();
            _cartPage.CheckoutButton.Click();

            _checkoutStepOnePage.FillAllFields();
            _checkoutStepOnePage.ContinueButton.Click();

            _checkoutStepTwoPage.FinishButton.Click();
        }
    }
}
