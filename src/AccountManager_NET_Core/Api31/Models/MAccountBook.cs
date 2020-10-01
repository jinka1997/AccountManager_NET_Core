using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class MAccountBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int SortOrder { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
