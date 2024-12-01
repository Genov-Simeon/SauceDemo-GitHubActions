using SauceDemo.Customizations.Factories;

namespace SauceDemoTests
{
    [Category("ErrorUser")]
    public class ErrorUserTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
            var user = UserInfoFactory.BuildUserCredentials("USER_ERROR", "PASSWORD");
            LoginPage.Login(user);
            InventoryPage.AssertLoggedSuccessfully();
        }

        [Test]
        public void AddToCartButtonsAreDisplayedAndClickable_When_LogWithErrorUser()
        {
            InventoryPage.AssertCartButtonsAreDisplayedAndClickable();
        }

        public void ImagesBroken_When_LogWithErrorUser()
        {
            var brokenImages = InventoryPage.GetBrokenImagesCount();

            Assert.AreEqual(0, brokenImages, "Some product images are broken for Error User.");
        }

        [Test]
        public void InventoryItemPageNavigated_When_LogWithErrorUser()
        {
            InventoryPage.ClickOnProduct(ProductInfoFactory.CreateSauceLabsBackpack().Name);

            Assert.IsTrue(InventoryItemPage.IsOnProductPageByName(ProductInfoFactory.CreateSauceLabsBackpack().Name), "Failed to navigate to the product detail page.");
        }

        [Test]
        public void CartItemsManipulatedIncorrectly_When_LogWithErrorUser()
        {
            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBoltTShirt().Name);
            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name);

            Assert.That(InventoryPage.GetCartItemCount(), Is.EqualTo(1), "Cart item count updated not as expected");

            InventoryPage.RemoveItemFromCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name);

            Assert.That(InventoryPage.GetCartItemCount(), Is.EqualTo(1), "Cart item count updated not as expected");
        }

        [Test]
        public void NoAlertAppears_When_LogWithErrorUser()
        {
            Assert.IsFalse(InventoryPage.IsAlertPresent(), "Unexpected alert appeared for Error User.");
        }
    }
}
