using Microsoft.AspNetCore.Mvc;

namespace Mbsample.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        //TODO:could be mediator added here if migratig to CQRS pattern
    }
}
