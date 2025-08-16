namespace Getway.Middlewares
{
    public class InterceptionMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request path
            Console.WriteLine($"Request Path: {context.Request.Path}");
            // Call the next middleware in the pipeline
            context.Request.Headers["Referrer"] = "Api-Getway";
            await next(context);
            // Log the response status code
            Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
        }
    }
}
