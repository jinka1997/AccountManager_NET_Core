using System;
using System.Collections.Generic;

namespace Api31.Models
{
    public partial class MAuthentication
    {
        public string ApiKey { get; set; }
        public long AccessCounter { get; set; }
        public DateTimeOffset? LastAccessTime { get; set; }
    }
}
