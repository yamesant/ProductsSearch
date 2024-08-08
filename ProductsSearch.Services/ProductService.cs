using ProductsSearch.Core;
using ProductsSearch.Repository;

namespace ProductsSearch.Services;

public class ProductService(IProductsCollection productsCollection) : IProductService
{
    private readonly IQueryable<Product> _products = productsCollection.Products;
    public List<Product> Search(ProductsSearchRequest request)
    {
        var result = _products;
        if (request.OnlyMinimumPrice != null && request.OnlyMinimumPrice.Value)
        {
            var minPrice = result.Min(p => p.Price);
            result = result
                .Where(x => x.Price == minPrice);
        }
        
        return result.ToList();
    }
}