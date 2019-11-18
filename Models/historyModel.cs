using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Models
{
	public class historyModel
	{
		public int id { get; set; }
		public int mimpin { get; set; }
		public string price { get; set; }
		public int item { get; set; }
        public string datetime { get; set; }
        public string buyer { get; set; }
        public string seller { get; set; }
	}
}
