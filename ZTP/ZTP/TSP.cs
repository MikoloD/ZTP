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
        private readonly IAdjacencyMatrix _adjacencyMatrix;
        private readonly IDijkstra _dijkstra;
        private readonly INearestFinder _nearestFinder;
        public List<int> AddedNodes { get; set; } = new List<int>();
        public TSP(IAdjacencyMatrix adjacencyMatrix,IDijkstra dijkstra,INearestFinder nearestFinder)
        {

            _adjacencyMatrix = adjacencyMatrix;
            _dijkstra = dijkstra;
            _nearestFinder = nearestFinder;

        }
        public Path Run(int StartNode,DotGraph<int> Graph)
        {
            int graphSize = Graph.Vertices.Count();
            Path result = new Path
            {
                Value = 0,
                Nodes = new int[graphSize + 1]
            };
            result.Nodes[0] = StartNode;

            int[,] weightMatrix = _adjacencyMatrix.CreateAdjMatrix(Graph);
            for (int i = 0; i < graphSize; i++)
            {
                _dijkstra.Run(weightMatrix, StartNode);
                var dijstraResult = _dijkstra.AlghoritmResult.Where(x => AddedNodes.All(y => y != x.TargetNodeId)).ToArray();
                Path path = _nearestFinder.Run(dijstraResult);
                result.Nodes[i+1] = path.Nodes[1];
                result.Value += path.Value;
                StartNode = path.Nodes[1];
                AddedNodes.Add(path.Nodes[0]);
            }        
            _dijkstra.Run(weightMatrix, StartNode);
            result.Nodes[graphSize] = result.Nodes[0];
            result.Value += _dijkstra.AlghoritmResult[result.Nodes[0]].Value;
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
