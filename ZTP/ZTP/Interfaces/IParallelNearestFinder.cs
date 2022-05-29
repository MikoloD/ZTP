using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    public interface IParallelNearestFinder
    {
        public ParallelSafePath Run(DijkstraResult[] dijkstraResults);
    }
}
