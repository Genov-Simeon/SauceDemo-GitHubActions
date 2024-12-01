using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class InventoryItemPage : BasePage
    {
        public InventoryItemPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddProductToCart()
        {
            if (AddToCartButton.Displayed && AddToCartButton.Enabled)
            {
                AddToCartButton.Click();
            }
            else
            {
                throw new InvalidOperationException("Add to Cart button is not clickable.");
            }
        }
    }
}
