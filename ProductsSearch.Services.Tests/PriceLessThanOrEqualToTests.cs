using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class PriceLessThanOrEqualToTests : FilterTests
{
    [Theory, AutoData]
    public void ItWorks(Product x, Product y, Product z)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        _productsCollection.Add(z);
        x.Price = 199.9m;
        y.Price = 200.0m;
        z.Price = 200.1m;
        var request = new ProductsSearchRequest { PriceLessThanOrEqualTo = 200 };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().ContainEquivalentOf(x).And.ContainEquivalentOf(y).And.HaveCount(2);
    }
}