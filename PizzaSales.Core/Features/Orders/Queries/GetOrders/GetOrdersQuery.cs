using AutoMapper;
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
    public class GetOrdersQuery : IRequest<IEnumerable<GetOrdersVM>>
    {

    }

    public class GetOrdersHandler(IMapper _mapper, IOrderRepository _orderRepository) : IRequestHandler<GetOrdersQuery, IEnumerable<GetOrdersVM>>
    {
        public async Task<IEnumerable<GetOrdersVM>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders();
            return _mapper.Map<IEnumerable<GetOrdersVM>>(orders);
        }
    }
}
