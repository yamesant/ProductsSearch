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
        try
        {
            var results = service.Search(request);
            return Results.Ok(results);
        }
        catch (Exception e)
        {
            return Results.BadRequest("Something went wrong");
        }
    }
}