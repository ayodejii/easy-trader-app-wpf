using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTrader.Domain.Services
{
    public interface IDataService<T>    
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}