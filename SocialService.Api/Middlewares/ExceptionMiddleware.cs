using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SocialService.Management.Services.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SocialService.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, string message = "", int statusCode = 0)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = statusCode == 0 ? context.Response.StatusCode : statusCode,
                Message = string.IsNullOrWhiteSpace(message) ? "Internal Server Error." : message
            }.ToString());
        }
    }

    class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
