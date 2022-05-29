using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    public  interface IPath
    {
        public IEnumerable<int> Nodes { get; set; }
        public long Value { get; set; }
    }
}
