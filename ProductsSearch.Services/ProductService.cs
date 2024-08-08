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
        
        if (request.OnlyMaximumPrice != null && request.OnlyMaximumPrice.Value)
        {
            var maxPrice = result.Max(p => p.Price);
            result = result
                .Where(x => x.Price == maxPrice);
        }
        
        if (request.PriceGreaterThanOrEqualTo != null)
        {
            result = result
                .Where(x => x.Price >= request.PriceGreaterThanOrEqualTo);
        }
        
        if (request.PriceLessThanOrEqualTo != null)
        {
            result = result
                .Where(x => x.Price <= request.PriceLessThanOrEqualTo);
        }
        
        if (request.IsFantastic != null)
        {
            result = result
                .Where(x => x.Attribute.Fantastic.Value == request.IsFantastic);
        }
        
        if (request.OnlyMinimumRating != null && request.OnlyMinimumRating.Value)
        {
            var minRating = result.Min(x => x.Attribute.Rating.Value);
            result = result
                .Where(x => x.Attribute.Rating.Value == minRating);
        }
        
        return result.ToList();
    }
}