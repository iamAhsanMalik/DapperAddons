using DapperAddons.Helpers.Contracts;
using DapperAddons.Helpers.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DapperAddons;
/// <summary>
/// Dapper Addons services container to register services in your main application
/// </summary>
public static class DapperAddonServices
{
    /// <summary>
    /// DapperAddons method that will help you inject AddDapperAddons services into your dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDapperAddons(this IServiceCollection services)
    {
        services.AddScoped(typeof(IDbHelpers), typeof(DbHelpers));
        return services;
    }
}
