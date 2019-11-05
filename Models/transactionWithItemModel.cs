using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Models
{
	public class transactionWithItemModel
	{
		
		public string ItemName { get; set; }
		public int ItemPrice { get; set; }
		public string ItemDetail { get; set; }
		public string[] ItemImage { get; set; }
		public int Seller { get; set; }
		
	}
}
