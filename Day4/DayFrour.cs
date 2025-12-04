using AdventOfCode2025.Utility;


namespace AdventOfCode2025.Day4;

internal class DayFrour : AdventDay
{
    internal override int Day => 4;

    private static readonly (int x, int y)[] Directions =
    {
        (-1,  0), // Up
        ( 1,  0), // Down
        ( 0, -1), // Left
        ( 0,  1), // Right
        (-1, -1), // Up-left
        (-1,  1), // Up-right
        ( 1, -1), // Down-left
        ( 1,  1)  // Down-right
    };

    private readonly char[,] grid;

    internal DayFrour() : base()
    {
        var rows = Input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        int height = rows.Length;
        int width = rows[0].Length;

        grid = new char[height, width];

        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                grid[x, y] = rows[x][y];
            }
        }
    }

    internal override string PartOne()
    {
        int canBeForklifted = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {

                if(grid[x, y] != '@')
                {
                    continue;
                }

                int rollNeighburCount = 0;
                foreach (var (cx, cy) in GetNeighbors(x, y))
                {
                    char charAtXY = grid[cx, cy];

                    if(charAtXY != '@')
                    {
                        continue;
                    }
                    if(charAtXY == '@')
                    {
                        rollNeighburCount ++;
                    }
                }
                if (rollNeighburCount < 4)
                {
                    canBeForklifted++;
                }
            }
        }

        return canBeForklifted.ToString();
    }

    internal override string PartTwo()
    {
        return base.PartTwo();
    }




    IEnumerable<(int x, int y)> GetNeighbors(int x, int y)
    {
        foreach (var (x2, y2) in Directions)
        {
            int nx = x + x2;
            int ny = y + y2;

            if (nx >= 0 && nx < grid.GetLength(0) && ny >= 0 && ny < grid.GetLength(1))
            {
                yield return (nx, ny);
            }
        }
    }

}
