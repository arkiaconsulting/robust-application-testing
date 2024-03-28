using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Core.Application;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
    {
        return services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ConfigurationExtensions).Assembly));
    }
}
