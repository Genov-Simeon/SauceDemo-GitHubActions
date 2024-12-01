using SauceDemo.Customizations.Factories;

namespace SauceDemoTests
{
    [Category("VisualUser")]
    public class VisualUserTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
            var user = UserInfoFactory.BuildUserCredentials("USER_VISUAL", "PASSWORD");
            LoginPage.Login(user);
            InventoryPage.AssertLoggedSuccessfully();
        }

        [Test]
        public void NoImagesAreBroken_When_LogWithVisualUser()
        {
            Assert.That(InventoryPage.GetBrokenImagesCount(), Is.EqualTo(0), "Some product images are broken.");
        }

        [Test]
        public void CorrectProductLayouts_When_LogWithVisualUser()
        {
            InventoryPage.ValidateProductLayout();
        }

        [Test]
        public void CorrectElementAlignment_When_LogWithVisualUser()
        {
            InventoryPage.ValidateElementAlignment("inventory_item", "inventory_item_price");
        }
    }
}
