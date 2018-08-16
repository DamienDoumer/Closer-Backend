using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class MessageModel : BaseModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public string ConversationId { get; set; }
        [Required]
        public string SenderId { get; set; }
        [MaxLength(30)]
        public string SenderName { get; set; }
        [MaxLength(30)]
        public string SenderPseudo { get; set; }
        public string SenderEmail { get; set; }
        public string RespondToMessageText { get; set; }
        public string RespondToMessageId { get; set; }

        public MessageModel RespondToMessage { get; set; }
        public UserModel Sender { get; set; }
    }
}
