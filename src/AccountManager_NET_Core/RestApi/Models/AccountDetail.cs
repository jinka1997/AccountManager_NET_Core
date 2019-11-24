using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    [Table("t_account_detail")]
    public class AccountDetail
    {
        [Key]
        [Column("id")]
        public long Id { set; get; }

        [Column("user_id")]
        public int UserId { set; get; }

        [Column("settlement_day")]
        public DateTime SettlementDay { set; get; }

        
        [Column("item_number")]
        public int ItemNumber { set; get; }

        [Column("account_type_id")]
        public int AccountTypeId { set; get;}

        [Column("expense_or_revenue")]
        public string ExpenseOrRevenue { set; get; }

        [Column("amount")]
        public int Amount { set; get; }

        [Column("remarks")]
        public string Remarks { set; get; }

        [Column("book_id")]
        public int BookId { set; get; }

        [Column("create_date")]
        public DateTimeOffset CreateDate { set; get; }

        [Column("update_time")]
        public DateTimeOffset UpdateTime { set; get; }
        
        [Column("version_no")]
        public int VersionNo { set; get; }
    }
}
