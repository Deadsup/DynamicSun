using DynamicSun.Core.Exceptions;
using DynamicSun.Core.Models;
using System.Text.Json;

namespace DynamicSun.Middlewares
{
    public class ExceptionsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary/>
        public ExceptionsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    AlreadyExistException => 400,
                    NotFoundException => 404,
                    NotParseableException => 400,
                    _ => 500,
                };
                var respone = new ExceptionsResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                };

                var result = JsonSerializer.Serialize(respone, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
