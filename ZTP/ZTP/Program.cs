using Graphviz4Net.Dot;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ZTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data\graphDuzy.dt";
            int startNode = 0;

            var serviceProvider = new ServiceCollection()
                .AddSingleton<GraphParser>()
                .AddSingleton<AdjacencyMatrix>()
                .AddSingleton<IDijkstra,Dijkstra>()
                .BuildServiceProvider();

            DotGraph<int> Graf = serviceProvider.GetService<GraphParser>().Run(path);
            AdjacencyMatrix AdjacencyMatrix = serviceProvider.GetService<AdjacencyMatrix>();
            IDijkstra Dijkstra = serviceProvider.GetService<IDijkstra>();
            Dijkstra.Run(AdjacencyMatrix.CreateAdjMatrix(Graf),startNode);
            foreach (var item in Dijkstra.AlghoritmResult)
            {
                Console.Write(item.SourceNodeId+" "+item.TargetNodeId+" "+item.Value);
                foreach (var elem in item.Path)
                {
                    Console.Write(" "+elem);
                }
                Console.WriteLine();
            }
        }
    }
}
