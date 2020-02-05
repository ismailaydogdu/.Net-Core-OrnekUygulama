using OrnekUyg.Core.DataAccess.EntityFramework.Abstract;
using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.DAL.Abstract
{
   public interface IProductRepository : IEFBaseRepository<Product>
    {
    }
}
