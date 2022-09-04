using GvnSoftware.Catalog.Api.Entities;
using MongoDB.Driver;

namespace GvnSoftware.Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration config)
        {
            var client=new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(config.GetValue<string>("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
