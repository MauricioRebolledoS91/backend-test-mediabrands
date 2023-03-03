using mbww.test.Application.User.Commands.CreateUser;
using mbww.test.Application.User.Commands.UpdateUser;
using mbww.test.Application.User.DeleteEvent;
using mbww.test.Application.User.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mbww.test.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserListVm>>> GetAllUsers()
        {
            var dtos = await _mediator.Send(new GetUserListQuery());
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateUserCommandResponse>> UpdateUser(string id, [FromBody] UpdateUserCommand updateUserCommand)
        {
            var response = await _mediator.Send(updateUserCommand);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var deleteUserCommand = new DeleteUserCommand() { UserId = id };
            await _mediator.Send(deleteUserCommand);
            return NoContent();
        }
    }
}
