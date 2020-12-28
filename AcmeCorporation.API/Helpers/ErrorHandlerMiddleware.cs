using System.Net;
using AcmeCorporation.API.Data.Contracts;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AcmeCorporation.API.Helpers
{
    public static class ErrorHandlerMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager loggerManager)
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
                        //  await issueLog.Add(new IssueLog
                        // {
                        //     ErrorDetails = "ontextFeature.Error.ToString()",
                        //     StackTrace = "contextFeature.Error.StackTrace"
                        // });

                        // issueLog.SaveChanges();
                        // logger.LogInformation(contextFeature.Error.ToString());           

                        // logger.LogError($"Something went wrong: {contextFeature.Error}");
                        loggerManager.LogError(contextFeature.Error.ToString());
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }

        // public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        // {
        //     app.UseMiddleware<ErrorHandlerMiddleware>();
        // }
    }
}