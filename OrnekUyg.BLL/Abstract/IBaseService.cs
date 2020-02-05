using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.BLL.Abstract
{
    public interface IBaseService<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        void Update(T entity);

        T Get(int entityID);

        ICollection<T> GetAll();
    }
}
