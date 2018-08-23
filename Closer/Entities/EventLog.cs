using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class EventLog
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
