using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP.Handlers.Interfaces;
using ZTP.Interfaces;
using ZTP.ParallelTSPAlghoritms.Interfaces;

namespace ZTP.Handlers
{
    public class HugeGraphHandler : AbstractHandler, IHugeGraphHandler
    {
        private readonly IParser _parser;
        private readonly IParallelTSP _tsp;
        public HugeGraphHandler(IParser parser, IParallelTSP tsp)
        {
            _parser = parser;
            _tsp = tsp;
        }
        public override object Handle(GraphRequest request)
        {
            DotGraph<int> graph = _parser.Run(request.Path);
            if (graph.Edges.Count() * graph.Vertices.Count() > 4 * Math.Pow(10, 6))
            {
                RunHandling handling = new RunHandling(_tsp, request.StartingNode, graph)
                {
                    Message = $"HugeGraphHandler was used"
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
