using Microsoft.Extensions.Caching.Memory;

namespace PolishNotation.API.Services.Cache;

public class ExpressionCache : IExpressionCache
{
    private readonly IMemoryCache _memoryCache;

    public ExpressionCache(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Set(string expression, double? value) => _memoryCache.Set(expression, value);

    public bool TryGetValue(string expression, out double? value) => _memoryCache.TryGetValue(expression, out value);
}
