using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Controllers
{
    [Route("transaction")]
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



        private async Task<IActionResult> Create(int itemId, int seller, int amountTotal)
        {
            Random rnd = new Random();
            int mimpin = rnd.Next(100000, 999999);
            DateTime aDate = DateTime.Now;
            var checkMimPin = db.Transaction.Where(t => t.id == mimpin).FirstOrDefault();
            if (checkMimPin == null)
            {
                db.Transaction.Add(new TransactionModel
                {
                    id = mimpin,
                    ItemID = itemId,
                    TrxStatus = "created",
                    Seller = seller,
                    AmountTotal = amountTotal,
                    Created = aDate.ToString("MM/dd/yyyy")
                });
                await db.SaveChangesAsync();
                return Ok(new
                {
                    message = "Insert success",
                    mimpin = mimpin
                });
            }
            return NotFound();
        }

        [HttpPost("createTrx")]
        public IActionResult saveProduct([FromBody]transactionWithItemModel p)
        {
            var item = new ItemModel
            {
                ItemName = p.ItemName,
                ItemPrice = p.ItemPrice,
                ItemDetail = p.ItemDetail,
            };
            db.Item.Add(item);

            db.SaveChanges();
            int id = item.id;

            // var images = p.ItemImage.Substring(0, p.ItemImage.Length-2);
            // var imageArray = images.Split(',');
            for (var i = 0; i < p.ItemImage.Length; i++)
            {
                var itemImage = new imageProductModel
                {
                    productId = id,
                    imageText = p.ItemImage[i]
                };
                db.imageProduct.Add(itemImage);
            }

            db.SaveChanges();

            var createTrx = Create(id, p.Seller, p.ItemPrice);
            try
            {
                return Ok(createTrx);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("getTransactionById")]
        public IActionResult getTransactionById([FromQuery]int id)
        {
            var transaction = (from t in db.Transaction
                               join i in db.Item on t.ItemID equals i.id
                               join p in db.imageProduct on i.id equals p.productId
                               where t.id == id
                               select new { t, i, p }).ToList();
            if (transaction != null)
            {
                return Ok(transaction);
            }
            return NotFound();
        }

        [HttpGet("getTransactionByUserId")]
        public IActionResult getTransactionByUserId([FromQuery]int userId)
        {
            var seller = (from t in db.Transaction
                          join i in db.Item on t.ItemID equals i.id
                          where t.Seller == userId
                          select new
                          {
                              ItemName = i.ItemName,
                              Price = i.ItemPrice,
                              photo = (from it in db.Item join p in db.imageProduct on it.id equals p.productId select p.imageText).FirstOrDefault(),
                              date = t.Created
                          }).ToList();
            var buyer = (from t in db.Transaction
                          join i in db.Item on t.ItemID equals i.id
                          where t.Buyer == userId
                          select new
                          {
                              ItemName = i.ItemName,
                              Price = i.ItemPrice,
                              photo = (from it in db.Item join p in db.imageProduct on it.id equals p.productId select p.imageText).FirstOrDefault(),
                              date = t.Created
                          }).ToList();

            if(seller.Count == 0 && buyer.Count == 0)
                return NoContent();

            return Ok(new {
                seller = seller,
                buyer = buyer
            });

        }
    }
}