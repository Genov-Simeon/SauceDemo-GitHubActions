using NUnit.Framework.Interfaces;
using SauceDemo.Customizations.Factories;
using SauceDemo.Customizations.Pages;

namespace SauceDemoTests
{
    public class AddItemsToCartTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
            var user = UserInfoFactory.BuildUserCredentials("USER_STANDARD", "PASSWORD");
            LoginPage.Login(user);
        }

        [Test]
        public void SingleItemAddedToCart_When_AddSingleItem()
        {
            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBackpack().Name);

            Assert.IsTrue(InventoryPage.IsItemInCart(ProductInfoFactory.CreateSauceLabsBackpack().Name), "The item was not added to the cart.");
        }

        [Test]
        public void MultipleItemsAddedToCart_When_AddMultipleItems()
        {
            var items = new[] { 
                ProductInfoFactory.CreateSauceLabsBackpack().Name, 
                ProductInfoFactory.CreateSauceLabsBoltTShirt().Name,
                ProductInfoFactory.CreateTestAllTheThingsTShirtRed().Name
            };

            foreach (var item in items)
            {
                InventoryPage.AddItemToCart(item);
            }

            foreach (var item in items)
            {
                Assert.IsTrue(InventoryPage.IsItemInCart(item), $"The item {item} was not added to the cart.");
            }
        }

        [Test]
        public void AllItemsAddedToCart_When_AddAllItems()
        {
            var allItems = InventoryPage.GetAllInventoryItems();

            foreach (var item in allItems)
            {
                InventoryPage.AddItemToCart(item);
            }

            foreach (var item in allItems)
            {
                Assert.IsTrue(InventoryPage.IsItemInCart(item), $"The item {item} was not added to the cart.");
            }
        }

        [Test]
        public void CartCountUpdated_When_AddSingleItemToCart()
        {
            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name);

            Assert.That(CartPage.GetCartItemCount(), Is.EqualTo(1), "Cart item count is incorrect.");
        }

        [Test]
        public void CartCountUpdated_When_AddMultipleItemsToCart()
        {
            var items = new[] 
            { 
                ProductInfoFactory.CreateSauceLabsBackpack().Name, 
                ProductInfoFactory.CreateSauceLabsBoltTShirt().Name, 
                ProductInfoFactory.CreateTestAllTheThingsTShirtRed().Name 
            };

            foreach (var item in items)
            {
                InventoryPage.AddItemToCart(item);
            }

            Assert.That(CartPage.GetCartItemCount(), Is.EqualTo(items.Length), "Cart item count is incorrect.");
        }

        [Test]
        public void ItemRemovedFromCart_When_RemoveSingleItem()
        {
            InventoryPage.AddItemToCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name);

            InventoryPage.RemoveItemFromCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name);
            Assert.IsFalse(InventoryPage.IsItemInCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name), "The item was not removed from the cart.");
        }

        [Test]
        public void MultipleItemsRemovedFromCart_When_RemoveMultipleItems()
        {
            var items = new[] 
            { 
                ProductInfoFactory.CreateSauceLabsBackpack().Name, 
                ProductInfoFactory.CreateSauceLabsBoltTShirt().Name, 
                ProductInfoFactory.CreateTestAllTheThingsTShirtRed().Name 
            };

            foreach (var item in items)
            {
                InventoryPage.AddItemToCart(item);
            }

            foreach (var item in items)
            {
                InventoryPage.RemoveItemFromCart(item);
            }

            foreach (var item in items)
            {
                Assert.That(InventoryPage.IsItemInCart(ProductInfoFactory.CreateSauceLabsBikeLight().Name), Is.False, "The item was not removed from the cart.");
            }
        }
    }
}
