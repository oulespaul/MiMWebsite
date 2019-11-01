using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Controllers
{
	[Route("User")]
	public class RedCatController : Controller
	{
		MyProjectContext db = new MyProjectContext();
		// GET: /<controller>/
		[HttpGet]
		public IActionResult Index()
		{
			//var db = new MyProjectContext();
			var RedCat = db.User.ToList();
			return View(RedCat);
		}
		[Route("welcome")]
		public string Welcome(string name, string id)
		{
			return $"hello {name} ,your id {id}";
		}
		[HttpGet("create")]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost("create")]
		public async Task<IActionResult> Create([FromBody]UserModel model)
		{
		
				db.User.Add(model);
				await db.SaveChangesAsync();
				return Ok(new
				{
					message = "Insert success"
				});
				
			
		}
	}
}
