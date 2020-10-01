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

        public virtual DbSet<MAccountBook> MAccountBook { get; set; }
        public virtual DbSet<MAccountType> MAccountType { get; set; }
        public virtual DbSet<MAuthentication> MAuthentication { get; set; }
        public virtual DbSet<MUserAccount> MUserAccount { get; set; }
        public virtual DbSet<TAccountDetail> TAccountDetail { get; set; }
        public virtual DbSet<TAccountDetailTemp> TAccountDetailTemp { get; set; }
        public virtual DbSet<VAccountDetails> VAccountDetails { get; set; }
        public virtual DbSet<VSumDay> VSumDay { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MAccountBook>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId });

                entity.ToTable("m_account_book");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasColumnName("book_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            });

            modelBuilder.Entity<MAccountType>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AccountTypeId });

                entity.ToTable("m_account_type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.AccountTypeName)
                    .IsRequired()
                    .HasColumnName("account_type_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            });

            modelBuilder.Entity<MAuthentication>(entity =>
            {
                entity.HasKey(e => e.ApiKey);

                entity.ToTable("m_authentication");

                entity.Property(e => e.ApiKey)
                    .HasColumnName("api_key")
                    .HasMaxLength(255);

                entity.Property(e => e.AccessCounter).HasColumnName("access_counter");

                entity.Property(e => e.LastAccessTime).HasColumnName("last_access_time");
            });

            modelBuilder.Entity<MUserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("m_user_account");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("password_salt")
                    .HasMaxLength(255);

                entity.Property(e => e.RegisteredDate).HasColumnName("registered_date");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.VersionNo).HasColumnName("version_no");
            });

            modelBuilder.Entity<TAccountDetail>(entity =>
            {
                entity.ToTable("t_account_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.ExpenseOrRevenue)
                    .IsRequired()
                    .HasColumnName("expense_or_revenue")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ItemNumber).HasColumnName("item_number");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.SettlementDay)
                    .HasColumnName("settlement_day")
                    .HasColumnType("date");

                entity.Property(e => e.UpdateTime).HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VersionNo).HasColumnName("version_no");
            });

            modelBuilder.Entity<TAccountDetailTemp>(entity =>
            {
                entity.ToTable("t_account_detail_temp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("create_user")
                    .HasMaxLength(50);

                entity.Property(e => e.ExpenseOrRevenue)
                    .HasColumnName("expense_or_revenue")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ItemNumber).HasColumnName("item_number");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.SettlementDay)
                    .HasColumnName("settlement_day")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("update_user")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VAccountDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_account_details");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.AccountTypeName)
                    .HasColumnName("account_type_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ExpenseOrRevenue)
                    .HasColumnName("expense_or_revenue")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ItemNumber).HasColumnName("item_number");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.SettlementDay)
                    .HasColumnName("settlement_day")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<VSumDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_sum_day");

                entity.Property(e => e.Cnt).HasColumnName("cnt");

                entity.Property(e => e.Expense).HasColumnName("expense");

                entity.Property(e => e.Revenue).HasColumnName("revenue");

                entity.Property(e => e.SettlementDay)
                    .HasColumnName("settlement_day")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
