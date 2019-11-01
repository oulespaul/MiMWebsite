using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Controllers
{
	public class TransactionController : Controller
	{
		MyProjectContext db = new MyProjectContext();
		// GET: /<controller>/
		[HttpGet]
		public IActionResult Index()
		{

			var db = new MyProjectContext();
			var Transaction = db.Transaction.ToList();
			return View(Transaction);
		}
		public string Welcome(string name, string id)
		{
			return $"hello {name} ,your id {id}";
		}


		[HttpPost("transaction")]
		public async Task<IActionResult> Create([FromBody]TransactionModel model)
		{

			db.Transaction.Add(model);
			await db.SaveChangesAsync();
			return Ok(new
			{
				message = "Insert success"
			});
		}
	}
}