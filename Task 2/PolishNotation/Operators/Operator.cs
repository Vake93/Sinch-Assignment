namespace PolishNotation.Operators;

public abstract class Operator
{
    private static readonly Dictionary<string, Operator> _operators = new()
    {
        { "+", new Addition() },
        { "-", new Subtraction() },
        { "*", new Multiplication() },
        { "/", new Division() }
    };

    public abstract int RequiredTermCount { get; }

    public abstract double? Evaluate(Stack<double> numbers);

    public bool Validate(Stack<double> numbers) => numbers.Count >= RequiredTermCount;

    public static Operator? GetOperator(string term)
    {
        _operators.TryGetValue(term, out var ops);
        return ops;
    }
}