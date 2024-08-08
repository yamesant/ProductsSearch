using ProductsSearch.Core;

namespace ProductsSearch.Services;

public interface IProductService
{
    List<Product> Search(ProductsSearchRequest request);
}