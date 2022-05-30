using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;

namespace ZTP.TSPAlghoritms
{
    public class Path : IPath
    {
        public IEnumerable<int> Nodes { get; set; } = new List<int>();
        public long Value { get; set; }
    }
}
