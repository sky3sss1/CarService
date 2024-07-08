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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> CreateUser([FromBody] CreateUserRequest request)
        {
            var createUserCommand = new CreateUserCommand(request.Name, request.Email, request.Phone_Number);

            var result = await _mediator.Send(createUserCommand);

            return Ok(result);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            var deleteUserCommand = new DeleteUserCommand(id);

            var result = await _mediator.Send(deleteUserCommand);

            return Ok(result);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var getUserByIdCommand = new GetUserByIdCommand(id);

            var user = await _mediator.Send(getUserByIdCommand);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var updateUserCommand = new UpdateUserCommand(request.Id, request.Name, request.Email, request.Phone_Number);

            var result = await _mediator.Send(updateUserCommand);

            return Ok(result);
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var command = new GetAllUsersCommand();
            var users = await _mediator.Send(command);
            return Ok(users);
        }
    }
}
