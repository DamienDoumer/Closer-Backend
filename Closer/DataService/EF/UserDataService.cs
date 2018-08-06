using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService.EF
{
    public class UserDataService : BaseDataService<User>
    {
        public UserDataService(CloserContext context) : base(context)
        {
        }

        public override async Task<User> CreateItemAsync(User item)
        {
            item.CreatedAt = DateTime.Now;
            var user = await Context.Users.AddAsync(item);
            await Context.SaveChangesAsync();
            return item;
        }

        public async override Task<bool> DeleteItemAsync(User item)
        {
            var userDiscussion = Context.UserDiscussions.Where(x => x.UserId == item.Id);
            Context.UserDiscussions.RemoveRange(userDiscussion);

            Context.Messages.RemoveRange(Context.Messages.Where(msg => msg.MessageUserId == item.Id));
            Context.Users.Remove(item);
            await Context.SaveChangesAsync();

            return true;
        }

        public async override Task<long> GetCount()
        {
            return Context.Users.Count();
        }

        public async override Task InitializeAsync()
        {
        }

        public async override Task<bool> PersonalizedDeleteQuery(Expression<Func<User, bool>> predicate)
        {
            var items = Context.Users.Where(predicate);
            Context.Users.RemoveRange(items);
            await Context.SaveChangesAsync();

            return true;
        }

        public override async Task<IEnumerable<User>> PersonalizedQuery(Expression<Func<User, bool>> predicate)
        {
            return Context.Users.Where(predicate);
        }

        public async override Task<IEnumerable<User>> ReadAllItemsAsync()
        {
            return Context.Users.ToList();
        }

        /// <summary>
        /// FInds a user with his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<User> ReadItemAsync(string id)
        {
            User user = await Context.Users.FindAsync(id);

            var intId = Convert.ToInt32(id);

            var userDiscussions = from ud in Context.UserDiscussions where ud.UserId == intId select ud;
            var discussions = from d in Context.Discussions join ud in userDiscussions on d.Id equals ud.DiscussionId select d;   
            user.Discussions = discussions.ToList();

            return user;
        }

        public async override Task<IEnumerable<User>> ReadItemsAsync(int start)
        {
            return Context.Users.ToList().Skip(start).Take(PAGE_SIZE);
        }

        public async override Task<User> UpdateItem(User item)
        {
            Context.Users.Update(item);
            await Context.SaveChangesAsync();

            return item;
        }

        public override Task<User> UpsertItemAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
