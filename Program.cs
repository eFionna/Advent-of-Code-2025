using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Utility;

Dictionary<int, AdventDay> days = new()
{
    { 1, new DayOne() },
    { 2, new DayTwo() },
    { 3, new DayThree() }
};

Console.WriteLine(days[3].PartOne());
Console.WriteLine(days[3].PartTwo());



Console.ReadLine();