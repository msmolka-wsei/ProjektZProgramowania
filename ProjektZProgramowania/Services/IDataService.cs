using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Services
{
    public interface IDataService<T>
    {
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> Get(long id);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Update(int id, T entity);
    }
}
