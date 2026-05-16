using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.DTO;
using RestApi.Entities;

namespace RestApi.Controllers;

[Authorize]
[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DetallesProductoDTO>> GetProduct(int id)
    {
        var product = await _context.Productos
            .Include(p => p.StockMovements)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        var result = new DetallesProductoDTO
        {
            Id = product.Id,
            Descripcion = product.Descripcion,
            Codigo = product.Codigo,
            Categoria = product.Categoria,
            CantidadStock = product.CantidadStock,
            PrecioUnitario = product.PrecioUnitario,
            Creado = product.Creado,

            MovmientosRecientes = product.StockMovements
                .OrderByDescending(m => m.FechaMovimiento)
                .Take(10)
                .Select(m => new MovimientoStockDTO
                {
                    Id = m.Id,
                    ProductId = m.ProductId,
                    Tipo = m.Tipo,
                    Cantidad = m.Cantidad,
                    Razon = m.Razon,
                    Creado = m.FechaMovimiento
                })
                .ToList()
        };

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductoDTO>> CreateProduct(
        CrearProductoDTO dto)
    {
        var skuExists = await _context.Productos
            .AnyAsync(p => p.Codigo == dto.Codigo);

        if (skuExists)
        {
            return Conflict(new
            {
                message = "El producto ya existe."
            });
        }

        var producto = new Producto
        {
            Descripcion = dto.Descripcion,
            CantidadStock = dto.CantidadStock,
            Codigo = dto.Codigo,
            Categoria = dto.Categoria,
            PrecioUnitario = dto.PrecioUnitario
        };

        _context.Productos.Add(producto);

        await _context.SaveChangesAsync();

        var result = new ProductoDTO
        {
            Id = producto.Id,
            Descripcion = producto.Descripcion,
            CantidadStock = producto.CantidadStock,
            Codigo = producto.Codigo,
            Categoria = producto.Categoria,
            Creado = producto.Creado,
            PrecioUnitario = producto.PrecioUnitario
        };

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = producto.Id },
            result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(
        int id,
        ActualizarProductoDTO dto)
    {
        var product = await _context.Productos.FindAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        var duplicateSku = await _context.Productos
            .AnyAsync(p =>
                p.Codigo == dto.Codigo &&
                p.Id != id);

        if (duplicateSku)
        {
            return Conflict(new
            {
                message = "El producto con el codigo ingresado ya existe."
            });
        }

        product.Descripcion = dto.Descripcion;
        product.Codigo = dto.Codigo;
        product.Categoria = dto.Categoria;
        product.CantidadStock = dto.CantidadStock;
        product.PrecioUnitario = dto.PrecioUnitario;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Productos.FindAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        _context.Productos.Remove(product);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}