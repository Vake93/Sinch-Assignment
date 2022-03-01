using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using PolishNotation.API.Services.Cache;
using System.Runtime.InteropServices;

namespace Test;

public static class TestHelpers
{
    public static IExpressionCache CreateTestExpressionCache()
    {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        var serviceProvider = services.BuildServiceProvider();

        var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();

        return new ExpressionCache(memoryCache);
    }

    public static T? GetObjectResultValue<T>(this IResult result)
    {
        var objectResultAccessor = new ObjectResultAccessor
        {
            Result = result,
        };

        return (T?)objectResultAccessor.ObjectResult?.Value;
    }

    public static int? GetObjectResultStatusCode(this IResult result)
    {
        var objectResultAccessor = new ObjectResultAccessor
        {
            Result = result,
        };

        return objectResultAccessor.ObjectResult?.StatusCode;
    }

    private class ObjectResult
    {
        public object? Value { get; }

        public int? StatusCode { get; set; }

        public string? ContentType { get; set; }
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct ObjectResultAccessor
    {
        [FieldOffset(0)]
        public IResult Result;

        [FieldOffset(0)]
        public ObjectResult ObjectResult;
    }
}