using BenchmarkDotNet.Attributes;

namespace CountPairs;

[MemoryDiagnoser(displayGenColumns: false)]
public class CounterBenchmark
{
    [Params(10, 100, 1000, 10000)]
    public int ElementCount { get; set; }

    public int TargetSum { get; set; }

    public List<int> Numbers { get; set; } = new List<int>();

    [GlobalSetup]
    public void Setup()
    {
        Numbers = Enumerable
            .Range(0, ElementCount)
            .ToList();

        TargetSum = ElementCount / 2;

        // Shuffle the list so that the sort doesn't have an advantage
        for (int i = 0; i < ElementCount / 2; i++)
        {
            var randomIndex = Random.Shared.Next(0, ElementCount);
            (Numbers[randomIndex], Numbers[i]) = (Numbers[i], Numbers[randomIndex]);
        }
    }

    [Benchmark(Baseline = true)]
    public int CountPairsByBruteForce() => Counter.CountPairsByBruteForce(TargetSum, Numbers);

    [Benchmark]
    public int CountPairsBySorting() => Counter.CountPairsBySorting(TargetSum, Numbers);

    [Benchmark]
    public int CountPairsByHashing() => Counter.CountPairsByHashing(TargetSum, Numbers);
}
