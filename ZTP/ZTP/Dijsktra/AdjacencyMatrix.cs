using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ZTP.Dijsktra.Interfaces;

namespace ZTP.Dijsktra
{
    public class AdjacencyMatrix : IAdjacencyMatrix
    {
        public int[,] CreateAdjMatrix(DotGraph<int> Graph)
        {
            int size = Graph.Vertices.Count();
            int[,] adjMatrix = new int[size, size];
            foreach (var item in Graph.VerticesEdges)
            {
                int x = item.Source.Id;
                int y = item.Destination.Id;
                adjMatrix[x, y] = (int)item.Weight;
                adjMatrix[y, x] = (int)item.Weight;
            }
            return adjMatrix;
        }
    }
}
