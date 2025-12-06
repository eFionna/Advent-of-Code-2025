using AdventOfCode2025.Utility;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

    private static List<List<List<char>>> ParseCephalopodWorksheet(string[] lines)
    {
        int width = lines.Max(l => l.Length);
        List<string> padedLines = [.. lines.Select(l => l.PadRight(width, 'X'))];

        int height = padedLines.Count;

        List<List<char>> colums = [];
        for (int x = 0; x < width; x++)
        {
            List<char> c = [];
            for (int y = 0; y < height; y++)
            {
                c.Add(padedLines[y][x]);
            }
            colums.Add(c);
        }

        List<List<List<char>>> numberList = [];
        List<List<char>> colum = [];

        foreach (var col in colums)
        {
            if (col.All(c => c == ' ' || c == 'X'))
            {
                if (colum.Count > 0)
                {
                    numberList.Add(colum);
                    colum = [];
                }
            }
            else
            {
                colum.Add(col);
            }
        }

        if (colum.Count > 0)
        {
            numberList.Add(colum);
        }

        numberList.Reverse();

        return numberList;
    }

    internal static List<List<long>> MakeNumbers(List<List<List<char>>> nums)
    {
        List<List<long>> list = [];
        foreach (var col in nums)
        {
            List<long> num = [];
            foreach (var a in col)
            {
                string s = string.Empty;
                foreach (var c in a)
                {
                    s += c;
                }
                num.Add(long.Parse(s));
            }
            num.Reverse();
            list.Add(num);
        }
        return list;
    }
    internal static List<string> GetOperators(string o)
    {
        return [.. o.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Reverse()];
    }

    internal override string PartTwo()
    {

        string[] split = Input.Split(Environment.NewLine);
        string[] numbers = [.. split.SkipLast(1)];
        List<List<List<char>>> r = ParseCephalopodWorksheet(numbers);
        List<List<long>> n = MakeNumbers(r);
        List<string> o = GetOperators(split.Last());

        long final = 0;

        for (int i = 0; i < o.Count; i++)
        {
            List<long> l = n[i];
            long num = l.First();
            
            foreach (var v in l.Skip(1))
            {
                Func<long, long, long> operation = o[i] == "*" ? (a, b) => a * b : (a, b) => a + b;
                num = operation(num, v);
            }
            final += num;
        }

        return final.ToString();
    }




}
//  