using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Day4;
using AdventOfCode2025.Utility;

Dictionary<int, AdventDay> days = new()
{
    { 1, new DayOne() },
    { 2, new DayTwo() },
    { 3, new DayThree() },
    { 4, new DayFrour() }
};

Console.WriteLine(days[4].PartOne());
Console.WriteLine(days[4].PartTwo());



Console.ReadLine();