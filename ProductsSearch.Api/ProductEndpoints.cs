using ProductsSearch.Services;

namespace ProductsSearch.Api;

public static class ProductEndpoints
{
    public static void AddProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");
        group.MapPost("/search", Search);
    }

    private static IResult Search(ProductsSearchRequest request, IProductService service)
    {
        var results = service.Search(request);
        return Results.Ok(results);
    }
}