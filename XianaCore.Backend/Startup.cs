namespace XianaCore.Backend
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using XianaCore.Backend.Middleware;
    using XianaCore.Infrastructure.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Cookie Policy Options
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var urlOrigins = Configuration.GetValue<string>("UrlOrigins").Split(';');

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy",
                    builder =>
                        builder.WithOrigins(urlOrigins).SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithHeaders("authorization", "accept", "content-type", "origin"));
            });
            #endregion

            string connection = Configuration.GetConnectionString("CSXianaCore");
            services.AddDbContext<XianaDbContext>(options => options.UseSqlServer(connection));

            //Enable migrations
            XianaDbContext.IsMigration = false;

            services.AddControllers();

            #region Register (dependency injection)

            IoC.AddDependency(services);

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("SiteCorsPolicy");
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
