using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class Calibration
    {
       public class Counter
 {

     private readonly Grid maze;
     private readonly VectorData start;

     public Counter(string input)
     {
         maze = new(input, '#');
         start = maze.Iterate().Where(x => x.Value == 'S').Select(x => x.Position).Single();
     }

     public long Part1()
     {
         const int PART_ONE_STEPS = 64;
         var count = SimpleStepsCounter(start, PART_ONE_STEPS);
         return count;
     }

     private long SimpleStepsCounter(VectorData localStart, int steps)
     {
         int stepsParity = steps % 2;
         IEnumerable<VectorData> GetNeighbors(VectorData position)
         {
             return position.NextFour().Where(p => maze.Get(p) != '#');
         }
         var bfsResult = GraphAlgos.BfsToAll(localStart, GetNeighbors);
         var count = bfsResult.Count(x => x.Value.distance <= steps && x.Value.distance % 2 == stepsParity);
         return count;
     }

     public long Part2()
     {
         const int PART_TWO_STEPS = 26501365;

         int repetitions = PART_TWO_STEPS / maze.Height;
         int halfMaze = maze.Height / 2;
        

         long interiorOddTiles = SimpleStepsCounter(start, maze.Height);
         long interiorEvenTiles = SimpleStepsCounter(start, maze.Height + 1);

         long topCorner = SimpleStepsCounter(new VectorData(maze.Height - 1, halfMaze), maze.Height - 1);
         long bottomCorner = SimpleStepsCounter(new VectorData(0, halfMaze), maze.Height - 1);
         long leftCorner = SimpleStepsCounter(new VectorData(halfMaze, maze.Width - 1), maze.Height - 1);
         long rightCorner = SimpleStepsCounter(new VectorData(halfMaze, 0), maze.Height - 1);

         long topRightEvenDiagonal = SimpleStepsCounter(new VectorData(maze.Height - 1, 0), halfMaze - 1);
         long topRightOddDiagonal = SimpleStepsCounter(new VectorData(maze.Height - 1, 0), maze.Height + halfMaze - 1);
         long bottomRightEvenDiagonal = SimpleStepsCounter(new VectorData(0, 0), halfMaze - 1);
         long bottomRightOddDiagonal = SimpleStepsCounter(new VectorData(0, 0), maze.Height + halfMaze - 1);
         long bottomLeftEvenDiagonal = SimpleStepsCounter(new VectorData(0, maze.Width - 1), halfMaze - 1);
         long bottomLeftOddDiagonal = SimpleStepsCounter(new VectorData(0, maze.Width - 1), maze.Height + halfMaze - 1);
         long topLeftEvenDiagonal = SimpleStepsCounter(new VectorData(maze.Height - 1, maze.Width - 1), halfMaze - 1);
         long topLeftOddDiagonal = SimpleStepsCounter(new VectorData(maze.Height - 1, maze.Width - 1), maze.Height + halfMaze - 1);

         long sum = interiorOddTiles +
             topCorner + bottomCorner + leftCorner + rightCorner +
             repetitions * (topRightEvenDiagonal + bottomRightEvenDiagonal + bottomLeftEvenDiagonal + topLeftEvenDiagonal) +
             (repetitions - 1) * (topRightOddDiagonal + bottomRightOddDiagonal + bottomLeftOddDiagonal + topLeftOddDiagonal);

         for (long i = 1; i < repetitions; i++)
         {
             if (i % 2 == 0)
             {
                 sum += 4 * i * interiorOddTiles;
             }
             else
             {
                 sum += 4 * i * interiorEvenTiles;
             }
         }
         return sum;
     }

   
 }

 public class Grid
 {
     public ImmutableArray<string> Data { get; init; }
     public int Height { get => Data.Length; }
     public int Width { get; init; }

     private readonly char outsideChar;

     public Grid(string input, char outsideChar)
     {
         Data = input.ReplaceLineEndings("\n").Split('\n', StringSplitOptions.RemoveEmptyEntries).ToImmutableArray();
         this.outsideChar = outsideChar;
         Width = Data.Max(row => row.Length);
     }

     public char Get(int row, int col)
     {
         if (row < 0 || row >= Data.Length || col < 0 || col >= Data[row].Length)
         {
             return outsideChar;
         }
         return Data[row][col];
     }

     public char Get(VectorData coord)
     {
         return Get(coord.Row, coord.Col);
     }

     public IEnumerable<(VectorData Position, char Value)> Iterate()
     {
         for (int row = 0; row < Height; row++)
         {
             for (int col = 0; col < Width; col++)
             {
                 yield return (new VectorData(row, col), Get(row, col));
             }
         }
     }
 }

 public record struct VectorData(int Row, int Col)
 {
     public static readonly VectorData Zero = new VectorData(0, 0);
     public static readonly VectorData Up = new VectorData(-1, 0);
     public static readonly VectorData Down = new VectorData(+1, 0);
     public static readonly VectorData Left = new VectorData(0, -1);
     public static readonly VectorData Right = new VectorData(0, +1);

     public static VectorData operator +(VectorData left, VectorData right)
     {
         return new VectorData(left.Row + right.Row, left.Col + right.Col);
     }
     public static VectorData operator -(VectorData left, VectorData right)
     {
         return new VectorData(left.Row - right.Row, left.Col - right.Col);
     }
     public static VectorData operator -(VectorData val)
     {
         return new VectorData(-val.Row, -val.Col);
     }

     public readonly VectorData Scale(int factor)
     {
         return new VectorData(Row * factor, Col * factor);
     }
     public readonly int Dot(VectorData that)
     {
         return this.Row * that.Row + this.Col * that.Col;
     }
     public readonly VectorData RotatedLeft()
     {
         return new VectorData(-Col, Row);
     }
     public readonly VectorData RotatedRight()
     {
         return new VectorData(Col, -Row);
     }

     public readonly int ManhattanMetric()
     {
         return Math.Abs(Row) + Math.Abs(Col);
     }
     public readonly int ChebyshevMetric()
     {
         return Math.Max(Math.Abs(Row), Math.Abs(Col));
     }

     public readonly VectorData NextUp()
     {
         return this + Up;
     }
     public readonly VectorData NextDown()
     {
         return this + Down;
     }
     public readonly VectorData NextLeft()
     {
         return this + Left;
     }
     public readonly VectorData NextRight()
     {
         return this + Right;
     }
     public readonly VectorData[] NextFour()
     {
         return
             [
                 this + Up,
                 this + Down,
                 this + Left,
                 this + Right,
             ];
     }
     public readonly VectorData[] NextEight()
     {
         return
             [
                 this + Up + Left,
                 this + Up,
                 this + Up + Right,
                 this + Left,
                 this + Right,
                 this + Down + Left,
                 this + Down,
                 this + Down + Right,
             ];
     }
 }

 public class GraphAlgos
 {
     public static Dictionary<T, (T parent, int distance)> BfsToAll<T>(T start, Func<T, IEnumerable<T>> getNeighbors)
         where T : notnull
     {
         Queue<T> queue = new();
         queue.Enqueue(start);
         Dictionary<T, (T, int)> parentsDistances = new();
         parentsDistances[start] = (start, 0);
         while (queue.Count > 0)
         {
             var current = queue.Dequeue();
             foreach (var next in getNeighbors(current))
             {
                 if (!parentsDistances.ContainsKey(next))
                 {
                     parentsDistances[next] = (current, parentsDistances[current].Item2 + 1);
                     queue.Enqueue(next);
                 }
             }
         }
         return parentsDistances;
     }

     public static (int, IEnumerable<T>) BfsToEnd<T>(T start, Func<T, IEnumerable<T>> getNeighbors, Predicate<T> isEnd)
         where T : notnull
     {
         Queue<T> queue = new();
         queue.Enqueue(start);
         Dictionary<T, (T, int)> parentsDistances = new();
         parentsDistances[start] = (start, 0);
         while (queue.Count > 0)
         {
             var current = queue.Dequeue();
             if (isEnd(current))
             {
                 IEnumerable<T> GetSteps()
                 {
                     T cursor = current;
                     while (!object.Equals(cursor, start))
                     {
                         yield return cursor;
                         cursor = parentsDistances[cursor].Item1;
                     }
                 }
                 return (parentsDistances[current].Item2, GetSteps());
             }
             foreach (var next in getNeighbors(current))
             {
                 if (!parentsDistances.ContainsKey(next))
                 {
                     parentsDistances[next] = (current, parentsDistances[current].Item2 + 1);
                     queue.Enqueue(next);
                 }
             }
         }
         return (-1, Enumerable.Empty<T>());
     }

     public static Dictionary<T, (T parent, int distance)> DijkstraToAll<T>(T start, Func<T, IEnumerable<(T, int)>> getNeighbors)
         where T : notnull
     {
         PriorityQueue<T, int> queue = new();
         queue.Enqueue(start, 0);
         Dictionary<T, (T, int)> parentsDistances = new();
         parentsDistances[start] = (start, 0);
         while (queue.TryDequeue(out var current, out var currentDistance))
         {
             if (parentsDistances[current].Item2 < currentDistance)
             {
                 continue;
             }
             if (parentsDistances[current].Item2 > currentDistance)
             {
                 throw new Exception("?");
             }
             foreach (var (neighbor, distanceToNext) in getNeighbors(current))
             {
                 var nextDistance = currentDistance + distanceToNext;
                 if (!parentsDistances.TryGetValue(neighbor, out var distanceInPD) || nextDistance < distanceInPD.Item2)
                 {
                     parentsDistances[neighbor] = (current, nextDistance);
                     queue.Enqueue(neighbor, nextDistance);
                 }
             }
         }
         return parentsDistances;
     }

     public static (int distance, IEnumerable<T> path) DijkstraToEnd<T>(T start, Func<T, IEnumerable<(T, int)>> getNeighbors, Predicate<T> isEnd)
         where T : notnull
     {
         PriorityQueue<T, int> queue = new();
         queue.Enqueue(start, 0);
         Dictionary<T, (T parent, int distance)> parentsDistances = new();
         parentsDistances[start] = (start, 0);
         while (queue.TryDequeue(out var current, out var currentDistance))
         {
             if (parentsDistances[current].distance < currentDistance)
             {
                 continue;
             }
             if (parentsDistances[current].distance > currentDistance)
             {
                 throw new Exception("?");
             }
             if (isEnd(current))
             {
                 IEnumerable<T> GetSteps()
                 {
                     T cursor = current;
                     while (!object.Equals(cursor, start))
                     {
                         yield return cursor;
                         cursor = parentsDistances[cursor].parent;
                     }
                 }
                 return (parentsDistances[current].distance, GetSteps());
             }
             foreach (var (neighbor, distanceToNext) in getNeighbors(current))
             {
                 var nextDistance = currentDistance + distanceToNext;
                 if (!parentsDistances.TryGetValue(neighbor, out var distanceInPD) || nextDistance < distanceInPD.distance)
                 {
                     parentsDistances[neighbor] = (current, nextDistance);
                     queue.Enqueue(neighbor, nextDistance);
                 }
             }
         }
         return (-1, Enumerable.Empty<T>());
     }
 }

        public static void Main()
        {
            var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\Step.txt");
            Counter counter = new Counter(input);
            long a = counter.Part1();
            long b = counter.Part2();
            Console.WriteLine("Part 1 {0}", a);
            Console.WriteLine("Part 2 {0}", b);
        }
    }
}
