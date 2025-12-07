using AdventOfCode2025.Utility;
using System.Diagnostics.Metrics;
namespace AdventOfCode2025.Day7;

internal enum MoveDir
{
    Down,
    Left,
    Right
}

internal class DaySeven : AdventDay
{
    internal override int Day => 7;

    private readonly char[,] tachyonManifold;
    private readonly Tuple<int, int> startPos;
    private readonly int endY;

    internal DaySeven() : base()
    {
        var split = Input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        int xLen = split[0].Length;
        int yLen = split.Length;
        endY = yLen - 1;

        tachyonManifold = new char[xLen, yLen];

        for (int y = 0; y < yLen; y++)
        {
            var line = split[y];
            for (int x = 0; x < xLen; x++)
            {
                char c = line[x];
                tachyonManifold[x, y] = c;
                if (c == 'S')
                {
                    startPos = Tuple.Create(x, y);
                }
            }
        }
        //WE MUST PLEASE THE IDE
        if (startPos == null)
        {
            startPos = Tuple.Create(-1, -1);
            Console.WriteLine("BAD FUCKING BAD");
        }
    }


    internal char GetCharAtXY(int x, int y)
    {
        return tachyonManifold[x, y];
    }

    internal override string PartOne()
    {
        int curY = startPos.Item2;
        HashSet<int> allX = [startPos.Item1];
        int splits = 0;
        do
        {
            curY++;
            List<int> newX = [];
            List<int> toRemove = [];
            foreach (int x in allX)
            {
                if (GetCharAtXY(x, curY) != '.')
                {
                    splits++;
                    toRemove.Add(x);
                    newX.Add(x + 1);
                    newX.Add(x - 1);
                }
            }
            foreach (int x in toRemove)
            {
                allX.Remove(x);
            }
            foreach (int x in newX)
            {
                allX.Add(x);

            }
        }
        while (curY < endY);

        return splits.ToString();
    }

    internal override string PartTwo()
    {
        int curY = startPos.Item2;
        Dictionary<int, long> history = new() { { startPos.Item1, 1 } };
        HashSet<int> allX = [startPos.Item1];
        do
        {
            curY++;
            List<int> newX = [];
            List<int> toRemove = [];

            Dictionary<int, long> newHistory = [];
            foreach (int x in allX)
            {
                long ways = history[x];

                if (GetCharAtXY(x, curY) != '.')
                {
                    toRemove.Add(x);
                    newX.Add(x + 1);
                    newX.Add(x - 1);

                    if (!newHistory.ContainsKey(x + 1))
                    {
                        newHistory[x + 1] = 0;
                    }
                    newHistory[x + 1] += ways;

                    if (!newHistory.ContainsKey(x - 1))
                    {
                        newHistory[x - 1] = 0;
                    }
                    newHistory[x - 1] += ways;
                }
                else
                {

                    if (!newHistory.ContainsKey(x))
                    {
                        newHistory[x] = 0;
                    }
                    newHistory[x] += ways;
                }
            }
            foreach (int x in toRemove)
            {
                allX.Remove(x);
            }
            foreach (int x in newX)
            {
                allX.Add(x);
            }
            history = newHistory;
        }
        while (curY < endY);

        return history.Values.Sum().ToString();
    }
}
