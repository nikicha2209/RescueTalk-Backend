using Microsoft.AspNetCore.Mvc;
using RescueTalk.Dispatcher.DTOs;
using RescueTalk.Dispatcher.Services;

namespace RescueTalk.Dispatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmbulancesController : ControllerBase
    {
        private readonly IAmbulanceService _service;

        public AmbulancesController(IAmbulanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }


        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] AssignDto dto)
        {
            try
            {
                await _service.AssignAsync(dto.IncidentCode, dto.AmbulanceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
