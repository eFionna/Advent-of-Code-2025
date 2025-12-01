using AdventOfCode2025.Utility;

namespace AdventOfCode2025.Day1;

internal class DayOne : AdventDay
{
    internal override int Day => 1;

    private int dial = 50;

    private readonly List<string> instructions;

    public DayOne() : base()
    {
        instructions = [.. Input.Split(Environment.NewLine, StringSplitOptions.TrimEntries)];
    }

    private void RotateDial(string instruction)
    {
        bool isLeft = char.Equals(instruction[0], 'L');
        int clicks = int.Parse(instruction[1..]);

        dial = isLeft ? dial - clicks : dial + clicks;
        WrapDial();
    }

    private void WrapDial()
    {
        dial = (dial % 100 + 100) % 100;
    }
    private int SimulateRotating(string instruction)
    {
        bool isLeft = instruction[0] == 'L';
        int clicks = int.Parse(instruction[1..]);

        int pastZero = 0;

        for (int i = 0; i < clicks; i++)
        {
            if (isLeft)
            {
                dial = (dial + 1) % 100;
            }
            else
            {
                dial = (dial - 1 + 100) % 100;
            }

            if (dial == 0)
            {
                pastZero++;
            }
        }

        return pastZero;
    }

    internal override int PartOne()
    {
        int isAtZero = 0;
        foreach (string instruction in instructions)
        {
            RotateDial(instruction);
            if (dial == 0)
            {
                isAtZero++;
            }
        }
        return isAtZero;
    }

    internal override int PartTwo()
    {
        int zeroCounter = 0;
        foreach (string instruction in instructions)
        {
            zeroCounter += SimulateRotating(instruction);
        }
        return zeroCounter;
    }

}
