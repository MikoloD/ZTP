﻿using System;
using System.Collections.Generic;
using System.Text;
using ZTP.Handlers.Interfaces;

namespace ZTP.Handlers
{
    public class HandlerBuilder : AbstractHandler,IHandlerBuilder
    {
        public HandlerBuilder(ISmallGraphHandler smallGraphHandler)
        {
            this.SetNext(smallGraphHandler);

        }
    }
}
