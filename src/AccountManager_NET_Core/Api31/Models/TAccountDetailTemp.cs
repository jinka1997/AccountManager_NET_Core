using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class TAccountDetailTemp
    {
        public long Id { get; set; }
        public DateTime? SettlementDay { get; set; }
        public int? ItemNumber { get; set; }
        public int? AccountTypeId { get; set; }
        public string ExpenseOrRevenue { get; set; }
        public int? Amount { get; set; }
        public string Remarks { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
