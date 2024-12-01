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
                Description = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
                Price = 29.99m,
                ButtonText = "Add to Cart",
                ImageUrl = $"{Configuration.BaseUrl}/static/media/sauce-backpack-1200x1500.34e7aa42.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsBikeLight()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Bike Light",
                Description = "A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.",
                Price = 9.99m,
                ButtonText = "Add to Cart",
                ImageUrl = $"{Configuration.BaseUrl}/static/media/bike-light-1200x1500.a0c9caae.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsBoltTShirt()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Bolt T-Shirt",
                Description = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.",
                Price = 15.99m,
                ButtonText = "Add to Cart",
                ImageUrl = $"{Configuration.BaseUrl}/static/media/bolt-shirt-1200x1500.c0dae290.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsFleeceJacket()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Fleece Jacket",
                Description = "It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office.",
                Price = 49.99m,
                ButtonText = "Add to Cart",
                ImageUrl = $"{Configuration.BaseUrl}/static/media/sauce-pullover-1200x1500.439fc934.jpg"
            };
        }

        public static ProductInfo CreateSauceLabsOnesie()
        {
            return new ProductInfo
            {
                Name = "Sauce Labs Onesie",
                Description = "Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.",
                Price = 7.99m,
                ButtonText = "Add to Cart",
                ImageUrl = $"{Configuration.BaseUrl}/static/media/red-onesie-1200x1500.2ec615b2.jpg"
            };
        }

        public static ProductInfo CreateTestAllTheThingsTShirtRed()
        {
            return new ProductInfo
            {
                Name = "Test.allTheThings() T-Shirt (Red)",
                Description = "This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.",
                Price = 15.99m,
                ButtonText = "Add to Cart",
                ImageUrl = $"{Configuration.BaseUrl}/static/media/red-tatt-1200x1500.30dadef4.jpg"
            };
        }
    }
}
