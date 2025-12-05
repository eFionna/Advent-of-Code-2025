using AdventOfCode2025.Utility;

namespace AdventOfCode2025.Day5;

internal class DayFive : AdventDay
{
    internal override int Day => 5;

    private readonly List<Tuple<long, long>> ingredientIDRanges;
    private readonly List<long> ingredientIDs;

    internal DayFive() : base()
    {
        ingredientIDRanges = [];
        ingredientIDs = [];
        string[] database = Input.Split([Environment.NewLine + Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);

        string[] tempRanges = database[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach (string range in tempRanges)
        {
            var split = range.Split('-', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            ingredientIDRanges.Add(new(long.Parse(split[0]), long.Parse(split[1])));
        }
        string[] tempIds = database[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach (string id in tempIds)
        {
            ingredientIDs.Add(long.Parse(id));
        }
    }

    internal override string PartOne()
    {
        long freshIngredientIDs = 0;
        foreach (long id in ingredientIDs)
        {
            foreach (Tuple<long, long> range in ingredientIDRanges)
            {
                if (id >= range.Item1 && id <= range.Item2)
                {
                    freshIngredientIDs++;
                    break;
                }
            }
        }
        return freshIngredientIDs.ToString();
    }


    internal override string PartTwo()
    {
        return base.PartTwo();
    }

}
