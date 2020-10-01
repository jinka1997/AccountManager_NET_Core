using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class MAccountType
    {
        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public int SortOrder { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
