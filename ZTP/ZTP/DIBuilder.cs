using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Dijsktra;
using ZTP.Dijsktra.Interfaces;
using ZTP.Handlers;
using ZTP.Handlers.Interfaces;
using ZTP.Interfaces;
using ZTP.ParallelTSPAlghoritms;
using ZTP.ParallelTSPAlghoritms.Interfaces;
using ZTP.Parser;
using ZTP.TSPAlghoritms;
using ZTP.TSPAlghoritms.Interfaces;

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
                .AddScoped<IParser, GraphParser>()
                .AddScoped<ITSP, TSP>()
                .AddScoped<IParallelTSP, ParallelTSP>()
                .AddSingleton<IHandlerBuilder, HandlerBuilder>()
                .AddScoped<ISmallGraphHandler, SmallGraphHandler>()
                .AddScoped<IHugeGraphHandler, HugeGraphHandler>()
                .BuildServiceProvider();
        }
    }
}
