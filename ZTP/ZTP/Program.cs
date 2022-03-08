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

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IParser,GraphParser>()
                .AddSingleton<IAdjacencyMatrix,AdjacencyMatrix>()
                .AddSingleton<IDijkstra,Dijkstra>()
                .BuildServiceProvider();

            DotGraph<int> Graf = serviceProvider.GetService<IParser>().Run(path);
            IAdjacencyMatrix AdjacencyMatrix = serviceProvider.GetService<IAdjacencyMatrix>();
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
