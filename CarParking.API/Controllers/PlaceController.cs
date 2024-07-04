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
    public class PlaceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlaceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreatePlace")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreatePlace([FromBody] CreatePlaceRequest request)
        {
            var createPlaceCommand = new CreatePlaceCommand(request.Is_Charge, request.Voltage);

            var result = await _mediator.Send(createPlaceCommand);

            return Ok(result);
        }

        [HttpPost("DeletePlace/{id}")]
        public async Task<ActionResult<bool>> DeletePlace(Guid id)
        {
            var deletePlaceCommand = new DeletePlaceCommand(id);

            var result = await _mediator.Send(deletePlaceCommand);

            return Ok(result);
        }

        [HttpGet("GetPlaceById/{id}")]
        public async Task<ActionResult<Place>> GetPlaceById(Guid id)
        {
            var getPlaceByIdCommand = new GetPlaceByIdCommand(id);

            var place = await _mediator.Send(getPlaceByIdCommand);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        [HttpPut("UpdatePlace")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdatePlace([FromBody] UpdatePlaceRequest request)
        {
            var updatePlaceCommand = new UpdatePlaceCommand(request.Id, request.Is_Charge, request.Voltage);

            var result = await _mediator.Send(updatePlaceCommand);

            return Ok(result);
        }
        [HttpGet("GetAllPlaces")]
        public async Task<ActionResult<IEnumerable<Place>>> GetAllPlaces()
        {
            var getAllPlacesCommand = new GetAllPlacesCommand();

            var places = await _mediator.Send(getAllPlacesCommand);

            return Ok(places);
        }
    }
}
