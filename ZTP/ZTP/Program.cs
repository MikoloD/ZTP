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
            int startNode;

            startNode = int.Parse(Console.ReadLine());
            Console.WriteLine();

            DIBuilder DIProvider  = new DIBuilder();
            var serviceProvider = DIProvider.BuildServices;
            DotGraph<int> Graf = serviceProvider.GetService<IParser>().Run(path);
            ITSP TravelingSalesmanProblem = serviceProvider.GetService<ITSP>();
            Path result = TravelingSalesmanProblem.Run(startNode,Graf);
            foreach (var item in result.Nodes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Wartość: "+ result.Value);
        }
    }
}
