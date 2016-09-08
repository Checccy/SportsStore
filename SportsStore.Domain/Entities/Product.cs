using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductGuid { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter a specify a category")]
        public string Category { get; set; }
        [DataType(DataType.Upload)]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
