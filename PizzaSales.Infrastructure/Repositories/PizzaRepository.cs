using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;
using PizzaSales.Domain.Models.Orders;
using PizzaSales.Domain.Models.Pizza;
using PizzaSales.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Infrastructure.Repositories
{
    public class PizzaRepository(PizzaDbContext _db) : IPizzaRepository
    {
        public async Task<bool> AddPizza(Pizza pizza, CancellationToken cancellationToken = default)
        {
            await _db.Pizzas.AddAsync(pizza, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> AddPizza(IEnumerable<Pizza> pizzas, CancellationToken cancellationToken = default)
        {
            await _db.Pizzas.AddRangeAsync(pizzas, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> AddPizzaType(PizzaType pizzaTypes, CancellationToken cancellationToken = default)
        {
            await _db.PizzaTypes.AddAsync(pizzaTypes, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> AddPizzaType(IEnumerable<PizzaType> pizzaTypes, CancellationToken cancellationToken = default)
        {
            await _db.PizzaTypes.AddRangeAsync(pizzaTypes, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
