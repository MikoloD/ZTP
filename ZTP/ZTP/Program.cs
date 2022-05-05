using Graphviz4Net.Dot;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZTP.Interfaces;

namespace ZTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data\graphDuzy.dt";
            int startNode = 0;

            DIBuilder DIProvider  = new DIBuilder();
            var serviceProvider = DIProvider.CoreServices;
            DotGraph<int> Graf = serviceProvider.GetService<IParser>().Run(path);
            ITSP TravelingSalesmanProblem = serviceProvider.GetService<ITSP>();
            Path result = TravelingSalesmanProblem.Run(startNode,Graf);
            foreach (var item in result.Nodes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Wartość: "+ result.Value);
            //IAdjacencyMatrix AdjacencyMatrix = serviceProvider.GetService<IAdjacencyMatrix>();
            //IDijkstra Dijkstra = serviceProvider.GetService<IDijkstra>();

            //Dijkstra.Run(AdjacencyMatrix.CreateAdjMatrix(Graf),startNode);

            //foreach (var item in Dijkstra.AlghoritmResult)
            //{
            //    Console.Write(item.SourceNodeId+" "+item.TargetNodeId+" "+item.Value);
            //    foreach (var elem in item.Path)
            //    {
            //        Console.Write(" "+elem);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
