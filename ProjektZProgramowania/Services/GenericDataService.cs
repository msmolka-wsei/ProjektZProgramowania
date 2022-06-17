using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjektZProgramowania.Data;
using System;
using System.Collections.Generic;
using ProjektZProgramowania.Enities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
