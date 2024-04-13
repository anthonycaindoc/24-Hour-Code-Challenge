using MediatR;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;

namespace PizzaSales.Core.Features.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQuery(int id) : IRequest<OrderVM>
    {
        public int OrderID { get; set; } = id;
    }

    public class GetOrderByIDHandler(IOrderRepository _orderRepository) : IRequestHandler<GetOrderByIDQuery, OrderVM>
    {
        public async Task<OrderVM> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrder(request.OrderID);
        }
    }
}
