using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Demo.Exif.ShowData.Web.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			var files = GetFiles();
			return View(files);
		}

		private IEnumerable<string> GetFiles()
		{
			const string dir = @".\Content";
			const string searchPattern = "*.jpg";
			return Directory.EnumerateFiles(dir, searchPattern);
		}
	}
}