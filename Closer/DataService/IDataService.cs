using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService
{
    interface IDataService<T> : ISingleDataService<T>
    {
        Task<T> CreateItemAsync(T item);
        Task<T> UpsertItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<IEnumerable<T>> ReadAllItemsAsync();
        Task<T> ReadItemAsync(string id);
        Task<T> UpdateItem(T item);
        Task InitializeAsync();
        Task<IEnumerable<T>> ReadItemsAsync(int start);
        Task<long> GetCount();
    }
}
