using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace NataliRecords.Filters
{
    public class SimpleActionFilters : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("actions is exucuted" + context.Controller.ToString());
        }
    }
}
