using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrnekUyg.Core.DataAccess.EntityFramework.Abstract
{
    public interface IEFBaseRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
