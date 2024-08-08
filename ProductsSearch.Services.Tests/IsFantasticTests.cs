using AutoFixture.Xunit2;
using FluentAssertions;
using ProductsSearch.Core;

namespace ProductsSearch.Services.Tests;

public sealed class IsFantasticTests : FilterTests
{
    [Theory, AutoData]
    public void GetsFantastic(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Attribute.Fantastic.Value = true;
        y.Attribute.Fantastic.Value = false;
        var request = new ProductsSearchRequest { IsFantastic = true };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().ContainEquivalentOf(x).And.ContainSingle();
    }
    
    [Theory, AutoData]
    public void GetsNonFantastic(Product x, Product y)
    {
        // Arrange
        _productsCollection.Add(x);
        _productsCollection.Add(y);
        x.Attribute.Fantastic.Value = true;
        y.Attribute.Fantastic.Value = false;
        var request = new ProductsSearchRequest { IsFantastic = false };

        // Act
        var result = _sut.Search(request);
        
        // Assert
        result.Should().ContainEquivalentOf(y).And.ContainSingle();
    }
}