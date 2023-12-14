using Bogus;
using models;

namespace InfrastructureTests.Fakers;

class OrderFaker : Faker<Order>
{
    public OrderFaker()
    {
        RuleFor(o => o.Id, f => f.IndexGlobal);
        RuleFor(o => o.Processed, f => f.Random.Bool());
        RuleFor(o => o.Products, f => GenerateProducts(f));
    }

    private static List<Product> GenerateProducts(Faker f)
    {
        var productFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 100));

        return productFaker.Generate(f.Random.Number(1, 5));
    }
}
