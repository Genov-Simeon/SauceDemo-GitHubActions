using SauceDemo.Customizations.Factories;
using SauceDemo.Customizations.Models;
using SauceDemo.Customizations.Pages;

namespace SauceDemoTests
{
    public class LoginTests : BaseTest
    {
        private UserInfo? _user;

        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
        }

        [Test]
        public void StandardUserLogged_When_EnterCredentials()
        {
            _user = UserInfoFactory.BuildUserCredentials("USER_STANDARD", "PASSWORD");

            LoginPage.Login(_user);

            InventoryPage.AssertLoggedSuccessfully();
        }

        [Test]
        public void LockedOutUserCannotLogin_When_EnterCredentials()
        {
            var lockedUserMessage = "Epic sadface: Sorry, this user has been locked out.";
            _user = UserInfoFactory.BuildUserCredentials("USER_LOCKED_OUT", "PASSWORD");

            LoginPage.Login(_user);

            LoginPage.AssertLoginFailed(lockedUserMessage);
        }

        [Test]
        public void ProblemUserLogged_And_WrongImagesDisplayed_When_EnterCredentials()
        {
            _user = UserInfoFactory.BuildUserCredentials("USER_PROBLEM", "PASSWORD");

            LoginPage.Login(_user);

            Assert.Multiple(() =>
            {
                InventoryPage.AssertLoggedSuccessfully();
                InventoryPage.AssertImagesAreWrong();
            });
        }

        [Test]
        public void PerformanceGlitchUserLogged_And_LoginTimeLessThanExpected_When_EnterCredentials()
        {
            const int ExpectedLoginTime = 6;
            _user = UserInfoFactory.BuildUserCredentials("USER_PERFORMANCE", "PASSWORD");

            var loginStartTime = DateTime.Now;
            LoginPage.Login(_user);
            var loginEndTime = DateTime.Now;
            var loginDuration = loginEndTime - loginStartTime;

            Assert.Multiple(() =>
            {
                InventoryPage.AssertLoggedSuccessfully();
                Assert.LessOrEqual(loginDuration.TotalSeconds, ExpectedLoginTime, $"Login took {loginDuration.TotalSeconds} seconds, which exceeds the acceptable limit.");
                InventoryPage.AssertLoadedOnTime();
            });
        }

        [Test]
        public void ErrorUserLogged_When_EnterCredentials()
        {
            _user = UserInfoFactory.BuildUserCredentials("USER_ERROR", "PASSWORD");

            LoginPage.Login(_user);

            InventoryPage.AssertLoggedSuccessfully();
        }

        public void VisualUserLogged_When_EnterCredentials()
        {
            _user = UserInfoFactory.BuildUserCredentials("USER_VISUAL", "PASSWORD");

            LoginPage.Login(_user);            

            InventoryPage.AssertLoggedSuccessfully();
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
