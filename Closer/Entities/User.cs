using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> DiscussionIds { get; set; }
    }
}
