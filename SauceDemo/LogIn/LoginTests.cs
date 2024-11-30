using SauceDemo.Customizations.Factories;
using SauceDemo.Customizations.Pages;

namespace SauceDemoTests
{
    public class LoginTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
        }

        [Test]
        public void StandardUserLogged_When_EnterCredentials()
        {
            var user = UserFactory.BuildUserCredentials("USER_STANDARD", "PASSWORD");

            LoginPage.Login(user);

            InventoryPage.AssertLoggedSuccessfully();
        }

        [Test]
        public void LockedOutUserCannotLogin_When_EnterCredentials()
        {
            var lockedUserMessage = "Epic sadface: Sorry, this user has been locked out.";
            var user = UserFactory.BuildUserCredentials("USER_LOCKED_OUT", "PASSWORD");

            LoginPage.Login(user);

            LoginPage.AssertLoginFailed(lockedUserMessage);
        }

        [Test]
        public void ProblemUserLogged_When_EnterCredentials()
        {
            var user = UserFactory.BuildUserCredentials("USER_PROBLEM", "PASSWORD");

            LoginPage.Login(user);

            Assert.Multiple(() =>
            {
                InventoryPage.AssertLoggedSuccessfully();
                InventoryPage.AssertImagesAreWrong();
            });
        }

        [Test]
        public void PerformanceGlitchUserLogged_When_EnterCredentials()
        {
            var user = UserFactory.BuildUserCredentials("USER_PERFORMANCE", "PASSWORD");

            var loginStartTime = DateTime.Now;
            LoginPage.Login(user);
            var loginEndTime = DateTime.Now;
            var loginDuration = loginEndTime - loginStartTime;

            Assert.Multiple(() =>
            {
                InventoryPage.AssertLoggedSuccessfully();
                Assert.LessOrEqual(loginDuration.TotalSeconds, 6, $"Login took {loginDuration.TotalSeconds} seconds, which exceeds the acceptable limit.");
                InventoryPage.AssertLoadedOnTime();
            });
        }

        [Test]
        public void ErrorUserLogged_When_EnterCredentials()
        {
            var user = UserFactory.BuildUserCredentials("USER_ERROR", "PASSWORD");

            LoginPage.Login(user);

            InventoryPage.AssertLoggedSuccessfully();
        }

        [Test]
        public void VisualUserLogged_When_EnterCredentials()
        {
            var user = UserFactory.BuildUserCredentials("USER_VISUAL", "PASSWORD");

            LoginPage.Login(user);            

            InventoryPage.AssertLoggedSuccessfully();
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
