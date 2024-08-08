using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class OnlyMinimumPriceTests : FilterTests
{
    [Theory, AutoData]
    public void GetsMinimum(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Price = 2;
        y.Price = 3;
        var request = new ProductsSearchRequest { OnlyMinimumPrice = true };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().ContainEquivalentOf(x).And.ContainSingle();
    }
    
    [Theory, AutoData]
    public void GetsAll(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Price = 2;
        y.Price = 3;
        var request = new ProductsSearchRequest { OnlyMinimumPrice = false };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().HaveCount(2);
    }
}