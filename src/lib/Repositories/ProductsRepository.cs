using app.Repositories;
using lib.Data;
using models;

namespace lib.Repositories.Concrete;

internal class ProductsRepository(IDatabaseAccessMethodes databaseAccessMethodes)
    : IProductsRepository
{

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

    public Product? Add(Product product)
    {
        string command = "INSERT INTO Products (Name,Price) VALUES (@Name,@Price); SELECT last_insert_rowid();";
        var param = new { product.Name, product.Price };
        var result = databaseAccessMethodes.CallDatabaseResponseAsync<int>(new(ResultType.Single, param, command)).Result;

        if (result.IsSuccess)
        {
            product.Id = result.Result;
        }

        return product;
    }

    public IList<Product> GetProductByOrderId(int Id)
    {
        string command = "select Products.* from Products,ProductsOrder where Products.Id = ProductsOrder.ProductId and ProductsOrder.OrderId = @Id";
        var param = new { Id };
        var result = databaseAccessMethodes.CallDatabaseResponseAsync<Product>(new(ResultType.Multiple, param, command)).Result;

        if (result.IsSuccess)
        {
            return result.Results.ToList().AsReadOnly();
        }

        return (new List<Product>()).AsReadOnly();
    }
}
