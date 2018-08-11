using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class UserModel : BaseModel
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string Pseudo { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        [MinLength(25)]
        [MaxLength(2000)]
        [Required]
        public string Bio { get; set; }
        
        public string Password { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DiscussionModel> Discussions { get; set; }
    }
}
