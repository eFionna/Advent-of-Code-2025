using AdventOfCode2025.Utility;

namespace AdventOfCode2025.Day1;

internal class DayOne : AdventDay
{
    internal override int Day => 1;

    private int dial = 50;

    private readonly List<string> instructions;

    public DayOne() : base()
    {

        instructions = Input.Split(Environment.NewLine, StringSplitOptions.TrimEntries).ToList();
    }


    private void RotateDial(string instruction)
    {
        bool isLeft = char.Equals(instruction[0], 'L');
        int clicks = int.Parse(instruction[1..]);
        Console.WriteLine("Clicks: " + instruction[1..]);
        dial = isLeft ? dial - clicks : dial + clicks;

        var rotationCorrection = Math.Abs(dial) / 100;
        if (dial < 0)
        {
            dial += 100 * rotationCorrection;
        }
        else if (dial > 99)
        {
            dial -= 100 * rotationCorrection;
        }
    }

    internal override int PartOne()
    {
        int isAtZero = 0;
        foreach (string instruction in instructions) 
        {
            RotateDial(instruction);
            if (dial == 0)
                isAtZero++;
        }
        return isAtZero;
    }

    internal override int PartTwo()
    {
        return base.PartTwo();
    }

}
