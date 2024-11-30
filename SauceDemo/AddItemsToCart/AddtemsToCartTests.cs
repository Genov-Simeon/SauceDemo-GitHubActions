using NUnit.Framework.Interfaces;
using SauceDemo.Customizations.Factories;
using SauceDemo.Customizations.Pages;
using SauceDemo.Pages.Constants;

namespace SauceDemoTests
{
    public class AddItemsToCartTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoginPage.Open();
            var user = UserFactory.BuildUserCredentials("USER_STANDARD", "PASSWORD");
            LoginPage.Login(user);
        }

        [Test]
        public void SingleItemAddedToCart_When_AddSingleItem()
        {
            InventoryPage.AddItemToCart(SauceLabsBackpack.Name);

            Assert.IsTrue(InventoryPage.IsItemInCart(SauceLabsBackpack.Name), "The item was not added to the cart.");
        }

        [Test]
        public void MultipleItemsAddedToCart_When_AddMultipleItems()
        {
            var items = new[] { SauceLabsBackpack.Name, SauceLabsBoltTShirt.Name, TestAllTheThingsTShirt.Name };

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
            InventoryPage.AddItemToCart(SauceLabsBikeLight.Name);

            Assert.That(CartPage.GetCartItemCount(), Is.EqualTo(1), "Cart item count is incorrect.");
        }

        [Test]
        public void CartCountUpdated_When_AddMultipleItemsToCart()
        {
            var items = new[] { SauceLabsBackpack.Name, SauceLabsBoltTShirt.Name, TestAllTheThingsTShirt.Name };

            foreach (var item in items)
            {
                InventoryPage.AddItemToCart(item);
            }

            Assert.That(CartPage.GetCartItemCount(), Is.EqualTo(3), "Cart item count is incorrect.");
        }

        [Test]
        public void ItemRemovedFromCart_When_RemoveSingleItem()
        {
            InventoryPage.AddItemToCart(SauceLabsBikeLight.Name);

            InventoryPage.RemoveItemFromCart(SauceLabsBikeLight.Name);
            Assert.IsFalse(InventoryPage.IsItemInCart(SauceLabsBikeLight.Name), "The item was not removed from the cart.");
        }

        [Test]
        public void MultipleItemsRemovedFromCart_When_RemoveMultipleItems()
        {
            var items = new[] { SauceLabsBackpack.Name, SauceLabsBoltTShirt.Name, TestAllTheThingsTShirt.Name };

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
                Assert.That(InventoryPage.IsItemInCart(SauceLabsBikeLight.Name), Is.False, "The item was not removed from the cart.");
            }
        }
    }
}
