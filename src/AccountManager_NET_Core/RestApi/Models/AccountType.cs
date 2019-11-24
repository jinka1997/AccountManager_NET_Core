using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RestApi.Models
{
    [Table("m_account_type")]
    public class AccountType
    {
        [Column("user_id")]
        public int UserId { set; get; }

        [Column("account_type_id")]
        public int AccountTypeId { set; get; }

        [Column("account_type_name")]
        public string AccountTypeName { set; get; }

        [Column("sort_order")]
        public int SortOrder { set; get; }

        [Column("create_date")]
        public DateTimeOffset CreateDate { set; get; }

    }
}
