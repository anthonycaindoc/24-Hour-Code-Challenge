using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Contracts.Interfaces.Services
{
    public interface IClientService
    {
        Task<bool> ValidateClient(string clientID, string clientSecret);
    }
}
