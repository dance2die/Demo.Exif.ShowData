using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Drawing;

namespace Demo.Exif.ShowData.Web.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			var files = GetFiles();
			Dictionary<string, ExifNET.Exif> exifs = new Dictionary<string, ExifNET.Exif>();
			foreach (var file in files)
			{
				var image = Image.FromFile(file);
				exifs.Add(file, new ExifNET.Exif(image.PropertyItems));
			}

			return View(exifs);
		}

		private IEnumerable<string> GetFiles()
		{
			const string dir = @"~\Content";
			const string searchPattern = "*.jpg";

			string path = Server.MapPath(dir);
			return Directory.EnumerateFiles(path, searchPattern);
		}
	}
}