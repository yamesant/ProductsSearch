using ProductsSearch.Core;
using ProductsSearch.Repository;

namespace ProductsSearch.Services;

public class ProductService(IProductsCollection productsCollection) : IProductService
{
    private readonly IQueryable<Product> _products = productsCollection.Products;
    public List<Product> Search(ProductsSearchRequest request)
    {
        var result = _products;
        return result.ToList();
    }
}