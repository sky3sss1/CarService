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
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateCar")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateCar([FromBody] CreateCarRequest request)
        {
            var createCarCommand = new CreateCarCommand(request.UserId, request.GovernmentNumber, request.Model, request.MinimalVoltage);

            var result = await _mediator.Send(createCarCommand);

            return Ok(result);
        }

        [HttpPost("DeleteCar/{id}")]
        public async Task<ActionResult<bool>> DeleteCar(Guid id)
        {
            var deleteCarCommand = new DeleteCarCommand(id);

            var result = await _mediator.Send(deleteCarCommand);

            return Ok(result);
        }

        [HttpGet("GetCarById/{id}")]
        public async Task<ActionResult<Car>> GetCarById(Guid id)
        {
            var getCarByIdCommand = new GetCarByIdCommand(id);

            var car = await _mediator.Send(getCarByIdCommand);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPut("UpdateCar")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateCar([FromBody] UpdateCarRequest request)
        {
            var updateCarCommand = new UpdateCarCommand(request.Id, request.UserId, request.GovernmentNumber, request.Model, request.MinimalVoltage);

            var result = await _mediator.Send(updateCarCommand);

            return Ok(result);
        }
        [HttpGet("GetAllCars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var getAllCarsQuery = new GetAllCarsCommand();

            var cars = await _mediator.Send(getAllCarsQuery);

            return Ok(cars);
        }
    }
}
