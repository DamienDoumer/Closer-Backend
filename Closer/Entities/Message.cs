using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Message : BaseEntity
    {
        public string InRespondToMessageID { get; set; }
        public string UserId { get; set; }
        public string DiscussionId { get; set; }
        public string Text { get; set; }
    }
}
