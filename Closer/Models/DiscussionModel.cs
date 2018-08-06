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

        /// <summary>
        /// The user who created this discussion
        /// </summary>
        public UserModel Creator { get; set; }

        /// <summary>
        /// Users who are in this discussion
        /// </summary>
        public List<UserModel> Users { get; set; }
    }
}
