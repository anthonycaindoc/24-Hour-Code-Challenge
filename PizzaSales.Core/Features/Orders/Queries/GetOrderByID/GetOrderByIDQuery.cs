using AutoMapper;
using MediatR;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;

namespace PizzaSales.Core.Features.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQuery(int id) : IRequest<GetOrderByIDVM>
    {
        public int OrderID { get; set; } = id;
    }

    public class GetOrderByIDHandler(IMapper _mapper, IOrderRepository _orderRepository) : IRequestHandler<GetOrderByIDQuery, GetOrderByIDVM>
    {
        public async Task<GetOrderByIDVM> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrder(request.OrderID);

            return _mapper.Map<GetOrderByIDVM>(order);
        }
    }
}
