using OrnekUyg.Core.DataAccess.EntityFramework.Concrete;
using OrnekUyg.DAL.Abstract;
using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.DAL.Concrate.Repository
{
    public class UserRepository : EFBaseRepository<User, OrnekUygDbContext>, IUserRepository
    {
    }
}
