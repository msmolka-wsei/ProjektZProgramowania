using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjektZProgramowania.Data;
using System;
using System.Collections.Generic;
using ProjektZProgramowania.Enities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektZProgramowania.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DefaulEntity
    {
        private readonly ApplicationDbContextFactory _applicationDbContextFactory;

        public GenericDataService(ApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {
                EntityEntry<T> createdEntity = await context.Set<T>().AddAsync(entity);
                context.SaveChanges();

                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(long id)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {

                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }
        public bool DeleteButBetterThanPrevorious(long userId, long notificationId)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {
                Notification entity = context.NotificationUsers.Find(notificationId);
                if (entity.creatorId != userId)
                {
                    string messageBoxText = "You can not delete this.";
                    string caption = "Warning";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
                else
                {
                    context.NotificationUsers.Remove(entity);
                    context.SaveChanges();
                    return true;
                }
                return false;
                
            }
        }
         public User Get(long id)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {

                User entity = context.Users.First(e => e.id == id);
                return entity;
            }
        }

        public User Get(string email)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {

                User entity = context.Users.FirstOrDefault((e) => e.email == email);
                return entity;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {

                IEnumerable<T> entities = context.Set<T>().ToList();
                return entities;
            }
        }

        public IEnumerable<Notification> GettAllNotification(long Id)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {
                IEnumerable<Notification> notificationList = context.NotificationUsers.Where(n => n.creatorId == Id).ToList();
                return notificationList;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (ApplicationDbContext context = _applicationDbContextFactory.CreateDbContext())
            {

                entity.id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
