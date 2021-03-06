using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP.Dijsktra;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.TSPAlghoritms
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
                    edge.Nodes.Clear();
                    edge.Nodes.Add(dijkstraResults[i].SourceNodeId);
                    edge.Nodes.Add(dijkstraResults[i].TargetNodeId);
                }
            }
            return edge;
        }
    }
}
