using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Day4;
using AdventOfCode2025.Day5;
using AdventOfCode2025.Day6;
using AdventOfCode2025.Day7;
using AdventOfCode2025.Utility;

Dictionary<int, AdventDay> days = new()
{
    //{ 1, new DayOne() },
    //{ 2, new DayTwo() },
    //{ 3, new DayThree() },
    //{ 4, new DayFrour() },
    //{ 5, new DayFive() },
    //{ 6, new DaySix() },
    { 7, new DaySeven() },

};

Console.WriteLine(days[7].PartOne());
Console.WriteLine();
Console.WriteLine(days[7].PartTwo());



Console.ReadLine();