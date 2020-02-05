using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace OrnekUyg.DAL.Concrate
{
    public class OrnekUygDbContext : DbContext
    {

        public OrnekUygDbContext():base("Server=.; Database=OrnekUygDb; Trusted_Connection=True"/*uid=sa; pwd=123*/)
        {
            
            Database.SetInitializer<OrnekUygDbContext>(new MyStrategy());
        }
      

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
