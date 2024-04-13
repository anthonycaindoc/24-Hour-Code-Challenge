using AutoMapper;
using MediatR;
using PizzaSales.Core.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Features.Token.Queries.GetToken
{
    public class GetTokenQuery(string clientID) : IRequest<GetTokenVM>
    {
        public string ClientID { get; set; } = clientID;
    }

    public class GetTokenHandler(IMapper _mapper,ITokenService _tokenService) : IRequestHandler<GetTokenQuery, GetTokenVM>
    {
        public async Task<GetTokenVM> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _tokenService.GenerateToken([new Claim(ClaimTypes.NameIdentifier, request.ClientID)]);

            return _mapper.Map<GetTokenVM>(result);
        }
    }
}
