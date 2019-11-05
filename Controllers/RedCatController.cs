using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiMWebsite.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

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
            var salt = genSalt();
            var hashed = hashPassword(model.Password, salt) + ":" + Convert.ToBase64String(salt);
            db.User.Add(new UserModel
            {
                AcNo = model.AcNo,
                AcName = model.AcName,
                Tel = model.Tel,
                Password = hashed,
            });
            await db.SaveChangesAsync();
            return Ok(new
            {
                message = "Insert success"
            });
        }

        private byte[] genSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        private string hashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserModel user)
        {
            var username = user.Tel;
            var password = user.Password;
            var item = db.User.FirstOrDefault(i => i.Tel == username);
            if (item != null)
            {
                var passwordWithSalt = item.Password.Split(':');
                var hashed = hashPassword(password, Convert.FromBase64String(passwordWithSalt[1]));
                if (hashed == passwordWithSalt[0])
                {
                    return Ok(new
                    {
                        message = "Login Success!",
                        authToken = username
                    });
                }
            }
            return NotFound("Login Failed!");
        }

        [HttpGet("getDetail")]
        public IActionResult getUserDetail([FromQuery]string username)
        {
            var currentUser = db.User.FirstOrDefault(i => i.Tel == username);
            if (currentUser != null)
                return Ok(currentUser);

            return NotFound();
        }

        [HttpPost("deleteUser")]
        public IActionResult deleteUser([FromQuery]int id)
        {
            UserModel user = db.User.Where(a => a.id == id).FirstOrDefault();

            if (user != null)
            {
                db.User.Remove(user);
                db.SaveChanges();
                return Ok("Delete Success!");
            }

            return NotFound();
        }
    }
}
