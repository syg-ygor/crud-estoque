using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MaintenancesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaintenancesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Maintenances
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Maintenance>>> GetMaintenances()
    {
        return await _context.Maintenances
            .Include(m => m.Product) 
            .ToListAsync();
    }


    // GET: api/Maintenances/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Maintenance>> GetMaintenance(int id)
    {
        var maintenance = await _context.Maintenances.FindAsync(id);

        if (maintenance == null)
        {
            return NotFound();
        }

        return maintenance;
    }

    // POST: api/Maintenances
    [HttpPost]
    public async Task<ActionResult<Maintenance>> CreateMaintenance([FromBody] MaintenancesDto maintenanceDto)
    {
        var maintenance = new Maintenance
        {
            Observation = maintenanceDto.Observation,
            ProductId = maintenanceDto.ProductId,
            ScheduleAt = maintenanceDto.ScheduleAt
        };

        _context.Maintenances.Add(maintenance);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMaintenance", new { id = maintenance.Id }, maintenance);
    }

    // PUT: api/Maintenances/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaintenance(int id, [FromBody] MaintenancesDto maintenanceDto)
    {
        if (id != maintenanceDto.Id)
        {
            return BadRequest();
        }

        var maintenance = await _context.Maintenances.FindAsync(id);
        if (maintenance == null)
        {
            return NotFound();
        }

        maintenance.Observation = maintenanceDto.Observation;
        maintenance.ProductId = maintenanceDto.ProductId;
        maintenance.ScheduleAt = maintenanceDto.ScheduleAt;

        _context.Entry(maintenance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MaintenanceExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Maintenances/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaintenance(int id)
    {
        var maintenance = await _context.Maintenances.FindAsync(id);
        if (maintenance == null)
        {
            return NotFound();
        }

        _context.Maintenances.Remove(maintenance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MaintenanceExists(int id)
    {
        return _context.Maintenances.Any(e => e.Id == id);
    }
}

public class MaintenancesDto
{
    public int Id { get; set; }
    public string Observation { get; set; }
    public int ProductId { get; set; }
    public DateTime ScheduleAt { get; set; }
}
