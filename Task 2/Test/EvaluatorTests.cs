using PolishNotation.Evaluator;
using Xunit;

namespace Test;

public class EvaluatorTests
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
    [InlineData("1 2", null)]
    [InlineData("+ 1", null)]
    public void PolishNotationEvaluatorTest(string expression, double? expected)
    {
        var result = PolishNotationEvaluator.Evaluate(expression);
        Assert.Equal(expected, result);
    }
}