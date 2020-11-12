using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api31.Models
{
    [Table("m_account_book")]
    public partial class AccountBook : Entity
    {
        public string BookName { get; set; }
        public int SortOrder { get; set; }

        public UserAccount UserAccount { get; private set; }

    }
}
