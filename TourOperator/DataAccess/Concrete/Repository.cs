using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Interfaces;
using Models;

namespace DataAccess.Concrete
{
    public class Repository<TModel>: IRepository<TModel> 
        where TModel: class, IModel
    {
        private readonly DbSet<TModel> _dbSet;

        public Repository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TModel>();
        }

        public void Create(TModel item)
        {
            _dbSet.Add(item);
        }

        public void Delete(TModel item)
        {
            TModel entity = _dbSet.Find(item.Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Update(TModel item)
        {
            TModel itemToUpdate = _dbSet.Find(item.Id);
            CopyFields(item, itemToUpdate);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public TModel GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public TModel GetByPredicate(Expression<Func<TModel, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        private void CopyFields(TModel source, TModel target)
        {
            var properties = typeof (TModel)
                .GetProperties()
                .Where(p => p.CanRead && p.CanWrite);

            foreach (var property in properties)
            {
                var value = property.GetValue(source);
                property.SetValue(target, value);
            }
        }
    }
}
