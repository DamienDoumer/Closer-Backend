using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class UserDiscussions : BaseEntity
    {
        public int UserId { get; set; }
        public int DiscussionId { get; set; }
    }
}
