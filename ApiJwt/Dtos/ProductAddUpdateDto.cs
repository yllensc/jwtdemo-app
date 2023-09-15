using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJwt.Dtos
{
    public class ProductAddUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido, ojito")]
        public string Name { get; set; }
        public decimal Price { get; set;}
        public DateTime Created { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}