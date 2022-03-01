namespace CountPairs;

public static class Counter
{
    // Time Complexity: O(n2)
    public static int CountPairsByBruteForce(int targetSum, List<int> numbers)
    {
        var count = 0;

        for (var i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] + numbers[j] == targetSum)
                {
                    count++;
                }
            }
        }

        return count;
    }

    // Time Complexity: O(n.log(n))
    public static int CountPairsBySorting(int targetSum, List<int> numbers)
    {
        numbers.Sort();

        var count = 0;
        var low = 0;
        var high = numbers.Count - 1;

        while (low < high)
        {
            if (numbers[low] + numbers[high] == targetSum)
            {
                count++;
            }

            if (numbers[low] + numbers[high] < targetSum)
            {
                low++;
            }
            else
            {
                high--;
            }
        }

        return count;
    }

    // Time Complexity: O(n)
    public static int CountPairsByHashing(int targetSum, List<int> numbers)
    {
        var items = new HashSet<int>();
        var count = 0;

        foreach (var number in numbers)
        {
            var key = targetSum - number;
            if (items.Contains(key))
            {
                count++;
                continue;
            }

            items.Add(number);
        }

        return count;
    }
}
