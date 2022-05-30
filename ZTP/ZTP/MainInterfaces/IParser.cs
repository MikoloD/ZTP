using Graphviz4Net.Dot;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Interfaces
{
    interface IParser
    {
        public DotGraph<int> Run(string path);
    }
}
