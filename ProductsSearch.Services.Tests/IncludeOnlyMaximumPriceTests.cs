using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class IncludeOnlyMaximumPriceTests : FilterTests
{
    [Theory, AutoData]
    public void GetsMaximum(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Price = 2;
        y.Price = 3;
        var request = new ProductsSearchRequest { OnlyMaximumPrice = true };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().ContainEquivalentOf(y).And.ContainSingle();
    }
    
    [Theory, AutoData]
    public void GetsAll(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Price = 2;
        y.Price = 3;
        var request = new ProductsSearchRequest { OnlyMaximumPrice = false };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().HaveCount(2);
    }
}