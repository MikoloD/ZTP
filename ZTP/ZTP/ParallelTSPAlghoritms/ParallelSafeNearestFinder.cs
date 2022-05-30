using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP.Dijsktra;
using ZTP.ParallelTSPAlghoritms.Interfaces;

namespace ZTP.ParallelTSPAlghoritms
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

                    edge.Vercites.Add(new Node(dijkstraResults[i].SourceNodeId, i + 1));
                    edge.Vercites.Add(new Node(dijkstraResults[i].TargetNodeId, i));
                }
            }
            var query = edge.Vercites.OrderByDescending(x => x.Order).Take(2).ToList();
            edge.Vercites.Clear();
            foreach (var item in query)
            {
                edge.Vercites.Add(item);
            }
            return edge;
        }
    }
}
