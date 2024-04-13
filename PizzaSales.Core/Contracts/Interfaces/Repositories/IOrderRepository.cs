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
        Task<IEnumerable<OrderVM>> GetOrders();
        Task<OrderVM> GetOrder(int id);
    }
}
