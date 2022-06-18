using ProjektZProgramowania.Enities;
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
        public User Get(long id);
        public User Get(string email);
        public Task<bool> Delete(long id);
        public bool DeleteButBetterThanPrevorious(long userId, long notificationId);
        public IEnumerable<T> GetAll();
        public IEnumerable<Notification> GettAllNotification(long Id);
        public Task<T> Update(int id, T entity);
    }
}
