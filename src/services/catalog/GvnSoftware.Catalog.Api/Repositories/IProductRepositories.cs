using GvnSoftware.Catalog.Api.Entities;

namespace GvnSoftware.Catalog.Api.Repositories
{
    public interface IProductRepositories
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        /// <summary>
        /// Get product by spesific id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Return product</returns>
        Task<Product> GetProductAsync(string id);
        /// <summary>
        /// Get product by sepesific product name
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <returns>Return products,given product name</returns>
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
        /// <summary>
        /// Get product by spesific category name
        /// </summary>
        /// <param name="categoryName">Category Name</param>
        /// <returns>Return products, given category name</returns>
        Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName);
        /// <summary>
        /// Create a product given by input product
        /// </summary>
        /// <param name="product">Product input info</param>
        /// <returns></returns>
        Task CreateProductAsync(Product product);
        /// <summary>
        /// Update product given by input product
        /// </summary>
        /// <param name="product">Input product</param>
        /// <returns></returns>
        Task<bool> UpdateProductAsync(Product product);
        /// <summary>
        /// Delete a product by given product id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns></returns>
        Task<bool> DeleteProductAsync(string id);
    }
}