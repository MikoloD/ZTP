using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using ZTP.Interfaces;

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
        public IEnumerable<int> Nodes { get; set; } = new ConcurrentBag<int>();

        public ParallelSafePath()
        {

        }
        public ParallelSafePath(object valueLock)
        {
            _valueLock = valueLock;

        }
    }
}
