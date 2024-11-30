using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open(string relativePath = "inventory.html")
        {
            base.Open(relativePath);
        }

        public void ClickOnProduct(string productName)
        {
            try
            {
                var productLink = Driver.FindElement(By.XPath($"//div[@class='inventory_item_name ' and text()='{productName}']"));
                productLink.Click();
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException($"The product '{productName}' could not be found.");
            }
        }

        public void AddItemToCart(string productName)
        {
            try
            {
                var addToCartButton = GetProductContainer(productName).FindElement(By.XPath(".//button[contains(text(), 'Add to cart')]"));
                addToCartButton.Click();
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException($"The product '{productName}' could not be found or the 'Add to Cart' button is missing.");
            }
        }

        public void RemoveItemFromCart(string productName)
        {
            try
            {
                var removeButton = GetProductContainer(productName).FindElement(By.XPath(".//button[contains(text(), 'Remove')]"));
                removeButton.Click();
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException($"No product with the name '{productName}' could be found, or the 'Remove' button is missing.");
            }
        }

        public int GetCartItemCount()
        {
            IWebElement CartBadge = Driver.FindElement(By.ClassName("shopping_cart_badge"));

            try
            {
                string cartItemCountText = CartBadge.Text;
                return int.Parse(cartItemCountText);
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }

        public List<string> GetAllInventoryItems()
        {
            var inventoryItems = Driver.FindElements(By.ClassName("inventory_item_name"));

            return inventoryItems.Select(item => item.Text).ToList();
        }


        public int GetBrokenImagesCount()
        {
            int brokenImageCount = 0;
            IReadOnlyCollection<IWebElement> ProductImages = Driver.FindElements(By.XPath("//img[@class='inventory_item_img']"));

            foreach (var image in ProductImages)
            {
                string imageSource = image.GetAttribute("src");
                if (string.IsNullOrEmpty(imageSource))
                {
                    brokenImageCount++;
                    continue;
                }
                var jsExecutor = (IJavaScriptExecutor)Driver;
                bool isImageLoaded = (bool)jsExecutor.ExecuteScript(@"
                var img = arguments[0];
                return img.complete && typeof img.naturalWidth != 'undefined' && img.naturalWidth > 0;
            ", image);

                if (!isImageLoaded)
                {
                    brokenImageCount++;
                }
            }

            return brokenImageCount;
        }

        public bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public void WaitForInventoryToLoad()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => InventoryContainer.Displayed);
        }
    }
}
