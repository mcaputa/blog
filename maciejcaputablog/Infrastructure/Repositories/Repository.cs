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
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T ReadById(int id)
        {
            T element = _dbContext.Set<T>().Find(id);
            return element;
        }

        public IEnumerable<T> GetList()
        {
            IEnumerable<T> elements = _dbContext.Set<T>().AsNoTracking().AsEnumerable();
            return elements;
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> elements = _dbContext.Set<T>().Where(predicate).AsNoTracking().AsEnumerable();
            return elements;
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
