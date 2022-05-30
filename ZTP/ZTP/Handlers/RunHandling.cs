using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ZTP.Interfaces;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.Handlers
{
    public class RunHandling
    {
        public string Message { get; set; }
        public RunHandling(ITSP TSP, int startNode, DotGraph<int> Graf)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            IPath result = TSP.Run(startNode, Graf);
            stopwatch.Stop();
            PrintSolution(result, stopwatch.Elapsed);
        }
        public void PrintSolution(IPath result, TimeSpan time)
        {
            foreach (var item in result.Nodes)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("Wartość: " + result.Value);
            Console.WriteLine("Czas: " + time);
            Console.WriteLine();
        }
    }
}
