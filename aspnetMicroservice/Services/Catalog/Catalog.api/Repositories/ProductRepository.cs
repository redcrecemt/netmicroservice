using Catalog.api.Data;
using Catalog.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Catalog.api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string Id)
        {
            var result = await _context.Products.DeleteOneAsync(filter: p => p.Id == Id);
            return result.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string Id)
        {
            return await _context.Products.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string Name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, Name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string Category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, Category);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _context.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
            return result.IsAcknowledged && result.ModifiedCount > 0;



        }
    }
}
