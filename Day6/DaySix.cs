using AdventOfCode2025.Utility;

namespace AdventOfCode2025.Day6;

internal class DaySix : AdventDay
{
    internal override int Day => 6;
    private readonly Dictionary<int, List<string>> problems = [];
    internal DaySix() : base()
    {
        string[] split = Input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        for (int y = 0; y < split.Length; y++)
        {
            string line = split[y];
            string[] m = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int x = 0; x < m.Length; x++)
            {
                string val = m[x];
                if (problems.TryGetValue(x, out var li))
                {
                    li.Add(val);
                }
                else
                {
                    problems[x] = [val];
                }
            }
        }
    }

    internal override string PartOne()
    {
        long final = 0;
        foreach (List<string> li in problems.Values)
        {
            string last = li.Last();
            long num = long.Parse(li.First()!);

            Func<long, long, long> operation = last == "*" ? (a, b) => a * b : (a, b) => a + b;

            foreach (string val in li.SkipLast(1).Skip(1))
            {
                long v = long.Parse(val);
                num = operation(num, v);
            }
            final += num;
        }


        return final.ToString();
    }

    internal override string PartTwo() 
    {
        return PartTwo();
    }
}
