using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaSales.API.Middlewares;
using PizzaSales.Core.Features.Orders.Queries.GetOrderByID;
using PizzaSales.Core.Features.Orders.Queries.GetOrders;
using PizzaSales.Core.ViewModels;

namespace PizzaSales.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("~/api/orders")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderVM>))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _mediator.Send(new GetOrdersQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderVM))]
        [ProducesResponseType(400, Type = typeof(ExceptionMiddlewareResponse))]
        public async Task<IActionResult> GetOrders([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetOrderByIDQuery(id)));
        }
    }
}
