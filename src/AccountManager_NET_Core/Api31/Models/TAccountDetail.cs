using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class TAccountDetail
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public DateTime SettlementDay { get; set; }
        public int ItemNumber { get; set; }
        public int AccountTypeId { get; set; }
        public string ExpenseOrRevenue { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateTime { get; set; }
        public int VersionNo { get; set; }
    }
}
