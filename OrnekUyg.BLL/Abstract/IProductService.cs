using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.BLL.Abstract
{
    public interface IProductService : IBaseService<Product>
    {
        ICollection<Product> GetByCategoryID(int categoryID);
    }
}
