
using Domain.Contracts.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TaxPayer.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ConfigureExceptionHandler<T>(this IApplicationBuilder app, ILogger<T> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        AppResponse e = new InternalErrorResponse(contextFeature.Error.Message);
                        logger.LogError("Something went wrong: {e}", contextFeature.Error);
                        await context.Response.WriteAsync(e.ToString() ?? contextFeature.Error.Message);
                    }
                });
            });
        }
    }
}