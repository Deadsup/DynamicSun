using DynamicSun.Core.Interfaces;
using DynamicSun.Core.Services;
using DynamicSun.Extensions;
using DynamicSun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DynamicSun.API
{
    public class Startup
    {
        /// <summary/>
        public readonly IConfiguration Configuration;

        /// <summary/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWeatherByHoursService, WeatherByHoursService>();
            services.AddScoped<IExelParserService, ExelParserService>();
            services.AddHttpContextAccessor();

            services.AddDbContext<DataContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), op => op.MigrationsAssembly("DynamicSun")));
           
            services.AddControllers();
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAppExceptionHandler();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOpenApi();
            app.UseSwaggerUi3();
            

        }
    }
}
