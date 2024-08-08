namespace ProductsSearch.Services;

public sealed class ProductsSearchRequest
{
    public bool? OnlyMinimumPrice { get; set; }
    public bool? OnlyMaximumPrice { get; set; }
    public decimal? PriceGreaterThanOrEqualTo { get; set; }
    public decimal? PriceLessThanOrEqualTo { get; set; }
    public bool? IsFantastic { get; set; }
    public bool? OnlyMinimumRating { get; set; }
    public bool? OnlyMaximumRating { get; set; }
    public decimal? RatingGreaterThanOrEqualTo { get; set; }
}