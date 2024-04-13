using PizzaSales.Domain.Models.Orders;
using PizzaSales.Domain.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Contracts.Interfaces.Repositories
{
    public interface IPizzaRepository
    {
        Task<bool> AddPizza(Pizza pizza, CancellationToken cancellationToken = default);
        Task<bool> AddPizza(IEnumerable<Pizza> pizzas, CancellationToken cancellationToken = default);
        Task<bool> AddPizzaType(PizzaType pizzaTypes, CancellationToken cancellationToken = default);
        Task<bool> AddPizzaType(IEnumerable<PizzaType> pizzaTypes, CancellationToken cancellationToken = default);
    }
}
