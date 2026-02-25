using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.DTOs;
using RescueTalk.Dispatcher.Models;
using RescueTalk.Dispatcher.Services;

namespace RescueTalk.Dispatcher.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _service;

        public IncidentsController(IIncidentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpPost("complete/{code}")]
        public async Task<IActionResult> Complete(string code)
        {
            await _service.CompleteAsync(code); 
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncidentDto dto)
            => Ok(await _service.CreateAsync(dto));

    }
}
