using Catalog.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.api.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(string Id);

        public Task<IEnumerable<Product>> GetProductByName(string Name);

        public Task<IEnumerable<Product>> GetProductsByCategory(string Category);

        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string Id);

    }
}
