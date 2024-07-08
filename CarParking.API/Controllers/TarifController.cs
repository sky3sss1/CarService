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
    public class TarifController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarifController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateTarif")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateTarif([FromBody] CreateTarifRequest request)
        {
            var createTarifCommand = new CreateTarifCommand(request.Wash_id, request.Name, request.Cost, request.CostIfLoosed);

            var result = await _mediator.Send(createTarifCommand);

            return Ok(result);
        }

        [HttpDelete("DeleteTarif/{id}")]
        public async Task<ActionResult<bool>> DeleteTarif(Guid id)
        {
            var deleteTarifCommand = new DeleteTarifCommand(id);

            var result = await _mediator.Send(deleteTarifCommand);

            return Ok(result);
        }

        [HttpGet("GetTarifById/{id}")]
        public async Task<ActionResult<Tarif>> GetTarifById(Guid id)
        {
            var getTarifByIdCommand = new GetTarifByIdCommand(id);

            var tarif = await _mediator.Send(getTarifByIdCommand);

            if (tarif == null)
            {
                return NotFound();
            }

            return Ok(tarif);
        }

        [HttpPut("UpdateTarif")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateTarif([FromBody] UpdateTarifRequest request)
        {
            var updateTarifCommand = new UpdateTarifCommand(request.Wash_Id, request.Id, request.Name, request.Cost, request.CostIfLoosed);

            var result = await _mediator.Send(updateTarifCommand);

            return Ok(result);
        }
        [HttpGet("GetAllTarifs")]
        public async Task<ActionResult<IEnumerable<Tarif>>> GetAllTarifs()
        {
            var command = new GetAllTarifsCommand();
            var tarifs = await _mediator.Send(command);
            return Ok(tarifs);
        }
        [HttpGet("GetTarifFullPriceById/{id}")]
        public async Task<ActionResult<Tarif>> GetTarifFullPriceById(Guid id)
        {
            var getTarifFullPriceByIdCommand = new GetTarifFullPriceByIdCommand(id);

            var tarif = await _mediator.Send(getTarifFullPriceByIdCommand);

            if (tarif == null)
            {
                return NotFound();
            }

            return Ok(tarif);
        }
        [HttpGet("GetTarifPriceById/{id}")]
        public async Task<ActionResult<Tarif>> GetTarifPriceById(Guid id)
        {
            var getTarifPriceByIdCommand = new GetTarifPriceByIdCommand(id);

            var tarif = await _mediator.Send(getTarifPriceByIdCommand);

            if (tarif == null)
            {
                return NotFound();
            }

            return Ok(tarif);
        }
    }
}
