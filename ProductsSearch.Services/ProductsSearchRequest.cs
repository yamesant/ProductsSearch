namespace ProductsSearch.Services;

public sealed class ProductsSearchRequest
{
    public bool? OnlyMinimumPrice { get; set; }
    public bool? OnlyMaximumPrice { get; set; }
    public decimal? PriceGreaterThanOrEqualTo { get; set; }
}