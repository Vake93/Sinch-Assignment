using CountPairs;
using System.Collections.Generic;
using Xunit;

namespace Test;

public class CounterTests
{
    [Fact]
    public void CountPairsByBruteForceTest()
    {
        var targetSum = 6;
        var numbers = new List<int>
        {
            2, 1, 4, 5, 3, -1 , 6, 7
        };

        var result = Counter.CountPairsByBruteForce(targetSum, numbers);

        Assert.Equal(3, result);
    }

    [Fact]
    public void CountPairsBySortingTest()
    {
        var targetSum = 6;
        var numbers = new List<int>
        {
            2, 1, 4, 5, 3, -1 , 6, 7
        };

        var result = Counter.CountPairsBySorting(targetSum, numbers);

        Assert.Equal(3, result);
    }


    [Fact]
    public void CountPairsByHashingTest()
    {
        var targetSum = 6;
        var numbers = new List<int>
        {
            2, 1, 4, 5, 3, -1 , 6, 7
        };

        var result = Counter.CountPairsByHashing(targetSum, numbers);

        Assert.Equal(3, result);
    }
}