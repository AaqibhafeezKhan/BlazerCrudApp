
using BlazorCrudApp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCrudApp.Server.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.00M },
            new Product { Id = 2, Name = "Product 2", Price = 20.00M },
            new Product { Id = 3, Name = "Product 3", Price = 30.00M },
        };

        public List<Product> GetAll() => products;

        public Product GetById(int id) => products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
}
