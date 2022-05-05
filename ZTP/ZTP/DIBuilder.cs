using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;

namespace ZTP
{
    public class DIBuilder
    {
        public ServiceProvider CoreServices { get; set; }
        public ServiceProvider BuildServices { get; set; }
        public DIBuilder()
        {
            BuildServices = new ServiceCollection()
                .AddSingleton<IAdjacencyMatrix, AdjacencyMatrix>()
                .AddSingleton<IDijkstra, Dijkstra>()
                .AddSingleton<INearestFinder, NearestFinder>()
                .BuildServiceProvider();

            CoreServices = new ServiceCollection()
                .AddSingleton<IParser, GraphParser>()
                .AddSingleton<ITSP, TSP>(config => new TSP(BuildServices))
                .BuildServiceProvider();
        }
    }
}
