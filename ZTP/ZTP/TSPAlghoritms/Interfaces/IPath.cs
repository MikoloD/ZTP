using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.TSPAlghoritms.Interfaces
{
    public interface IPath
    {
        public List<int> Nodes { get; set; }
        public long Value { get; set; }
    }
}
