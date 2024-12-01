using SauceDemo.Customizations;
using SauceDemo.Customizations.Factories;
using SauceDemo.Customizations.Models;
using SauceDemo.Customizations.Pages;

namespace SauceDemoTests
{
    public class CheckOutTests : BaseTest
    {
        private UserData _userData;

        [SetUp]
        public void Setup()
        {
            _userData = UserDataFactory.Generate();
            LoginPage.Open();
            var user = UserInfoFactory.BuildUserCredentials("USER_STANDARD", "PASSWORD");
            LoginPage.Login(user);
        }

        [Test]
        public void CheckOutSuccessFull_When_AddItemToCart_And_CompletePurchase()
        {
            var productList = new List<ProductInfo> 
            { 
                ProductInfoFactory.CreateSauceLabsBoltTShirt() 
            };

            PurchaseFacade.CompletePurchase(productList);

            Assert.That(CheckoutCompletePage.GetConfirmationMessage(), Is.EqualTo("Thank you for your order!"));
        }

        [Test]
        public void CheckOutSuccessFull_When_AddMultipleItemsToCart_And_CompletePurchase()
        {
            var productList = new List<ProductInfo>
            {
                ProductInfoFactory.CreateSauceLabsBoltTShirt(),
                ProductInfoFactory.CreateSauceLabsFleeceJacket(),
                ProductInfoFactory.CreateSauceLabsOnesie()
            };

            PurchaseFacade.CompletePurchase(productList);

            Assert.That(CheckoutCompletePage.GetConfirmationMessage(), Is.EqualTo("Thank you for your order!"));
        }

        [Test]
        public void ValidationErrorDisplayed_When_CheckOutWithMissingFirstName()
        {
            _userData.FirstName = string.Empty;
            
            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBoltTShirt().Name);
            CartPage.Open();
            CartPage.CheckoutButton.Click();
            CheckoutStepOnePage.FillAllFields(_userData);
            CheckoutStepOnePage.ContinueButton.Click();

            Assert.That(CheckoutStepOnePage.GetErrorMessage(), Is.EqualTo("Error: First Name is required"));
        }

        [Test]
        public void ValidationErrorDisplayed_When_CheckOutWithMissingLastName()
        {
            _userData.LastName = string.Empty;

            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBoltTShirt().Name);
            CartPage.Open();
            CartPage.CheckoutButton.Click();
            CheckoutStepOnePage.FillAllFields(_userData);
            CheckoutStepOnePage.ContinueButton.Click();

            Assert.That(CheckoutStepOnePage.GetErrorMessage(), Is.EqualTo("Error: Last Name is required"));
        }

        [Test]
        public void ValidationErrorDisplayed_When_CheckOutWithMissingPostalCode()
        {
            _userData.PostalCode = string.Empty;

            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBoltTShirt().Name);
            CartPage.Open();
            CartPage.CheckoutButton.Click();
            CheckoutStepOnePage.FillAllFields(_userData);
            CheckoutStepOnePage.ContinueButton.Click();

            Assert.That(CheckoutStepOnePage.GetErrorMessage(), Is.EqualTo("Error: Postal Code is required"));
        }

        [Test]
        public void CorrectTotalPrice_When_CompletePurchase()
        {   
            var productList = new List<ProductInfo>
            {
                ProductInfoFactory.CreateSauceLabsBoltTShirt(),
                ProductInfoFactory.CreateSauceLabsBackpack()
            };
            var expectedSubtotal = productList[0].Price + productList[1].Price;

            foreach (var product in productList)
            {
                InventoryPage.AddItemToCart(product.Name);
            }
            CartPage.Open();
            CartPage.CheckoutButton.Click();
            CheckoutStepOnePage.FillAllFields();
            CheckoutStepOnePage.ContinueButton.Click();
            var getSubtotal = CheckoutStepTwoPage.GetSubtotal();
            CheckoutStepTwoPage.FinishButton.Click();

            Assert.That(getSubtotal, Is.EqualTo(expectedSubtotal), "Subtotal price is incorrect.");
        }
    }
}
