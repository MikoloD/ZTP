using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using ZTP.TSPAlghoritms.Interfaces;

namespace ZTP.ParallelTSPAlghoritms
{
    public class ParallelSafePath : IPath
    {
        private object _valueLock = new object();
        private long _value;
        public long Value
        {
            get
            {
                lock (_valueLock)
                {
                    return _value;
                }
            }
            set
            {
                lock (_valueLock)
                {
                    _value = value;
                }
            }
        }
        public List<int> Nodes { get; set; } = new List<int>();
        public ConcurrentBag<Node> Vercites { get; set; } = new ConcurrentBag<Node>();

        public ParallelSafePath()
        {

        }
    }
}
