using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    interface INearestFinder
    {
        public Path Run(DijkstraResult[] dijkstraResults);
    }
}
