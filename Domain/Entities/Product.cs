using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set;}
        public DateTime CreatedDate { get; set; }
        public int IdBrand { get; set; }
        public Brand Brand { get; set; }
        public int IdCategory { get; set; }
        public Category Category {get; set;} 
    }
}