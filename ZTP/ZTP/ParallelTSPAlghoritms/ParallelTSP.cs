using Graphviz4Net.Dot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP.Dijsktra.Interfaces;
using ZTP.Interfaces;
using ZTP.ParallelTSPAlghoritms.Interfaces;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.ParallelTSPAlghoritms
{
    class ParallelTSP : IParallelTSP
    {
        private readonly IAdjacencyMatrix _adjacencyMatrix;
        private readonly IDijkstra _dijkstra;
        private readonly IParallelNearestFinder _nearestFinder;
        public ConcurrentBag<int> AddedNodes { get; set; }
        public ParallelTSP(IAdjacencyMatrix adjacencyMatrix, IDijkstra dijkstra, IParallelNearestFinder nearestFinder)
        {

            _adjacencyMatrix = adjacencyMatrix;
            _dijkstra = dijkstra;
            _nearestFinder = nearestFinder;

        }
        IPath ITSP.Run(int StartNode, DotGraph<int> Graph)
        {
            AddedNodes = new ConcurrentBag<int>();
            int graphSize = Graph.Vertices.Count();
            ParallelSafePath result = new ParallelSafePath
            {
                Value = 0
            };
            int startingPosition = StartNode;
            result.Vercites.Add(new Node(StartNode, 0));
            int[,] weightMatrix = _adjacencyMatrix.CreateAdjMatrix(Graph);
            object loopLock = new object();
            Node sorceNode = new Node();
            Node targetNode = new Node();
            ParallelSafePath path = new ParallelSafePath();
            Parallel.For(1, graphSize, i =>
            {
                lock (loopLock)
                {
                    _dijkstra.Run(weightMatrix, StartNode);
                    var dijstraResult = _dijkstra.AlghoritmResult.Where(x => AddedNodes.All(y => y != x.TargetNodeId)).ToArray();
                    path = _nearestFinder.Run(dijstraResult);
                    sorceNode = path.Vercites.OrderByDescending(x => x.Order).FirstOrDefault();
                    targetNode = path.Vercites.OrderByDescending(x => x.Order).LastOrDefault();
                    sorceNode.Order = i;
                    targetNode.Order = i;
                    StartNode = targetNode.Name;
                }
                result.Vercites.Add(targetNode);
                result.Value += path.Value;
                AddedNodes.Add(sorceNode.Name);
            });
            _dijkstra.Run(weightMatrix, StartNode);
            result.Vercites.Add(new Node(startingPosition, graphSize + 1));
            result.Value += _dijkstra.AlghoritmResult[startingPosition].Value;
            result.Nodes = result.Vercites.OrderBy(x => x.Order).Select(x => x.Name).ToList();
            return result;
        }
    }
}
