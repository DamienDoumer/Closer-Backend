using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService.EF
{
    public class UserDiscussionDataService : ISingleDataService<UserDiscussion>
    {
        protected CloserContext Context { get; set; }

        public UserDiscussionDataService(CloserContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<UserDiscussion>> PersonalizedQuery(Expression<Func<UserDiscussion, bool>> predicate)
        {
            return Context.UserDiscussions.Where(predicate);
        }

        public async Task<bool> PersonalizedDeleteQuery(Expression<Func<UserDiscussion, bool>> predicate)
        {
            var items = Context.UserDiscussions.Where(predicate);
            Context.UserDiscussions.RemoveRange(items);
            await Context.SaveChangesAsync();

            return true;
        }
        public async Task<UserDiscussion> CreateItemAsync(UserDiscussion item)
        {
            item.CreatedAt = DateTime.Now;
            await Context.UserDiscussions.AddAsync(item);
            await Context.SaveChangesAsync();

            return item;
        }
    }
}
