using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class RatingGreaterThanOrEqualToTests : FilterTests
{
    [Theory, AutoData]
    public void ItWorks(Product x, Product y, Product z)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        _productsCollection.Add(z);
        x.Attribute.Rating.Value = 2.99m;
        y.Attribute.Rating.Value = 3.00m;
        z.Attribute.Rating.Value = 3.01m;
        var request = new ProductsSearchRequest { RatingGreaterThanOrEqualTo = 3 };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().ContainEquivalentOf(y).And.ContainEquivalentOf(z).And.HaveCount(2);
    }
}