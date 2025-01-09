using System.ComponentModel.DataAnnotations.Schema;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.Orders
            .Include(m => m.Product)
            .ToListAsync();
    }


    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // POST: api/Orders
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] OrdersDto ordersDto)
    {
        var order = new Order
        {
            Observation = ordersDto.Observation,
            ProductId = ordersDto.ProductId,
            Quantity = ordersDto.Quantity,
        };

        var product = await _context.Products.FindAsync(ordersDto.ProductId);
        if (product == null)
        {
            return NotFound();
        }

        product.Quantity -= (int)ordersDto.Quantity; 

        if (product.Quantity < 0)
        {
            return BadRequest("Quantidade insuficiente do produto.");
        }

        _context.Entry(product).State = EntityState.Modified;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();


        return CreatedAtAction("GetOrder", new { id = order.Id }, order);
    }




    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }
}

public class OrdersDto
{
    public int Id { get; set; }
    public string? Observation { get; set; }
    public float Quantity { get; set; }
    public int ProductId { get; set; }
}
