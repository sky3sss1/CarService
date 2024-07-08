using Application.Templates;
using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Entities;

namespace CarParking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FloorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FloorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateFloor")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateFloor([FromBody] CreateFloorRequest request)
        {
            var createFloorCommand = new CreateFloorCommand(request.FloorNumber);

            var result = await _mediator.Send(createFloorCommand);

            return Ok(result);
        }

        [HttpDelete("DeleteFloor/{id}")]
        public async Task<ActionResult<bool>> DeleteFloor(Guid id)
        {
            var deleteFloorCommand = new DeleteFloorCommand(id);

            var result = await _mediator.Send(deleteFloorCommand);

            return Ok(result);
        }

        [HttpGet("GetFloorById/{id}")]
        public async Task<ActionResult<Floor>> GetFloorById(Guid id)
        {
            var getFloorByIdCommand = new GetFloorByIdCommand(id);

            var floor = await _mediator.Send(getFloorByIdCommand);

            if (floor == null)
            {
                return NotFound();
            }

            return Ok(floor);
        }

        [HttpPut("UpdateFloor")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateFloor([FromBody] UpdateFloorRequest request)
        {
            var updateFloorCommand = new UpdateFloorCommand(request.Id, request.FloorNumber);

            var result = await _mediator.Send(updateFloorCommand);

            return Ok(result);
        }
        [HttpGet("GetAllFloors")]
        public async Task<ActionResult<IEnumerable<Floor>>> GetAllFloors()
        {
            var getAllFloorsCommand = new GetAllFloorsCommand();

            var floors = await _mediator.Send(getAllFloorsCommand);

            return Ok(floors);
        }
    }
}
