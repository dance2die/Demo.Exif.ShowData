using System.Diagnostics;
using System.Web.Mvc;

namespace Demo.Exif.ShowData.Web.Filters
{
	public class ProfileResultAttribute : FilterAttribute, IResultFilter
	{
		private Stopwatch _timer;

		public void OnResultExecuting(ResultExecutingContext filterContext)
		{
			_timer = Stopwatch.StartNew();
		}

		public void OnResultExecuted(ResultExecutedContext filterContext)
		{
			_timer.Stop();
			if (filterContext.Exception != null) return;

			string data = string.Format(
				"<div>Result elapsed time: {0:F6}</div>", _timer.Elapsed.TotalSeconds);
			filterContext.HttpContext.Response.Write(data);
		}
	}
}