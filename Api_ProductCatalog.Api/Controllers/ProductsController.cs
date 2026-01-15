using Api_ProductCatalog.Application.Interfaces.Services;
using Api_ProductCatalog.Application.Models.Requests;
using Api_ProductCatalog.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador para la gestión del catálogo de productos y su stock.
/// Expone operaciones CRUD básicas para ser consumidas por aplicaciones web, móviles u otros servicios.
/// </summary>
[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    /// <summary>
    /// Crea un nuevo producto en el catálogo.
    /// </summary>
    /// <param name="request">Información del producto a crear.</param>
    /// <returns>Producto creado con su identificador.</returns>
    /// <response code="200">Producto creado correctamente.</response>
    /// <response code="400">Datos inválidos enviados en la solicitud.</response>
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var result = await _service.CreateAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Obtiene el listado completo de productos activos del catálogo.
    /// </summary>
    /// <returns>Lista de productos.</returns>
    /// <response code="200">Listado retornado correctamente.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Obtiene un producto específico a partir de su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto.</param>
    /// <returns>Producto encontrado.</returns>
    /// <response code="200">Producto encontrado.</response>
    /// <response code="404">No existe un producto con el identificador indicado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Actualiza el stock disponible de un producto.
    /// </summary>
    /// <param name="id">Identificador del producto.</param>
    /// <param name="stock">Nuevo valor de stock.</param>
    /// <response code="204">Stock actualizado correctamente.</response>
    /// <response code="400">El valor de stock es inválido.</response>
    /// <response code="404">No existe el producto.</response>
    [HttpPatch("{id}/stock")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] int stock)
    {
        await _service.UpdateStockAsync(id, stock);
        return NoContent();
    }

    /// <summary>
    /// Elimina un producto del catálogo.
    /// La eliminación es lógica (el producto no se borra físicamente).
    /// </summary>
    /// <param name="id">Identificador del producto.</param>
    /// <response code="204">Producto eliminado correctamente.</response>
    /// <response code="404">No existe el producto.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}