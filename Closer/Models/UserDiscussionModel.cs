using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class UserDiscussionModel : BaseModel
    {
        public int UserId { get; set; }
        public int DiscussionId { get; set; }
    }
}
