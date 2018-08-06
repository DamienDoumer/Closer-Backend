using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Message : BaseEntity
    {
        public int MessageUserId { get; set; }
        public int MessageDiscussionId { get; set; }
        public string InRespondToMessageID { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Message this responds to.
        /// </summary>
        [NotMapped]
        public Message RespondMessage { get; set; }
        [NotMapped]
        public User Sender { get; set; }
    }
}
