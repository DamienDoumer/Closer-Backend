using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService.EF
{
    public abstract class BaseDataService<T> : IDataService<T>
    {
        public string NewGuid =>  Guid.NewGuid().ToString();
        protected CloserContext Context { get; set; }
        protected int PAGE_SIZE = 50;

        public BaseDataService(CloserContext context)
        {
            Context = context;
        }

        #region override 


        public virtual Task<T> CreateItemAsync(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteItemAsync(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<long> GetCount()
        {
            throw new NotImplementedException();
        }

        public virtual Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> PersonalizedDeleteQuery(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> PersonalizedQuery(Expression<Func<T, bool>> predicate)
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

        public virtual Task<IEnumerable<T>> ReadItemsAsync(int start)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> UpdateItem(T item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> UpsertItemAsync(T item)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
