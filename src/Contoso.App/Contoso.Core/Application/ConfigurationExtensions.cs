using Contoso.Core.Application.Features.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Core.Application;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services) =>
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ConfigurationExtensions).Assembly))
        .AddSingleton<FakeUserStore>()
        .AddTransient<IUserStore>(sp => sp.GetRequiredService<FakeUserStore>());
}
