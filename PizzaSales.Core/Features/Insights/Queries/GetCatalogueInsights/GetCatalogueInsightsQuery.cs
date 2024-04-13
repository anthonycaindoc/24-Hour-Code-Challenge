using MediatR;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Features.Insights.Queries.GetCatalogueInsights
{
    public class GetCatalogueInsightsQuery(DateTime from, DateTime to) : IRequest<IEnumerable<GetCatalogueInsightsVM>>
    {
        public DateTime DateFrom { get; set; } = from;
        public DateTime DateTo { get; set; } = to;
    }

    public class GetCatalogueInsightsHandler(IOrderRepository _orderRepository) : IRequestHandler<GetCatalogueInsightsQuery, IEnumerable<GetCatalogueInsightsVM>>
    {
        public async Task<IEnumerable<GetCatalogueInsightsVM>> Handle(GetCatalogueInsightsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(request.DateFrom, request.DateTo, cancellationToken);

            return orders
                .SelectMany(o => o.OrderDetails.Select(od => new GetCatalogueInsightsVM
                {
                    Name = od.Pizza.PizzaType.Name,
                    Size = od.Pizza.Pizza.Size,
                    TotalSales = od.Quantity * od.Pizza.Pizza.Price
                }))
                .GroupBy(p => (p.Name, p.Size))
                .Select(g => new GetCatalogueInsightsVM
                {
                    Name = g.Key.Name,
                    Size = g.Key.Size,
                    TotalSales = g.Sum(p => p.TotalSales)
                })
                .OrderByDescending(m => m.TotalSales);
        }
    }
}
