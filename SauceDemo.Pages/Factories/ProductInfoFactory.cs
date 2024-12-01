using SauceDemo.Customizations.Models;

namespace SauceDemo.Customizations.Factories
{
    public static class ProductInfoFactory
    {
        public static ProductInfo CreateSauceLabsBackpack()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Backpack",
                Description = "A sleek, streamlined backpack with Sauce Labs branding.",
                Price = 29.99m,
                ButtonText = "Add to Cart",
                ImageUrl = "https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.34e7aa42.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsBikeLight()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Bike Light",
                Description = "A red light for your bike to ensure visibility at night.",
                Price = 9.99m,
                ButtonText = "Add to Cart",
                ImageUrl = "https://www.saucedemo.com/static/media/bike-light-1200x1500.a0c9caae.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsBoltTShirt()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Bolt T-Shirt",
                Description = "Get your Sauce Labs swag on with this bold T-shirt.",
                Price = 15.99m,
                ButtonText = "Add to Cart",
                ImageUrl = "https://www.saucedemo.com/static/media/bolt-shirt-1200x1500.c0dae290.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsFleeceJacket()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Fleece Jacket",
                Description = "A fleece jacket that lets you show off your Sauce Labs pride.",
                Price = 49.99m,
                ButtonText = "Add to Cart",
                ImageUrl = "https://www.saucedemo.com/static/media/sauce-pullover-1200x1500.439fc934.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsOnesie()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Onesie",
                Description = "Rib snap infant onesie for the Sauce Labs baby in your life.",
                Price = 7.99m,
                ButtonText = "Add to Cart",
                ImageUrl = "https://www.saucedemo.com/static/media/red-onesie-1200x1500.2ec615b2.jpg"
            };
        }

        public static ProductInfo CreateTestAllTheThingsTShirtRed()
        {
            return new ProductInfo
            {
                Name = "Test.allTheThings() T-Shirt (Red)",
                Description = "This classic Sauce Labs T-shirt is perfect for testing enthusiasts.",
                Price = 15.99m,
                ButtonText = "Add to Cart",
                ImageUrl = "https://www.saucedemo.com/static/media/red-tatt-1200x1500.30dadef4.jpg"
            };
        }
    }
}
