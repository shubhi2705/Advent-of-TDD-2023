using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Day17
{
    public Day17()
    {

    }

    public int GetMinHeatLoss(int[][] heat_map, int braking_duration = 0, int maximum_speed = 3)
    {
        var crucibleQueue = new PriorityQueue<(int, int, int, int, int, int)>();
        var crucibleHistory = new HashSet<(int, int, int, int, int)>();
        int rows = heat_map.Length;
        int columns = heat_map[0].Length;
        var destination = (columns - 1, rows - 1);
        crucibleQueue.Enqueue((0, 0, 0, 0, 0, 0));
        while (crucibleQueue.Count() > 0)
        {
            var (heat_loss, x, y, x_dir, y_dir, speed) = crucibleQueue.Dequeue();
            var state = (x, y, x_dir, y_dir, speed);
            if (crucibleHistory.Contains(state))
            {
                continue;
            }
            crucibleHistory.Add(state);
            if ((x, y) == destination && speed >= braking_duration)
            {
                return heat_loss;
            }
            if (speed >= braking_duration || speed == 0)
            {
                if (x_dir == 0)
                {
                    foreach (var i in new[] { 1, -1 })
                    {
                        if (0 <= x + i && x + i < columns)
                        {
                            crucibleQueue.Enqueue((heat_loss + heat_map[y][x + i], x + i, y, i, 0, 1));
                        }
                    }
                }
                if (y_dir == 0)
                {
                    foreach (var i in new[] { 1, -1 })
                    {
                        if (0 <= y + i && y + i < rows)
                        {
                            crucibleQueue.Enqueue((heat_loss + heat_map[y + i][x], x, y + i, 0, i, 1));
                        }
                    }
                }
            }
            if (speed < maximum_speed)
            {
                var new_x = x + x_dir;
                var new_y = y + y_dir;
                if (0 <= new_x && new_x < columns && 0 <= new_y && new_y < rows)
                {
                    crucibleQueue.Enqueue((heat_loss + heat_map[new_y][new_x], new_x, new_y, x_dir, y_dir, speed + 1));
                }
            }
        }
        return -1;
    }

    public static void Main(string[] args)
    {
        string file = @"C:\Users\Administrator\Documents\InputFile\Day17.txt";
        var obj = new Day17();
        int[][] heat_map = obj.ProcessFile(file);
        Console.WriteLine("Part 1: " + obj.GetMinHeatLoss(heat_map));
        Console.WriteLine("\nPart 2: " + obj.GetMinHeatLoss(heat_map, 4, 10));
    }

    public int[][] ProcessFile(string file)
    {
        var lines = System.IO.File.ReadAllLines(file);
        var heat_map = new int[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            heat_map[i] = Array.ConvertAll(lines[i].ToCharArray(), c => (int)Char.GetNumericValue(c));
        }

        return heat_map;
    }
}

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> data;

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int ci = data.Count - 1;
        while (ci > 0)
        {
            int pi = (ci - 1) / 2;
            if (data[ci].CompareTo(data[pi]) >= 0)
                break;
            T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
            ci = pi;
        }
    }

    public T Dequeue()
    {
        int li = data.Count - 1;
        T frontItem = data[0];
        data[0] = data[li];
        data.RemoveAt(li);

        --li;
        int pi = 0;
        while (true)
        {
            int ci = pi * 2 + 1;
            if (ci > li)
                break;
            int rc = ci + 1;
            if (rc <= li && data[rc].CompareTo(data[ci]) < 0)
                ci = rc;
            if (data[pi].CompareTo(data[ci]) <= 0)
                break;
            T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
            pi = ci;
        }
        return frontItem;
    }

    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }

    public int Count()
    {
        return data.Count;
    }
}


