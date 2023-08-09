using System.Net;
using System.Net.Mime;

namespace FinanceOperation.Api.Common.Web.ErrorMiddleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if(context.Response.HasStarted)
            {
                return;
            }

            switch (ex)
            {
                // 500
                default:
                    await GenerateErrorResponse(context, HttpStatusCode.InternalServerError, ex.Message);
                    break;
            }
        }

        static Task GenerateErrorResponse(HttpContext httpContext, HttpStatusCode httpStatus, string message)
        {
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)httpStatus;
            return httpContext.Response.WriteAsync(message);
        }
    }
}

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ErrorHandlerMiddleware>();
}
