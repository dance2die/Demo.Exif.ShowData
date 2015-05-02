using System.Web.Mvc;

namespace Demo.Exif.ShowData.Web.Filters
{
	public class CustomActionAttribute : FilterAttribute, IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Request.IsLocal)
				filterContext.Result = new HttpNotFoundResult("CustomActionAttribute => OnActionExecuting");
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//if (filterContext.HttpContext.Request.IsLocal)
			//	filterContext.Result = new HttpNotFoundResult("CustomActionAttribute => OnActionExecuted");
		}
	}
}