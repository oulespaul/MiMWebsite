using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Controllers
{
	public class RedCatController : Controller
	{
		// GET: /<controller>/
		public IActionResult Index()
		{
			var db = new MyProjectContext();
			var RedCat = db.RedCat.ToList();
			return View(RedCat);
		}
		public string Welcome(string name, string id)
		{
			return $"hello {name} ,your id {id}";
		}
	}
}
