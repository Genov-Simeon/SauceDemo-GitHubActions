using NUnit.Framework;

namespace SauceDemo.Customizations.Pages
{
    public partial class LoginPage
    {
        public void AssertLoginFailed(string expectedMessage)
        {
            string actualMessage = ErrorMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage, $"Expected error message: '{expectedMessage}', but got: '{actualMessage}'");
        }
    }
}
