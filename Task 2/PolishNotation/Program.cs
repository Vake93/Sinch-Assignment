using PolishNotation.Evaluator;

while (true)
{
    Console.WriteLine("Enter polish notation expression:");

    var expression = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(expression))
    {
        break;
    }

    var result = PolishNotationEvaluator.Evaluate(expression);

    Console.WriteLine(result.HasValue ? result.Value.ToString("0.00") : "error");
    Console.WriteLine();
}