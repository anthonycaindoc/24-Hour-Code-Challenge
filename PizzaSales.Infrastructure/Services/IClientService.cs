using Microsoft.Extensions.Options;
using PizzaSales.Core.Contracts.Interfaces.Services;
using PizzaSales.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Infrastructure.Services
{
    public class ClientService(IOptions<TokenConfiguration> options) : IClientService
    {
        private readonly TokenConfiguration _tokenConfiguration = options.Value;

        public Task<bool> ValidateClient(string clientID, string clientSecret)
        {
            return Task.FromResult(_tokenConfiguration.CLIENT_ID == clientID && _tokenConfiguration.CLIENT_SECRET == clientSecret);
        }
    }
}
