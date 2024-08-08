using Microsoft.Extensions.Options;

namespace ProductsSearch.Core;

public sealed class ProductsCollectionConfig
{
    public string ConnectionString { get; set; } = string.Empty;
    public string ProductsDatabaseName { get; set; } = string.Empty;
    public string ProductsCollectionName { get; set; } = string.Empty;
}

public sealed class ProductsCollectionConfigValidator : IValidateOptions<ProductsCollectionConfig>
{
    public ValidateOptionsResult Validate(string? name, ProductsCollectionConfig options)
    {
        if (options.ConnectionString.Length == 0)
        {
            return ValidateOptionsResult.Fail("Connection string is required");
        }
        
        if (options.ProductsDatabaseName.Length == 0)
        {
            return ValidateOptionsResult.Fail("Products database name is required");
        }
        
        if (options.ProductsCollectionName.Length == 0)
        {
            return ValidateOptionsResult.Fail("Products collection name is required");
        }
        
        return ValidateOptionsResult.Success;
    }
}