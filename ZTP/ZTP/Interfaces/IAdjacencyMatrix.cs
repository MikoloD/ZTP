using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    interface IAdjacencyMatrix
    {
        public int[,] CreateAdjMatrix(DotGraph<int> Graph);
    }
}
