using System.Net;
using BookShop.Application;
using BookShop.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace BookShop.Api;

public static class ExceptionHandling
{
    private class ErrorDetails
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public static IApplicationBuilder ConfigureExceptionHandling(this IApplicationBuilder app)
    {
        var logger=
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                if (IsTypeOfBusinessOrApplicationException(context)) await HandleResponse(context);
                else
                {
                    await DoLog(context);
                    await ThrowUnHandledError(context);
                }
            });
        });
        return app;
    }

    private static async Task HandleResponse(HttpContext context)
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(new ErrorDetails()
        {
            Message = exceptionHandlerFeature?.Error.Message??"",
        }.ToString());
    }
    private static async Task ThrowUnHandledError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(new ErrorDetails()
        {
            Message = "عملیات با شکست مواجه شد",
        }.ToString());
    }

    private static async Task DoLog(HttpContext context)
    {
        //todo log
    }

    private static bool IsTypeOfBusinessOrApplicationException(HttpContext context)
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerPathFeature?.Error is BusinessException or AppException) return true;
        return false;
    }
}