using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;
using MarsRover.Core;

namespace MarsRover.Api
{
    public static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ILossesRepository, InMemoryLossesRepository>();
            services.AddScoped<PathMaker>();
            services.AddScoped<RoverRider>();
            return services;
        }
    }
}
