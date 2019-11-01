using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Models
{
	public class TransactionModel
	{

		public int id { get; set; }
		public int ItemID { get; set; }
		public string TrxStatus { get; set; }
		public int Seller { get; set; }
		public int Buyer { get; set; }
		public int AmountTotal { get; set; }
		public string Created { get; set; }


	}
}
