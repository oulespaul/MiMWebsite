using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Controllers
{
	public class ItemController : Controller
	{
		// GET: /<controller>/
		public IActionResult Index()
		{
			var db = new MyProjectContext();
			var Item = db.Item.ToList();
			return View(Item);
		}
		public string Welcome(string name, string id)
		{
			return $"hello {name} ,your id {id}";
		}
	}
}
