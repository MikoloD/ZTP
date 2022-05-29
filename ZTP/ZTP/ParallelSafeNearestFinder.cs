using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP.Interfaces;

namespace ZTP
{
    public class ParallelSafeNearestFinder : IParallelNearestFinder
    {
        public ParallelSafePath Run(DijkstraResult[] dijkstraResults)
        {
            ParallelSafePath edge = new ParallelSafePath
            {
                Value = int.MaxValue
            };
            for (int i = 0; i < dijkstraResults.Length; i++)
            {
                if (edge.Value > dijkstraResults[i].Value && dijkstraResults[i].Value > 0)
                {
                    edge.Value = dijkstraResults[i].Value;
                    ((ConcurrentBag<int>)edge.Nodes).Add(dijkstraResults[i].SourceNodeId);
                    ((ConcurrentBag<int>)edge.Nodes).Add(dijkstraResults[i].TargetNodeId);
                }
            }
            edge.Nodes = edge.Nodes.Take(2);
            return edge;
        }
    }
}
