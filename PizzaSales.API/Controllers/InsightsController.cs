using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaSales.Core.Features.Insights.Queries.GetCatalogueInsights;
using PizzaSales.Core.Features.Insights.Queries.GetDaillySalesInsights;
using PizzaSales.Core.Features.Insights.Queries.GetMonthlySalesInsights;

namespace PizzaSales.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InsightsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("sales/monthly")]
        public async Task<IActionResult> GetMonthlySalesInsights([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            return Ok(await _mediator.Send(new GetMonthlySalesInsightsQuery(from, to)));
        }

        [HttpGet("sales/daily")]
        public async Task<IActionResult> GetDailySalesInsights([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            return Ok(await _mediator.Send(new GetDaillySalesInsightsQuery(from, to)));
        }

        [HttpGet("catalogue")]
        public async Task<IActionResult> GetCatalogueInsights([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            return Ok(await _mediator.Send(new GetCatalogueInsightsQuery(from, to)));
        }
    }
}
