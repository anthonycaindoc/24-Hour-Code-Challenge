using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaSales.API.Middlewares;
using PizzaSales.Core.Features.Pizzas.Commands.AddBatchPizza;
using PizzaSales.Core.Features.Pizzas.Commands.AddBatchPizzaType;

namespace PizzaSales.API.Controllers
{
    [Route("api/pizza")]
    [ApiController]
    public class PizzaController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("~/api/pizzas")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> PostPizzas()
        {
            if (!Request.ContentType.Equals("text/csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Expected content type text/csv");
            }

            return Ok(await _mediator.Send(new AddBatchPizzaCommand(Request.Body)));
        }

        [HttpPost("types")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> PostPizzaTypes()
        {
            if (!Request.ContentType.Equals("text/csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Expected content type text/csv");
            }

            return Ok(await _mediator.Send(new AddBatchPizzaTypeCommand(Request.Body)));
        }
    }
}
