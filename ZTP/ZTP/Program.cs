using Graphviz4Net.Dot;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ZTP.Handlers.Interfaces;
using ZTP.Interfaces;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GraphRequest> requests = new List<GraphRequest>()
            {
                new GraphRequest()
                {
                    Path= @"Data\graphDuzy.dt",
                    StartingNode= 12
                },
                new GraphRequest()
                {
                    Path= @"Data\graphDuzy.dt",
                    StartingNode= 14
                }
            };

            DIBuilder DIProvider  = new DIBuilder();
            ServiceProvider serviceProvider = DIProvider.BuildServices;
            IHandlerBuilder chainOfResposibility = serviceProvider.GetService<IHandlerBuilder>();
            foreach (var item in requests)
            {
                chainOfResposibility.Handle(item);
            }

            //DotGraph<int> Graf = serviceProvider.GetService<IParser>().Run(path);

            //ITSP NaiveTSP = serviceProvider.GetService<ITSP>();
            //IParallelTSP ParallelNaiveTSP = serviceProvider.GetService<IParallelTSP>();

            //Test(NaiveTSP, startNode, Graf);
            //Test(ParallelNaiveTSP, startNode, Graf);
        }
    }
}
