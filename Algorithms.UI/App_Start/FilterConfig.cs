using Algorithms.UI.Filters;
using System.Web.Mvc;

namespace Algorithms.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorLoggingAttribute());
        }
    }
}
