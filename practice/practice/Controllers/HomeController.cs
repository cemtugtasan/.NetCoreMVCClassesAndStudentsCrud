using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice.Context;
using practice.Models;
using System.Diagnostics;

namespace practice.Controllers
{
	public class HomeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return View();
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