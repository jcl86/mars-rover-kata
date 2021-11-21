using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly)
                .Services;
    }
}
