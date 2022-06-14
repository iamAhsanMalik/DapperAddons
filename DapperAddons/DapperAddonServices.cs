using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DapperAddons;
public static class DapperAddonServices
{
    public static IServiceCollection AddDapperAddon(this IServiceCollection services)
    {
        services.TryAddScoped<IDbHelpers, DbHelpers>();
        return services.AddDapperAddon();
    }
}
