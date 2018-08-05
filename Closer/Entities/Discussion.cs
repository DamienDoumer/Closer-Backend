using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Discussion : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// The user who created this discussion
        /// </summary>
        public int DiscussionUserCreatorId { get; set; }
    }
}
