using System.Diagnostics;
using System.Web.Mvc;

namespace Algorithms.UI.Filters
{
    public class ErrorLoggingAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Trace.TraceError(filterContext.Exception.Message);
            Trace.TraceError(filterContext.Exception.StackTrace);
            if (filterContext.Exception.InnerException != null)
            {
                Trace.TraceError("Inner exception:");
                Trace.TraceError(filterContext.Exception.InnerException.Message);
                if (!string.IsNullOrEmpty(filterContext.Exception.InnerException.StackTrace))
                {
                    Trace.TraceError(filterContext.Exception.InnerException.StackTrace);
                }
            }
            base.OnException(filterContext);
        }
    }
}