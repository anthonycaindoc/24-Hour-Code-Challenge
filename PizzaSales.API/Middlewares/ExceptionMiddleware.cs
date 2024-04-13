using Newtonsoft.Json;
using PizzaSales.Core.Contracts.Exceptions;
using System.Net;

namespace PizzaSales.API.Middlewares
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> _logger, RequestDelegate _requestDelegate)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            var result = string.Empty;
            var httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case UnauthorizedAccessException e:
                    {
                        httpStatusCode = HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new ExceptionMiddlewareResponse
                        {
                            ErrorMessage = "Client ID or Client Secret is not valid. Please contact the administrator.",
                        });

                        _logger.LogWarning(e, e.ToString());
                        break;
                    }
                case ValidationException e:
                    {
                        httpStatusCode = HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new ExceptionMiddlewareResponse
                        {
                            ErrorMessage = e.ValidationErrors.FirstOrDefault(),
                            ErrorPayload = JsonConvert.SerializeObject(e.ValidationErrors)
                        });

                        _logger.LogWarning(e, e.ToString());
                        break;
                    }
                case Exception e:
                    {
                        httpStatusCode = HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new ExceptionMiddlewareResponse
                        {
                            ErrorMessage = e.Message
                        });

                        _logger.LogError(e, e.ToString());
                        break;
                    }
            }

            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(result);
        }
    }

    public class ExceptionMiddlewareResponse
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public string ErrorPayload { get; set; } = string.Empty;
    }
}
