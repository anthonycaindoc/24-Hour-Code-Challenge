using MediatR;
using PizzaSales.Core.Contracts.Exceptions;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Domain.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PizzaSales.Core.Features.Pizzas.Commands.AddBatchPizza
{
    public class AddBatchPizzaCommand(Stream file) : IRequest<bool>
    {
        public Stream File { get; set; } = file;
    }

    public class AddBatchPizzaHandler(IPizzaRepository _pizzaRepository) : IRequestHandler<AddBatchPizzaCommand, bool>
    {
        public async Task<bool> Handle(AddBatchPizzaCommand request, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(request.File);
            var csvData = await reader.ReadToEndAsync(cancellationToken);
            var lines = csvData.Split("\r\n");

            var lstPizzas = new List<Pizza>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                    continue;

                var line = lines[i].Split(',');
                if (line.Length != 4)
                    throw new ValidationException("Invalid file format.");

                lstPizzas.Add(new Pizza()
                {
                    Code = line[0],
                    PizzaTypeCode = line[1],
                    Size = line[2],
                    Price = Convert.ToDecimal(line[3]),
                });
            }

            return await _pizzaRepository.AddPizza(lstPizzas, cancellationToken);
        }
    }
}
