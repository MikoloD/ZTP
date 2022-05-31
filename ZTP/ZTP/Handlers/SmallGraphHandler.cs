using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ZTP.Handlers.Interfaces;
using ZTP.Interfaces;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.Handlers
{
    public class SmallGraphHandler : AbstractHandler, ISmallGraphHandler
    {
        private readonly IParser _parser;
        private readonly ITSP _tsp;
        public SmallGraphHandler(IParser parser,ITSP tsp)
        {
            _parser = parser;
            _tsp = tsp;
        }
        public override object Handle(GraphRequest request)
        {
            DotGraph<int> graph = _parser.Run(request.Path);
            if (graph.Edges.Count() * graph.Vertices.Count() <= 4*Math.Pow(10,6)) 
            {
                RunHandling handling = new RunHandling(_tsp, request.StartingNode, graph)
                {
                    Message = $"SmallGraphHandler was used"
                };
                return handling.Message;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
