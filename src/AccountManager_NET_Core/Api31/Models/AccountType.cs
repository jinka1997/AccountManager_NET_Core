using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api31.Models
{
    [Table("m_account_type")]
    public partial class AccountType : Entity
    {
        public string AccountTypeName { get; set; }
        public int SortOrder { get; set; }

        public UserAccount UserAccount { get; private set; }
    }
}
