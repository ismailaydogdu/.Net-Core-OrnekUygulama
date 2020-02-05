using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace OrnekUyg.DAL.Concrate
{
    class MyStrategy : DropCreateDatabaseAlways<OrnekUygDbContext>
    {
        protected override void Seed(OrnekUygDbContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName="Cep Telefonu",
                    Products= new List<Product>()
                    {
                        new Product()
                        {
                            ProductName="IPhone 6",
                            Description="16gb"
                        },
                        new Product()
                        {
                            ProductName="Huawei P20",
                            Description="64gb"
                        },
                        new Product()
                        {
                            ProductName="Samsung S10",
                            Description="64gb"
                        }
                    }
                },
                new Category()
                {
                    CategoryName="Bilgisayar",
                    Products= new List<Product>()
                    {
                        new Product()
                        {
                            ProductName="HUAWEI MEDIAPAD T3",
                            Description="HUAWEI MEDIAPAD T3 10 CORTEX A53 QUAD CORE-1.4GHZ-2GB-32GB-BT-9.6'-CAM- AND.7.0"
                        },
                        new Product()
                        {
                            ProductName="HP PAVILION 15-DK0020NT",
                            Description="HP PAVILION 15-DK0020NT CORE İ7 9750H 2.6GHZ-8GB-256GB SSD-15.6''GTX1650 4GB-W10"

                        },
                        new Product()
                        {
                            ProductName="LENOVO 510S",
                            Description="LENOVO 510S CORE İ5 BİLGİSAYAR ve LENOVO 23.8 MONİTÖR"
                        }
                    }
                }
            };
            User user = new User() { UserName = "admin", Password = "123" };
            context.Users.Add(user);
            context.SaveChanges();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
