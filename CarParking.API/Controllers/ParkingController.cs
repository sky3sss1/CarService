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
    public class ParkingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateParking")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateParking([FromBody] CreateParkingRequest request)
        {
            var createParkingCommand = new CreateParkingCommand(request.Floor_Id, request.Place_Id);

            var result = await _mediator.Send(createParkingCommand);

            return Ok(result);
        }

        [HttpPost("DeleteParking/{id}")]
        public async Task<ActionResult<bool>> DeleteParking(Guid id)
        {
            var deleteParkingCommand = new DeleteParkingCommand(id);

            var result = await _mediator.Send(deleteParkingCommand);

            return Ok(result);
        }

        [HttpGet("GetParkingById/{id}")]
        public async Task<ActionResult<Parking>> GetParkingById(Guid id)
        {
            var getParkingByIdCommand = new GetParkingByIdCommand(id);

            var parking = await _mediator.Send(getParkingByIdCommand);

            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking);
        }

        [HttpPut("UpdateParking")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateParking([FromBody] UpdateParkingRequest request)
        {
            var updateParkingCommand = new UpdateParkingCommand(request.Id, request.Floor_Id, request.Place_Id);

            var result = await _mediator.Send(updateParkingCommand);

            return Ok(result);
        }
        [HttpGet("GetAllParkings")]
        public async Task<ActionResult<IEnumerable<Parking>>> GetAllParkings()
        {
            var getAllParkingsCommand = new GetAllParkingsCommand();

            var parkings = await _mediator.Send(getAllParkingsCommand);

            return Ok(parkings);
        }
    }
}
