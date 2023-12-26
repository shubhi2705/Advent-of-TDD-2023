using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AdventOfCodeTDD
{
    public class Lava
    {
        public enum Direction { Up, Right, Down, Left }

        public static void Main()
        {
            
            var fileName =@"C:\Users\input_16.txt";
            var lines = ReadFile(fileName);
            var map = processInput(lines);
            var part1 = calculatePart1(map);
            Console.WriteLine($"Part 1 Result = {part1}");

            var part2 = calculatePart2(map);
            Console.WriteLine($"Part 2 Result = {part2}");
        }
        public static string[] ReadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new FileNotFoundException();
            }
            var lines = File.ReadAllLines(fileName);
            return lines;
        }

        public static Mapping processInput(string[] input)
        {
            if (input.Length==0)
            {
                throw new InvalidDataException();
            }
            else
            {
                var devices = new List<Device>();
                for (int y = 0; y < input.Length; y++)
                {
                    var line = input[y];
                    for (int x = 0; x < line.Length; x++)
                    {
                        var ch = line[x];
                        if (ch != '.')
                        {
                            var device = new Device(new(x, y), ch);
                            devices.Add(device);
                        }
                    }
                }
                var d = devices.ToImmutableDictionary(x => x.Position);
                var map = new Mapping(input[0].Length, input.Length, d);
                return map;
            }
        }
        public static int calculatePart1(Mapping map)
        {
            var visited = FindVisitedPositions(map, new(-1, 0), Direction.Right);
            var part1 = visited.Count();
            return part1;
        }
        public static int calculatePart2(Mapping map)
        {
            var part2 = map.EnumStartPositions().AsParallel()
                             .Max(p => FindVisitedPositions(map, p.pos, p.dir).Count());
            return part2;
        }
        public static IEnumerable<Point> FindVisitedPositions(Mapping map, Point start, Direction direction)
        {
            HashSet<(Point pos, Direction dir)> visited = new();
            Queue<(Point pos, Direction dir)> queue = new([(start, direction)]);

            while (queue.Count > 0)
            {
                var (pos, dir) = queue.Dequeue();
                var next = pos.Move(dir);
                if (!visited.Contains((next, dir)) && next.X >= 0 && next.Y >= 0 && next.X < map.Width && next.Y < map.Height)
                {
                    visited.Add((next, dir));

                    if (map.Devices.TryGetValue(next, out var device))
                    {
                        foreach (var nextDir in device.EnumOutDirections(dir))
                            queue.Enqueue((next, nextDir));
                    }
                    else
                    {
                        queue.Enqueue((next, dir));
                    }
                }
            }

            return visited.Select(x => x.pos).Distinct();
        }


        public record struct Point(int X, int Y)
        {
            public Point Move(Direction direction)
              => direction switch
              {
                  Direction.Up => new(X, Y - 1),
                  Direction.Right => new(X + 1, Y),
                  Direction.Down => new(X, Y + 1),
                  Direction.Left => new(X - 1, Y),
                  _ => this
              };
        }

        public record Device(Point Position, char Type)
        {
            public IEnumerable<Direction> EnumOutDirections(Direction incoming)
              => (Type, incoming) switch
              {
                  ('|', Direction.Left or Direction.Right) => [Direction.Up, Direction.Down],
                  ('-', Direction.Down or Direction.Up) => [Direction.Left, Direction.Right],
                  ('\\', Direction.Up) => [Direction.Left],
                  ('\\', Direction.Right) => [Direction.Down],
                  ('\\', Direction.Down) => [Direction.Right],
                  ('\\', Direction.Left) => [Direction.Up],
                  ('/', Direction.Up) => [Direction.Right],
                  ('/', Direction.Right) => [Direction.Up],
                  ('/', Direction.Down) => [Direction.Left],
                  ('/', Direction.Left) => [Direction.Down],
                  _ => [incoming]
              };
        }

        public record Mapping(int Width, int Height, ImmutableDictionary<Point, Device> Devices)
        {
            public IEnumerable<(Point pos, Direction dir)> EnumStartPositions()
            {
                for (var y = 0; y < Height; ++y)
                {
                    yield return (new(-1, y), Direction.Right);
                    yield return (new(Width, y), Direction.Left);
                }

                for (var x = 0; x < Width; ++x)
                {
                    yield return (new(x, -1), Direction.Down);
                    yield return (new(x, Height), Direction.Up);
                }
            }
        }
    }
}