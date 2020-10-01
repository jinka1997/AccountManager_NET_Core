using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class MUserAccount
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTimeOffset? RegisteredDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public int? VersionNo { get; set; }
    }
}
