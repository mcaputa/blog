using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        void Create(T entity);

        T ReadById(int id);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> GetList();

        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
    }
}
