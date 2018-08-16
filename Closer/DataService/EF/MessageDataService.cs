using Closer.Entities;
using Closer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService.EF
{
    public class MessageDataService : BaseDataService<Message>
    {
        public MessageDataService(CloserContext context) : base(context)
        {
        }

        public override async Task<Message> CreateItemAsync(Message item)
        {
            var user = await Context.Messages.AddAsync(item);
            await Context.SaveChangesAsync();

            return item;
        }

        public override async Task<bool> DeleteItemAsync(Message item)
        {
            Context.Messages.Remove(item);
            await Context.SaveChangesAsync();

            return true;
        }

        public async override Task<long> GetCount()
        {
            return Context.Messages.Count();
        }

        public async override Task InitializeAsync()
        {
        }

        public async override Task<bool> PersonalizedDeleteQuery(Expression<Func<Message, bool>> predicate)
        {
            var items = Context.Messages.Where(predicate);
            Context.Messages.RemoveRange(items);
            await Context.SaveChangesAsync();

            return true;
        }

        public async override Task<IEnumerable<Message>> PersonalizedQuery(Expression<Func<Message, bool>> predicate)
        {
            return Context.Messages.Where(predicate);
        }

        public async override Task<IEnumerable<Message>> ReadAllItemsAsync()
        {
            return Context.Messages.ToList().Select((msg) =>
            {
                msg.Sender = Context.Users.Find(msg.SenderId);
                if (msg.RespondToMessageId != null) msg.RespondToMessage = Context.Messages.Find(msg.RespondToMessageId);
                return msg;
            }); 
        }

        public async override Task<Message> ReadItemAsync(string id)
        {
            var msg = await Context.Messages.FindAsync(Convert.ToInt32(id));
            msg.Sender = Context.Users.Find(msg.SenderId);
                if (msg.RespondToMessageId != null) msg.RespondToMessage = Context.Messages.Find(msg.RespondToMessageId);
            
            return msg;
        }

        public async override Task<IEnumerable<Message>> ReadItemsAsync(int start)
        {
            return Context.Messages.ToList().Skip(start).Take(Utilities.PAGE_SIZE)
                .Select((msg) =>                
                {
                    msg.Sender = Context.Users.Find(msg.SenderId);
                    if(msg.RespondToMessageId != null) msg.RespondToMessage = Context.Messages.Find(msg.RespondToMessageId);
                    return msg;
                });
        }

        public async override Task<Message> UpdateItem(Message item)
        {
            Context.Messages.Update(item);
            await Context.SaveChangesAsync();

            return item;
        }

        public async override Task<Message> UpsertItemAsync(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
