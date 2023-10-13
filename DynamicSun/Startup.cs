
namespace DynamicSun.API
{
    public class Startup
    {
        /// <summary/>
        public readonly IConfiguration _configuration;

        /// <summary/>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument();
            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
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
