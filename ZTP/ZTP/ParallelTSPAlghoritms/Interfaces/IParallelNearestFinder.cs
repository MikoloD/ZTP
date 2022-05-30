using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Dijsktra;
using ZTP.ParallelTSPAlghoritms;

namespace ZTP.ParallelTSPAlghoritms.Interfaces
{
    public interface IParallelNearestFinder
    {
        public ParallelSafePath Run(DijkstraResult[] dijkstraResults);
    }
}
