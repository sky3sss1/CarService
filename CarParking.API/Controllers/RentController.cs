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
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateRent")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateRent([FromBody] CreateRentRequest request)
        {
            var createRentCommand = new CreateRentCommand(
                request.Parking_Id,
                request.Car_Id,
                request.Payment_Id,
                request.Start_Date,
                request.End_Date,
                request.LosedDays);

            var result = await _mediator.Send(createRentCommand);

            return Ok(result);
        }

        [HttpPost("DeleteRent/{id}")]
        public async Task<ActionResult<bool>> DeleteRent(Guid id)
        {
            var deleteRentCommand = new DeleteRentCommand(id);

            var result = await _mediator.Send(deleteRentCommand);

            return Ok(result);
        }

        [HttpGet("GetRentById/{id}")]
        public async Task<ActionResult<Rent>> GetRentById(Guid id)
        {
            var getRentByIdCommand = new GetRentByIdCommand(id);

            var rent = await _mediator.Send(getRentByIdCommand);

            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        [HttpPut("UpdateRent")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateRent([FromBody] UpdateRentRequest request)
        {
            var updateRentCommand = new UpdateRentCommand(
                request.Id,
                request.Parking_Id,
                request.Car_Id,
                request.Payment_Id,
                request.Start_Date,
                request.End_Date,
                request.LosedDays);

            var result = await _mediator.Send(updateRentCommand);

            return Ok(result);
        }
        [HttpGet("GetAllRents")]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAllRents()
        {
            var getAllRentsCommand = new GetAllRentsCommand();

            var rents = await _mediator.Send(getAllRentsCommand);

            return Ok(rents);
        }
    }
}
