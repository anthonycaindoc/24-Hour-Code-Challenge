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

namespace PizzaSales.Core.Features.Orders.Commands.AddBatchOrderDetails
{
    public class AddBatchOrderDetailCommand(Stream file) : IRequest<bool>
    {
        public Stream File { get; set; } = file;
    }

    public class AddBatchOrderDetailHandler(IOrderRepository _orderRepository) : IRequestHandler<AddBatchOrderDetailCommand, bool>
    {
        public async Task<bool> Handle(AddBatchOrderDetailCommand request, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(request.File);
            var csvData = await reader.ReadToEndAsync(cancellationToken);
            var lines = csvData.Split("\r\n");

            var lstOrderDetails = new List<OrderDetail>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                    continue;

                var line = lines[i].Split(',');
                if (line.Length != 4)
                    throw new ValidationException("Invalid file format.");
                
                lstOrderDetails.Add(new OrderDetail()
                {
                    OrderID = Convert.ToInt32(line[1]),
                    PizzaCode = line[2],
                    Quantity = Convert.ToInt32(line[3]),
                });
            }

            return await _orderRepository.AddOrderDetail(lstOrderDetails, cancellationToken);
        }
    }
}
