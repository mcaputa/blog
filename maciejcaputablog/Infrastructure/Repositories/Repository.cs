using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
     public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T ReadById(int id)
        {
            T element = this.dbContext.Set<T>().Find(id);
            return element;
        }

        public IEnumerable<T> GetList()
        {
            IEnumerable<T> elements = this.dbContext.Set<T>().AsNoTracking().AsEnumerable();
            return elements;
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> elements = this.dbContext.Set<T>().Where(predicate).AsNoTracking().AsEnumerable();
            return elements;
        }

        public void Create(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
            this.dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
    }
}
