using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class LongWalk
    {
        public static void Main()
        {
            var fileName = @"C:\Users\input23.txt";
            var lines= ReadFile(fileName);
            var map = ParseInput(lines);

            var result1=Part1(map);
            Console.WriteLine($"Part 1 Result = {result1}");

            var result2= Part2(map);
            Console.WriteLine($"Part 2 Result = {result2}");
        }

        public static int Part1(Map map)
        {
            var result1 = FindPathLengths(
              map.GetStart(),
              map.GetEnd(),
              pt => map.EnumMoves(pt).Select(n => (n, 1))).Max();
            return result1;
        }

        public static int Part2(Map map)
        {
            var graph = BuildSimplifiedGraph(map);

            var result2 = FindPathLengths(
              map.GetStart(),
              map.GetEnd(),
              pt => graph[pt]).Max();
            return result2;
        }

        public static ImmutableArray<string> ReadFile(string fileName)
        {
            if(string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            var lines = File.ReadLines(@"C:\Users\input23.txt").ToImmutableArray();
            return lines;
        }
        public static Map ParseInput(ImmutableArray<string> lines)
        {
            if (lines.Length == 0)
            {
                throw new InvalidDataException();
            }
            var map = new Map(lines);
            return map;
        }
        public static IEnumerable<int> FindPathLengths(Point start, Point goal, Func<Point, IEnumerable<(Point pt, int steps)>> edges)
        {
            Stack<(Point, ImmutableHashSet<Point>, int)> stack = new([(start, [start], 0)]);

            while (stack.Count > 0)
            {
                var (pt, visited, steps) = stack.Pop();
                foreach (var next in edges(pt).Where(next => !visited.Contains(next.pt)))
                {
                    if (next.pt == goal)
                        yield return steps + next.steps;
                    else
                        stack.Push((next.pt, visited.Add(next.pt), steps + next.steps));
                }
            }
        }

       public static ILookup<Point, (Point to, int size)> BuildSimplifiedGraph(Map map)
        {
            var start = map.GetStart();
            var goal = map.GetEnd();
            HashSet<(Point from, Point to, int size)> edges = new();
            HashSet<(Point, Point)> visited = [];
            Stack<(Point start, Point next, int steps, ImmutableHashSet<Point>)> stack = new();

            foreach (var m in map.EnumMoves(start, true))
            {
                visited.Add((start, m));
                stack.Push((start, m, 1, [start]));
            }

            while (stack.Count > 0)
            {
                var (from, pt, steps, path) = stack.Pop();

                if (pt == goal)
                {
                    edges.Add((from, pt, steps));
                    edges.Add((pt, from, steps));
                }
                else
                {
                    var moves = map.EnumMoves(pt, true)
                                   .Where(n => !path.Contains(n))
                                   .ToArray();

                    if (moves.Length == 1)
                    {
                        stack.Push((from, moves[0], steps + 1, path.Add(pt)));
                    }
                    else if (moves.Length > 0)
                    {
                        edges.Add((from, pt, steps));
                        edges.Add((pt, from, steps));

                        foreach (var m in moves)
                        {
                            if (!visited.Contains((pt, m)))
                            {
                                visited.Add((pt, m));
                                stack.Push((pt, m, 1, [pt]));
                            }
                        }
                    }
                }
            }

            return edges.ToLookup(x => x.from, x => (x.to, x.size));
        }


        public record struct Point(int X, int Y)
        {
            public IEnumerable<Point> EnumAdjacent()
              => [new(X - 1, Y), new(X + 1, Y), new(X, Y - 1), new(X, Y + 1)];
        }

        public record Map(ImmutableArray<string> Data)
        {
            public int Width = Data.FirstOrDefault()?.Length ?? 0;

            public int Height = Data.Length;

            public char this[Point pt]
              => Contains(pt) ? Data[pt.Y][pt.X] : default;

            public bool Contains(Point pt)
              => pt.X >= 0 && pt.X < Width
              && pt.Y >= 0 && pt.Y < Height;

            public bool IsWalkable(Point pt)
              => this[pt] is '.' or '^' or '>' or 'v' or '<';

            public bool IsBadMove(Point from, Point to)
              => (to.X - from.X, to.Y - from.Y) switch
              {
                  (1, 0) => this[to] != '<',
                  (-1, 0) => this[to] != '>',
                  (0, 1) => this[to] != '<',
                  (0, -1) => this[to] != '^',
                  _ => false
              };

            public Point GetStart() => new(Data[0].IndexOf('.'), 0);

            public Point GetEnd() => new(Data.Last().IndexOf('.'), Data.Length - 1);

            public IEnumerable<Point> EnumMoves(Point pt, bool slopesAsPaths = false)
            {
                return from to in EnumMovesInternal(pt, slopesAsPaths)
                       where IsWalkable(to) && (slopesAsPaths || !IsBadMove(pt, pt))
                       select to;
            }

            private IEnumerable<Point> EnumMovesInternal(Point pt, bool slopesAsPaths = false)
              => slopesAsPaths
                ? pt.EnumAdjacent()
                : this[pt] switch
                {
                    '.' => pt.EnumAdjacent(),
                    '^' => [new(pt.X, pt.Y - 1)],
                    '>' => [new(pt.X + 1, pt.Y)],
                    'v' => [new(pt.X, pt.Y + 1)],
                    '<' => [new(pt.X - 1, pt.Y)],
                    _ => []
                };
        }
    }
}
