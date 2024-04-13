using MediatR;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaSales.Core.Features.Insights.Queries.GetDaillySalesInsights
{
    public class GetDaillySalesInsightsQuery(DateTime from, DateTime to) : IRequest<IEnumerable<GetDaillySalesInsightsVM>>
    {
        public DateTime DateFrom { get; set; } = from;
        public DateTime DateTo { get; set; } = to;
    }

    public class GetDaillySalesInsightsHandler(IOrderRepository _orderRepository) : IRequestHandler<GetDaillySalesInsightsQuery, IEnumerable<GetDaillySalesInsightsVM>>
    {
        public async Task<IEnumerable<GetDaillySalesInsightsVM>> Handle(GetDaillySalesInsightsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(request.DateFrom, request.DateTo, cancellationToken);

            return orders.GroupBy(o => new { o.OrderDate.Date, })
                .Select(g => new GetDaillySalesInsightsVM
                {
                    Date = g.Key.Date,
                    TotalSales = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.Pizza.Pizza.Price))
                })
                .OrderBy(m => m.Date);
        }
    }
}
