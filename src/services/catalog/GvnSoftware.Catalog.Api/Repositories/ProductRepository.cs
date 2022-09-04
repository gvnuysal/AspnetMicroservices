using GvnSoftware.Catalog.Api.Data;
using GvnSoftware.Catalog.Api.Entities;
using MongoDB.Driver;

namespace GvnSoftware.Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepositories
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public virtual async Task CreateProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public virtual async Task<bool> DeleteProductAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            
            return deleteResult.IsAcknowledged &&
                    deleteResult.DeletedCount > 0;
        }

        public virtual async Task<Product> GetProductAsync(string id)
        {
            return await _context
                                .Products
                                .Find(x => x.Id == id)
                                .FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter
                                                                .Eq(x => x.Category, categoryName);

            return await _context
                                .Products
                                .Find(filter)
                                .ToListAsync();
        }

        public virtual async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter
                                                                .Eq(x => x.Name, name);

            return await _context
                                .Products
                                .Find(filter)
                                .ToListAsync();
        }

        public virtual async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context
                                .Products
                                .Find(p => true)
                                .ToListAsync();
        }

        public virtual async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _context
                                    .Products
                                    .ReplaceOneAsync(filter: x => x.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged &&
                    updateResult.ModifiedCount > 0;
        }
    }
}