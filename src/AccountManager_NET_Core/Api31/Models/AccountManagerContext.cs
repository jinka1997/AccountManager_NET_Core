using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api31.Models
{
    public partial class AccountManagerContext : DbContext
    {
        public AccountManagerContext()
        {
        }

        public AccountManagerContext(DbContextOptions<AccountManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountBook> AccountBooks { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Authentication> Authentications { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    }
}
