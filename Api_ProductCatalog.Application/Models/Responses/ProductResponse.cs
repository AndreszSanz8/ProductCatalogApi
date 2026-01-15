namespace Api_ProductCatalog.Application.Models.Responses;

public record ProductResponse(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock
);