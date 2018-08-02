using Closer.DataService.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Entities
{
    public class BaseEntity
    {
        [BsonId(IdGenerator = typeof(MyIDGenerator))]
        public int Id { get; set; }
        [BsonElement("moniker")]
        public string Moniker { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
