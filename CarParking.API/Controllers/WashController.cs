using Application.Templates;
using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Entities;

namespace CarParking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WashController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WashController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateWash")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateWash([FromBody] CreateWashRequest request)
        {
            var createWashCommand = new CreateWashCommand(request.Price, request.Description);

            var result = await _mediator.Send(createWashCommand);

            return Ok(result);
        }

        [HttpPost("DeleteWash/{id}")]
        public async Task<ActionResult<bool>> DeleteWash(Guid id)
        {
            var deleteWashCommand = new DeleteWashCommand(id);

            var result = await _mediator.Send(deleteWashCommand);

            return Ok(result);
        }

        [HttpGet("GetWashById/{id}")]
        public async Task<ActionResult<Wash>> GetWashById(Guid id)
        {
            var getWashByIdCommand = new GetWashByIdCommand(id);

            var wash = await _mediator.Send(getWashByIdCommand);

            if (wash == null)
            {
                return NotFound();
            }

            return Ok(wash);
        }

        [HttpPut("UpdateWash")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateWash([FromBody] UpdateWashRequest request)
        {
            var updateWashCommand = new UpdateWashCommand(request.Id, request.Price, request.Description);

            var result = await _mediator.Send(updateWashCommand);

            return Ok(result);
        }

        [HttpGet("GetAllWashes")]
        public async Task<ActionResult<IEnumerable<Wash>>> GetAllWashes()
        {
            var command = new GetAllWashesCommand();
            var washes = await _mediator.Send(command);
            return Ok(washes);
        }
    }
}
