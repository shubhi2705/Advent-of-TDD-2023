using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class Calibration
    {
        public static void Main()
        {
            var a = "Parabolic.txt";
            Parabolic para = new Parabolic();
            var data=para.PartOne(a);
            Console.WriteLine($"P1: {data}");
            var data2=para.PartTwo(a);
            Console.WriteLine($"P2: {data2}");
        }
    }
    public  class Parabolic
{


    public void RollNorth(char[,] map, int size)
    {
        for (int r = 1; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                if (map[r, c] == 'O')
                {
                    int nr = r;
                    while (nr - 1 >= 0 && map[nr - 1, c] == '.')
                    {
                        map[nr - 1, c] = 'O';
                        map[nr, c] = '.';
                        --nr;
                    }
                }
            }
        }
    }

    public void RollSouth(char[,] map, int size)
    {
        for (int r = size - 1; r >= 0; r--)
        {
            for (int c = 0; c < size; c++)
            {
                if (map[r, c] == 'O')
                {
                    int nr = r;
                    while (nr + 1 < size && map[nr + 1, c] == '.')
                    {
                        map[nr + 1, c] = 'O';
                        map[nr, c] = '.';
                        ++nr;
                    }
                }
            }
        }
    }


    public int CountLoad(char[,] map, int size)
    {
        int load = 0;
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                if (map[r, c] == 'O')
                    load += size - r;
            }
        }

        return load;
    }

    public void RollWest(char[,] map, int size)
    {
        for (int r = 0; r < size; r++)
        {
            for (int c = 1; c < size; c++)
            {
                if (map[r, c] == 'O')
                {
                    int nc = c;
                    while (nc - 1 >= 0 && map[r, nc - 1] == '.')
                    {
                        map[r, nc - 1] = 'O';
                        map[r, nc] = '.';
                        --nc;
                    }
                }
            }
        }
    }

    public void RollEast(char[,] map, int size)
    {
        for (int r = 0; r < size; r++)
        {
            for (int c = size - 1; c >= 0; c--)
            {
                if (map[r, c] == 'O')
                {
                    int nc = c;
                    while (nc + 1 < size && map[r, nc + 1] == '.')
                    {
                        map[r, nc + 1] = 'O';
                        map[r, nc] = '.';
                        ++nc;
                    }
                }
            }
        }
    }

    public void Cycle(char[,] map, int size)
    {
        RollNorth(map, size);
        RollWest(map, size);
        RollSouth(map, size);
        RollEast(map, size);
    }

    public int MapHash(char[,] map, int size)
    {
        var sb = new StringBuilder();
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                sb.Append(map[r, c]);
            }
        }

        return sb.ToString().GetHashCode();
    }

    public (char[,], int) FetchInput(string fileName)
    {
        string path = @"C:\Users\MSUSERSL123\Documents\Data\" + fileName;
        if (File.Exists(path))
        {
            var input = File.ReadAllLines(path);
            int size = input.Length;
            char[,] map = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    map[r, c] = input[r][c];
                }
            }

            return (map, size);
        }
        else
        {
            throw new Exception("File Not found");
        }
    }

    public int PartOne(string fileName)
    {
        var (map, size) = FetchInput(fileName);
        RollNorth(map, size);
        return CountLoad(map, size);
    }

    static bool IsCycle(List<int> hashes, int a, int b)
    {
        int c = b - a;

        for (int j = 0; j < c; j++)
        {
            if (hashes[a + j] != hashes[b + j])
                return false;
        }

        return true;
    }

    public int PartTwo(string fileName)
    {
        var (map, size) = FetchInput(fileName);

        // okay, lets run through a bunch of cycles!
        int round = 0;
        var loads = new List<int>();
        var hashes = new List<int>();
        do
        {
            Cycle(map, size);
            int hash = MapHash(map, size);
            hashes.Add(hash);
            int load = CountLoad(map, size);
            loads.Add(load);

            ++round;
        }
        while (round < 1100);

        int firstOne = 0, secondOne;
        do
        {
            for (secondOne = firstOne + 1; secondOne < hashes.Count; secondOne++)
            {
                if (hashes[firstOne] == hashes[secondOne] && IsCycle(hashes, firstOne, secondOne))
                {
                    goto done;
                }
            }
            ++firstOne;
        }
        while (true);
    done:

        int cycleLen = secondOne - firstOne;
        int offset = (1_000_000_000 - secondOne) % cycleLen - 1;
        return loads[firstOne + offset];
    }


}
}
