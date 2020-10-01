using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class VAccountDetails
    {
        public DateTime? SettlementDay { get; set; }
        public int? ItemNumber { get; set; }
        public int? AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public string ExpenseOrRevenue { get; set; }
        public int? Amount { get; set; }
        public string Remarks { get; set; }
    }
}
