using AdventOfCode2025.Utility;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day2;

internal partial class DayTwo : AdventDay
{
    internal override int Day => 2;

    private readonly List<Tuple<long, long>> ranges = [];


    internal DayTwo() : base()
    {
        List<string> rangeStrs = [.. Input.Split(',', StringSplitOptions.RemoveEmptyEntries)];

        foreach (var rangeStr in rangeStrs)
        {
            string[] split = rangeStr.Split('-');
            long start = long.Parse(split[0]);
            long end = long.Parse(split[1]);
            ranges.Add(new Tuple<long, long>(start, end));
        }

    }



    internal override string PartOne()
    {

        long total = 0;

        List<string> numbers = [];
        long i;
        foreach (Tuple<long, long> range in ranges)
        {
            numbers.Clear();
            long start = range.Item1;
            long end = range.Item2;
          
            for (i = start; i <= end; i++)
            {
                numbers.Add(i.ToString());
            }

            foreach (string n in numbers)
            {
                var firstHalf = n[..(n.Length / 2)];
                var secondHalf = n[(n.Length / 2)..];
                if (firstHalf.Length != secondHalf.Length)
                {
                    continue;
                }
                if (firstHalf == secondHalf)
                {
                    total += long.Parse(n);
                }
            }

        }

        return total.ToString();
    }
    internal override string PartTwo()
    {
        long total = 0;

        List<string> numbers = [];
        long i;
        foreach (Tuple<long, long> range in ranges)
        {
            numbers.Clear();
            long start = range.Item1;
            long end = range.Item2;

            for (i = start; i <= end; i++)
            {
                numbers.Add(i.ToString());
            }

            foreach (string n in numbers)
            {
                if (IsRepeated(n))
                {
                    total += long.Parse(n);
                }
            }
        }

        return total.ToString();
    }


    public static bool IsRepeated(string s)
    {
        return RepeatingRegex().IsMatch(s);
    }

    [GeneratedRegex(@"^(.+)\1+$")]
    private static partial Regex RepeatingRegex();
}
