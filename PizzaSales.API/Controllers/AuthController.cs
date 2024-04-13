using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaSales.Core.Contracts.Attributes;
using PizzaSales.Core.Features.Token.Queries.GetToken;
using System.Security.Claims;

namespace PizzaSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("login")]
        [ClientAuthentication]
        public async Task<IActionResult> Login()
        {
            var clientID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _mediator.Send(new GetTokenQuery(clientID))) ;
        }
    }
}
