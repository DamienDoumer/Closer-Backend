using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class Message : BaseEntity
    {
        public User User { get; set; }
        public Discussion Discussion { get; set; }
        public string Text { get; set; }
    }
}
