using Api_ProductCatalog.Application.Models.Requests;
using Api_ProductCatalog.Application.Validators;
using FluentValidation.TestHelper;

namespace Api_ProductCatalog.Application.UnitTests.Validators;

public class CreateProductRequestValidatorTests
{
    private readonly CreateProductRequestValidator _validator;

    public CreateProductRequestValidatorTests()
    {
        _validator = new CreateProductRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var request = new CreateProductRequest("", "desc", 100, 1);

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        var request = new CreateProductRequest("Mouse", "Mouse gamer", 50, 5);

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
