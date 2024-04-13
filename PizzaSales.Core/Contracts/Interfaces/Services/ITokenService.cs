using PizzaSales.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Contracts.Interfaces.Services
{
    public interface ITokenService
    {
        Task<Token> GenerateToken(IEnumerable<Claim> claims);
    }
}
