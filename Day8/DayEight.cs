using AdventOfCode2025.Utility;
using System.Globalization;
namespace AdventOfCode2025.Day8;

internal class DayEight : AdventDay
{
    internal override int Day => 8;

    private readonly List<Tuple<int, int, int>> points3d = [];
    private readonly int boxCount;
    internal DayEight() : base()
    {
        string[] lines = Input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        boxCount = lines.Length;
        foreach (string line in lines)
        {
            string[] points = line.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            points3d.Add(Tuple.Create(int.Parse(points[0]), int.Parse(points[1]), int.Parse(points[2])));
        }
    }


    internal override string PartOne()
    {
        List<Edge> edges = [];


        for (int i = 0; i < points3d.Count; i++)
        {
            for (int j = i + 1; j < points3d.Count; j++)
            {

                Tuple<int, int, int> pointA = points3d[i];
                Tuple<int, int, int> pointB = points3d[j];

                double dx = pointA.Item1 - pointB.Item1;
                double dy = pointA.Item2 - pointB.Item2;
                double dz = pointA.Item3 - pointB.Item3;

                double dist = Math.Sqrt(dx * dx + dy * dy + dz * dz);

                edges.Add(new Edge(i, j, dist));
            }
        }

        var sorted = edges.OrderBy(p => p.Dist).ToList();
        var dsu = new DisjointUnionSets(boxCount);

        int limit = 1000; // The test input requiers the fucking limit to be 10 annoying
        for (int i = 0; i < limit; i++)
        {
            Edge edge = sorted[i];
            dsu.Union(edge.A, edge.B);
        }

        Dictionary<int, int> counts = [];

        for (int i = 0; i < boxCount; i++)
        {
            int root = dsu.Find(i);

            if (!counts.TryGetValue(root, out int value))
            {
                value = 0;
                counts[root] = value;
            }

            counts[root] = ++value;
        }

        List<int> largest = [.. counts.Values.OrderByDescending(x => x)];

        var size = largest[0] * largest[1] * largest[2];

        return size.ToString();
    }



    class Edge(int a, int b, double dist)
    {
        public int A = a;
        public int B = b;
        public double Dist = dist;
    }

    //#GFG
    class DisjointUnionSets
    {
        private readonly int[] parent;
        private readonly int[] rank;

        public DisjointUnionSets(int n)
        {
            parent = new int[n];
            rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int i)
        {
            if (parent[i] != i)
            {
                parent[i] = Find(parent[i]);
            }

            return parent[i];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }

    }

}
