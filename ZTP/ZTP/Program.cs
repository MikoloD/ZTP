using Graphviz4Net.Dot;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using ZTP.Interfaces;

namespace ZTP
{
    internal class Program
    {
        static void Test(ITSP TSP,int startNode, DotGraph<int> Graf)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            IPath result = TSP.Run(startNode, Graf);
            stopwatch.Stop();
            PrintSolution(result, stopwatch.Elapsed);
        }
        static void PrintSolution(IPath result,TimeSpan time)
        {
            foreach (var item in result.Nodes)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine("Wartość: " + result.Value);
            Console.WriteLine("Czas: " + time);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string path = @"Data\graphDuzy.dt";
            int startNode;

            startNode = int.Parse(Console.ReadLine());
            Console.WriteLine();

            DIBuilder DIProvider  = new DIBuilder();
            var serviceProvider = DIProvider.BuildServices;
            DotGraph<int> Graf = serviceProvider.GetService<IParser>().Run(path);

            ITSP NaiveTSP = serviceProvider.GetService<ITSP>();
            IParallelTSP ParallelNaiveTSP = serviceProvider.GetService<IParallelTSP>();


            //Test(NaiveTSP, startNode, Graf);
            //Work in progress
            Test(ParallelNaiveTSP, startNode, Graf);
        }
    }
}
