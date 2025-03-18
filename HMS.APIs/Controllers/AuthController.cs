using HMS.Application.Features.Auth.Queries;
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
        public async Task<IActionResult> LoginAsync([FromBody] LoginQuery query, CancellationToken cancellationToken)
        {
            var authResult = await _mediator.Send(query, cancellationToken);

            return authResult.IsSuccess
                ? Ok(authResult.Value)
                : authResult.ToProblem();
        }
    }
}
