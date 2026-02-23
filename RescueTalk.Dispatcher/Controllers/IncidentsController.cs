using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.Models;

namespace RescueTalk.Dispatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly RescueTalkDbContext _context;

        public IncidentsController(RescueTalkDbContext context)
        {
            _context = context;
        }

        [HttpGet("bycode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var incident = await _context.Incidents
                .Include(i => i.Ambulance)
                .FirstOrDefaultAsync(i => i.Code == code && i.IsActive);

            if (incident == null)
                return NotFound();

            return Ok(incident);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _context.Incidents
                .Include(i => i.Ambulance)
                .Where(i => i.IsActive)
                .ToListAsync();

            return Ok(incidents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] Incident incident)
        {
            incident.Id = Guid.NewGuid();
            incident.IsActive = true;
            incident.Status = "Pending";
            incident.Code = GenerateIncidentCode();
            //incident.CreatedAt = DateTime.UtcNow;

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return Ok(incident);
        }

        private string GenerateIncidentCode()
        {
            var random = new Random();
            return "RT-" + random.Next(100000, 999999);
        }
    }
}
