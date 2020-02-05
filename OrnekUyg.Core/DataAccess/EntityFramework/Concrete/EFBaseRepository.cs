using OrnekUyg.Core.DataAccess.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrnekUyg.Core.DataAccess.EntityFramework.Concrete
{
    public class EFBaseRepository<TEntity, TContext> : IEFBaseRepository<TEntity>
        where TEntity : class, new()
        where TContext:DbContext,new()
    {
        TContext _db;
        public EFBaseRepository()
        {
            _db = new TContext();
        }

        public void Add(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Added;
                _db.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _db.Set<TEntity>().Where(filter).SingleOrDefault();

        }
        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _db.Set<TEntity>().ToList();
            }
            else
            {
                return _db.Set<TEntity>().Where(filter).ToList();
            }

        }
    }
}
