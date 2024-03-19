using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repository;
using TaxPayer.MapperProfiles;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services;

namespace TaxPayer.Extensions
{
    public static class ServiceExtensions
    {
        #region Services Configs
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile<TaxPayerMapperProfile>());
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(o =>
                {
                    o.SuppressAsyncSuffixInActionNames = true;
                    o.RespectBrowserAcceptHeader = true;
                    o.ReturnHttpNotAcceptable = true;
                })
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.WriteIndented = true;
                    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                })
                .AddXmlDataContractSerializerFormatters();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithExposedHeaders("X-Pagination");

                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureDataProtection(this IServiceCollection services)
        {
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"/app/tmpkeys"))
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                });
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var loggerFactory = LoggerFactory
                .Create(builder =>
                {
                    builder.ClearProviders();
                    builder.AddConsole();
                });
            var logger = loggerFactory.CreateLogger<Startup>();

            try
            {
                var connectionString = configuration.GetConnectionString("defaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    logger.LogWarning("Missing Taxpayer DB Context Information [Persistence Model] <= {c}", "caller");
                    return;
                }

                services.AddDbContext<TaxContext>(opt =>
                {
                    opt.UseSqlServer(connectionString, b => b
                        .MigrationsAssembly("Persistence"));
                });

                var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
                logger.LogInformation("Taxpayer Context for DB : {c}@{d}", connectionBuilder.InitialCatalog, connectionBuilder.DataSource);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error setting tax context [persistence Model] <= {c}: {m}", "", e.Message);
            }
        }

        public static void ConfigureForwardHeaders(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.All;
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(o => { });
        }

        #endregion Services Configs

        #region App Configs

        public static void ConfigureSwagger(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration Configuration)
        {
            var useSwagger = Convert.ToBoolean(Configuration["UseSwagger"]);
            if (env.IsProduction()) app.UseHsts();
            if (!useSwagger && !env.IsDevelopment()) return;
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void StartupInfo<T>(this IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration Configuration, ILogger<T> logger)
        {
            logger.LogInformation("Starting {n} @ {e}", env.ApplicationName, env.EnvironmentName);
        }

        #endregion App Configs

        #region Register Custom Services

        public static void AddServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient<ITaxReceiptRepository, TaxReceiptRepository>();
            services.AddTransient<IContributorRepository, ContributorRepository>();

            #endregion Repositories

            #region Services
            services.AddTransient<ITaxReceiptService, TaxReceiptService>();
            services.AddTransient<IContributorService, ContributorService>();
            services.AddTransient<CancellationTokenSource>();

            #endregion Services
        }

        #endregion Register Custom Services
    }
}