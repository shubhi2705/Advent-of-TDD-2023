using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using Microsoft.Z3;

namespace AdventOfCodeTDD
{
   public class Calibration
    {
        public static void Main()
        {
            Hailstones hailstones = new Hailstones();
            hailstones.ReadData("Input24.txt");
            var a = hailstones.Part1();
            var b = hailstones.Part2();
            Console.WriteLine("Part 1 {0}", a);
            Console.WriteLine("Part 2 {0}", b);
        }
    }
    public class Hailstones
  {
     public double min = 200000000000000.0;
     public double max = 400000000000000.0;

     public List<Hail> hails = new List<Hail>();
     public record Position(double X, double Y, double Z = 0)
     {
         public Position Move(double x, double y, double z) => new(X + x, Y + y, Z + z);
         public bool InBounds(double min, double max) => X >= min && X <= max && Y >= min && Y <= max;
     }

     public record Hail(Position Position, Position Velocity, double Slope = 0, double Intersect = 0)
     {
         public Hail Move() => this with { Position = Position.Move(Velocity.X, Velocity.Y, Velocity.Z) };
     }

     public void ReadData(string FileName)
     {

         var path = @"C:\Users\MSUSERSL123\Documents\Data\" + FileName;

         if (File.Exists(path))
         {
             var input = File.ReadAllLines(path);
             foreach (var line in input)
             {
                 var split = line.Split('@', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                 var position = split[0].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                     .Select(double.Parse).ToArray();
                 var velocity = split[1].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                     .Select(double.Parse).ToArray();

                 var hail = new Hail(
                     new Position(position[0], position[1], position[2]),
                     new Position(velocity[0], velocity[1], velocity[2]));

                 var next = hail.Move();

                 var slope = (next.Position.Y - hail.Position.Y) / (next.Position.X - hail.Position.X);
                 var intercept = next.Position.Y - slope * next.Position.X;

                 hails.Add(hail with { Slope = slope, Intersect = intercept });
             }


         }
         else
         {
             throw new FileNotFoundException();
         }

     }
     public long Part1()
     {

         var part1 = 0;
         var visited = new HashSet<Hail>();
         const int b = -1;
         foreach (var first in hails)
         {
             visited.Add(first);
             var a1 = first.Slope;
             var c1 = first.Intersect;
             var x1 = first.Position.X;
             var y1 = first.Position.Y;
             var vx1 = first.Velocity.X;
             var vy1 = first.Velocity.Y;

             foreach (var second in hails.Where(h => !visited.Contains(h)))
             {
                 var a2 = second.Slope;
                 var c2 = second.Intersect;
                 var x2 = second.Position.X;
                 var y2 = second.Position.Y;
                 var vx2 = second.Velocity.X;
                 var vy2 = second.Velocity.Y;

                 if (a1 == a2)
                 {
                     continue;
                 }

                 var x = (b * c2 - b * c1) / (a1 * b - a2 * b);
                 var y = (a2 * c1 - a1 * c2) / (a1 * b - a2 * b);

                 if (x - x1 < 0 != vx1 < 0 ||
                     y - y1 < 0 != vy1 < 0)
                 {
                     continue;
                 }

                 if (x - x2 < 0 != vx2 < 0 ||
                     y - y2 < 0 != vy2 < 0)
                 {
                     continue;
                 }

                 if (new Position(x, y).InBounds(min, max))
                 {
                     part1++;
                 }
             }
         }
         return part1;
     }
     public long Part2()
     {
         var hailstones = hails;
         var ctx = new Context();
         var solver = ctx.MkSolver();


         var x = ctx.MkIntConst("x");
         var y = ctx.MkIntConst("y");
         var z = ctx.MkIntConst("z");


         var vx = ctx.MkIntConst("vx");
         var vy = ctx.MkIntConst("vy");
         var vz = ctx.MkIntConst("vz");
         for (var i = 0; i < 3; i++)
         {
             var t = ctx.MkIntConst($"t{i}"); 
             var hail = hailstones[i];

             var px = ctx.MkInt(Convert.ToInt64(hail.Position.X));
             var py = ctx.MkInt(Convert.ToInt64(hail.Position.Y));
             var pz = ctx.MkInt(Convert.ToInt64(hail.Position.Z));

             var pvx = ctx.MkInt(Convert.ToInt64(hail.Velocity.X));
             var pvy = ctx.MkInt(Convert.ToInt64(hail.Velocity.Y));
             var pvz = ctx.MkInt(Convert.ToInt64(hail.Velocity.Z));

             var xLeft = ctx.MkAdd(x, ctx.MkMul(t, vx));
             var yLeft = ctx.MkAdd(y, ctx.MkMul(t, vy)); 
             var zLeft = ctx.MkAdd(z, ctx.MkMul(t, vz)); 

             var xRight = ctx.MkAdd(px, ctx.MkMul(t, pvx)); 
             var yRight = ctx.MkAdd(py, ctx.MkMul(t, pvy)); 
             var zRight = ctx.MkAdd(pz, ctx.MkMul(t, pvz)); 

             solver.Add(t >= 0); 
             solver.Add(ctx.MkEq(xLeft, xRight)); 
             solver.Add(ctx.MkEq(yLeft, yRight)); 
             solver.Add(ctx.MkEq(zLeft, zRight)); 
         }

         solver.Check();
         var model = solver.Model;

         var rx = model.Eval(x);
         var ry = model.Eval(y);
         var rz = model.Eval(z);

         return Convert.ToInt64(rx.ToString()) + Convert.ToInt64(ry.ToString()) + Convert.ToInt64(rz.ToString());
     }
 }
}
