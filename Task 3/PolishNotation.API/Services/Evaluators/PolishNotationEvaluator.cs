using PolishNotation.API.Services.Operators;

namespace PolishNotation.API.Services.Evaluators;

public static class PolishNotationEvaluator
{
    public static double? Evaluate(string expression)
    {
        if (string.IsNullOrEmpty(expression))
        {
            return null;
        }

        var terms = expression.Split(' ');
        var numbers = new Stack<double>();

        for (var i = terms.Length - 1; i >= 0; i--)
        {
            var term = terms[i];

            if (double.TryParse(term, out var number))
            {
                numbers.Push(number);
                continue;
            }

            var ops = Operator.GetOperator(term);
            var result = ops?.Evaluate(numbers);

            if (result is null)
            {
                return null;
            }

            numbers.Push(result.Value);
        }

        if (numbers.Count != 1)
        {
            return null;
        }

        return Math.Round(numbers.Pop(), 2);
    }
}