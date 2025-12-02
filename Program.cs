using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Utility;

Dictionary<int, AdventDay> days = new()
{
    { 1, new DayOne() },
    { 2, new DayTwo() }
};

Console.WriteLine(days[2].PartOne());



Console.ReadLine();