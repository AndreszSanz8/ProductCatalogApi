using Api_ProductCatalog.Application.Interfaces.Services;
using Api_ProductCatalog.Application.Models.Requests;
using Api_ProductCatalog.Application.Services;
using Api_ProductCatalog.Domain.Entities;
using Api_ProductCatalog.Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace Api_ProductCatalog.Application.UnitTests.Services;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repoMock;
    private readonly IProductService _service;

    public ProductServiceTests()
    {
        _repoMock = new Mock<IProductRepository>();
        _service = new ProductService(_repoMock.Object);
    }

    [Fact]
    public async Task CreateAsync_Should_Create_Product_And_Return_Response()
    {
        // Arrange
        var request = new CreateProductRequest(
            "Laptop",
            "Laptop gamer",
            2500,
            10
        );

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Product>()))
            .ReturnsAsync((Product p) => p);

        // Act
        var result = await _service.CreateAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Laptop");
        result.Stock.Should().Be(10);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_When_Not_Found_Should_Return_Null()
    {
        _repoMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Product?)null);

        var result = await _service.GetByIdAsync(99);

        result.Should().BeNull();
    }
}
