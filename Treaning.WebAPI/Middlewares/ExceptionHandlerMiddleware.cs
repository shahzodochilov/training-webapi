using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json.Serialization;
using Treaning.WebAPI.Exceptions;

namespace Treaning.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }

            catch (StatusCodeException exception)
            {
                await HandleAsync(exception, context);
            }

            catch (Exception error)
            {
                await HandleOtherExceptionAsync(error, context);
            }
            
        }

        public async Task HandleAsync(StatusCodeException exception, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int) exception.StatusCode;
            var json = JsonConvert.SerializeObject(new { Message = exception.Message } );
            httpContext.Response.ContentType= "application/json";
            await httpContext.Response.WriteAsync(json);
        }

        public async Task HandleOtherExceptionAsync(Exception exception, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 500;
            var json = JsonConvert.SerializeObject(new { Message = exception.Message });
            httpContext.Response.ContentType = "application/json";
            Log.Error(exception.Message);
            await httpContext.Response.WriteAsync(json);
        }
    }
}
