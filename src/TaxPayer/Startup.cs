using TaxPayer.Extensions;

namespace TaxPayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataProtection();
            services.ConfigureDbContext(Configuration);
            services.ConfigureIISIntegration();
            services.ConfigureControllers();
            services.ConfigureForwardHeaders();
            services.AddHttpContextAccessor();
            services.ConfigureCors();
            services.AddServices();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.ConfigureExceptionHandler(logger);
            app.StartupInfo(env, Configuration, logger);
            app.ConfigureSwagger(env, Configuration);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
