using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Handlers.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(GraphRequest request);
    }
}
