using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.ParallelTSPAlghoritms
{
    public class Node
    {
        private object _nodeLock = new object();
        private int _name;
        private int _order;
        public int Name
        {
            get
            {
                lock (_nodeLock)
                {
                    return _name;
                }
            }
            set
            {
                lock (_nodeLock)
                {
                    _name = value;
                }
            }
        }
        public int Order
        {
            get
            {
                lock (_nodeLock)
                {
                    return _order;
                }
            }
            set
            {
                lock (_nodeLock)
                {
                    _order = value;
                }
            }
        }
        public Node()
        {

        }

        public Node(int name,int order)
        {
            Name = name;
            Order = order;
        }
    }
}
