using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
using Northwind.Web.Models;
using System.Diagnostics;

namespace Northwind.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private NorthwindContext _db;

		public HomeController(ILogger<HomeController> logger, NorthwindContext db)
		{
			_logger = logger;
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			try
			{
                ViewData.Model = await _db.Employees.ToListAsync();
                return View();
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
