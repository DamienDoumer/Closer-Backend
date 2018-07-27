using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Discussion : BaseEntity
    {
        public string Title { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> Users { get; set; }
    }
}
