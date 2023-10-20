using DynamicSun.Core.Exceptions;
using DynamicSun.Core.Models;
using DynamicSun.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace DynamicSun.Extensions
{
    public static class ExceptionHandler
    {
        public static void UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsHandlerMiddleware>();
        }
    }
}
