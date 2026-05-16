using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.DTO;
using RestApi.Entities;
using RestApi.Enums;

namespace RestApi.Controllers;

[ApiController]
[Route("api/products/{productId:int}/movements")]
public class StockMovementsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StockMovementsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovimientoStockDTO>>> GetMovements(
        int productId)
    {
        var productExists = await _context.Productos
            .AnyAsync(p => p.Id == productId);

        if (!productExists)
        {
            return NotFound(new
            {
                message = "El producto no ha sido encontrado."
            });
        }

        var movements = await _context.MovimientosStock
            .Where(m => m.ProductId == productId)
            .OrderByDescending(m => m.FechaMovimiento)
            .Select(m => new MovimientoStockDTO
            {
                Id = m.Id,
                ProductId = m.ProductId,
                Tipo = m.Tipo,
                Cantidad = m.Cantidad,
                Razon = m.Razon,
                Creado = m.FechaMovimiento
            })
            .ToListAsync();

        return Ok(movements);
    }

    [HttpPost]
    public async Task<ActionResult<MovimientoStockDTO>> CreateMovement(
        int productId,
        CrearMovimientoDTO dto)
    {
        var product = await _context.Productos
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
        {
            return NotFound(new
            {
                message = "El producto no ha sido encontrado."
            });
        }

        if (dto.Tipo == MovimientoStock.Vendido)
        {
            if (product.CantidadStock < dto.Cantidad)
            {
                return BadRequest(new
                {
                    message = "No existe suficiente Stock"
                });
            }

            product.CantidadStock -= dto.Cantidad;
        }
        else
        {
            product.CantidadStock += dto.Cantidad;
        }

        var movement = new Movimientos
        {
            ProductId = productId,
            Tipo = dto.Tipo,
            Cantidad = dto.Cantidad,
            Razon = dto.Razon 
        };

        _context.MovimientosStock.Add(movement);

        await _context.SaveChangesAsync();

        var result = new MovimientoStockDTO
        {
            Id = movement.Id,
            ProductId = movement.ProductId,
            Tipo = movement.Tipo,
            Cantidad = movement.Cantidad,
            Razon = movement.Razon,
            Creado = movement.FechaMovimiento
        };

        return Ok(result);
    }
}