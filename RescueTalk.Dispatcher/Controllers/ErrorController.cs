using Microsoft.AspNetCore.Mvc;

namespace RescueTalk.Dispatcher.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            return Problem("An unexpected error occurred.");
        }
    }
}
