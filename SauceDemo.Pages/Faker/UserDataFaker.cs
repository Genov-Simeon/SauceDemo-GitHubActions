using Bogus;
using SauceDemo.Customizations.Models;

namespace SauceDemo.Customizations.Faker
{
    public class UserDataFaker : Faker<UserData>
    {
        public UserDataFaker()
        {
            RuleFor(user => user.FirstName, faker => faker.Person.FirstName.Replace('\'', 'a'));
            RuleFor(user => user.LastName, faker => faker.Person.LastName.Replace('\'', 'a'));
            RuleFor(user => user.PostalCode, faker => faker.Address.ZipCode().Replace('\'', '0'));
        }
    }
}
