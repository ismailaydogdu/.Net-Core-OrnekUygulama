using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.BLL.Abstract
{
    public interface IUserService: IBaseService<User>
    {
        User Login(string username, string password);
    }
}
