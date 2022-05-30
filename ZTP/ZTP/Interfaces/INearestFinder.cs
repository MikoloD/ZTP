using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Dijsktra;
using ZTP.TSPAlghoritms;

namespace ZTP.Interfaces
{
    public interface INearestFinder
    {
        public Path Run(DijkstraResult[] dijkstraResults);
    }
}
