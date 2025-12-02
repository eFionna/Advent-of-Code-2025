using System.Reflection;

namespace AdventOfCode2025.Utility;

internal class AdventDay
{
    internal virtual int Day { get; }
    internal string Input { get; }
    public AdventDay()
    {
        string inputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"Day{Day}", "Input.txt");
        Input = File.ReadAllText(inputFilePath);
    }

    internal virtual string PartOne()
    {
        return string.Empty;
    }
    internal virtual string PartTwo()
    {
        return string.Empty;
    }
}
