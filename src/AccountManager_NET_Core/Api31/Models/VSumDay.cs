using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class VSumDay
    {
        public DateTime SettlementDay { get; set; }
        public int? Expense { get; set; }
        public int? Revenue { get; set; }
        public int? Cnt { get; set; }
    }
}
