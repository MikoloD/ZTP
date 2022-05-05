using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;

namespace ZTP
{
    public class NearestFinder : INearestFinder
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
                if (edge.Value > dijkstraResults[i].Value && dijkstraResults[i].Value > 0)
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
