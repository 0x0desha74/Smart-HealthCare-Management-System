using CareFlow.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return NotFound(new ApiResponse(404,"Not found endpoint"));
        }
    }
}
