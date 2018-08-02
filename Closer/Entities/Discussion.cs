using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Discussion : BaseEntity
    {
        public string Title { get; set; }
        //public IEnumerable<string> MessagesIds { get; set; }
        //public IEnumerable<string> UserIds { get; set; }
    }
}
