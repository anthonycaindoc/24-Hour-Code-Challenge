﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Core.ViewModels;
using PizzaSales.Domain.Models.Orders;
using PizzaSales.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Infrastructure.Repositories
{
    public class OrderRepository(PizzaDbContext _db) : IOrderRepository
    {
        public async Task<IEnumerable<OrderVM>> GetOrders(CancellationToken cancellationToken = default)
        {
            var orders = _db.Orders
                .Select(o => new OrderVM
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    OrderDetails = _db.OrderDetails
                        .Where(od => od.OrderID == o.OrderID)
                        .Select(od => new OrderDetailsVM
                        {
                            OrderDetailID = od.OrderDetailID,
                            OrderID = od.OrderID,
                            Quantity = od.Quantity,
                            Pizza = new PizzaVM
                            {
                                Pizza = _db.Pizzas.FirstOrDefault(p => p.Code == od.PizzaCode),
                                PizzaType = _db.PizzaTypes.FirstOrDefault(pt => pt.Code == _db.Pizzas.FirstOrDefault(p => p.Code == od.PizzaCode).PizzaTypeCode)
                            }
                        })
                        .ToList()
                });

            return await orders.ToListAsync(cancellationToken);
        }

        public async Task<OrderVM> GetOrder(int id, CancellationToken cancellationToken = default)
        {
            var orders = _db.Orders
                .Where(m => m.OrderID == id)
                .Select(o => new OrderVM
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    OrderDetails = _db.OrderDetails
                        .Where(od => od.OrderID == o.OrderID)
                        .Select(od => new OrderDetailsVM
                        {
                            OrderDetailID = od.OrderDetailID,
                            OrderID = od.OrderID,
                            Quantity = od.Quantity,
                            Pizza = new PizzaVM
                            {
                                Pizza = _db.Pizzas.FirstOrDefault(p => p.Code == od.PizzaCode),
                                PizzaType = _db.PizzaTypes.FirstOrDefault(pt => pt.Code == _db.Pizzas.FirstOrDefault(p => p.Code == od.PizzaCode).PizzaTypeCode)
                            }
                        })
                        .ToList()
                });

            return await orders.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderVM>> GetOrders(DateTime from, DateTime to, CancellationToken cancellationToken = default)
        {
            var orders = _db.Orders
                .Where(o => o.OrderDate.Date >= from.Date && o.OrderDate.Date <= to.Date)
                .Select(o => new OrderVM
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    OrderDetails = _db.OrderDetails
                        .Where(od => od.OrderID == o.OrderID)
                        .Select(od => new OrderDetailsVM
                        {
                            OrderDetailID = od.OrderDetailID,
                            OrderID = od.OrderID,
                            Quantity = od.Quantity,
                            Pizza = new PizzaVM
                            {
                                Pizza = _db.Pizzas.FirstOrDefault(p => p.Code == od.PizzaCode),
                                PizzaType = _db.PizzaTypes.FirstOrDefault(pt => pt.Code == _db.Pizzas.FirstOrDefault(p => p.Code == od.PizzaCode).PizzaTypeCode)
                            }
                        })
                        .ToList()
                });

            return await orders.ToListAsync(cancellationToken);
        }

        public async Task<bool> AddOrder(Order order, CancellationToken cancellationToken = default)
        {
            await _db.Orders.AddAsync(order, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> AddOrder(IEnumerable<Order> orders, CancellationToken cancellationToken)
        {
            await _db.Orders.AddRangeAsync(orders, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> AddOrderDetail(OrderDetail orderDetail, CancellationToken cancellationToken = default)
        {
            await _db.OrderDetails.AddAsync(orderDetail, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> AddOrderDetail(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default)
        {
            await _db.OrderDetails.AddRangeAsync(orderDetails, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
