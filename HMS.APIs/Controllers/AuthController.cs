using HMS.Application.Features.Auth.Commands.Register;
using HMS.Application.Features.Auth.Queries.Login;
using HMS.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HMS.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginQuery query, CancellationToken cancellationToken = default)
        {
            var authResult = await _mediator.Send(query, cancellationToken);

            return authResult.IsSuccess
                ? Ok(authResult.Value)
                : authResult.ToProblem();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return result.IsSuccess
                ? Ok(result.Value)
                : result.ToProblem();
        }
    }
}
