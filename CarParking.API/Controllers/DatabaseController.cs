using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DatabaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("tables")]
        public async Task<ActionResult<List<string>>> GetAllTables()
        {
            var result = await _mediator.Send(new GetAllTablesCommand());
            return Ok(result);
        }
    }
}
