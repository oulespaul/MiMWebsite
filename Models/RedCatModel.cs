using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Models
{
	public class RedCatModel
	{
		public int id { get; set; }
		public string title { get; set; }
		public string coverImg { get; set; }
		public string releaseDate { get; set; }
		public string genre { get; set; }
		public int duration { get; set; }
		public string createDate { get; set; }
		public string modifyDate { get; set; }
	}
}
