using MediatR;
using PizzaSales.Core.Contracts.Exceptions;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Features.Orders.Commands.AddBatchOrder
{
    public class AddBatchOrderCommand(Stream file) : IRequest<bool>
    {
        public Stream File { get; set; } = file;
    }

    public class AddBatchOrderHandler(IOrderRepository _orderRepository) : IRequestHandler<AddBatchOrderCommand, bool>
    {
        public async Task<bool> Handle(AddBatchOrderCommand request, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(request.File);
            var csvData = await reader.ReadToEndAsync(cancellationToken);
            var lines = csvData.Split("\r\n");

            var lstOrders = new List<Order>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                    continue;

                var line = lines[i].Split(',');
                if (line.Length != 3)
                    throw new ValidationException("Invalid file format.");

                var format = "yyyy-MM-dd HH:mm:ss";
                DateTime.TryParseExact($"{line[1]} {line[2]}", format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

                lstOrders.Add(new Order()
                {
                    OrderID = Convert.ToInt32(line[0]),
                    OrderDate = result
                });
            }

            return await _orderRepository.AddOrder(lstOrders, cancellationToken);
        }
    }
}
