using CashMachine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CashMachine.Dal
{
    public class CashMachineDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Movement>().ToTable("Movement");
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}