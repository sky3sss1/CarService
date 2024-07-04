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
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreatePayment")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var createPaymentCommand = new CreatePaymentCommand(request.FromStart, request.Tarif_Id);

            var result = await _mediator.Send(createPaymentCommand);

            return Ok(result);
        }

        [HttpPost("DeletePayment/{id}")]
        public async Task<ActionResult<bool>> DeletePayment(Guid id)
        {
            var deletePaymentCommand = new DeletePaymentCommand(id);

            var result = await _mediator.Send(deletePaymentCommand);

            return Ok(result);
        }

        [HttpGet("GetPaymentById/{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(Guid id)
        {
            var getPaymentByIdCommand = new GetPaymentByIdCommand(id);

            var payment = await _mediator.Send(getPaymentByIdCommand);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPut("UpdatePayment")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdatePayment([FromBody] UpdatePaymentRequest request)
        {
            var updatePaymentCommand = new UpdatePaymentCommand(request.Id, request.FromStart, request.Tarif_Id);

            var result = await _mediator.Send(updatePaymentCommand);

            return Ok(result);
        }
        [HttpGet("GetAllPayments")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPayments()
        {
            var getAllPaymentsCommand = new GetAllPaymentsCommand();

            var payments = await _mediator.Send(getAllPaymentsCommand);

            return Ok(payments);
        }
    }
}
