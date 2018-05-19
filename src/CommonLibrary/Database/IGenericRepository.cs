using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Database
{
    public interface IGenericRepository<T> where T : BaseClass
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string idd);
        Task Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string name);
        void SetCollection(string collection);
    }
}
