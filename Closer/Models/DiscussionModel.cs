using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class DiscussionModel : BaseModel
    {
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }

        [MinLength(10)]
        [MaxLength(2000)]
        [Required]
        public string Description { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string CreatorName { get; set; }
        
        [Required]
        public string CreatorEmail { get; set; }

        [MaxLength(30)]
        [Required]
        public string CreatorPseudo { get; set; }

        /// <summary>
        /// Users who are in this discussion
        /// </summary>
        public List<UserModel> Users { get; set; }
    }
}
