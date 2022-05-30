using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP.Handlers
{
    class SmallGraphHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Banana")
            {
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
