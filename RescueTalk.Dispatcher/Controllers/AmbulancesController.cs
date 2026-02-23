using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.Models;
using Microsoft.AspNetCore.SignalR;
using RescueTalk.Dispatcher.Hubs;
using RescueTalk.Dispatcher.DTOs;

namespace RescueTalk.Dispatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmbulancesController : Controller
    {
        private readonly RescueTalkDbContext _context;
        private readonly IHubContext<AmbulanceHub> _hub;

        public AmbulancesController(RescueTalkDbContext context, IHubContext<AmbulanceHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        // GET: api/ambulances
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ambulances = await _context.Ambulances.ToListAsync();
            return Ok(ambulances);
        }

        // GET: api/ambulances/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var ambulances = await _context.Ambulances
                .Where(a => a.IsAvailable)
                .ToListAsync();

            return Ok(ambulances);
        }

        // PUT: api/ambulances/{id}/location
        [HttpPut("{id}/location")]
        public async Task<IActionResult> UpdateLocation(Guid id, [FromBody] UpdateLocationDto locationUpdate)
        {
            var ambulance = await _context.Ambulances.FindAsync(id);

            if (ambulance == null)
                return NotFound();

            ambulance.Latitude = locationUpdate.Latitude;
            ambulance.Longitude = locationUpdate.Longitude;
            ambulance.LastUpdate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync(
                "ReceiveLocation",
                ambulance.Id,
                ambulance.Latitude,
                ambulance.Longitude
            );

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ambulance ambulance)
        {
            ambulance.Id = Guid.NewGuid();
            ambulance.IsAvailable = true;
            ambulance.LastUpdate = DateTime.UtcNow;

            _context.Ambulances.Add(ambulance);
            await _context.SaveChangesAsync();

            return Ok(ambulance);
        }

    }
}
