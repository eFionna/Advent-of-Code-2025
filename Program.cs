using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Day4;
using AdventOfCode2025.Day5;
using AdventOfCode2025.Utility;

Dictionary<int, AdventDay> days = new()
{
    { 1, new DayOne() },
    { 2, new DayTwo() },
    { 3, new DayThree() },
    { 4, new DayFrour() },
    { 5, new DayFive() },
};

Console.WriteLine(days[5].PartOne());
Console.WriteLine(days[5].PartTwo());



Console.ReadLine();