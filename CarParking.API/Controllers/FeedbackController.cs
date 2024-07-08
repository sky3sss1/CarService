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
    public class FeedbackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedbackController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateFeedback")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            var createFeedbackCommand = new CreateFeedbackCommand(request.User_Id, request.Text);

            var result = await _mediator.Send(createFeedbackCommand);

            return Ok(result);
        }

        [HttpDelete("DeleteFeedback/{id}")]
        public async Task<ActionResult<bool>> DeleteFeedback(Guid id)
        {
            var deleteFeedbackCommand = new DeleteFeedbackCommand(id);

            var result = await _mediator.Send(deleteFeedbackCommand);

            return Ok(result);
        }

        [HttpGet("GetFeedbackById/{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(Guid id)
        {
            var getFeedbackByIdCommand = new GetFeedbackByIdCommand(id);

            var feedback = await _mediator.Send(getFeedbackByIdCommand);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        [HttpPut("UpdateFeedback")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateFeedback([FromBody] UpdateFeedbackRequest request)
        {
            var updateFeedbackCommand = new UpdateFeedbackCommand(request.Id, request.User_Id, request.Text);

            var result = await _mediator.Send(updateFeedbackCommand);

            return Ok(result);
        }
        [HttpGet("GetAllFeedbacks")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedbacks()
        {
            var getAllFeedbacksQuery = new GetAllFeedbacksCommand();

            var feedbacks = await _mediator.Send(getAllFeedbacksQuery);

            return Ok(feedbacks);
        }
    }
}
