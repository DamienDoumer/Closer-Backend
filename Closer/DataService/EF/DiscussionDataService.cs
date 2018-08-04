using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService.EF
{
    public class DiscussionDataService : BaseDataService<Discussion>
    {
        public DiscussionDataService(CloserContext context) : base(context)
        {
        }

        public override Task CreateItemAsync(Discussion item)
        {
            return base.CreateItemAsync(item);
        }

        public override Task<Discussion> DeleteItemAsync(Discussion item)
        {
            return base.DeleteItemAsync(item);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override Task<long> GetCount()
        {
            return base.GetCount();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task InitializeAsync()
        {
            return base.InitializeAsync();
        }

        public override Task<bool> PersonalizedDeleteQuery(Expression<Func<Discussion, bool>> predicate)
        {
            return base.PersonalizedDeleteQuery(predicate);
        }

        public override Task<IEnumerable<Discussion>> PersonalizedQuery(Expression<Func<Discussion, bool>> predicate)
        {
            return base.PersonalizedQuery(predicate);
        }

        public override Task<IEnumerable<Discussion>> ReadAllItemsAsync()
        {
            return base.ReadAllItemsAsync();
        }

        public override Task<Discussion> ReadItemAsync(string id)
        {
            return base.ReadItemAsync(id);
        }

        public override Task<IEnumerable<Discussion>> ReadItemsAsync(int start)
        {
            return base.ReadItemsAsync(start);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override Task<Discussion> UpdateItem(Discussion item)
        {
            return base.UpdateItem(item);
        }

        public override Task<Discussion> UpsertItemAsync(Discussion item)
        {
            return base.UpsertItemAsync(item);
        }
    }
}
