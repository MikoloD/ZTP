using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Dijsktra;

namespace ZTP.Dijsktra.Interfaces
{
    public interface IDijkstra
    {
        public DijkstraResult[] AlghoritmResult { get; set; }
        public void Run(int[,] adjacencyMatrix, int startVertex);
    }

}
