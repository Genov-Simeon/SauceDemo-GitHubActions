using SauceDemo.Customizations.Factories;
using SauceDemo.Pages.Constants;

namespace SauceDemoTests
{
    public class ErrorUserTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
            var user = UserFactory.BuildUserCredentials("USER_ERROR", "PASSWORD");
            LoginPage.Login(user);
            InventoryPage.AssertLoggedSuccessfully();
        }

        [Test]
        public void AddToCartButtonsAreDisplayedAndClickable_When_LogWithErrorUser()
        {
            InventoryPage.AssertCartButtonsAreDisplayedAndClickable();
        }

        [Test]
        public void ImagesBroken_When_LogWithErrorUser()
        {
            var brokenImages = InventoryPage.GetBrokenImagesCount();

            Assert.AreEqual(0, brokenImages, "Some product images are broken for Error User.");
        }

        [Test]
        public void InventoryItemPageNavigated_When_LogWithErrorUser()
        {
            InventoryPage.ClickOnProduct(SauceLabsBackpack.Name);

            Assert.IsTrue(InventoryItemPage.IsOnProductPageByName(SauceLabsBackpack.Name), "Failed to navigate to the product detail page.");
        }

        [Test]
        public void CartItemsManipulatedIncorrectly_When_LogWithErrorUser()
        {
            InventoryPage.AddItemToCart(SauceLabsBoltTShirt.Name);
            InventoryPage.AddItemToCart(SauceLabsBikeLight.Name);

            Assert.That(InventoryPage.GetCartItemCount(), Is.EqualTo(1), "Cart item count updated not as expected");

            InventoryPage.RemoveItemFromCart(SauceLabsBikeLight.Name);

            Assert.That(InventoryPage.GetCartItemCount(), Is.EqualTo(1), "Cart item count updated not as expected");
        }

        [Test]
        public void NoAlertAppears_When_LogWithErrorUser()
        {
            Assert.IsFalse(InventoryPage.IsAlertPresent(), "Unexpected alert appeared for Error User.");
        }
    }
}
