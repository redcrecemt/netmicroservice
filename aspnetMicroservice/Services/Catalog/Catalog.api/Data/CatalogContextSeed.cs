using Catalog.api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existsProduct = productCollection.Find(p => true).Any();
            if (!existsProduct)
            {
                productCollection.InsertManyAsync(GetPreconguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconguredProducts()
        {
            return new List<Product>
            {
                new Product{ Id="60f858e3e3456b0de2b6b7f4",Name="Iphone 12",Summary="Apple's Product",ImageFile="product-1.png",Price=999.00M,Description="Apple Iphone 12",Category="Smart Phone" },
                new Product{ Id="60f8595116a519411dee5078",Name="Iphone 12 Pro",Summary="Apple's Product",ImageFile="product-1.png",Price=1200.00M,Description="Apple Iphone 12 Pro",Category="Smart Phone" }
            };
        }
    }
}
