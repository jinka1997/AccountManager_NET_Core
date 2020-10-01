using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RestApi.Models;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

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

        //public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] {
        //    new DebugLoggerProvider((category, level)
        //        => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
        //    });

        public static readonly LoggerFactory LoggerFactory;
        public DbSet<AccountDetail> AccountDetails { set; get; }
        public DbSet<AccountType> AccountTypes { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasKey(c => new { c.UserId, c.AccountTypeId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }
    }
}
