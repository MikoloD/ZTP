using Graphviz4Net.Dot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP.Interfaces;

namespace ZTP
{
    class ParallelTSP : IParallelTSP
    {
        private readonly IAdjacencyMatrix _adjacencyMatrix;
        private readonly IDijkstra _dijkstra;
        private readonly INearestFinder _nearestFinder;
        public ConcurrentBag<int> AddedNodes { get; set; } = new ConcurrentBag<int>();
        public ConcurrentBag<ConcurrentBag<int>> WeightMatrix { get; set; } = new ConcurrentBag<ConcurrentBag<int>>();
        public ParallelTSP(IAdjacencyMatrix adjacencyMatrix, IDijkstra dijkstra, INearestFinder nearestFinder)
        {

            _adjacencyMatrix = adjacencyMatrix;
            _dijkstra = dijkstra;
            _nearestFinder = nearestFinder;

        }
        public Path Run(int StartNode, DotGraph<int> Graph)
        {
            int graphSize = Graph.Vertices.Count();
            Path result = new Path
            {
                Value = 0,
                Nodes = new int[graphSize + 1]
            };
            result.Nodes[0] = StartNode;
            int[,] weightMatrix = _adjacencyMatrix.CreateAdjMatrix(Graph);
            Parallel.For(0, graphSize, i =>
            {
                _dijkstra.Run(weightMatrix, StartNode);
                var dijstraResult = _dijkstra.AlghoritmResult.Where(x => AddedNodes.All(y => y != x.TargetNodeId)).ToArray();
                Path path = _nearestFinder.Run(dijstraResult);
                result.Nodes[i + 1] = path.Nodes[1];
                result.Value += path.Value;
                StartNode = path.Nodes[1];
                AddedNodes.Add(path.Nodes[0]);
            });
            _dijkstra.Run(weightMatrix, StartNode);
            result.Nodes[graphSize] = result.Nodes[0];
            result.Value += _dijkstra.AlghoritmResult[result.Nodes[0]].Value;
            return result;
        }
    }
}
