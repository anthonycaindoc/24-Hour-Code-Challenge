using Microsoft.EntityFrameworkCore;
using PizzaSales.Domain.Models.Orders;
using PizzaSales.Domain.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Infrastructure.Contexts
{
    public class PizzaDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Pizza>().HasKey(x => x.PizzaID);
            modelBuilder.Entity<PizzaType>().HasKey(x => x.PizzaTypeID);
            modelBuilder.Entity<Order>().HasKey(x => x.OrderID);
            modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderDetailID);
        }
    }
}
