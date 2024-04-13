using MediatR;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Features.Insights.Queries.GetMonthlySalesInsights
{
    public class GetMonthlySalesInsightsQuery(DateTime from, DateTime to) : IRequest<IEnumerable<GetMonthlySalesInsightsVM>>
    {
        public DateTime DateFrom { get; set; } = from;
        public DateTime DateTo { get; set; } = to;
    }

    public class GetMonthlySalesInsightsHandler(IOrderRepository _orderRepository) : IRequestHandler<GetMonthlySalesInsightsQuery, IEnumerable<GetMonthlySalesInsightsVM>>
    {
        public async Task<IEnumerable<GetMonthlySalesInsightsVM>> Handle(GetMonthlySalesInsightsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(request.DateFrom, request.DateTo, cancellationToken);

            return orders.GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month, })
                .Select(g => new GetMonthlySalesInsightsVM
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalSales = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.Pizza.Pizza.Price))
                })
                .OrderBy(m => m.Month);
        }
    }
}
