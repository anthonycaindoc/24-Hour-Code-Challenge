using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaSales.API.Middlewares;
using PizzaSales.Core.Features.Orders.Commands.AddBatchOrder;
using PizzaSales.Core.Features.Orders.Commands.AddBatchOrderDetails;
using PizzaSales.Core.Features.Orders.Queries.GetOrderByID;
using PizzaSales.Core.Features.Orders.Queries.GetOrders;
using PizzaSales.Core.ViewModels;

namespace PizzaSales.API.Controllers
{
    [Authorize]
    [Route("api/order")]
    [ApiController]
    public class OrderController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("~/api/orders")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetOrdersVM>))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _mediator.Send(new GetOrdersQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetOrderByIDVM))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> GetOrders([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetOrderByIDQuery(id)));
        }

        [HttpPost("~/api/orders")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> PostOrders()
        {
            if (!Request.ContentType.Equals("text/csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Expected content type text/csv");
            }

            return Ok(await _mediator.Send(new AddBatchOrderCommand(Request.Body)));
        }

        [HttpPost("details")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> PostOrderDetails()
        {
            if (!Request.ContentType.Equals("text/csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Expected content type text/csv");
            }

            return Ok(await _mediator.Send(new AddBatchOrderDetailCommand(Request.Body)));
        }
    }
}
