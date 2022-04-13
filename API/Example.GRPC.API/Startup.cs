namespace Example.GRPC.API
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
            services.AddGrpc();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.MapGrpcService<Example.GRPC.API.Controllers.V1.StatusInvestController>();
        }
    }
}