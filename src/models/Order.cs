using System;
using System.Collections.Generic;
using System.Linq;


namespace models
{

    public sealed class Order
    {
        private static int _count = 0;
        private readonly List<Product> _products = new List<Product>();
        // private readonly List<Product> _products = [];
        public int Id { get; private init; } = ++_count;
        public bool Processed { get; private set; }
        public IReadOnlyList<Product> Products => _products.ToArray();
        public decimal TotalPrice => Products.Sum(p => p.Price);

        public void AddProduct(Product product)
        {
            if (product == null)
            {             
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            _products.Add(product);
            // throw new NotImplementedException();
        }

        public void RemoveProduct(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Product productToRemove = _products.FirstOrDefault(p => p.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
            else
            {
                throw new ArgumentException($"Product with Id {id} not found in the order.", nameof(id));
            }
        
 
            // throw new NotImplementedException();
        }

        public void ChangeOrderStatus(bool status)
        {
            Processed = status;
        }
    }
}