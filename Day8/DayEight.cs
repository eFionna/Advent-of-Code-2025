using AdventOfCode2025.Utility;
using System.Globalization;
namespace AdventOfCode2025.Day8;

internal class DayEight : AdventDay
{
    internal override int Day => 8;

    private readonly List<Tuple<double, double, double>> points3d = [];
    private readonly int boxCount;
    internal DayEight() : base()
    {
        string[] lines = Input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        boxCount = lines.Length;
        foreach (string line in lines)
        {
            string[] points = line.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            points3d.Add(Tuple.Create(double.Parse(points[0]), double.Parse(points[1]), double.Parse(points[2])));
        }
    }

    private List<Edge> GetSortedEdges()
    {
        List<Edge> edges = [];


        for (int i = 0; i < points3d.Count; i++)
        {
            for (int j = i + 1; j < points3d.Count; j++)
            {

                Tuple<double, double, double> pointA = points3d[i];
                Tuple<double, double, double> pointB = points3d[j];

                double dx = pointA.Item1 - pointB.Item1;
                double dy = pointA.Item2 - pointB.Item2;
                double dz = pointA.Item3 - pointB.Item3;

                double dist = Math.Sqrt(dx * dx + dy * dy + dz * dz);

                edges.Add(new Edge(i, j, dist));
            }
        }

        var sorted = edges.OrderBy(p => p.Dist).ToList();
        return sorted;
    }

    internal override string PartOne()
    {
        List<Edge> sorted = GetSortedEdges();
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

  

    internal override string PartTwo()
    {
        List<Edge> sorted = GetSortedEdges();
        Edge lastEdge = null;
        var dsu = new DisjointUnionSets(boxCount);
        int components = boxCount;

        foreach (Edge edge in sorted)
        {
            int rootA = dsu.Find(edge.A);
            int rootB = dsu.Find(edge.B);

            if (rootA != rootB)
            {
                dsu.Union(edge.A, edge.B);
                components--;
                lastEdge = edge;

                if (components == 1) break;
            }
        }


        if (lastEdge == null) 
        {
            throw new NullReferenceException("BAD");
        }

        var a = points3d[lastEdge.A];
        var b = points3d[lastEdge.B];

        double final =  a.Item1 * b.Item1;
        return final.ToString();
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
