using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP
{
    public class GraphRequest
    {
        public int StartingNode { get; set; }
        public string Path { get; set; }
        public GraphRequest()
        {

        }
        public GraphRequest(int startingNode, string path)
        {
            StartingNode = startingNode;
            Path = path;
        }
    }
}
