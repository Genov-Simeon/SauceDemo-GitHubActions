using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Customizations.Factories;

namespace SauceDemo.Customizations.Pages
{
    public partial class InventoryPage
    {
        public void AssertLoggedSuccessfully()
        {
            Assert.IsTrue(Driver.Url.Contains("inventory.html"));
        }

        public void AssertImagesAreWrong()
        {            
            List<string> productImages = GetAllProductImageSources();

            var expectedImageSources = new List<string>
            {
                ProductInfoFactory.CreateSauceLabsBackpack().ImageUrl,
                ProductInfoFactory.CreateSauceLabsBikeLight().ImageUrl,
                ProductInfoFactory.CreateSauceLabsBoltTShirt().ImageUrl,
                ProductInfoFactory.CreateSauceLabsFleeceJacket().ImageUrl,
                ProductInfoFactory.CreateSauceLabsOnesie().ImageUrl,
                ProductInfoFactory.CreateTestAllTheThingsTShirtRed().ImageUrl
            };

            Assert.AreNotEqual(expectedImageSources, productImages, "Product images do not match the expected images for Problem User.");
        }

        private List<string> GetAllProductImageSources()
        {
            var productImageSources = new List<string>();

            foreach (var product in Products)
            {
                var imageElement = product.FindElement(By.TagName("img"));
                string imageSource = imageElement.GetAttribute("src");
                productImageSources.Add(imageSource);
            }

            return productImageSources;
        }

        public void AssertLoadedOnTime()
        {
            const int LoadingTime = 5;
            var inventoryStartTime = DateTime.Now;
            WaitForInventoryToLoad();
            var inventoryEndTime = DateTime.Now;
            var inventoryLoadDuration = inventoryEndTime - inventoryStartTime;

            Assert.LessOrEqual(inventoryLoadDuration.TotalSeconds, LoadingTime, $"Inventory page load took {inventoryLoadDuration.TotalSeconds} seconds, which exceeds the acceptable limit.");
        }

        public void AssertCartButtonsAreDisplayedAndClickable()
        {
            foreach (var button in GetAllAddToCartButtons())
            {
                Assert.IsTrue(button.Displayed, "'Add to Cart' button is not displayed.");
                Assert.IsTrue(button.Enabled, "'Add to Cart' button is not clickable.");
            }
        }

        public void ValidateProductLayout()
        {
            foreach (var product in Products)
            {
                Assert.IsTrue(product.Displayed, "A product element is not visible.");

                Assert.IsTrue(product.Size.Width > 0 && product.Size.Height > 0, "Product element has invalid dimensions.");
            }
        }

        public void ValidateElementAlignment(string parentClassName, string childClassName)
        {
            var parentElements = Driver.FindElements(By.ClassName(parentClassName));

            foreach (var parent in parentElements)
            {
                var child = parent.FindElement(By.ClassName(childClassName));

                // Ensure the child element (price) is aligned with the parent (product container)
                Assert.IsTrue(parent.Location.Y == child.Location.Y || parent.Location.Y < child.Location.Y,
                    $"Alignment issue between parent ({parentClassName}) and child ({childClassName}).");
            }
        }

        public bool IsItemInCart(string itemName)
        {
            try
            {
                // Locate the shopping cart badge to confirm items in the cart
                var cartBadge = Driver.FindElement(By.ClassName("shopping_cart_badge"));

                var shoppingCartLink = Driver.FindElement(By.ClassName("shopping_cart_link"));
                shoppingCartLink.Click();

                var cartItems = Driver.FindElements(By.ClassName("inventory_item_name"));
                foreach (var item in cartItems)
                {
                    if (item.Text.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                // Return false if no cart badge or item found
                return false;
            }
        }

    }
}
