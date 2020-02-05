using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.Model
{
    public class User:BaseModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
