using GvnSoftware.Catalog.Api.Entities;
using MongoDB.Driver;

namespace GvnSoftware.Catalog.Api.Data;
public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}
