using System;

namespace OrnekUyg.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
    }
}
