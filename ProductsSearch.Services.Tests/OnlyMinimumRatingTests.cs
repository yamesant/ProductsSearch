using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class OnlyMinimumRatingTests : FilterTests
{
    [Theory, AutoData]
    public void GetsMinimum(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Attribute.Rating.Value = 1.1m;
        y.Attribute.Rating.Value = 4.9m;
        var request = new ProductsSearchRequest { OnlyMinimumRating = true };

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
        x.Attribute.Rating.Value = 1.1m;
        y.Attribute.Rating.Value = 4.9m;
        var request = new ProductsSearchRequest { OnlyMinimumRating = false };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().HaveCount(2);
    }
}