using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autransoft.Test.Lib.Helpers
{
    internal static class StartupHelper
    {
        internal static object[] GetConstructorParams<CLASS>(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var listConstructor = typeof(CLASS).GetConstructors();
            var listParams = new List<object>();

            foreach (var construtor in listConstructor)
            {
                if (construtor.IsPublic)
                {
                    foreach (var param in construtor.GetParameters())
                    {
                        if(param.ParameterType == typeof(IServiceCollection))
                            listParams.Add(serviceCollection);
                        else if (param.ParameterType == typeof(IConfiguration))
                            listParams.Add(configuration);
                    }

                    break;
                }
            }

            return listParams.ToArray();
        }

        internal static MethodInfo GetMethod<CLASS>(string methodName)
        {
            var listMethods = typeof(CLASS).GetMethods();

            return listMethods.FirstOrDefault(method => method.Name.ToUpper().Trim() == methodName.ToUpper().Trim());        
        }

        internal static void InvokeConfigureServices(object statup, MethodInfo method, IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var methodParams = GetMethodParams(method, serviceCollection, configuration, null, null);
            method.Invoke(statup, methodParams);
        }

        internal static void InvokeConfigure(object statup, MethodInfo method, WebApplication webApplication, IWebHostEnvironment webHostEnvironment)
        {
            var methodParams = GetMethodParams(method, null, null, webApplication, webHostEnvironment);
            method.Invoke(statup, methodParams);
        }

        private static object[] GetMethodParams(MethodInfo method, IServiceCollection serviceCollection, IConfiguration configuration, WebApplication webApplication, IWebHostEnvironment webHostEnvironment)
        {
            var listParams = new List<object>();

            if (method.IsPublic)
            {
                foreach (var param in method.GetParameters())
                {
                    if (serviceCollection != null && param.ParameterType == typeof(IServiceCollection))
                        listParams.Add(serviceCollection);
                    else if (configuration != null && param.ParameterType == typeof(IConfiguration))
                        listParams.Add(configuration);
                    else if (webApplication != null && param.ParameterType == typeof(WebApplication))
                        listParams.Add(webApplication);
                    else if (webHostEnvironment != null && param.ParameterType == typeof(IWebHostEnvironment))
                        listParams.Add(webHostEnvironment);
                }
            }

            return listParams.ToArray();
        }
    }
}