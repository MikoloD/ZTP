using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    public interface IParser
    {
        public DotGraph<int> Run(string path);
    }
}
