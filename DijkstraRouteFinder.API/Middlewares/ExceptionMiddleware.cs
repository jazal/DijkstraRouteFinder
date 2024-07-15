using DijkstraRouteFinder.API.Errors;
using System.Net;
using System.Text.Json;

namespace DijkstraRouteFinder.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var message = GetLastMessageOfInnerException(ex);

                _logger.LogError(ex, message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError, message, ex.StackTrace.ToString());

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }

        private string GetLastMessageOfInnerException(Exception ex)
        {
            Exception lastInnerException = ex;
            while (lastInnerException.InnerException != null)
            {
                lastInnerException = lastInnerException.InnerException;
            }

            return lastInnerException.Message;
        }
    }
}
