using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Dijsktra
{
    public class DijkstraResult
    {
        public int SourceNodeId { get; set; }
        public int TargetNodeId { get; set; }
        public int Value { get; set; }
        public List<int> Path { get; set; } = new List<int>();
    }
}
