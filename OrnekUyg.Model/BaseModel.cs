using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.Model
{
    public abstract class BaseModel
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }

    }
}
