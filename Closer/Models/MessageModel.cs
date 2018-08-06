using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class MessageModel : BaseModel
    {
        public string ConversationMoniker { get; set; }
        public string Moniker { get; set; }
    }
}
