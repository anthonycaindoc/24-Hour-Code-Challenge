using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using PizzaSales.Core.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Contracts.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ClientAuthenticationAttribute : Attribute, IAsyncActionFilter
    {
        public ClientAuthenticationAttribute() { }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationValue))
            {
                throw new UnauthorizedAccessException();
            }

            var authorization = authorizationValue.ToString();
            if (!authorization.Contains("Basic "))
            {
                throw new UnauthorizedAccessException();
            }

            var clientService = context.HttpContext.RequestServices.GetRequiredService<IClientService>();
            var encodedCredential = authorization.Replace("Basic ", "");
            var data = Convert.FromBase64String(encodedCredential);
            var clientCredential = Encoding.UTF8.GetString(data).Split(":");

            var result = await clientService.ValidateClient(clientCredential[0], clientCredential[1]);

            if (!result)
            {
                throw new UnauthorizedAccessException();
            }

            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, clientCredential[0]),
            }));

            await next();
        }
    }
}
