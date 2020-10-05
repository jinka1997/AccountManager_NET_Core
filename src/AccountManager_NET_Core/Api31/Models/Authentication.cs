using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api31.Models
{
    [Table("m_authentication")]
    public partial class Authentication : Entity
    {
        public string ApiKey { get; set; }
        public long AccessCounter { get; set; }
        public DateTimeOffset? LastAccessTime { get; set; }
    }
}
