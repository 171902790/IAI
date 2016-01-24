using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IAI.Exceptions;

namespace IAI.Web.Tools
{
    public class HandleLogicErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            if (context.Exception is LogicErrorException)
            {
                var exception = context.Exception as LogicErrorException;
                context.Result=new HttpStatusCodeResult(500,exception.ErrorMessage);
            }
            context.Result=new HttpNotFoundResult();
        }
    }
}