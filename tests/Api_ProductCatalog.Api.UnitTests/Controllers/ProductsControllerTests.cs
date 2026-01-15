using Api_ProductCatalog.Application.Interfaces.Services;
using Api_ProductCatalog.Application.Models.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api_ProductCatalog.Api.UnitTests.Controllers;

public class ProductsControllerTests
{
    private readonly Mock<IProductService> _serviceMock;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _serviceMock = new Mock<IProductService>();
        _controller = new ProductsController(_serviceMock.Object);
    }

    [Fact]
    public async Task GetById_When_Product_Exists_Returns_Ok()
    {
        var product = new ProductResponse(1, "Keyboard", "Gaming", 100, 5);

        _serviceMock
            .Setup(s => s.GetByIdAsync(1))
            .ReturnsAsync(product);

        var result = await _controller.GetById(1);

        var okResult = result as OkObjectResult;

        okResult.Should().NotBeNull();
        okResult!.Value.Should().Be(product);
    }

    [Fact]
    public async Task GetById_When_Not_Found_Returns_404()
    {
        _serviceMock
            .Setup(s => s.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((ProductResponse?)null);

        var result = await _controller.GetById(99);

        result.Should().BeOfType<NotFoundResult>();
    }
}
