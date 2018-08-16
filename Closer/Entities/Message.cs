using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Message : BaseEntity
    {
        public int SenderId { get; set; }
        public int DiscussionId { get; set; }
        public string RespondToMessageId { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Message this responds to.
        /// </summary>
        [NotMapped]
        public Message RespondToMessage { get; set; }
        [NotMapped]
        public User Sender { get; set; }
    }
}
