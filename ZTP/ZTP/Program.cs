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
                    StartingNode= 100
                },
                new GraphRequest()
                {
                    Path= @"Data\graf1000.gv",
                    StartingNode= 10
                },
                new GraphRequest()
                {
                    Path= @"Data\graf1000.gv",
                    StartingNode= 100
                }
            };

            DIBuilder DIProvider  = new DIBuilder();
            ServiceProvider serviceProvider = DIProvider.BuildServices;
            IHandlerBuilder chainOfResposibility = serviceProvider.GetService<IHandlerBuilder>();
            foreach (var item in requests)
            {
                Console.WriteLine(chainOfResposibility.Handle(item));
            }
        }
    }
}
