using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> predicate);
    }
}
