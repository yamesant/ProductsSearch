using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class OnlyMaximumRatingTests : FilterTests
{
    [Theory, AutoData]
    public void GetsMaximum(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Attribute.Rating.Value = 1.1m;
        y.Attribute.Rating.Value = 4.9m;
        var request = new ProductsSearchRequest { OnlyMaximumRating = true };

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
        x.Attribute.Rating.Value = 1.1m;
        y.Attribute.Rating.Value = 4.9m;
        var request = new ProductsSearchRequest { OnlyMaximumRating = false };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().HaveCount(2);
    }
}