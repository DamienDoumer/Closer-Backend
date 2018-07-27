using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string Moniker { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
