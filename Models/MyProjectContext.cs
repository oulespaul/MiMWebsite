using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMWebsite.Models
{
    public class MyProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=database/MimDB.db");
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<ItemModel> Item { get; set; }
        public DbSet<TransactionModel> Transaction { get; set; }
        public DbSet<imageProductModel> imageProduct { get; set; }
        public DbSet<historyModel> history { get; set; }

    }
}
