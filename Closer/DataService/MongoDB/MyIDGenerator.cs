using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.DataService.MongoDB
{
    public class MyIDGenerator : IIdGenerator
    {
        private static int _counter = 0;
        public object GenerateId(object container, object document)
        {
            var id = Guid.NewGuid().ToString();
            return $"{_counter++}{Guid.NewGuid().ToString()}";
        }

        public bool IsEmpty(object id)
        {
            return id.Equals(default(int));
        }
    }
}
