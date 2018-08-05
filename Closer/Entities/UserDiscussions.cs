using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    /// <summary>
    /// This entity is present just to establish 
    /// Relation between user and discussions they belong to.
    /// </summary>
    public class UserDiscussion : BaseEntity
    {
        public int UserId { get; set; }
        public int DiscussionId { get; set; }
    }
}
