using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public List<DiscussionModel> Discussions { get; set; }
    }
}
