using SauceDemo.Customizations.Faker;
using SauceDemo.Customizations.Models;

namespace SauceDemo.Customizations.Factories
{
    public static class UserDataFactory
    {
        public static UserData Generate()
        {
            return new UserDataFaker().Generate();
        }
    }
}
