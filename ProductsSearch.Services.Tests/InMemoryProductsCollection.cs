using ProductsSearch.Core;
using ProductsSearch.Repository;

namespace ProductsSearch.Services.Tests;

public sealed class InMemoryProductsCollection : IProductsCollection
{
    private readonly List<Product> _products = new();
    public IQueryable<Product> Products => _products.AsQueryable();

    public void Add(Product product)
    {
        _products.Add(product);
    }
}