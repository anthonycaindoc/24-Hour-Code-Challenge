using MediatR;
using Microsoft.VisualBasic.FileIO;
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

namespace PizzaSales.Core.Features.Pizzas.Commands.AddBatchPizzaType
{
    public class AddBatchPizzaTypeCommand(Stream file) : IRequest<bool>
    {
        public Stream File { get; set; } = file;
    }

    public class AddBatchPizzaTypeHandler(IPizzaRepository _pizzaRepository) : IRequestHandler<AddBatchPizzaTypeCommand, bool>
    {
        public async Task<bool> Handle(AddBatchPizzaTypeCommand request, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(request.File);
            var csvData = await reader.ReadToEndAsync(cancellationToken);
            var lines = csvData.Split("\r\n");

            var lstPizzaTypes = new List<PizzaType>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                    continue;

                var parser = new TextFieldParser(new StringReader(lines[i]))
                {
                    HasFieldsEnclosedInQuotes = true
                };

                parser.SetDelimiters(",");

                string[] fields = [];

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                }

                if (fields.Length != 4)
                    throw new ValidationException("Invalid file format.");

                lstPizzaTypes.Add(new PizzaType()
                {
                    Code = fields[0],
                    Name = fields[1],
                    Category = fields[2],
                    Ingredients = fields[3],
                });
            }

            return await _pizzaRepository.AddPizzaType(lstPizzaTypes, cancellationToken);
        }
    }
}
