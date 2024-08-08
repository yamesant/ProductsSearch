namespace ProductsSearch.Api;

public static class ProductEndpoints
{
    public static void AddProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");
        group.MapPost("/search", Search);
    }

    private static IResult Search()
    {
        return Results.Ok("All good");
    }
}