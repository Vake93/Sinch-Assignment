using BenchmarkDotNet.Running;
using CountPairs;

if (args is not null && args.Length == 1 && args[0] == "--b")
{
    BenchmarkRunner.Run(typeof(CounterBenchmark).Assembly);
    return;
}

var input = Console.ReadLine();

if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("error");
    return;
}

var numbers = new List<int>();
var validNumber = int.TryParse(input, out var targetSum);

if (!validNumber)
{
    Console.WriteLine("error");
    return;
}

while (true)
{
    input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        var count = Counter.CountPairsBySorting(targetSum, numbers);
        Console.WriteLine(count);
        break;
    }

    validNumber = int.TryParse(input, out var number);

    if (!validNumber)
    {
        Console.WriteLine("error");
        return;
    }

    numbers.Add(number);
}