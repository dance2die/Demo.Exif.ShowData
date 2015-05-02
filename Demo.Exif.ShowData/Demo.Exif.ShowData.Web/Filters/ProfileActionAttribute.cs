using System.Diagnostics;
using System.Web.Mvc;

namespace Demo.Exif.ShowData.Web.Filters
{
	public class ProfileActionAttribute : FilterAttribute, IActionFilter
	{
		private Stopwatch _timer;

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			_timer = Stopwatch.StartNew();
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			_timer.Stop();
			if (filterContext.Exception != null) return;

			string data = string.Format(
				"<div>Action method elapsed time: {0:F6}</div>", _timer.Elapsed.TotalSeconds);
			filterContext.HttpContext.Response.Write(data);
		}
	}
}