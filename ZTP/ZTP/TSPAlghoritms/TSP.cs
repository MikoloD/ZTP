using Graphviz4Net.Dot;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP.Dijsktra.Interfaces;
using ZTP.Interfaces;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.TSPAlghoritms
{
    class TSP : ITSP
    {
        private readonly IAdjacencyMatrix _adjacencyMatrix;
        private readonly IDijkstra _dijkstra;
        private readonly INearestFinder _nearestFinder;
        public List<int> AddedNodes { get; set; } = new List<int>();
        public TSP(IAdjacencyMatrix adjacencyMatrix, IDijkstra dijkstra, INearestFinder nearestFinder)
        {

            _adjacencyMatrix = adjacencyMatrix;
            _dijkstra = dijkstra;
            _nearestFinder = nearestFinder;

        }

        IPath ITSP.Run(int StartNode, DotGraph<int> Graph)
        {
            int graphSize = Graph.Vertices.Count() - 1;
            Path result = new Path
            {
                Value = 0,
            };
            result.Nodes.Add(StartNode);

            int[,] weightMatrix = _adjacencyMatrix.CreateAdjMatrix(Graph);
            for (int i = 0; i < graphSize; i++)
            {
                _dijkstra.Run(weightMatrix, StartNode);
                var dijstraResult = _dijkstra.AlghoritmResult.Where(x => AddedNodes.All(y => y != x.TargetNodeId)).ToArray();
                Path path = _nearestFinder.Run(dijstraResult);

                int sorceNode = path.Nodes.FirstOrDefault();
                int targetNode = path.Nodes.LastOrDefault();
                result.Nodes.Add(targetNode);
                result.Value += path.Value;
                StartNode = targetNode;
                AddedNodes.Add(sorceNode);
            }
            _dijkstra.Run(weightMatrix, StartNode);
            result.Nodes.Add(result.Nodes.FirstOrDefault());
            result.Value += _dijkstra.AlghoritmResult[result.Nodes.FirstOrDefault()].Value;
            return result;
        }
    }
}
