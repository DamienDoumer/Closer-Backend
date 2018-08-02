using Closer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService.MongoDB
{
    public class UserDataService : BaseDataService<User>
    {
        public UserDataService() : base()
        {
            Collection = Database.GetCollection<User>(nameof(User));
        }

        public override async Task CreateItemAsync(User item)
        {
            await Collection.InsertOneAsync(item);
        }

        public override async Task<User> DeleteItemAsync(User item)
        {
            await Collection.DeleteOneAsync(i => i == item);
            return item;
        }

        public override async Task<long> GetCount()
        {
            return await Collection.EstimatedDocumentCountAsync();
        }

        public async override Task InitializeAsync()
        {

        }

        public async override Task<bool> PersonalizedDeleteQuery(Expression<Func<User, bool>> predicate)
        {
            var deleted = await Collection.DeleteOneAsync(predicate);
            return deleted.DeletedCount > 0;
        }

        public override async Task<IEnumerable<User>> PersonalizedQuery(Expression<Func<User, bool>> predicate)
        {
            return await base.PersonalizedQuery(predicate);
        }

        public override async Task<IEnumerable<User>> ReadAllItemsAsync()
        {
            var items = await Collection.FindAsync(x => true);
            return items.ToEnumerable();
        }

        public override async Task<User> ReadItemAsync(string id)
        {
            var item = await Collection.FindAsync(i => i.Id == id);
            return item.ToEnumerable().First();
        }

        public Task<IEnumerable<User>> ReadItemsAsync(int start)
        {
            throw new NotImplementedException();
        }

        public override async Task<User> UpdateItem(User item)
        {
            var i = await Collection.ReplaceOneAsync(it => item.Id == it.Id, item);
            return i.IsAcknowledged ? item : null;
        }

        public Task<User> UpsertItemAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
