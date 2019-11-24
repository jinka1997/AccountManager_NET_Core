using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {
            //var instance = SqlProviderServices.Instance;
            //Database.SetInitializer<MyDbContext>(null);
        }
        public MyDbContext()
        {

        }
        public DbSet<AccountDetail> AccountDetails { set; get; }
        public DbSet<AccountType> AccountTypes { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasKey(c => new { c.UserId, c.AccountTypeId });
        }
    }
}
