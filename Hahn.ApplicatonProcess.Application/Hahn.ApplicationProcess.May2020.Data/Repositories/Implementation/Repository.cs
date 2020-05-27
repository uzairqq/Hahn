using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Models;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.May2020.Data.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly HahnDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(HahnDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        
        public async Task<T> Insert(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }
        

        public async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            //context.SaveChanges();
        }

        // public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        //     => context.Set<T>().FirstOrDefaultAsync(predicate);
    }
}
