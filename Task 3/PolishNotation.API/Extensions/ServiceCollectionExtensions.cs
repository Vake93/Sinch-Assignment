using PolishNotation.API.Services.Cache;

namespace PolishNotation.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExpressionCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IExpressionCache, ExpressionCache>();

        return services;
    }
}
