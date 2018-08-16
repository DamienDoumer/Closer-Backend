using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class MessageModel : BaseModel
    {
        public string Text { get; set; }
        public string ConversationId { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderPseudo { get; set; }
        public string SenderEmail { get; set; }
        public string RespondToMessageText { get; set; }
        public string RespondToMessageId { get; set; }

        public MessageModel RespondToMessage { get; set; }
        public UserModel Sender { get; set; }
    }
}
