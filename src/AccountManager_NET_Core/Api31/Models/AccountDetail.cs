using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Api31.Models.Enumeration;

namespace Api31.Models
{
    [Table("t_account_detail")]
    public partial class AccountDetail : Entity
    {
        public DateTimeOffset SettlementDay { get; set; }
        public int ItemNumber { get; set; }
        public IncomeOrOutgo IncomeOrOutgo { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }

        public AccountBook AccountBook { get; private set; }
        public AccountType AccountType { get; private set; }
        public UserAccount UserAccount { get; private set; }
    }
}
