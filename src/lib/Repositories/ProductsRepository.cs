using app.Repositories;
using lib.Data;
using models;

namespace lib.Repositories.Concrete;

internal class ProductsRepository(IDatabaseAccessMethodes databaseAccessMethodes)
    : IProductsRepository
{
   // private readonly List<Product> _products = products.ToList();

    public IReadOnlyCollection<Product> GetAll()
    {
        string command = "select * from products";
        var result = databaseAccessMethodes.CallDatabaseResponseAsync<Product>(new(ResultType.Multiple,null, command)).Result;

        if (result.IsSuccess)
        {
            return result.Results.ToList().AsReadOnly();
        }

        return (new List<Product>()).AsReadOnly();
    }

    public Product? GetById(int Id)
    {
        string command = "select * from products where Id = @Id";
        var param = new {Id = Id};
        var result = databaseAccessMethodes.CallDatabaseResponseAsync<Product>(new(ResultType.Single, param, command)).Result;

        if (result.IsSuccess)
        {
            return result.Result;
        }

        return new Product();
    }
}
