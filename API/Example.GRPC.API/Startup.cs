namespace Example.GRPC.API
{
    public class Startup : Example.GRPC.API.ApplicationCore.Interfaces.IStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpc();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.MapGrpcService<Example.GRPC.API.Controllers.V1.StatusInvestController>();
        }
    }
}