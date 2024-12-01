using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CartPage : BasePage
	{
		public CartPage(IWebDriver driver) : base(driver)
		{
		}

        public override void Open(string relativePath = "/cart.html")
        {
            base.Open(relativePath);
        }

        public int GetCartItemCount()
        {
            try
            {
                var cartBadge = Driver.FindElement(By.ClassName("shopping_cart_badge"));

                return int.Parse(cartBadge.Text);
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}
