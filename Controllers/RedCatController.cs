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
		public async Task<IActionResult> Create(UserModel model, IFormFile fileUpload)
		{
			string pathImgUser = "/image/user/";
			string pathSave = $"wwwroot{pathImgUser}";
			if (!Directory.Exists(pathSave))
			{
				Directory.CreateDirectory(pathSave);
			}
			if (fileUpload != null)
			{
				string extFile = Path.GetExtension(fileUpload.ContentDisposition);

				var path = Path.Combine(Directory.GetCurrentDirectory());

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await fileUpload.CopyToAsync(stream);
				}
			}
				db.User.Add(model);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
				
			
		}
	}
}
