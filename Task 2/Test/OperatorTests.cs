using PolishNotation.Operators;
using Xunit;

namespace Test;

public class OperatorTests
{
    [Theory]
    [InlineData("+", nameof(Addition))]
    [InlineData("/", nameof(Division))]
    [InlineData("-", nameof(Subtraction))]
    [InlineData("*", nameof(Multiplication))]
    public void ResolveOperatorTest(string term, string expecteName)
    {
        var ops = Operator.GetOperator(term);

        Assert.NotNull(ops);
        Assert.Equal(expecteName, ops!.GetType().Name);
    }

    [Fact]
    public void AdditionTest()
    {
        var ops = Operator.GetOperator("+");

        Assert.NotNull(ops);

        var result = ops!.Evaluate(new(new[]
        {
            1d, 2d
        }));

        Assert.NotNull(result);
        Assert.Equal(3d, result!.Value);
    }

    [Fact]
    public void SubtractionTest()
    {
        var ops = Operator.GetOperator("-");

        Assert.NotNull(ops);

        var result = ops!.Evaluate(new(new[]
        {
            1d, 2d
        }));

        Assert.NotNull(result);
        Assert.Equal(1d, result!.Value);
    }

    [Fact]
    public void MultiplicationTest()
    {
        var ops = Operator.GetOperator("*");

        Assert.NotNull(ops);

        var result = ops!.Evaluate(new(new[]
        {
            1d, 2d
        }));

        Assert.NotNull(result);
        Assert.Equal(2d, result!.Value);
    }

    [Fact]
    public void DivisionTest()
    {
        var ops = Operator.GetOperator("/");

        Assert.NotNull(ops);

        var result = ops!.Evaluate(new(new[]
        {
            5d, 20d
        }));

        Assert.NotNull(result);
        Assert.Equal(4d, result!.Value);
    }
}