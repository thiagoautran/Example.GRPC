using Example.GRPC.API.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Example.GRPC.API.IntegrationTest
{
    public class BaseGRPCTest<Startup> : IDisposable
        where Startup : IStartup, new()
    {
        private WebApplication _app;
        private string _environment;

        public string HttpUrl { get; private set; }
        public string HttpsUrl { get; private set; }

        public BaseGRPCTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "IntegrationTest");
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "IntegrationTest");
            _environment = "IntegrationTest";
            HttpsUrl = string.Empty;
            HttpUrl = string.Empty;
        }

        public BaseGRPCTest(string environment)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", environment);
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", environment);
            _environment = environment;
            HttpsUrl = string.Empty;
            HttpUrl = string.Empty;
        }

        public void Initialize()
        {
            _app = CreateHost();
        }

        public virtual void AddToDependencyInjection(IServiceCollection serviceCollection, IConfiguration configuration) { }

        private WebApplication CreateHost()
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                ApplicationName = "test",
                EnvironmentName = _environment
            });
            
            builder.WebHost.UseSetting("https_port", "4567");

            var startup = new Startup();
            startup.ConfigureServices(builder.Services, builder.Configuration);

            AddToDependencyInjection(builder.Services, builder.Configuration);

            var app = builder.Build();
            startup.Configure(app, app.Environment);

            var task = app.StartAsync();
            task.Wait();

            HttpUrl = app.Urls.First(url => url.Contains("http:"));
            HttpsUrl = app.Urls.First(url => url.Contains("https:"));

            return app;
        }

        public void Dispose()
        {
            HostDispose();
        }

        private void HostDispose()
        {
            if (_app != null)
            {
                var stopTask = _app.StopAsync();
                stopTask.Wait();

                var disposeTask = _app.DisposeAsync();
                disposeTask.GetAwaiter();
            }
        }
    }
}
