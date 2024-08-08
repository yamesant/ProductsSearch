using ProductsSearch.Core;
using ProductsSearch.Repository;

namespace ProductsSearch.Services;

public class ProductService(IProductsCollection productsCollection) : IProductService
{
    private readonly IQueryable<Product> _products = productsCollection.Products;

    public List<Product> Search(ProductsSearchRequest request)
    {
        var query = _products;
        if (request.OnlyMinimumPrice != null && request.OnlyMinimumPrice.Value)
        {
            var minPrice = query.Min(p => p.Price);
            query = query
                .Where(x => x.Price == minPrice);
        }

        if (request.OnlyMaximumPrice != null && request.OnlyMaximumPrice.Value)
        {
            var maxPrice = query.Max(p => p.Price);
            query = query
                .Where(x => x.Price == maxPrice);
        }

        if (request.PriceGreaterThanOrEqualTo != null)
        {
            query = query
                .Where(x => x.Price >= request.PriceGreaterThanOrEqualTo);
        }

        if (request.PriceLessThanOrEqualTo != null)
        {
            query = query
                .Where(x => x.Price <= request.PriceLessThanOrEqualTo);
        }

        if (request.IsFantastic != null)
        {
            query = query
                .Where(x => x.Attribute.Fantastic.Value == request.IsFantastic);
        }

        if (request.OnlyMinimumRating != null && request.OnlyMinimumRating.Value)
        {
            var minRating = query.Min(x => x.Attribute.Rating.Value);
            query = query
                .Where(x => x.Attribute.Rating.Value == minRating);
        }

        if (request.OnlyMaximumRating != null && request.OnlyMaximumRating.Value)
        {
            var maxRating = query.Max(x => x.Attribute.Rating.Value);
            query = query
                .Where(x => x.Attribute.Rating.Value == maxRating);
        }

        if (request.RatingGreaterThanOrEqualTo != null)
        {
            query = query
                .Where(x => x.Attribute.Rating.Value >= request.RatingGreaterThanOrEqualTo);
        }

        if (request.RatingLessThanOrEqualTo != null)
        {
            query = query
                .Where(x => x.Attribute.Rating.Value <= request.RatingLessThanOrEqualTo);
        }

        var result = query.ToList();
        return result;
    }
}