using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Models
{
	public class pickupModel
	{
		public string seller { get; set; }
        public int amount { get; set; }
        public int id { get; set; }
	}
}
