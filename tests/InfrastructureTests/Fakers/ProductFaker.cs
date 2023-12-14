using Bogus;
using models;

namespace InfrastructureTests.Fakers;

class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {

        RuleFor(p => p.Name, f => f.Commerce.Product());
        RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(2000, 10000)));
    }
}
