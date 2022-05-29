using System;
using System.Collections.Generic;
using System.Linq;
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
                Value = int.MaxValue
            };
            for (int i = 0; i < dijkstraResults.Length; i++)
            {
                if (edge.Value > dijkstraResults[i].Value && dijkstraResults[i].Value > 0)
                {
                    edge.Value = dijkstraResults[i].Value;
                    ((List<int>)edge.Nodes).Add(dijkstraResults[i].SourceNodeId);
                    ((List<int>)edge.Nodes).Add(dijkstraResults[i].TargetNodeId);
                }
            }
            edge.Nodes = edge.Nodes.Reverse().Take(2).Reverse();
            return edge;
        }
    }
}
