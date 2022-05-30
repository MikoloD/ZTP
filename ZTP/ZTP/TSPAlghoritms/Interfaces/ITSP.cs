using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;

namespace ZTP.TSPAlghoritms.Interfaces
{
    public interface ITSP
    {
        public IPath Run(int StartNode, DotGraph<int> Graph);
    }
}
