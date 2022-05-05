using Graphviz4Net.Dot;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP.Interfaces;

namespace ZTP
{
    class TSP : ITSP
    {
        private readonly ServiceProvider _serviceProvider;
        public List<int> AddedNodes { get; set; } = new List<int>();
        public TSP(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public Path Run(int StartNode,DotGraph<int> Graph)
        {
            IAdjacencyMatrix AdjacencyMatrix = _serviceProvider.GetService<IAdjacencyMatrix>();
            IDijkstra Dijkstra = _serviceProvider.GetService<IDijkstra>();
            INearestFinder NearestFinder = _serviceProvider.GetService<INearestFinder>();

            int index = 0;
            Path result = new Path
            {
                Value = 0,
                Nodes = new int[Graph.Vertices.Count() + 1]
            };
            result.Nodes[index] = StartNode;

            int[,] weightMatrix = AdjacencyMatrix.CreateAdjMatrix(Graph);
            while (AddedNodes.Count() < Graph.Vertices.Count())
            {
                Dijkstra.Run(weightMatrix, StartNode);
                var dijstraResult = Dijkstra.AlghoritmResult.Where(x => AddedNodes.All(y => y != x.TargetNodeId)).ToArray();
                Path path = NearestFinder.Run(dijstraResult);
                index++;
                result.Nodes[index] = path.Nodes[1];
                result.Value += path.Value;
                StartNode = path.Nodes[1];
                AddedNodes.Add(path.Nodes[0]);
            }
            return result;
        }

        //public Path Run()
        //{
        //    Path path = new Path
        //    {
        //        Value = 0,
        //        Nodes = new int[dijkstraResults.Length]
        //    };
        //    while(dijkstraResults.Length > 0)
        //    {
        //        Path result = FindNearest(dijkstraResults);
        //        path.Value += result.Value;

        //    }
        //}
    }
}
