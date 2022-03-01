using Microsoft.AspNetCore.Mvc;
using PolishNotation.API;
using PolishNotation.API.Models;
using Xunit;

namespace Test;
public class EndpointTest
{
    [Theory]
    [InlineData("100500", 100500d)]
    [InlineData("-100500", -100500d)]
    [InlineData("+100500", +100500d)]
    [InlineData("0", 0)]
    [InlineData("-0", 0)]
    [InlineData("+0", 0)]
    [InlineData("2e2", 200)]
    [InlineData("-2e2", -200)]
    [InlineData("+ 1 2", 3)]
    [InlineData("+ 1 -2", -1)]
    [InlineData("+ 0 0", 0)]
    [InlineData("+ 2e2 1", 201)]
    [InlineData("- 1 2", -1)]
    [InlineData("- 1 -2", 3)]
    [InlineData("- 2e2 1", 199)]
    [InlineData("/ 2e2 2", 100)]
    [InlineData("/ 2e2 0", double.PositiveInfinity)]
    [InlineData("+ + 0.5 1.5 * 4 10", 42)]
    [InlineData("- 2e3 - 700 + 7 * 2 15", 1337)]
    [InlineData("- -1.5 * 3.1415 / -7 -2", -12.5)]
    public void EvaluateSuccessTest(string expression, double expected)
    {
        var cache = TestHelpers.CreateTestExpressionCache();
        var request = new EvalutateRequest
        {
            Expression = expression,
        };

        var result = Endpoints.Evaluate(request, cache);

        var statusCode = result.GetObjectResultStatusCode();

        Assert.Equal(200, statusCode);

        var response = result.GetObjectResultValue<EvalutateResponse>();

        Assert.NotNull(response);

        Assert.Equal(expected, response!.Result);
    }

    [Theory]
    [InlineData("1 2")]
    [InlineData("+ 1")]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void EvaluateErrorTest(string expression)
    {
        var cache = TestHelpers.CreateTestExpressionCache();
        var request = new EvalutateRequest
        {
            Expression = expression,
        };

        var result = Endpoints.Evaluate(request, cache);

        var statusCode = result.GetObjectResultStatusCode();

        Assert.Equal(400, statusCode);

        var response = result.GetObjectResultValue<ProblemDetails>();

        Assert.NotNull(response);
    }
}
