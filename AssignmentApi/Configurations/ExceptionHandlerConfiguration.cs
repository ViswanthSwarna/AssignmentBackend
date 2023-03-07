using static System.Net.Mime.MediaTypeNames;

namespace Assignment.Api.Configurations
{
    public static class ExceptionHandlerConfiguration
    {
        public static WebApplication UseBasicExceptionHandler(this WebApplication app) 
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = Text.Plain;

                    await context.Response.WriteAsync("An exception was thrown.");
                });
            });
            return app;
        }
    }
}
