using ProductsSearch.Core;

namespace ProductsSearch.Repository;

public interface IProductsCollection
{
    IQueryable<Product> Products { get; }
}