using PizzaSales.Core.ViewModels;
using PizzaSales.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Contracts.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderVM>> GetOrders(CancellationToken cancellationToken = default);
        Task<OrderVM> GetOrder(int id, CancellationToken cancellationToken = default);
        Task<bool> AddOrder(Order order, CancellationToken cancellationToken = default);
        Task<bool> AddOrder(IEnumerable<Order> orders, CancellationToken cancellationToken = default);
        Task<bool> AddOrderDetail(OrderDetail orderDetail, CancellationToken cancellationToken = default);
        Task<bool> AddOrderDetail(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default);
    }
}
