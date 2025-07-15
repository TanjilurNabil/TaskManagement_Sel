using Serilog;
using Serilog.Core;
using System.Net;
using System.Text.Json;

namespace TaskManagement.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
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
                //Log exception
                var errorId = Guid.NewGuid();
                _logger.LogError(ex, $"{errorId} : {ex.Message}");

                //Return a custom response
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    errorId,
                    message = "An unexpected error occurred. Please contact support with the error ID."
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));

            }
        }
    }
}
