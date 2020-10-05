using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api31.Models
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        public DateTimeOffset CreateDate { get; private set; }
        public DateTimeOffset UpdateTime { get; private set; }
        public int VersionNo { get; private set; }
    }
}
