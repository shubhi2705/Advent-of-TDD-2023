using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeMaze
{
    public class PipeMaze_Part1
    {
        public PipeMaze_Part1()
        {

        }
        static void Main(string[] args)
        {
            string file = Console.ReadLine().Trim();
            var obj = new PipeMaze_Part1();
            int value = obj.TotalSteps(file);
            Console.WriteLine(value);
        }

        public int TotalSteps(string file)
        {
            int value = 0;
            if (File.Exists(file))
            {
                List<string> grid = new List<string>(File.ReadAllLines(file));//read each row in file
                int sr, sc;
                
                CordinatesOfStartPosition(grid, out sr, out sc);

                Console.WriteLine(grid[sr][sc]);

                HashSet<(int, int)> visitedPipes = new HashSet<(int, int)>();
                Queue<(int, int)> q = new Queue<(int, int)>();

                string TopList = "S|LJ"; //Top
                string CanUpward = "|7F";
                string BottomList = "S|7F";
                string CanDownward = "|LJ";
                string LeftList = "S-J7";
                string CanLeft = "-LF";
                string RightList = "S-LF";
                string CanRight = "-J7";

                TotalVisitedCordinates(grid, sr, sc, visitedPipes, q, TopList, CanUpward, BottomList, CanDownward, LeftList, CanLeft, RightList, CanRight);

                value = visitedPipes.Count / 2;
            }
            else
            {
                throw new FileNotFoundException();
            }
            return value;
        }

        public void CordinatesOfStartPosition(List<string> grid, out int sr, out int sc)
        {
            sr = -1;
            sc = -1;
            //find the start position
            for (int r = 0; r < grid.Count; r++)
            {
                string row = grid[r];
                for (int c = 0; c < row.Length; c++)
                {
                    char ch = row[c];
                    if (ch == 'S')
                    {
                        sr = r;
                        sc = c;
                        break;
                    }
                }
                if (sr != -1 && sc != -1)//break the outer loop once cordinates of start position is found 
                {
                    break;
                }
            }
        }

        public void TotalVisitedCordinates(List<string> grid, int sr, int sc, HashSet<(int, int)> visitedPipes, Queue<(int, int)> q, string TopList, string CanUpward, string BottomList, string CanDownward, string LeftList, string CanLeft, string RightList, string CanRight)
        {
            visitedPipes.Add((sr, sc));//move start S to visitedPipes (which is visited already)
            q.Enqueue((sr, sc));//add the visited tile to the queue

            while (q.Count > 0)
            {
                (int r, int c) = q.Dequeue();//remove visited tile from begining of the queue 
                char ch = grid[r][c];
                if (r > 0 && TopList.Contains(ch) && CanUpward.Contains(grid[r - 1][c]) && !visitedPipes.Contains((r - 1, c)))
                {
                    visitedPipes.Add((r - 1, c));
                    q.Enqueue((r - 1, c));
                }
                if (grid.Count - 1 > r && BottomList.Contains(ch) && CanDownward.Contains(grid[r + 1][c]) && !visitedPipes.Contains((r + 1, c)))
                {
                    visitedPipes.Add((r + 1, c));
                    q.Enqueue((r + 1, c));
                }
                if (c > 0 && LeftList.Contains(ch) && CanLeft.Contains(grid[r][c - 1]) && !visitedPipes.Contains((r, c - 1)))
                {
                    visitedPipes.Add((r, c - 1));
                    q.Enqueue((r, c - 1));
                }
                if (grid[r].Length - 1 > c && RightList.Contains(ch) && CanRight.Contains(grid[r][c + 1]) && !visitedPipes.Contains((r, c + 1)))
                {
                    visitedPipes.Add((r, c + 1));
                    q.Enqueue((r, c + 1));
                }
            }
        }

        //| is a vertical pipe connecting north and south.
        //- is a horizontal pipe connecting east and west.
        //L is a 90-degree bend connecting north and east.
        //J is a 90-degree bend connecting north and west.
        //7 is a 90-degree bend connecting south and west.
        //F is a 90-degree bend connecting south and east.
        //. is ground; there is no pipe in this tile.
        //S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
    }
}
