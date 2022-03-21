using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP
{
    class NearestFinder
    {
        public Path Run(DijkstraResult[] dijkstraResults)
        {
            Path edge = new Path
            {
                Value = int.MaxValue,
                Nodes = new int[2]
            };
            for (int i = 0; i < dijkstraResults.Length; i++)
            {
                if (edge.Value > dijkstraResults[i].Value)
                {
                    edge.Value = dijkstraResults[i].Value;
                    edge.Nodes[0] = dijkstraResults[i].SourceNodeId;
                    edge.Nodes[1] = dijkstraResults[i].TargetNodeId;
                }
            }
            return edge;
        }
    }
}
