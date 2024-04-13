using MediatR;
using MediatR.Pipeline;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;
using PizzaSales.Domain.Models.Orders;
using PizzaSales.Domain.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Features.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderVM>>
    {

    }

    public class GetOrdersHandler(IOrderRepository _orderRepository) : IRequestHandler<GetOrdersQuery, IEnumerable<OrderVM>>
    {
        public async Task<IEnumerable<OrderVM>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrders();
        }
    }
}
