namespace PolishNotation.API.Services.Cache;

public interface IExpressionCache
{
    void Set(string expression, double? value);

    bool TryGetValue(string expression, out double? value);
}
