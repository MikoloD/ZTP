using System;
using System.Collections.Generic;
using System.Text;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.TSPAlghoritms
{
    public class Path : IPath
    {
        public List<int> Nodes { get; set; } = new List<int>();
        public long Value { get; set; }
    }
}
