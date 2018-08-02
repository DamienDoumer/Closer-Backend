using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.DataService.MongoDB
{
    public class BaseDataService<T> : IDataService<T>
    {
        protected MongoClient Client { get; set; }
        protected IMongoCollection<T> Collection { get; set; }
        protected IMongoDatabase Database { get; set; } 

        public BaseDataService()
        {
            Client = CreateClient();
            Database = Client.GetDatabase("closer");
        }

        private MongoClient CreateClient()
        {
            return new MongoClient(
                new MongoClientSettings
                {
                    Server = new MongoServerAddress("localhost", 27017),
                    ServerSelectionTimeout = TimeSpan.FromSeconds(5)
                });
        }

        public virtual Task CreateItemAsync(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> UpsertItemAsync(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> DeleteItemAsync(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> ReadAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> ReadItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> UpdateItem(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> ReadItemsAsync(int start)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> PersonalizedQuery(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var item = await Collection.FindAsync<T>(predicate);
            return item.ToEnumerable();
        }

        public virtual Task<bool> PersonalizedDeleteQuery(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<long> GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
