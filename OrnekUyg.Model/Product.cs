using System;
using System.ComponentModel.DataAnnotations;

namespace OrnekUyg.Model
{
    public class Product:BaseModel
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Ürün adı boş geçilemez")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string Description { get; set; }
        public virtual Category Category { get; set; }
    }
}