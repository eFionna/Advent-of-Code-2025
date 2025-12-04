using AdventOfCode2025.Utility;
namespace AdventOfCode2025.Day3;

internal class DayThree : AdventDay
{

    internal override int Day => 3;
    private readonly List<string> batterieBanks;
    internal DayThree() : base()
    {
        batterieBanks = [.. Input
        .Split('\n', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => x.Trim())];
    }

    private static int GetLargestJoltage(string bank)
    {
        List<char> joltages = [];
        foreach (char joltage in bank)
        {
            joltages.Add(joltage);
        }
        int largetsNum = -1;

        for (int i = 0; i < joltages.Count - 1; i++)
        {
            for (int j = i + 1; j < joltages.Count - 1; j++)
            {
                if (j > joltages.Count - 1)
                {
                    break;
                }

                int newNum = int.Parse($"{joltages[i]}{joltages[j]}");

                if (newNum > largetsNum)
                {
                    largetsNum = newNum;
                }

            }
        }
        return largetsNum;
    }


    internal override string PartOne()
    {
        int total = 0;
        foreach (var bank in batterieBanks)
        {
            total += GetLargestJoltage(bank);
        }

        return total.ToString();
    }
    private static long GetLargestJoltageTwo(string bank)
    {
        int k = 12;
        int toRemove = bank.Length - k;
        List<char> s = new(bank.Length);

        foreach (char c in bank)
        {
            while (s.Count > 0 && toRemove > 0 && s[^1] < c)
            {
                s.RemoveAt(s.Count - 1);
                toRemove--;
            }
            s.Add(c);
        }
        while (s.Count > k)
        {
            s.RemoveAt(s.Count - 1);
        }

        return long.Parse(new string([.. s]));
    }


    internal override string PartTwo()
    {
        long total = 0;
        foreach (var bank in batterieBanks)
        {
            total += GetLargestJoltageTwo(bank);
        }
        return total.ToString();
    }
}
