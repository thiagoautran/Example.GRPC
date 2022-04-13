using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.GRPC.API.ApplicationCore.Interfaces
{
    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void Configure(WebApplication app, IWebHostEnvironment env);
    }
}