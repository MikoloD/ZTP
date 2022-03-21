using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;

namespace ZTP
{
    class TSP : ITSP
    {
        private readonly IDijkstra _dijkstra;
        public TSP(IDijkstra dijkstra)
        {
            _dijkstra = dijkstra;
        }

        //public Path Run()
        //{
        //    Path path = new Path
        //    {
        //        Value = 0,
        //        Nodes = new int[dijkstraResults.Length]
        //    };
        //    while(dijkstraResults.Length > 0)
        //    {
        //        Path result = FindNearest(dijkstraResults);
        //        path.Value += result.Value;

        //    }
        //}
    }
}
