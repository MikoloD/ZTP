using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Dijsktra;
using ZTP.Interfaces;
using ZTP.ParallelTSPAlghoritms;
using ZTP.TSPAlghoritms;

namespace ZTP
{
    public class DIBuilder
    {
        public ServiceProvider BuildServices { get; set; }
        public DIBuilder()
        {
            BuildServices = new ServiceCollection()
                .AddScoped<IAdjacencyMatrix, AdjacencyMatrix>()
                .AddScoped<IDijkstra, Dijkstra>()
                .AddScoped<INearestFinder, NearestFinder>()
                .AddScoped<IParallelNearestFinder, ParallelSafeNearestFinder>()
                .AddSingleton<IParser, GraphParser>()
                .AddSingleton<ITSP, TSP>()
                .AddSingleton<IParallelTSP, ParallelTSP>()
                .BuildServiceProvider();
        }
    }
}
