using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NZWalksAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var errorID = Guid.NewGuid();

                //Log exception
                logger.LogError(ex, errorID + " : " + ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorID,
                    ErrorMessage = "Something went wrong!!!"
                };

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
