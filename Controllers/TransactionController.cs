using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;
using Omise;
using Omise.Models;


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

            // var db = new MyProjectContext();
            // var Transaction = db.Transaction.ToList();
            // return View(Transaction);
            var list = new List<object>();
            for (var i = 0;i<5;i++)
            {
                var name = new {
                    test = "Ou",
                    test2 = "Ice"
                }; 
                list.Add(name);
            }
            return Ok(list.ToArray());
        }
        public string Welcome(string name, string id)
        {
            return $"hello {name} ,your id {id}";
        }



        private async Task<IActionResult> Create(int itemId, string seller, string amountTotal)
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
                    TrxStatus = "รอผู้ซื้อ",
                    Seller = seller,
                    Buyer = "0",
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
                               select new { t, i, p, u = (from u in db.User where u.Tel == t.Seller select u.Tel).FirstOrDefault() }).ToList();
            if (transaction != null)
            {
                return Ok(transaction);
            }
            return NotFound();
        }

        [HttpGet("getTransactionByUserId")]
        public IActionResult getTransactionByUserId([FromQuery]string userId)
        {
            var seller = (from t in db.Transaction
                          join i in db.Item on t.ItemID equals i.id
                          where t.Seller == userId
                          select new
                          {
                              ItemName = i.ItemName,
                              Price = i.ItemPrice,
                              photo = (from p in db.imageProduct where p.productId == i.id select p.imageText).FirstOrDefault(),
                              date = t.Created,
                              mimpin = t.id,
                              trxStatus = t.TrxStatus
                          }).ToList();
            var buyer = (from t in db.Transaction
                         join i in db.Item on t.ItemID equals i.id
                         where t.Buyer == userId
                         select new
                         {
                             ItemName = i.ItemName,
                             Price = i.ItemPrice,
                             photo = (from p in db.imageProduct where p.productId == i.id select p.imageText).FirstOrDefault(),
                             date = t.Created,
                             mimpin = t.id,
                             trxStatus = t.TrxStatus
                         }).ToList();

            var history = (from h in db.history
                           join i in db.Item on h.item equals i.id
                           where h.buyer == userId || h.seller == userId
                           select new
                           {
                               h,
                               i,
                               photo = (from p in db.imageProduct where p.productId == i.id select p.imageText).FirstOrDefault()
                           }).ToList();

            if (seller.Count == 0 && buyer.Count == 0)
                return NoContent();

            return Ok(new
            {
                seller = seller,
                buyer = buyer,
                history = history
            });

        }

        [HttpPost("updateBuyer")]
        public IActionResult updateBuyer([FromBody]TransactionModel trx)
        {
            var rowTrx = (from t in db.Transaction
                          where t.id == trx.id
                          select t).FirstOrDefault();

            if (rowTrx.Buyer == trx.Buyer)
            {
                return Ok("You're Buyer");
            }
            else if (rowTrx.Seller == trx.Buyer)
            {
                return Ok("You're Seller");
            }
            else if (rowTrx.Buyer == "0")
            {
                rowTrx.Buyer = trx.Buyer;
                rowTrx.TrxStatus = "ผู้ใช้เข้าห้องซื้อขายแล้ว";
                db.SaveChanges();
                return Ok("updated");
            }

            return NotFound("already used");
        }

        [HttpPost("middleware")]
        public IActionResult middleware([FromBody] TransactionModel trx)
        {
            var rowTrx = (from t in db.Transaction
                          where t.id == trx.id
                          select t).FirstOrDefault();
            if (rowTrx.Buyer == trx.Buyer || rowTrx.Seller == trx.Buyer)
            {
                return Ok("passed");
            }
            else
            {
                return NotFound("rejected");
            }
        }


        [HttpPost("omise")]
        public async Task<IActionResult> omise([FromBody]omiseModel o)
        {
            Console.WriteLine(o);
            var client = new Client("pkey_test_5gyy5c8qvcpfbn6mfut", "skey_test_5h22fokvom2l9ltjvj0");

            // var token = GetToken();
            var customer = await client.Customers.Create(new CreateCustomerRequest
            {
                Email = "customers_email@example.com",
                Description = "customer#1234",
                Card = o.token
            });

            // Print("created customer: {0}", customer.Id);

            var charge = await client.Charges.Create(new CreateChargeRequest
            {
                Customer = customer.Id,
                Amount = o.amount, // 2,000.00 THB
                Currency = "thb"
            });

            return Ok(charge.Id);
        }

        [HttpPost("updateStatus")]
        public IActionResult updateStatus([FromBody]TransactionModel trx)
        {
            var rowTrx = (from t in db.Transaction
                          where t.id == trx.id
                          select t).FirstOrDefault();
            if (rowTrx == null)
                return NotFound();

            rowTrx.TrxStatus = trx.TrxStatus;
            db.SaveChanges();
            return Ok("Updated!");
        }

        [HttpPost("pickupedItem")]
        public IActionResult pickupedItem([FromBody]pickupModel p)
        {
            DateTime aDate = DateTime.Now;
            var date = aDate.ToString("MM/dd/yyyy");

            var rowSeller = (from s in db.User
                             where s.Tel == p.seller
                             select s).FirstOrDefault();
            rowSeller.Balance += p.amount;

            var rowTrx = (from t in db.Transaction
                          where t.id == p.id
                          select t).FirstOrDefault();

            if (rowSeller == null || rowTrx == null)
                return NotFound();

            db.history.Add(new historyModel
            {
                mimpin = rowTrx.id,
                price = rowTrx.AmountTotal,
                item = rowTrx.ItemID,
                datetime = date,
                buyer = rowTrx.Buyer
            });
            db.history.Add(new historyModel
            {
                mimpin = rowTrx.id,
                price = rowTrx.AmountTotal,
                item = rowTrx.ItemID,
                datetime = date,
                seller = rowTrx.Seller
            });
            db.SaveChanges();
            db.Transaction.Remove(rowTrx);
            db.SaveChanges();

            return Ok("updated!");
        }
    }
}