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
        private readonly IParallelNearestFinder _nearestFinder;
        public ConcurrentBag<int> AddedNodes { get; set; } = new ConcurrentBag<int>();
        public ConcurrentBag<ConcurrentBag<int>> WeightMatrix { get; set; } = new ConcurrentBag<ConcurrentBag<int>>();
        public ParallelTSP(IAdjacencyMatrix adjacencyMatrix, IDijkstra dijkstra, IParallelNearestFinder nearestFinder)
        {

            _adjacencyMatrix = adjacencyMatrix;
            _dijkstra = dijkstra;
            _nearestFinder = nearestFinder;

        }
        IPath ITSP.Run(int StartNode, DotGraph<int> Graph)
        {
            int graphSize = Graph.Vertices.Count()-1;
            ParallelSafePath result = new ParallelSafePath
            {
                Value = 0
            };
            ((ConcurrentBag<int>)result.Nodes).Add(StartNode);
            int[,] weightMatrix = _adjacencyMatrix.CreateAdjMatrix(Graph);
            object loopLock = new object();
            Parallel.For(0, graphSize, i =>
            {              
                lock (loopLock)
                {
                    ParallelSafePath path = new ParallelSafePath(loopLock);
                    _dijkstra.Run(weightMatrix, StartNode);
                    var dijstraResult = _dijkstra.AlghoritmResult.Where(x => AddedNodes.All(y => y != x.TargetNodeId)).ToArray();
                    path = _nearestFinder.Run(dijstraResult);
                    var query = path.Nodes;
                    ConcurrentBag<int> road = new ConcurrentBag<int>();
                    foreach (var item in query)
                    {
                        road.Add(item);
                    }
                    int sorceNode = road.FirstOrDefault();
                    int targetNode = road.LastOrDefault();
                    ((ConcurrentBag<int>)result.Nodes).Add(targetNode);
                    result.Value += path.Value;
                    AddedNodes.Add(sorceNode);
                    StartNode = targetNode;
                }               
            });
            _dijkstra.Run(weightMatrix, StartNode);
            int startingNode = result.Nodes.LastOrDefault();
            ((ConcurrentBag<int>)result.Nodes).Add(startingNode);
            result.Value += _dijkstra.AlghoritmResult[startingNode].Value;
            return result;
        }
    }
}
