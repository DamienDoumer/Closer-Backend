using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class BaseModel
    {
        public string Url { get; set; }
        /// <summary>
        /// Represents the Entity's moniker
        /// </summary>
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
