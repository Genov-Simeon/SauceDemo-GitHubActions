using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoTests
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void LoginTest()
        {
            _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            _driver.FindElement(By.Id("login-button")).Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }

        [Test]
        public void AddItemToCartTest()
        {
            // Login first
            LoginTest();

            // Add backpack to cart
            _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

            // Verify cart badge shows "1"
            var cartBadge = _driver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.That(cartBadge.Text, Is.EqualTo("1"));
        }

        [Test]
        public void CompleteCheckoutTest()
        {
            // Add item to cart first
            AddItemToCartTest();

            // Go to cart
            _driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            // Click checkout
            _driver.FindElement(By.Id("checkout")).Click();

            // Fill in checkout information
            _driver.FindElement(By.Id("first-name")).SendKeys("John");
            _driver.FindElement(By.Id("last-name")).SendKeys("Doe");
            _driver.FindElement(By.Id("postal-code")).SendKeys("12345");

            // Continue to next page
            _driver.FindElement(By.Id("continue")).Click();

            // Complete checkout
            _driver.FindElement(By.Id("finish")).Click();

            // Verify order completion
            var confirmationMessage = _driver.FindElement(By.ClassName("complete-header"));
            Assert.That(confirmationMessage.Text, Is.EqualTo("Thank you for your order!"));
        }

        [Test]
        public void SortProductsTest()
        {
            // Login first
            LoginTest();

            // Click sort dropdown and select price high to low
            var sortDropdown = _driver.FindElement(By.ClassName("product_sort_container"));
            sortDropdown.Click();
            sortDropdown.FindElement(By.CssSelector("option[value='hilo']")).Click();

            // Get all prices
            var prices = _driver.FindElements(By.ClassName("inventory_item_price"))
                .Select(e => decimal.Parse(e.Text.Replace("$", "")))
                .ToList();

            // Verify prices are in descending order
            Assert.That(prices, Is.Ordered.Descending);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}