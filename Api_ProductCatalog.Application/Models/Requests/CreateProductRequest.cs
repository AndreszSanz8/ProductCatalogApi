namespace Api_ProductCatalog.Application.Models.Requests;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int Stock
);
