namespace ProductsSearch.Services.Tests;

public abstract class FilterTests
{
    protected readonly InMemoryProductsCollection _productsCollection;
    protected readonly IProductService _sut;
    protected FilterTests()
    {
        _productsCollection = new InMemoryProductsCollection();
        _sut = new ProductService(_productsCollection);
    }
}