using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    interface ITSP
    {
        public Path Run(int StartNode, DotGraph<int> Graph);
    }
}
