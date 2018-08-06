using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class DiscussionModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }
        public string CreatorEmail { get; set; }
        public string CreatorPseudo { get; set; }

        /// <summary>
        /// Users who are in this discussion
        /// </summary>
        public List<UserModel> Users { get; set; }
    }
}
