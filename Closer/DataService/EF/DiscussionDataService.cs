using Closer.Entities;
using Closer.Helpers;
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
            item.CreatedAt = DateTime.Now;
            var creator = item.Creator;

            if ((await Context.Users.FindAsync(creator.Id)) == null)
                throw new Exception("The user creating this discussion was not found");

            item.DiscussionUserCreatorId = creator.Id;
            item.Users = new List<User> { creator };

            item.Creator = null;
            await Context.Discussions.AddAsync(item);
            await Context.SaveChangesAsync();
            Context.UserDiscussions.Add(
                new UserDiscussion { DiscussionId = item.Id, UserId = item.DiscussionUserCreatorId, CreatedAt = DateTime.Now });
            await Context.SaveChangesAsync();

            return item;
        }

        public async override Task<bool> DeleteItemAsync(Discussion item)
        {
            var userDiscussion = Context.UserDiscussions.Where(x => x.DiscussionId == item.Id).ToList();
            Context.UserDiscussions.RemoveRange(userDiscussion);

            Context.Messages.RemoveRange(Context.Messages.Where(msg => msg.DiscussionId == item.Id));
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
            var item = await Context.Discussions.FindAsync(Convert.ToInt32(id));

            if (item != null)
            {
                var creator = await Context.Users.FindAsync(item.DiscussionUserCreatorId);
                var userDiscussions = Context.UserDiscussions.Where(i => i.DiscussionId.ToString() == id);

                var users = from usrs in Context.Users join ud in userDiscussions on usrs.Id equals ud.UserId select usrs;
                item.Creator = creator;
                item.Users = users.ToList();
            }

            return item;
        }

        public async override Task<IEnumerable<Discussion>> ReadItemsAsync(int start)
        {
            return Context.Discussions.ToList().Skip(start).Take((Utilities.PAGE_SIZE));
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
