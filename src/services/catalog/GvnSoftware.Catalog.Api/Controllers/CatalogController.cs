using GvnSoftware.Catalog.Api.Entities;
using GvnSoftware.Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GvnSoftware.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepositories _productRepositories;
        private readonly ILogger<CatalogController> _logger;


        public CatalogController(IProductRepositories productRepositories, ILogger<CatalogController> logger)
        {
            _productRepositories = productRepositories;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products=await _productRepositories.GetProductsAsync();

            return Ok(products);
        }
        [HttpGet("{id:length(24)}",Name ="GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product=await _productRepositories.GetProductAsync(id);
            if (product == null)
            {
                _logger.LogError($"Product with id:{id},not found");
            }
            return Ok(product);
        }
        [Route("[action]/category",Name ="GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _productRepositories.GetProductByCategoryAsync(category);
            return Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]Product product)
        {
            await _productRepositories.CreateProductAsync(product);

            return CreatedAtRoute("GetProduct", new{id=product.Id},product);
        }
        [HttpPut]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _productRepositories.UpdateProductAsync(product));
        }
        [HttpDelete("{id:length(24)",Name ="DeleteProduct")]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productRepositories.DeleteProductAsync(id));
        }
    }
}