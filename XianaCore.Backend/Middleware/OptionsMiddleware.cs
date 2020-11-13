namespace XianaCore.Backend.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    public class OptionsMiddleware
    {
        /// <summary>
        /// The next.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public OptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        /// <summary>
        /// Begins the invoke.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private Task BeginInvoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
            context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
            context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            return _next.Invoke(context);
        }
    }

    public static class OptionsMiddlewareExtensions
    {
        /// <summary>
        /// Uses the options.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OptionsMiddleware>();
        }
    }
}
