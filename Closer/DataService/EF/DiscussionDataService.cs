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

        public override async Task<Discussion> CreateItemAsync(Discussion item)
        {
            var user = await Context.Discussions.AddAsync(item);
            await Context.SaveChangesAsync();

            return item;
        }

        public async override Task<bool> DeleteItemAsync(Discussion item)
        {
            var userDiscussion = Context.UserDiscussions.Where(x => x.DiscussionId == item.Id).ToList();
            Context.UserDiscussions.RemoveRange(userDiscussion);

            Context.Messages.RemoveRange(Context.Messages.Where(msg => msg.MessageDiscussionId == item.Id));
            Context.Discussions.Remove(item);
            await Context.SaveChangesAsync();

            return true;
        }

        public async override Task<long> GetCount()
        {
            return Context.Discussions.Count();
        }

        public async override Task InitializeAsync()
        {
        }

        public async override Task<bool> PersonalizedDeleteQuery(Expression<Func<Discussion, bool>> predicate)
        {
            var items = Context.Discussions.Where(predicate);
            Context.Discussions.RemoveRange(items);
            await Context.SaveChangesAsync();

            return true;
        }

        public override async Task<IEnumerable<Discussion>> PersonalizedQuery(Expression<Func<Discussion, bool>> predicate)
        {
            return Context.Discussions.Where(predicate);
        }

        public async override Task<IEnumerable<Discussion>> ReadAllItemsAsync()
        {
            return Context.Discussions.ToList();
        }

        /// <summary>
        /// FInds a user with his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Discussion> ReadItemAsync(string id)
        {
            return await Context.Discussions.FindAsync(id);
        }

        public async override Task<IEnumerable<Discussion>> ReadItemsAsync(int start)
        {
            return Context.Discussions.ToList().Skip(start).Take(PAGE_SIZE);
        }

        public async override Task<Discussion> UpdateItem(Discussion item)
        {
            Context.Discussions.Update(item);
            await Context.SaveChangesAsync();

            return item;
        }

        public override Task<Discussion> UpsertItemAsync(Discussion item)
        {
            throw new NotImplementedException();
        }
    }
}
