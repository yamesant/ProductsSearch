using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using ProductsSearch.Core;

namespace ProductsSearch.Repository;

public sealed class ProductsCollection : IProductsCollection
{
    public IQueryable<Product> Products => _collection.AsQueryable();
    private readonly IMongoCollection<Product> _collection;
    
    public ProductsCollection(IOptions<ProductsCollectionConfig> options)
    {
        var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.ProductsDatabaseName);
        _collection = database.GetCollection<Product>(options.Value.ProductsCollectionName);
    }
}