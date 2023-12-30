using System;
using System.IO;
using System.Collections.Generic;

class Day25
{
    List<string> allLines;
    List<string[]> edgesOriginal = new List<string[]>();

    public void buildGraph()
    {
        foreach (string line in allLines)
        {
            string[] nodes = line.Replace(":", "").Split(' ');
            string src = nodes[0];
            for (int i = 1; i < nodes.Length; i++)
            {
                edgesOriginal.Add(new string[] { src, nodes[i] });
            }
        }
    }
    static void Main(string[] args)
    {
        Day25 day25 = new Day25();
        day25.allLines = new List<string>(File.ReadAllLines(args[0]));
        day25.buildGraph();
        day25.part1();
    }

    public void part1()
    {
        int res = -1;

        while (res < 0)
        {
            res = KragersMinCut();
        }
        Console.WriteLine("Part 1: {0}", res);
    }
    public int KragersMinCut()
    {
        List<string[]> edges = new List<string[]>();

        foreach (string[] edge in edgesOriginal)
        {
            edges.Add(new string[] { edge[0], edge[1] });
        }
        Random rand = new Random();

        while (edges.Count > 3)
        {
            int randomEdge = rand.Next(edges.Count);
            string[] contractingNodes = edges[randomEdge];
            string newVertex = contractingNodes[0] + contractingNodes[1];
            edges.RemoveAt(randomEdge);

            for (int i = 0; i < edges.Count; i++)
            {
                string[] edge = edges[i];
                if (contractingNodes[0].Equals(edge[0]) || contractingNodes[1].Equals(edge[0]))
                {
                    edge[0] = newVertex;
                }
                if (contractingNodes[0].Equals(edge[1]) || contractingNodes[1].Equals(edge[1]))
                {
                    edge[1] = newVertex;
                }
                if (edge[0].Equals(edge[1]))
                {
                    edges.RemoveAt(i);
                    i--;
                }
            }
        }
        HashSet<string> uniqueNodes = new HashSet<string>();
        foreach (string[] edge in edges)
        {
            uniqueNodes.Add(edge[0]);
            uniqueNodes.Add(edge[1]);
        }

        if (uniqueNodes.Count != 2)
        {
            return -1;
        }

        int key = edges[0][0].Length;
        int values = edges[0][1].Length;
        return (key / 3) * (values / 3);
    }
}

